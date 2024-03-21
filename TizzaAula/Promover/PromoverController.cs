using Microsoft.AspNetCore.Mvc;
using TizzaAula;

[ApiController]
[Route("[controller]")]

public class PromoverController : ControllerBase
{
    private IServPromover _servPromover;

    public PromoverController(IServPromover servPromover)
    {
        _servPromover = servPromover;
    }
    [HttpPost]
    public IActionResult Inserir(InserirPromoverDTO inserirPromoverDTO)
    {
        try
        {
            _servPromover.Inserir(inserirPromoverDTO);

            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }


    [HttpPost("id")]
    public IActionResult BuscarPromover(int id)
    {
        try
        {
            var registro = _servPromover.BuscarPromover(id);

            return Ok(registro);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet]
    public IActionResult Listar()
    {
        try
        {
            var lista = _servPromover.Listar();

            return Ok(lista);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [Route("/[Controller]/Efetivar/{id}")]
    [HttpPost]
    public IActionResult Efetivar(int id)
    {
        try
        {
            //_servPromover.Efetivar(inserirPromoverDTO);
            _servPromover.Efetivar(id);

            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}