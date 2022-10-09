using API.Service;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CepController : ControllerBase
    {


        private readonly ILogger<CepController> _logger;
        private readonly CepService _service;

        public CepController(ILogger<CepController> logger, CepService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string cep)
        {
            return Ok(await _service.BuscarCep(cep));
        }
    }
}