using System;
using System.Collections.Generic;

namespace ODataExperiments.Server.Models;

public sealed record DataApiResponse<T>
{
    public IReadOnlyCollection<T> Result { get; init; } = [];

    public int Count { get; init; } = 0;
}