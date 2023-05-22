using $safesolutionname$.Common;

#pragma warning disable IDE0057 // Use range operator
#pragma warning disable CA1845 // Use span-based 'string.Concat'
namespace $safesolutionname$.Domain.Services.Setting
{
    public static class SettingService
    {
        private static readonly int HiddenChars = 4;

        public static string HideValue(string value, string securityKey)
        {
            if (string.IsNullOrEmpty(value)) return value;

            string? hiddenValue;

            try { hiddenValue = value.Decrypt(securityKey); }
            catch (Exception) { hiddenValue = string.Empty; }

            if (!string.IsNullOrEmpty(hiddenValue))
            {
                if (hiddenValue.Length <= HiddenChars)
                    hiddenValue = string.Concat(Enumerable.Repeat("*", hiddenValue.Length));
                else
                    hiddenValue = string.Concat(Enumerable.Repeat("*", hiddenValue.Length - HiddenChars)) + hiddenValue.Substring(hiddenValue.Length - HiddenChars);
            }

            return hiddenValue;
        }
    }
}
#pragma warning restore CA1845 // Use span-based 'string.Concat'
#pragma warning restore IDE0057 // Use range operator
