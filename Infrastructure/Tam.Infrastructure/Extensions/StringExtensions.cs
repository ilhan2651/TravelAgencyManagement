using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tam.Infrastructure.Extensions
{
    public static class StringExtensions
    {
        public static string NormalizeToAscii(this string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return string.Empty;

            return string.Concat(
                input.Normalize(NormalizationForm.FormD)
                     .Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
            ).ToLowerInvariant();
        }
    }
}
