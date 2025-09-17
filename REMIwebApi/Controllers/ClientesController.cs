using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using REMIwebApi.Datos;
using REMIwebApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace REMIwebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<cliente> _user;

        public ClientesController(UserManager<cliente> user, ApplicationDbContext context) //parametro  
        {
            this._user = user;
            this._context = context;
        }
        // GET: api/<ClientesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ClientesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ClientesController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] cliente models)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var usuario = new cliente()
            {
                Id_cliente = models.Id_cliente,
                nombre = models.nombre,
                Apellido = models.Apellido,
                correo = models.correo,
                Telefono = models.Telefono
            };

            return Ok(new { usuario.Id_cliente, usuario.correo });
        }
            // PUT api/<ClientesController>/5
            [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ClientesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
