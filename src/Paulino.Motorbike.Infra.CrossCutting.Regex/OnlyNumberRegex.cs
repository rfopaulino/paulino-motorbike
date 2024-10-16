namespace Paulino.Motorbike.Infra.CrossCutting.Regex
{
    public static class OnlyNumberRegex
    {
        public static string Apply(string value) =>
            System.Text.RegularExpressions.Regex.Replace(value ?? "", @"\D", "");
    }
}
