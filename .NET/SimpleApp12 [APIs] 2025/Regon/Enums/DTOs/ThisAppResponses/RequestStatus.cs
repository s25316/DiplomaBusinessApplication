namespace Regon.Enums.DTOs.ThisAppResponses
{
    public enum RequestStatus
    {
        Captcha = 1, //Konieczne jest pobranie i sprawdzenie kodu Captcha (metody PobierzCaptcha i SprawdzCaptcha). 
        TooManyIds = 2, //Do metody DaneSzukaj przekazano zbyt wiele identyfikatorów.
        NotFound = 4, //Nie znaleziono podmiotów. 
        Forbidden = 5, //Brak uprawnień do raportu.
        ExpiredSession = 7, //Brak sesji. Sesja wygasła lub przekazano nieprawidłową wartość nagłówka sid. 

        ServiceUnavailable = 10,
        TechnicalBreak = 12,

        InvalidUSerKey = 20,
        InvalidInputValue = 21,

        Success = 30,
        ThisAppProblem = 31,
    }
}
