using Microsoft.AspNetCore.Mvc;

namespace ODataExperiments.Server.Controllers;

[Route("[controller]")]
public sealed class DictionariesController : Controller
{
    public IReadOnlyCollection<IDictionary<string, object>> GetDictionaries() => 
        RecordsProvider.Dictionariess;
}
