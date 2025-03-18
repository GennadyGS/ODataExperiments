using System;

namespace ODataExperiments.Server.Extensions;

internal static class StringExtensions
{
    public static bool EqualsIgnoreCase(this string source, string other) =>
        string.Equals(source, other, StringComparison.OrdinalIgnoreCase);

    public static bool StartsWithIgnoreCase(this string source, string value) =>
        source.StartsWith(value, StringComparison.OrdinalIgnoreCase);
}
