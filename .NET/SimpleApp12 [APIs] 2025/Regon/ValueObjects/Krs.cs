using Regon.Exceptions;
using System.Text.RegularExpressions;

namespace Regon.ValueObjects
{
    public record Krs
    {
        //Properties
        public static readonly Regex _regex = new Regex(@"^\d{10}$");
        private string _value = null!;
        public string Value
        {
            get { return _value; }
            init
            {
                if (!IsValid(ref value))
                {
                    throw new KrsException();
                }
                _value = value;
            }
        }


        //=================================================================================================
        //=================================================================================================
        //=================================================================================================
        //Public Methods
        public bool IsValid(ref string value)
        {
            value = value
                .Replace(" ", "")
                .Replace("-", "")
                .Trim();
            return _regex.IsMatch(value);
        }

        public static implicit operator string(Krs value)
        {
            return value.Value;
        }

        public static implicit operator Krs(string value)
        {
            return new Krs
            {
                Value = value
            };
        }
        //=================================================================================================
        //=================================================================================================
        //=================================================================================================
        //Public Methods
    }
}
