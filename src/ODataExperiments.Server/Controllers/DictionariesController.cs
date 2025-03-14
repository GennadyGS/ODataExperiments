using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ODataExperiments.Server.Providers;

namespace ODataExperiments.Server.Controllers;

[Route("[controller]")]
public sealed class DictionariesController : Controller
{
    [HttpGet]
    public IReadOnlyCollection<IDictionary<string, object>> GetDictionaries() => 
        RecordsProvider.Dictionaries;
}
