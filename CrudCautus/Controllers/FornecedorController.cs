using CrudCautus.Models;
using CrudCautus.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace CrudCautus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedorController : ControllerBase
    {
        private readonly IFornecedorRepositorio _fornecedorRepositorio;
        public FornecedorController(IFornecedorRepositorio fornecedorRepositorio)
        {
            _fornecedorRepositorio = fornecedorRepositorio;
        }

        [HttpGet]
        public async Task <ActionResult<List<Fornecedor>>> MostrarFornecedor()
        {
            List<Fornecedor> fornecedores = await _fornecedorRepositorio.BuscarTodosFornecedores();
            return Ok(fornecedores);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Fornecedor>> BuscarPorId(int id)
        {
            Fornecedor fornecedor = await _fornecedorRepositorio.BuscarId(id);
            return Ok(fornecedor);
        }

        [HttpPost]
        public async Task<ActionResult<Fornecedor>> Cadastrar([FromBody] Fornecedor Fornecedor)
        {
            Fornecedor fornecedor = await _fornecedorRepositorio.Adicionar(Fornecedor);
            return Ok(fornecedor);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Fornecedor>> Atualizar([FromBody] Fornecedor Fornecedor, int id)
        {
            Fornecedor.IdFornecedor = id;
            Fornecedor fornecedor = await _fornecedorRepositorio.Atualizar(Fornecedor, id);
            return Ok(fornecedor);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Fornecedor>> Apagar(int id)
        {
           bool apagado = await _fornecedorRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}
