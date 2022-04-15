using Microsoft.AspNetCore.Mvc;

namespace ODataExperiments.Server.Controllers;

[Route("[controller]")]
public sealed class DictionariesController : Controller
{
    [HttpGet]
    public IReadOnlyCollection<IDictionary<string, object>> GetDictionaries() => 
        RecordsProvider.Dictionaries;
}
