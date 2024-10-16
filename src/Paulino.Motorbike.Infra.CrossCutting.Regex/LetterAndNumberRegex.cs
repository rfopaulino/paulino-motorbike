namespace Paulino.Motorbike.Infra.CrossCutting.Regex
{
    public static class LetterAndNumberRegex
    {
        public static string Apply(string value) =>
            System.Text.RegularExpressions.Regex.Replace(value ?? "", "[^a-zA-Z0-9]", "");
    }
}
