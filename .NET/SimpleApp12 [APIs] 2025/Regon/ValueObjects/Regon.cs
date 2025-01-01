using System.Text.RegularExpressions;

namespace Regon.ValueObjects
{
    public record Regon
    {
        //Properties
        private static readonly Regex _regex = new Regex(@"^(\d{9}|\d{14})$");
        private string _value = null!;
        public string Value
        {
            get { return _value; }
            init
            {
                if (!IsValid(ref value))
                {
                    throw new InvalidOperationException();
                }
                _value = value;
            }
        }


        //===============================================================================================
        //===============================================================================================
        //===============================================================================================
        //Public Methods
        public bool IsValid(ref string value)
        {
            value = value
                .Replace(" ", "")
                .Replace("-", "")
                .Trim();
            return _regex.IsMatch(value);
        }

        public static implicit operator Regon(string value)
        {
            return new Regon
            {
                Value = value
            };
        }

        //===============================================================================================
        //===============================================================================================
        //===============================================================================================
        //Private Methods
    }
}
