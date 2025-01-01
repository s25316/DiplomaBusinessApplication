using Regon.DTOs.RegonApiResponses.Raporty;
using Regon.DTOs.RegonApiResponses.Raporty.Pelny;
using Regon.DTOs.ThisAppResponses;
using Regon.Enums;
using Regon.Repositories.Requests;
using Regon.ValueObjects;
using System.Xml.Serialization;

namespace Regon.Services.MainService
{
    public class RegonService : IRegonService
    {
        //Parameters
        private readonly IRequestRepository _repository;


        //Constructor
        public RegonService(IRequestRepository repository)
        {
            _repository = repository;
        }


        //==============================================================================================
        //==============================================================================================
        //==============================================================================================
        //Public Methods

        /// <summary>
        /// Zwraca status uslugi. Zwraca komunikat usługi.
        /// </summary>
        /// <param name="cancellation"></param>
        /// <param name="isProduction"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<StatusUslugiResponse> StatusUslugiAsync(CancellationToken cancellation,
            bool isProduction = true)
        {
            var status = _repository.GetValueAsync(null, GetValueEnum.StatusUslugi,
                cancellation, isProduction);
            var komunikat = _repository.GetValueAsync(null, GetValueEnum.KomunikatUslugi,
                cancellation, isProduction);

            Task.WaitAll(status, komunikat);
            switch (int.Parse(status.Result))
            {
                case (int)StatusUslugiEnum.Niedostepna:
                    return new StatusUslugiResponse
                    {
                        IsActive = false,
                        Status = Messages.GetValue_StatusUslugi_Niedostepna,
                        Message = komunikat.Result,
                    };
                case (int)StatusUslugiEnum.Dostepna:
                    return new StatusUslugiResponse
                    {
                        IsActive = true,
                        Status = Messages.GetValue_StatusUslugi_Dostepna,
                        Message = komunikat.Result,
                    };
                case (int)StatusUslugiEnum.PrzerwaTechniczna:
                    return new StatusUslugiResponse
                    {
                        IsActive = false,
                        Status = Messages.GetValue_StatusUslugi_PrzerwaTechniczna,
                        Message = komunikat.Result,
                    };
                default:
                    throw new NotImplementedException();
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="typeValue">Regon, Krs, Nip</param>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        public async Task<DaneSzukajResponse> DaneSzukajAsync(
            string key,
            string value,
            string typeValue,
            CancellationToken cancellation,
            bool isProduction = true)
        {
            DaneSzukajEnum szukajZa;
            AdaptParameter(out szukajZa, ref value, typeValue);

            var sessionId = await _repository.ZalogujAsync(key, cancellation, isProduction);
            if (sessionId == null)
            {
                var activeServiceDetails = await StatusUslugiAsync(cancellation, isProduction);
                return new DaneSzukajResponse
                {
                    IsActiveService = activeServiceDetails.IsActive,
                    IsValidUserKey = false,
                    IsSuccess = false,
                    InputProblem = null,
                    Result = null,
                };
            }

            var dane = await _repository.DaneSzukajAsync(sessionId, szukajZa, value,
                cancellation, isProduction);
            if (dane == null)
            {
                var problem = await KomunikatKodAsync(sessionId, cancellation, isProduction);
                return new DaneSzukajResponse
                {
                    IsActiveService = true,
                    IsValidUserKey = true,
                    IsSuccess = false,
                    InputProblem = problem,
                    Result = null,
                };
            }
            var wyloguj = await _repository.WylogujAsync(sessionId, cancellation, isProduction);

            return new DaneSzukajResponse
            {
                IsActiveService = true,
                IsValidUserKey = true,
                IsSuccess = true,
                InputProblem = null,
                Result = dane,
            };
        }

        public async Task<PelnyRaportResponse> DanePobierzPelnyRaportAsync(
            string key,
            string value,
            string typeValue,
            CancellationToken cancellation,
            bool isProduction = true)
        {
            DaneSzukajEnum szukajZa;
            AdaptParameter(out szukajZa, ref value, typeValue);

            var sessionId = await _repository.ZalogujAsync(key, cancellation, isProduction);
            if (sessionId == null)
            {
                var activeServiceDetails = await StatusUslugiAsync(cancellation, isProduction);
                return new PelnyRaportResponse
                {
                    IsActiveService = activeServiceDetails.IsActive,
                    IsValidUserKey = false,
                    IsSuccess = false,
                    InputProblem = null,
                    Result = null,
                };
            }

            var dane = await _repository.DaneSzukajAsync(sessionId, szukajZa, value,
                cancellation, isProduction);
            if (dane == null)
            {
                var problem = await KomunikatKodAsync(sessionId, cancellation, isProduction);
                return new PelnyRaportResponse
                {
                    IsActiveService = true,
                    IsValidUserKey = true,
                    IsSuccess = false,
                    InputProblem = problem,
                    Result = null,
                };
            }

            var raportType = new PelnyRaport(dane.Typ, dane.SilosID);
            var raportXml = await _repository.DanePobierzPelnyRaport(
                sessionId, dane.Regon, raportType.Raport, cancellation,
                isProduction);

            var wyloguj = await _repository.WylogujAsync(sessionId, cancellation, isProduction);

            Dane d = null;

            if (raportXml != null)
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Root<ReportFull>));
                using (var reader = raportXml.CreateReader())
                {
                    var res = serializer.Deserialize(reader) as Root<ReportFull> ??
                        throw new Exception();
                    d = res.Dane.FirstOrDefault();
                }
            }
            return new PelnyRaportResponse
            {
                IsActiveService = true,
                IsValidUserKey = true,
                IsSuccess = true,
                InputProblem = null,
                Result = raportXml.ToString(),
                ResultDane = d,
            };
        }

        public async Task<PelnyRaportResponse> RaportDzialalnosciPkdAsync(
            string key,
            string value,
            string typeValue,
            CancellationToken cancellation,
            bool isProduction = true)
        {
            DaneSzukajEnum szukajZa;
            AdaptParameter(out szukajZa, ref value, typeValue);

            var sessionId = await _repository.ZalogujAsync(key, cancellation, isProduction);
            if (sessionId == null)
            {
                var activeServiceDetails = await StatusUslugiAsync(cancellation, isProduction);
                return new PelnyRaportResponse
                {
                    IsActiveService = activeServiceDetails.IsActive,
                    IsValidUserKey = false,
                    IsSuccess = false,
                    InputProblem = null,
                    Result = null,
                };
            }

            var dane = await _repository.DaneSzukajAsync(sessionId, szukajZa, value,
                cancellation, isProduction);
            if (dane == null)
            {
                var problem = await KomunikatKodAsync(sessionId, cancellation, isProduction);
                return new PelnyRaportResponse
                {
                    IsActiveService = true,
                    IsValidUserKey = true,
                    IsSuccess = false,
                    InputProblem = problem,
                    Result = null,
                };
            }

            var raportType = new PelnyRaport(dane.Typ, dane.SilosID);
            var raportXml = await _repository.DanePobierzPelnyRaport(
                sessionId, dane.Regon, raportType.RaportPkd, cancellation,
                isProduction);

            var wyloguj = await _repository.WylogujAsync(sessionId, cancellation, isProduction);


            return new PelnyRaportResponse
            {
                IsActiveService = true,
                IsValidUserKey = true,
                IsSuccess = true,
                InputProblem = null,
                Result = raportXml.ToString(),
            };
        }

        //==============================================================================================
        //==============================================================================================
        //==============================================================================================
        //Private Methods

        private void AdaptParameter(out DaneSzukajEnum daneSzukaj, ref string value,
            string typeValue)
        {
            switch (typeValue.ToLower())
            {
                case "regon":
                    daneSzukaj = 0;
                    value = new ValueObjects.Regon
                    {
                        Value = value,
                    }.Value;
                    break;
                case "krs":
                    daneSzukaj = (DaneSzukajEnum)1;
                    value = new Krs
                    {
                        Value = value
                    }.Value;
                    break;
                case "nip":
                    daneSzukaj = (DaneSzukajEnum)2;
                    value = new Nip
                    {
                        Value = value
                    }.Value;
                    break;
                default:
                    throw new ArgumentException();
            }
        }

        /// <summary>
        /// Zwraca status sesji, true => tak, false => nie. 
        /// </summary>
        /// <param name="session"></param>
        /// <param name="cancellation"></param>
        /// <param name="isProduction"></param>
        /// <returns></returns>
        private async Task<bool> StatusSesjiIsActiveAsync(SessionId session,
            CancellationToken cancellation, bool isProduction = true)
        {
            var status = await _repository.GetValueAsync(session, GetValueEnum.StatusSesji,
                cancellation, isProduction);
            return (int.Parse(status)) > 0;
        }

        /// <summary>
        /// Zwraca kod komunikatu, i treść odpowiedna do danego kodu
        /// </summary>
        /// <param name="session"></param>
        /// <param name="cancellation"></param>
        /// <param name="isProduction"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private async Task<KomunikatKodResponse> KomunikatKodAsync(SessionId session,
            CancellationToken cancellation, bool isProduction = true)
        {
            var status = await _repository.GetValueAsync(session, GetValueEnum.KomunikatKod,
                cancellation, isProduction);

            switch (int.Parse(status))
            {
                case (int)KomunikatKodEnum.Captcha:
                    return new KomunikatKodResponse
                    {
                        KomunikatKod = KomunikatKodEnum.Captcha,
                        Message = Messages.GetValue_KomunikatKod_Captcha,
                    };
                case (int)KomunikatKodEnum.TooManyIds:
                    return new KomunikatKodResponse
                    {
                        KomunikatKod = KomunikatKodEnum.TooManyIds,
                        Message = Messages.GetValue_KomunikatKod_TooManyIds,
                    };
                case (int)KomunikatKodEnum.NotFound:
                    return new KomunikatKodResponse
                    {
                        KomunikatKod = KomunikatKodEnum.NotFound,
                        Message = Messages.GetValue_KomunikatKod_NotFound,
                    };
                case (int)KomunikatKodEnum.Forbidden:
                    return new KomunikatKodResponse
                    {
                        KomunikatKod = KomunikatKodEnum.Forbidden,
                        Message = Messages.GetValue_KomunikatKod_Forbidden,
                    };
                case (int)KomunikatKodEnum.UnAuthorize:
                    return new KomunikatKodResponse
                    {
                        KomunikatKod = KomunikatKodEnum.UnAuthorize,
                        Message = Messages.GetValue_KomunikatKod_UnAuthorize,
                    };
                default:
                    throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Zwraca kod komunikatu {zwykle jakąś wiadomość o niepowodzeniu}
        /// </summary>
        /// <param name="session"></param>
        /// <param name="cancellation"></param>
        /// <param name="isProduction"></param>
        /// <returns></returns>
        private async Task<string> KomunikatTrescAsync(SessionId session,
            CancellationToken cancellation, bool isProduction = true)
        {
            return await _repository.GetValueAsync(session, GetValueEnum.KomunikatTresc,
                cancellation, isProduction);
        }

        /// <summary>
        /// Zwracana jest informacja o stanie danych jaki jest udostępniany
        /// </summary>
        /// <param name="session"></param>
        /// <param name="cancellation"></param>
        /// <param name="isProduction"></param>
        /// <returns></returns>
        private async Task<DateTime> StanDanychAsync(SessionId session,
           CancellationToken cancellation, bool isProduction = true)
        {
            var dateTime = await _repository.GetValueAsync(session, GetValueEnum.StanDanych,
                cancellation, isProduction);
            return DateTime.Parse(dateTime);
        }
    }
}
