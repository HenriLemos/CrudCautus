using CrudCautus.Data;
using CrudCautus.Models;
using CrudCautus.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CrudCautus.Repositorios
{
    public class FornecedorRepositorio : IFornecedorRepositorio
    {
        private readonly FuncionarioDBContext _DbContext;
        public FornecedorRepositorio(FuncionarioDBContext funcionarioDBContext)
        {
            _DbContext = funcionarioDBContext;
        }

        /* Aqui o Contrutor Busca um Id do Fornecedor na tabela e retorna na tela */
        public async Task<Fornecedor> BuscarId(int id)
        {
            return await _DbContext.Tb_Fornecedor.FirstOrDefaultAsync(x => x.IdFornecedor == id);
        }

        /* Aqui o Contrutor Busca todos os Id's dos Fornecedores na tabela e retorna na tela */
        public async Task<List<Fornecedor>> BuscarTodosFornecedores()
        {
            return await _DbContext.Tb_Fornecedor.ToListAsync();
        }

        /* Aqui o Contrutor Adiciona novo Fornecedor na tabela e salva as mudanças */
        public async Task<Fornecedor> Adicionar(Fornecedor fornecedor)
        {
            await _DbContext.Tb_Fornecedor.AddAsync(fornecedor);
            await _DbContext.SaveChangesAsync();

            return fornecedor;
        }

        /* Aqui o Contrutor Atualiza as informações de um Fornecedor existente na tabela */
        public async Task<Fornecedor> Atualizar(Fornecedor fornecedor, int id)
        {
            Fornecedor fornecedorPorId = await BuscarId(id);
            
            if (fornecedorPorId == null)
            {
                throw new Exception($" O Fornecedor(A) para o ID: {id} não foi encontrado.");
            }

            fornecedorPorId.Nome = fornecedor.Nome;
            fornecedorPorId.Email = fornecedor.Email;

            _DbContext.Tb_Fornecedor.Update(fornecedorPorId);
            await _DbContext.SaveChangesAsync();

            return fornecedorPorId;
        }

        /* Aqui o Contrutor remove um Fornecedor da tabela por meio do Id */
        public async Task<bool> Apagar(int id)
        {
            Fornecedor fornecedorPorId = await BuscarId(id);

            if (fornecedorPorId == null)
            {
                throw new Exception($" O Fornecedor(A) para o ID: {id} não foi encontrado.");
            }

            _DbContext.Tb_Fornecedor.Remove(fornecedorPorId);
            await _DbContext.SaveChangesAsync();
            return true;
        }

    }
}
