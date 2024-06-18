using Api.Data;
using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Api.Repositorios
{
    public class ObjetoRepositorio : IObjetoRepositorio
    {
        private readonly Contexto _dbContext;

        public ObjetoRepositorio(Contexto dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ObjetoModel>> GetAll()
        {
            return await _dbContext.Objeto.ToListAsync();
        }

        public async Task<List<ObjetoModel>> GetAllStatus1()
        {
            return await _dbContext.Objeto.Where(x => x.ObjetoStatus== 1).ToListAsync();
        }

        public async Task<ObjetoModel> GetById(int id)
        {
            return await _dbContext.Objeto.FirstOrDefaultAsync(x => x.ObjetoId == id);
        }

        public async Task<ObjetoModel> InsertObjeto(ObjetoModel objeto)
        {
            await _dbContext.Objeto.AddAsync(objeto);
            await _dbContext.SaveChangesAsync();
            return objeto;
        }

        public async Task<ObjetoModel> UpdateObjeto(ObjetoModel objeto, int id)
        {
            ObjetoModel objetos = await GetById(id);
            if (objetos == null)
            {
                throw new Exception("Não encontrado.");
            }
            else
            {
                objetos.ObjetoNome = objeto.ObjetoNome;
                objetos.ObjetoCor = objeto.ObjetoCor;
                objetos.ObjetoObservacao = objeto.ObjetoObservacao;
                objetos.ObjetoLocalDesaparecimento = objeto.ObjetoLocalDesaparecimento;
                objetos.ObjetoFoto = objeto.ObjetoFoto;
                objetos.ObjetoDtDesaparecimento = objeto.ObjetoDtDesaparecimento;
                objetos.ObjetoDtEncontro = objeto.ObjetoDtEncontro;
                objetos.ObjetoStatus = objeto.ObjetoStatus;
                _dbContext.Objeto.Update(objetos);
                await _dbContext.SaveChangesAsync();
            }
            return objetos;

        }

        public async Task<bool> DeleteObjeto(int id)
        {
            ObjetoModel objetos = await GetById(id);
            if (objetos == null)
            {
                throw new Exception("Não encontrado.");
            }

            _dbContext.Objeto.Remove(objetos);
            await _dbContext.SaveChangesAsync();
            return true;
        }

    }
}
