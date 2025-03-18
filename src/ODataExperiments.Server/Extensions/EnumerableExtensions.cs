using System.Collections.Generic;
using System.Linq;
using ODataExperiments.Server.Models;

namespace ODataExperiments.Server.Extensions;

internal static class EnumerableExtensions
{
    public static DataApiResponse<T> CreateDataApiResponse<T>(
        this IEnumerable<T> source, DataApiRequestBase request)
    {
        var sourceList = source.ToList();
        var result = sourceList
            .Skip(request.Skip ?? 0)
            .TakeIfNotNull(request.Take)
            .ToList();
        return new DataApiResponse<T>
        {
            Result = result,
            Count = sourceList.Count,
        };
    }

    public static IEnumerable<T> TakeIfNotNull<T>(this IEnumerable<T> source, int? count) =>
        count.HasValue
            ? source.Take(count.Value)
            : source;
}
