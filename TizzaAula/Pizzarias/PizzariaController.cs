using Microsoft.AspNetCore.Mvc;

namespace TizzaAula
{
    [ApiController]
    [Route("[controller]")]
    public class PizzariaController : ControllerBase
    {
        private IServPizzaria _servPizzaria;

        public PizzariaController(IServPizzaria servPizzaria)
        {
            _servPizzaria = servPizzaria;
        }

        [HttpPost]
        public ActionResult Inserir(Pizzaria pizzaria)
        {
            try
            {
                _servPizzaria.Inserir(pizzaria);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("[controller]/{id}")]
        [HttpPut]
        public ActionResult Alterar(int id, [FromBody] AlterarPizzariaDTO alterarPizzariaDto)
        {
            try
            {
                _servPizzaria.Alterar(id, alterarPizzariaDto);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
