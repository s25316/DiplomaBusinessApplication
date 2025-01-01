namespace Regon.Enums
{
    public enum KomunikatKodEnum
    {
        Captcha = 1, //Konieczne jest pobranie i sprawdzenie kodu Captcha (metody PobierzCaptcha i SprawdzCaptcha). 
        TooManyIds = 2, //Do metody DaneSzukaj przekazano zbyt wiele identyfikatorów.
        NotFound = 4, //Nie znaleziono podmiotów. 
        Forbidden = 5, //Brak uprawnień do raportu.
        UnAuthorize = 7, //Brak sesji. Sesja wygasła lub przekazano nieprawidłową wartość nagłówka sid. 
    }
}
