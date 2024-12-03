namespace RentHouse.WebUI.Utilities
{
    using System.Globalization;
    using System.Text;
    using System.Text.RegularExpressions;

    public static class SlugHelper
    {
        public static string GenerateSlug(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return string.Empty;

            input = input.ToLowerInvariant();

            input = RemoveDiacritics(input);

            input = Regex.Replace(input, @"[^a-z0-9\s-]", string.Empty);

            input = Regex.Replace(input, @"\s+", " ").Trim();

            input = input.Replace(" ", "-");

            return input;
        }

        private static string RemoveDiacritics(string text)
        {
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }
    }

}
