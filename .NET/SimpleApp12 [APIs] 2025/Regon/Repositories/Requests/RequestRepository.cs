using Regon.DTOs.RegonApiResponses;
using Regon.Enums;
using Regon.Services.EnvelopesForRequest;
using Regon.ValueObjects;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Regon.Repositories.Requests
{
    public class RequestRepository : IRequestRepository
    {
        //Properties
        private readonly IRequestEnvelopes _envelopes;


        //Constructor 
        public RequestRepository(IRequestEnvelopes envelopes)
        {
            _envelopes = envelopes;
        }


        //=============================================================================================
        //=============================================================================================
        //=============================================================================================
        //Public Methods
        public async Task<SessionId?> ZalogujAsync(UserKey key, CancellationToken cancellation,
            bool isProduction = true)
        {
            var endpoint = _envelopes.GetEndpoint(isProduction);
            var envelope = _envelopes.Zaloguj(key, isProduction);
            var response = await MakeRequestAsync(null, endpoint, envelope, cancellation);

            XDocument doc = XDocument.Parse(response);
            XNamespace ns = "http://CIS/BIR/PUBL/2014/07";

            string zalogujResult = doc
                .Descendants(ns + "ZalogujResult")
                .FirstOrDefault()?
                .Value ?? "";

            return string.IsNullOrWhiteSpace(zalogujResult) ? null : (SessionId)zalogujResult;
        }

        public async Task<bool> WylogujAsync(SessionId session, CancellationToken cancellation,
            bool isProduction = true)
        {
            var endpoint = _envelopes.GetEndpoint(isProduction);
            var envelope = _envelopes.Wyloguj(session, isProduction);
            var response = await MakeRequestAsync(session, endpoint, envelope, cancellation);

            XDocument doc = XDocument.Parse(response);
            XNamespace ns = "http://CIS/BIR/PUBL/2014/07";

            string wylogujResult = doc
                .Descendants(ns + "WylogujResult")
                .FirstOrDefault()?
                .Value ?? "";

            return System.Boolean.Parse(wylogujResult);
        }

        public async Task<DaneSzukaj?> DaneSzukajAsync(SessionId session, DaneSzukajEnum szukajZa,
            string dane, CancellationToken cancellation, bool isProduction = true)
        {
            var endpoint = _envelopes.GetEndpoint(isProduction);
            var envelope = _envelopes.DaneSzukaj(szukajZa, dane, isProduction);
            var response = await MakeRequestAsync(session, endpoint, envelope, cancellation);

            response = ReplaceSpecifySignsToXml(response);
            XDocument doc = XDocument.Parse(response);
            XNamespace ns = "http://CIS/BIR/PUBL/2014/07";

            var daneSzukajResult = doc
                .Descendants(ns + "dane")
                .FirstOrDefault();

            if (daneSzukajResult == null)
            {
                return null;
            }

            XmlSerializer serializer = new XmlSerializer(typeof(DaneSzukaj));
            using (var reader = daneSzukajResult.CreateReader())
            {
                DaneSzukaj result = serializer.Deserialize(reader) as DaneSzukaj ??
                    throw new Exception();
                return result;
            }
        }

        public async Task<string> GetValueAsync(SessionId? session, GetValueEnum type, CancellationToken cancellation,
            bool isProduction = true)
        {
            var endpoint = _envelopes.GetEndpoint(isProduction);
            var envelope = _envelopes.GetValue(type, isProduction);
            var response = await MakeRequestAsync(session, endpoint, envelope, cancellation);

            XDocument doc = XDocument.Parse(response);
            XNamespace ns = "http://CIS/BIR/2014/07";

            return doc
                .Descendants(ns + "GetValueResult")
                .FirstOrDefault()?
                .Value ?? "";
        }

        public async Task<XElement?> DanePobierzPelnyRaport(SessionId session, string regon,
            PelnyRaportEnum nazwaRaportu, CancellationToken cancellation, bool isProduction = true)
        {
            var endpoint = _envelopes.GetEndpoint(isProduction);
            var envelope = _envelopes.PobierzPelnyRaport(regon, nazwaRaportu, isProduction);
            var response = await MakeRequestAsync(session, endpoint, envelope, cancellation);


            response = ReplaceSpecifySignsToXml(response);
            XDocument doc = XDocument.Parse(response);
            XNamespace ns = "http://CIS/BIR/PUBL/2014/07";

            return doc
                .Descendants(ns + "root")
                .FirstOrDefault();
        }

        //=============================================================================================
        //=============================================================================================
        //=============================================================================================
        //Private Methods
        private async Task<string> MakeRequestAsync(SessionId? session, string endpoint, string envelope,
            CancellationToken cancellation)
        {
            using (var client = new HttpClient())
            {
                //Prepare Request
                var request = new HttpRequestMessage()
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri(endpoint),
                    Content = new StringContent(
                        envelope, Encoding.UTF8, "application/soap+xml")
                };

                if (session != null)
                {
                    request.Headers.Add("sid", (string)session);
                }

                //Making Request
                var response = await client.SendAsync(request, cancellation);
                string body = await response.Content.ReadAsStringAsync(cancellation);

                request.Dispose();
                response.Dispose();

                return ExtractSoapEnvelopeFromBody(body);
            }
        }


        private string ExtractSoapEnvelopeFromBody(string body)
        {
            /* Body Response looks like for Zaloguj
            [
                  "0 ",
                  "1 --uuid:d7df59b9-21aa-45e0-97c3-54d9a4e79d76+id=42489",
                  "2 Content-ID: <http://tempuri.org/0>",
                  "3 Content-Transfer-Encoding: 8bit",
                  "4 Content-Type: application/xop+xml;charset=utf-8;type=\"application/soap+xml\"",
                  "5 ",
                  "6 <s:Envelope xmlns:s=\"http://www.w3.org/2003/05/soap-envelope\" xmlns:a=\"http://www.w3.org/2005/08/addressing\"><s:Header><a:Action s:mustUnderstand=\"1\">http://CIS/BIR/PUBL/2014/07/IUslugaBIRzewnPubl/ZalogujResponse</a:Action></s:Header><s:Body><ZalogujResponse xmlns=\"http://CIS/BIR/PUBL/2014/07\"><ZalogujResult>37sh7z5e54nc7f4f8fvx</ZalogujResult></ZalogujResponse></s:Body></s:Envelope>",
                  "7 --uuid:d7df59b9-21aa-45e0-97c3-54d9a4e79d76+id=42489--",
                  "8 "
            ]   
             */
            /* Body Response looks like for DaneSzukajByNip
             [
              "0 ",
              "1 --uuid:1afb972f-320c-4279-80f5-480b11f0dff7+id=42262",
              "2 Content-ID: <http://tempuri.org/0>",
              "3 Content-Transfer-Encoding: 8bit",
              "4 Content-Type: application/xop+xml;charset=utf-8;type=\"application/soap+xml\"",
              "5 ",
              "6 <s:Envelope xmlns:s=\"http://www.w3.org/2003/05/soap-envelope\" xmlns:a=\"http://www.w3.org/2005/08/addressing\"><s:Header><a:Action s:mustUnderstand=\"1\">http://CIS/BIR/PUBL/2014/07/IUslugaBIRzewnPubl/DaneSzukajResponse</a:Action></s:Header><s:Body><DaneSzukajResponse xmlns=\"http://CIS/BIR/PUBL/2014/07\"><DaneSzukajResult>&lt;Root&gt;&#xD;",
              "7 &lt;Dane&gt;&#xD;",
              "8 &lt;Regon&gt;01081624800000&lt;/Regon&gt;&#xD;",
              "9 &lt;RegonLink&gt;&amp;lt;a href='javascript:danePobierzPelnyRaport(\"01081624800000\",\"DaneRaportPrawnaPubl\", 0);'&amp;gt;010816248&amp;lt;/a&amp;gt;&lt;/RegonLink&gt;&#xD;",
              "10 &lt;Nazwa&gt;POLSKO-JAPOŃSKA AKADEMIA TECHNIK KOMPUTEROWYCH&lt;/Nazwa&gt;&#xD;",
              "11 &lt;Wojewodztwo&gt;MAZOWIECKIE&lt;/Wojewodztwo&gt;&#xD;",
              "12 &lt;Powiat&gt;m. st. Warszawa&lt;/Powiat&gt;&#xD;",
              "13 &lt;Gmina&gt;Śródmieście&lt;/Gmina&gt;&#xD;",
              "14 &lt;Miejscowosc&gt;Warszawa&lt;/Miejscowosc&gt;&#xD;",
              "15 &lt;KodPocztowy&gt;02-008&lt;/KodPocztowy&gt;&#xD;",
              "16 &lt;Ulica&gt;ul. Test-Krucza&lt;/Ulica&gt;&#xD;",
              "17 &lt;Typ&gt;P&lt;/Typ&gt;&#xD;",
              "18 &lt;SilosID&gt;6&lt;/SilosID&gt;&#xD;",
              "19 &lt;/Dane&gt;&#xD;",
              "20 &lt;/Root&gt;</DaneSzukajResult></DaneSzukajResponse></s:Body></s:Envelope>",
              "21 --uuid:1afb972f-320c-4279-80f5-480b11f0dff7+id=42262--",
              "22 "
            ]             
             */
            var list = body.Split("\n").ToList();
            if (list.Count() < 9)
            {
                throw new NotImplementedException();
            }

            for (int i = 0; i < 6; i++)
            {
                list.RemoveAt(0);
            }
            for (int i = 0; i < 2; i++)
            {
                list.RemoveAt(list.Count() - 1);
            }
            var envelope = string.Join("", list.Select(x => x.Trim()).ToList());
            return envelope;
        }

        private string ReplaceSpecifySignsToXml(string envelope)
        {
            envelope = envelope.Replace("&lt;", "<")
                    .Replace("&gt;", ">")
                    .Replace("&#xD;", "")//"\r"
                    .Replace("&amp;", "&");
            return envelope;
        }
    }
}
