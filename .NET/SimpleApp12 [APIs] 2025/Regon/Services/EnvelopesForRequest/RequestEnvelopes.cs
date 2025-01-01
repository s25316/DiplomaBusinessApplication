using Regon.Enums;
using Regon.ValueObjects;

namespace Regon.Services.EnvelopesForRequest
{
    public class RequestEnvelopes : IRequestEnvelopes
    {
        //Properties
        private static readonly string _production =
            "https://wyszukiwarkaregon.stat.gov.pl/wsBIR/UslugaBIRzewnPubl.svc";
        private static readonly string _testing =
            "https://wyszukiwarkaregontest.stat.gov.pl/wsBIR/UslugaBIRzewnPubl.svc";


        //==============================================================================================
        //==============================================================================================
        //==============================================================================================
        //Public Methods
        public string GetEndpoint(bool isProduction = true) => isProduction ? _production : _testing;

        public string Zaloguj(UserKey key, bool isProduction = true)
        {
            var endpoint = GetEndpoint(isProduction);

            return $@"<soap:Envelope xmlns:soap=""http://www.w3.org/2003/05/soap-envelope"" xmlns:ns=""http://CIS/BIR/PUBL/2014/07"">
                                    <soap:Header xmlns:wsa=""http://www.w3.org/2005/08/addressing"">
                                        <wsa:Action>http://CIS/BIR/PUBL/2014/07/IUslugaBIRzewnPubl/Zaloguj</wsa:Action>
                                        <wsa:To>{endpoint}</wsa:To>
                                    </soap:Header>
                                    <soap:Body>
                                        <ns:Zaloguj>
                                            <ns:pKluczUzytkownika>{(string)key}</ns:pKluczUzytkownika>
                                        </ns:Zaloguj>
                                    </soap:Body>
                                    </soap:Envelope>";
        }

        public string Wyloguj(SessionId session, bool isProduction = true)
        {
            var endpoint = GetEndpoint(isProduction);

            return $@"<soap:Envelope xmlns:soap=""http://www.w3.org/2003/05/soap-envelope"" xmlns:ns=""http://CIS/BIR/PUBL/2014/07"">
                                    <soap:Header xmlns:wsa=""http://www.w3.org/2005/08/addressing"">
                                        <wsa:To>{endpoint}</wsa:To>
                                        <wsa:Action>http://CIS/BIR/PUBL/2014/07/IUslugaBIRzewnPubl/Wyloguj</wsa:Action>
                                    </soap:Header>
                                    <soap:Body>
                                        <ns:Wyloguj>
                                            <ns:pIdentyfikatorSesji>{(string)session}</ns:pIdentyfikatorSesji>
                                        </ns:Wyloguj>
                                    </soap:Body>
                                    </soap:Envelope>";
        }

        public string DaneSzukaj(DaneSzukajEnum szukajZa, string dane, bool isProduction = true)
        {
            var endpoint = GetEndpoint(isProduction);

            string partOfEnvelope;
            switch (szukajZa)
            {
                case DaneSzukajEnum.Regon:
                    partOfEnvelope = $"<dat:Regon>{dane}</dat:Regon>";
                    break;
                case DaneSzukajEnum.Nip:
                    partOfEnvelope = $"<dat:Nip>{dane}</dat:Nip>";
                    break;
                case DaneSzukajEnum.Krs:
                    partOfEnvelope = $"<dat:Krs>{dane}</dat:Krs>";
                    break;
                default:
                    throw new NotImplementedException();
            }
            return $@"<soap:Envelope xmlns:soap=""http://www.w3.org/2003/05/soap-envelope"" xmlns:ns=""http://CIS/BIR/PUBL/2014/07"" xmlns:dat=""http://CIS/BIR/PUBL/2014/07/DataContract"">
                                    <soap:Header xmlns:wsa=""http://www.w3.org/2005/08/addressing"">
                                        <wsa:To>{endpoint}</wsa:To>
                                        <wsa:Action>http://CIS/BIR/PUBL/2014/07/IUslugaBIRzewnPubl/DaneSzukaj</wsa:Action>
                                    </soap:Header>
                                    <soap:Body>
                                        <ns:DaneSzukaj>
                                            <ns:pParametryWyszukiwania>
                                                {partOfEnvelope}
                                            </ns:pParametryWyszukiwania>
                                        </ns:DaneSzukaj>
                                    </soap:Body>
                                    </soap:Envelope>";
        }


        public string GetValue(GetValueEnum type, bool isProduction = true)
        {
            var endpoint = GetEndpoint(isProduction);
            string parameter;
            switch (type)
            {
                case GetValueEnum.StanDanych:
                    parameter = "StanDanych";
                    break;
                case GetValueEnum.KomunikatKod:
                    parameter = "KomunikatKod";
                    break;
                case GetValueEnum.KomunikatTresc:
                    parameter = "KomunikatTresc";
                    break;
                case GetValueEnum.StatusSesji:
                    parameter = "StatusSesji";
                    break;
                case GetValueEnum.StatusUslugi:
                    parameter = "StatusUslugi";
                    break;
                case GetValueEnum.KomunikatUslugi:
                    parameter = "KomunikatUslugi";
                    break;
                default:
                    throw new NotImplementedException();//Not Implemented
            }
            return $@"<soap:Envelope xmlns:soap=""http://www.w3.org/2003/05/soap-envelope"" xmlns:ns=""http://CIS/BIR/2014/07"">
                    <soap:Header xmlns:wsa=""http://www.w3.org/2005/08/addressing"">
                    <wsa:To>{endpoint}</wsa:To>
                    <wsa:Action>http://CIS/BIR/2014/07/IUslugaBIR/GetValue</wsa:Action>
                    </soap:Header>
                       <soap:Body>
                          <ns:GetValue>
                             <ns:pNazwaParametru>{parameter}</ns:pNazwaParametru>
                          </ns:GetValue>
                       </soap:Body>
                    </soap:Envelope>";
        }

        public string PobierzPelnyRaport(string regon, PelnyRaportEnum nazwaRaportu,
            bool isProduction = true)
        {
            var endpoint = GetEndpoint(isProduction);
            string name = Enum.GetName(typeof(PelnyRaportEnum), nazwaRaportu) ??
                throw new NotImplementedException();

            return $@"<soap:Envelope xmlns:soap=""http://www.w3.org/2003/05/soap-envelope"" xmlns:ns=""http://CIS/BIR/PUBL/2014/07"">
                    <soap:Header xmlns:wsa=""http://www.w3.org/2005/08/addressing"">
                    <wsa:To>{endpoint}</wsa:To>
                    <wsa:Action>http://CIS/BIR/PUBL/2014/07/IUslugaBIRzewnPubl/DanePobierzPelnyRaport</wsa:Action>            
                    </soap:Header>
                      <soap:Body>
                          <ns:DanePobierzPelnyRaport>
                             <ns:pRegon>{regon}</ns:pRegon>         
                             <ns:pNazwaRaportu>{name}</ns:pNazwaRaportu>
                          </ns:DanePobierzPelnyRaport>
                       </soap:Body>
                    </soap:Envelope>";
        }

        //==============================================================================================
        //==============================================================================================
        //==============================================================================================
        //Private Methods
    }
}
