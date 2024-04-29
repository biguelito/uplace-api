using Microsoft.AspNetCore.Mvc;
using UplaceApi.Repository;

namespace UplaceApi.Controllers;

[ApiController]
[Route("api")]
public class TesteController : ControllerBase
{
    private readonly ITesteRepository _testeRepository;

    public TesteController(ITesteRepository testeRepository)
    {
        _testeRepository = testeRepository;
    }

    [HttpGet("teste")]
    public async Task<IActionResult> GetAsync()
    {
        Console.WriteLine("testano");
        return Ok(await _testeRepository.ObterTestes());
    }
}
