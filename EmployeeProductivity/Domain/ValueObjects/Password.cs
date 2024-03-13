using System.Text.RegularExpressions;

namespace Domain.ValueObjects
{
    public partial class Password(string password, Func<string, string> GetHash)
    {
        public string Hash => GetHash(password);
    }
}
