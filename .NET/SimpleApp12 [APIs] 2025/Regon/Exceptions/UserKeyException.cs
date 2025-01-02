namespace Regon.Exceptions
{
    public class UserKeyException : InputDataException
    {
        public UserKeyException() : base(Messages.Invalid_UserKey) { }
    }
}
