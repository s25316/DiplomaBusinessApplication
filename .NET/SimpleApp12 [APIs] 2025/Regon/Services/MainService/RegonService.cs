using Regon.DTOs.RegonApiResponses.Raporty;
using Regon.DTOs.RegonApiResponses.Raporty.Pelny;
using Regon.DTOs.RegonApiResponses.Raporty.PKDs;
using Regon.DTOs.ThisAppResponses;
using Regon.Enums;
using Regon.Enums.DTOs.ThisAppResponses;
using Regon.Exceptions;
using Regon.Repositories.Requests;
using Regon.ValueObjects;
using System.Xml.Linq;
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
            var status = await _repository.GetValueAsync(null, GetValueEnum.StatusUslugi,
                cancellation, isProduction);
            /*var komunikat = _repository.GetValueAsync(null, GetValueEnum.KomunikatUslugi,
                cancellation, isProduction);

            Task.WaitAll(status, komunikat);*/
            switch (int.Parse(status))
            {
                case (int)StatusUslugiEnum.Niedostepna:
                    return new StatusUslugiResponse
                    {
                        IsActive = false,
                        Status = StatusUslugiEnum.Niedostepna,
                        Message = Messages.GetValue_StatusUslugi_Niedostepna,
                    };
                case (int)StatusUslugiEnum.Dostepna:
                    return new StatusUslugiResponse
                    {
                        IsActive = true,
                        Status = StatusUslugiEnum.Dostepna,
                        Message = Messages.GetValue_StatusUslugi_Dostepna,
                    };
                case (int)StatusUslugiEnum.PrzerwaTechniczna:
                    return new StatusUslugiResponse
                    {
                        IsActive = false,
                        Status = StatusUslugiEnum.PrzerwaTechniczna,
                        Message = Messages.GetValue_StatusUslugi_PrzerwaTechniczna,
                    };
                default:
                    throw new RegonAppNotImplementedException(
                                string.Format("{0}: {1}, {2}",
                                Messages.App_NotImplemented,
                                typeof(StatusUslugiEnum).Name,
                                $"Typ {int.Parse(status)}")
                                );
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
        public async Task<Response<DaneSzukajResponse>> DaneSzukajAsync(
            string key,
            string value,
            string typeValue,
            CancellationToken cancellation,
            bool isProduction = true)
        {
            try
            {
                DaneSzukajEnum szukajZa = GetDaneSzukajEnum(ref value, typeValue);

                var sessionId = await _repository.ZalogujAsync(key, cancellation, isProduction);
                if (sessionId == null)
                {
                    return await ResponseIfInvalidUserKeyAsync<DaneSzukajResponse>(
                        cancellation, isProduction);
                }

                var danePodstawowe = await _repository.DaneSzukajAsync(
                    sessionId, szukajZa, value, cancellation, isProduction);
                if (danePodstawowe == null)
                {
                    return await ResponseIfNotFoundAsync<DaneSzukajResponse>(
                        sessionId, cancellation, isProduction);
                }
                await _repository.WylogujAsync(sessionId, cancellation, isProduction);
                return ResponseCorrect<DaneSzukajResponse>((DaneSzukajResponse)danePodstawowe);
            }
            catch (System.Exception ex)
            {
                return ExceptionResponse<DaneSzukajResponse>(ex);
            }
        }

        public async Task<Response<ReportFullResponse>> DanePobierzPelnyRaportAsync(
            string key,
            string value,
            string typeValue,
            CancellationToken cancellation,
            bool isProduction = true)
        {
            try
            {
                DaneSzukajEnum szukajZa = GetDaneSzukajEnum(ref value, typeValue);

                var sessionId = await _repository.ZalogujAsync(key, cancellation, isProduction);
                if (sessionId == null)
                {
                    return await ResponseIfInvalidUserKeyAsync<ReportFullResponse>(
                       cancellation, isProduction);
                }

                var danePodstawowe = await _repository.DaneSzukajAsync(sessionId, szukajZa, value,
                    cancellation, isProduction);
                if (danePodstawowe == null)
                {
                    return await ResponseIfNotFoundAsync<ReportFullResponse>(
                        sessionId, cancellation, isProduction);
                }

                var raportType = new PelnyRaport(danePodstawowe.Typ, danePodstawowe.SilosID);
                var raportXml = await _repository.DanePobierzPelnyRaport(
                    sessionId, danePodstawowe.Regon, raportType.Raport, cancellation,
                    isProduction);

                var wyloguj = await _repository.WylogujAsync(sessionId, cancellation, isProduction);

                if (raportXml == null)
                {
                    return await ResponseIfNotFoundAsync<ReportFullResponse>(
                            sessionId, cancellation, isProduction);
                }

                ReportFullResponse report = Deserialize<ReportFull>(raportXml).Dane.First();
                return ResponseCorrect<ReportFullResponse>(report);
            }
            catch (System.Exception ex)
            {
                return ExceptionResponse<ReportFullResponse>(ex);
            }

        }

        public Response<T> ExceptionResponse<T>(Exception ex) where T : class
        {
            switch (ex)
            {
                case RegonException:
                    return new Response<T>
                    {
                        Status = RequestStatus.InvalidInputValue,
                        ExceptionMessage = ex.Message,
                    };
                case NipException:
                    return new Response<T>
                    {
                        Status = RequestStatus.InvalidInputValue,
                        ExceptionMessage = ex.Message,
                    };
                case KrsException:
                    return new Response<T>
                    {
                        Status = RequestStatus.InvalidInputValue,
                        ExceptionMessage = ex.Message,
                    };
                case UserKeyException:
                    return new Response<T>
                    {
                        Status = RequestStatus.InvalidUSerKey,
                        ExceptionMessage = ex.Message,
                    };
                default:
                    return new Response<T>
                    {
                        Status = RequestStatus.ThisAppProblem,
                        ExceptionMessage = ex.ToString(),
                    };
            };
        }

        public async Task<Response<IEnumerable<PkdResponse>>> RaportDzialalnosciPkdAsync(
            string key,
            string value,
            string typeValue,
            CancellationToken cancellation,
            bool isProduction = true)
        {
            try
            {
                DaneSzukajEnum szukajZa = GetDaneSzukajEnum(ref value, typeValue);

                var sessionId = await _repository.ZalogujAsync(key, cancellation, isProduction);
                if (sessionId == null)
                {
                    return await ResponseIfInvalidUserKeyAsync<IEnumerable<PkdResponse>>(
                       cancellation, isProduction);
                }

                var danePodstawowe = await _repository.DaneSzukajAsync(sessionId, szukajZa, value,
                    cancellation, isProduction);
                if (danePodstawowe == null)
                {
                    return await ResponseIfNotFoundAsync<IEnumerable<PkdResponse>>(
                        sessionId, cancellation, isProduction);
                }

                var raportType = new PelnyRaport(danePodstawowe.Typ, danePodstawowe.SilosID);
                var raportXml = await _repository.DanePobierzPelnyRaport(
                    sessionId, danePodstawowe.Regon, raportType.RaportPkd, cancellation,
                    isProduction);

                var wyloguj = await _repository.WylogujAsync(sessionId, cancellation, isProduction);
                if (raportXml == null)
                {
                    return await ResponseIfNotFoundAsync<IEnumerable<PkdResponse>>(
                        sessionId, cancellation, isProduction);
                }
                var list = Deserialize<Pkd>(raportXml)
                        .Dane
                        .Select(x => ((PkdResponse)x))
                        .ToList();
                return ResponseCorrect<IEnumerable<PkdResponse>>(list);
            }
            catch (System.Exception ex)
            {
                return ExceptionResponse<IEnumerable<PkdResponse>>(ex);
            }
        }

        public async Task<Response<ReportFullWithPkdResponse>> DanePobierzPelnyRaportZPkdAsync(
           string key,
           string value,
           string typeValue,
           CancellationToken cancellation,
           bool isProduction = true)
        {
            try
            {
                DaneSzukajEnum szukajZa = GetDaneSzukajEnum(ref value, typeValue);

                var sessionId = await _repository.ZalogujAsync(key, cancellation, isProduction);
                if (sessionId == null)
                {
                    return await ResponseIfInvalidUserKeyAsync<ReportFullWithPkdResponse>(
                       cancellation, isProduction);
                }

                var danePodstawowe = await _repository.DaneSzukajAsync(sessionId, szukajZa, value,
                    cancellation, isProduction);
                if (danePodstawowe == null)
                {
                    return await ResponseIfNotFoundAsync<ReportFullWithPkdResponse>(
                        sessionId, cancellation, isProduction);
                }

                var raportType = new PelnyRaport(danePodstawowe.Typ, danePodstawowe.SilosID);

                var raportXml = await _repository.DanePobierzPelnyRaport(
                    sessionId, danePodstawowe.Regon, raportType.Raport, cancellation,
                    isProduction);
                var raportPkdXml = await _repository.DanePobierzPelnyRaport(
                    sessionId, danePodstawowe.Regon, raportType.RaportPkd, cancellation,
                    isProduction);

                var wyloguj = await _repository.WylogujAsync(sessionId, cancellation, isProduction);

                if (raportXml == null || raportPkdXml == null)
                {
                    return await ResponseIfNotFoundAsync<ReportFullWithPkdResponse>(
                            sessionId, cancellation, isProduction);
                }
                var report = Deserialize<ReportFull>(raportXml).Dane.First();
                var listPkd = Deserialize<Pkd>(raportPkdXml).Dane;

                var response = new ReportFullWithPkdResponse
                {
                    Type = ((DaneSzukajResponse)danePodstawowe).TypNazwa,
                    Report = report,
                    Pkd = listPkd.Select(x => ((PkdResponse)x)),
                };
                return ResponseCorrect<ReportFullWithPkdResponse>(response);
            }
            catch (System.Exception ex)
            {
                return ExceptionResponse<ReportFullWithPkdResponse>(ex);
            }
        }
        //==============================================================================================
        //==============================================================================================
        //==============================================================================================
        //Private Methods
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
                    throw new RegonAppNotImplementedException(
                                string.Format("{0}: {1}, {2}",
                                Messages.App_NotImplemented,
                                typeof(KomunikatKodEnum).Name,
                                $"Value {status ?? "null"}")
                                );
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


        private DaneSzukajEnum GetDaneSzukajEnum(ref string value,
            string typeValue)
        {
            switch (typeValue.ToLower())
            {
                case "regon":
                    value = new ValueObjects.Regon
                    {
                        Value = value,
                    }.Value;
                    return DaneSzukajEnum.Regon;
                case "krs":
                    value = new Krs
                    {
                        Value = value
                    }.Value;
                    return DaneSzukajEnum.Krs;
                case "nip":
                    value = new Nip
                    {
                        Value = value
                    }.Value;
                    return DaneSzukajEnum.Nip;
                default:
                    throw new RegonAppNotImplementedException(
                                string.Format("{0}: {1}, {2}",
                                Messages.App_NotImplemented,
                                typeof(DaneSzukajEnum).Name,
                                $"Value {value}"));
            }
        }

        private async Task<Response<T>> ResponseIfInvalidUserKeyAsync<T>(
            CancellationToken cancellation,
            bool isProduction = true)
        {
            var status = await StatusUslugiAsync(cancellation, isProduction);
            return new Response<T>
            {
                Status = status.IsActive ?
                    RequestStatus.InvalidUSerKey :
                    (
                    status.Status == StatusUslugiEnum.PrzerwaTechniczna ?
                        RequestStatus.TechnicalBreak :
                        RequestStatus.ServiceUnavailable
                    ),
            };
        }

        private async Task<Response<T>> ResponseIfNotFoundAsync<T>(
            SessionId sessionId,
            CancellationToken cancellation,
            bool isProduction = true)
        {
            var problem = await KomunikatKodAsync(sessionId, cancellation, isProduction);
            return new Response<T>
            {
                Status = (RequestStatus)((int)problem.KomunikatKod),
                //RequestProblem = problem,
            };
        }

        private Response<T> ResponseCorrect<T>(T value)
        {
            return new Response<T>
            {
                Status = RequestStatus.Success,
                Result = value,
            };
        }

        private Root<T> Deserialize<T>(XElement xml) where T : class
        {
            XmlSerializer s = new XmlSerializer(typeof(Root<T>));
            using (var reader = xml.CreateReader())
            {
                var root = s.Deserialize(reader) as Root<T> ??
                    throw new RegonAppNotImplementedException(
                                string.Format("{0}: {1}",
                                Messages.AppProblem_Deserialization,
                                xml.ToString()));
                return root;
            }
        }
    }
}
