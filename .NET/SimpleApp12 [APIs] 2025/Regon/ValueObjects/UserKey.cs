using Regon.Exceptions;

namespace Regon.ValueObjects
{
    public record UserKey
    {
        //Properties
        private string _value = null!;
        public string Value
        {
            get { return _value; }
            init
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new UserKeyException();
                }
                _value = value;
            }
        }


        //================================================================================================
        //================================================================================================
        //================================================================================================
        //Public Methods
        public static implicit operator string(UserKey value)
        {
            return value.Value;
        }

        public static implicit operator UserKey(string value)
        {
            return new UserKey
            {
                Value = value,
            };
        }

        //================================================================================================
        //================================================================================================
        //================================================================================================
        //Private Methods
    }
}
