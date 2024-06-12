using Api.Models;

namespace Api.Repositorios.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Task<List<UsuarioModel>> GetAll();

        Task<UsuarioModel> GetById(int id);

        Task<UsuarioModel> GetByEmail(string email);

        Task<UsuarioModel> InsertUsuario(UsuarioModel usuario);

        Task<UsuarioModel> UpdateUsuario(UsuarioModel usuario, int id);

        Task<bool> DeleteUsuario(int id);
    }
}
