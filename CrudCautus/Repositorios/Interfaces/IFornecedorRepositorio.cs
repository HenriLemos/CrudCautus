using CrudCautus.Models;

namespace CrudCautus.Repositorios.Interfaces
{
    public interface IFornecedorRepositorio
    {
        Task<List<Fornecedor>> BuscarTodosFornecedores();
        Task<Fornecedor> BuscarId(int id);
        Task<Fornecedor> Adicionar(Fornecedor fornecedor);
        Task<Fornecedor> Atualizar(Fornecedor fornecedor, int id);
        Task<bool> Apagar(int id);
    }
}
