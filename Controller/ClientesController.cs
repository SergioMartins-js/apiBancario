using apiBancario.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace apiBancario.Controller
{

    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly List<Cliente> _clientes;
        private int _idCounter; // Contador sequencial de IDs

        public ClientesController()
        {
            // Inicializa a lista de clientes (substitua por acesso ao banco de dados, se aplicável)
            _clientes = new List<Cliente>();
            _idCounter = 0; // Inicializa o contador de IDs
        }

        [HttpGet]
        public ActionResult<IEnumerable<Cliente>> Get()
        {
            // Retorna a lista completa de clientes
            return Ok(_clientes);
        }

        [HttpGet("{id}")]
        public ActionResult<Cliente> Get(int id)
        {
            // Procura um cliente pelo ID e retorna o cliente encontrado
            var cliente = _clientes.Find(c => c.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }
            return Ok(cliente);
        }

        [HttpPost]
        public ActionResult Post([FromBody] Cliente cliente)
        {
            // Valida se o modelo de cliente é válido
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Gera o novo ID automaticamente
            cliente.Id = ++_idCounter;

            // Adiciona o cliente à lista de clientes
            _clientes.Add(cliente);

            return CreatedAtAction(nameof(Get), new { id = cliente.Id }, cliente);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Cliente cliente)
        {
            // Valida se o modelo de cliente é válido
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Procura o cliente pelo ID na lista
            var index = _clientes.FindIndex(c => c.Id == id);
            if (index == -1)
            {
                return NotFound();
            }

            // Atualiza as propriedades do cliente
            _clientes[index].Nome = cliente.Nome;
            _clientes[index].Endereco = cliente.Endereco;
            _clientes[index].Telefone = cliente.Telefone;
            _clientes[index].Email = cliente.Email;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            // Procura o cliente pelo ID na lista
            var cliente = _clientes.Find(c => c.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }

            // Remove o cliente da lista
            _clientes.Remove(cliente);

            return NoContent();
        }
    }

}
