using Api.Models;

namespace Api.Repositorios.Interfaces
{
    public interface IObjetoRepositorio
    {
        Task<List<ObjetoModel>> GetAll();

        Task<ObjetoModel> GetById(int id);

        Task<ObjetoModel> InsertObjeto(ObjetoModel objeto);

        Task<ObjetoModel> UpdateObjeto(ObjetoModel objeto, int id);

        Task<bool> DeleteObjeto(int id);
    }
}
