namespace Regon.Exceptions
{
    public class KrsException : InputDataException
    {
        public KrsException() : base(Messages.Invalid_Krs) { }
    }
}
