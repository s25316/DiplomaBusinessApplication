namespace Regon.Exceptions
{
    public class NipException : InputDataException
    {
        public NipException() : base(Messages.Invalid_Nip) { }
    }
}
