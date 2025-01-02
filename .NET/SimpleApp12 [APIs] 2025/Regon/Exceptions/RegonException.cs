namespace Regon.Exceptions
{
    public class RegonException : InputDataException
    {
        public RegonException() : base(Messages.Invalid_Regon) { }
    }
}
