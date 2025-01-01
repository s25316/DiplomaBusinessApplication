using System.Text.RegularExpressions;

namespace Regon.ValueObjects
{
    public record Nip
    {
        //Properties
        private static readonly Regex _regex = new Regex(@"^\d{10}$");
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


        //=============================================================================================
        //=============================================================================================
        //=============================================================================================
        //Public Methods
        public bool IsValid(ref string value)
        {
            value = value
                .Replace(" ", "")
                .Replace("-", "")
                .Trim();
            return _regex.IsMatch(value);
        }
        //=============================================================================================
        //=============================================================================================
        //=============================================================================================
        //Private Methods
    }
}
