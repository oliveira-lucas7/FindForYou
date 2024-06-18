using Api.Models;
using Api.Repositorios;
using Api.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObjetoController : ControllerBase
    {
        private readonly IObjetoRepositorio _objetoRepositorio;

        public ObjetoController(IObjetoRepositorio objetoRepositorio)
        {
            _objetoRepositorio = objetoRepositorio;
        }

        [HttpGet("GetAllObjeto")]
        public async Task<ActionResult<List<ObjetoModel>>> GetAllObjeto()
        {
            List<ObjetoModel> objetos = await _objetoRepositorio.GetAll();
            return Ok(objetos);
        }

        [HttpGet("GetAllStatus1")]
        public async Task<ActionResult<List<ObjetoModel>>> GetAllStatus1()
        {
            List<ObjetoModel> objetos = await _objetoRepositorio.GetAllStatus1();
            return Ok(objetos);
        }

        [HttpGet("GetObjetoId/{id}")]
        public async Task<ActionResult<ObjetoModel>> GetObjetoId(int id)
        {
            ObjetoModel objeto = await _objetoRepositorio.GetById(id);
            return Ok(objeto);
        }

        [HttpPost("CreateObjeto")]
        public async Task<ActionResult<ObjetoModel>> InsertObjeto([FromBody] ObjetoModel objetoModel)
        {
            ObjetoModel objeto = await _objetoRepositorio.InsertObjeto(objetoModel);
            return Ok(objeto);
        }

        [HttpPut("UpdateObjeto/{id:int}")]
        public async Task<ActionResult<ObjetoModel>> UpdateObjeto(int id, [FromBody] ObjetoModel objetoModel)
        {
            objetoModel.ObjetoId = id;
            ObjetoModel objeto = await _objetoRepositorio.UpdateObjeto(objetoModel, id);
            return Ok(objeto);
        }

        [HttpDelete("DeleteObjeto/{id:int}")]
        public async Task<ActionResult<ObjetoModel>> DeleteObjeto(int id)
        {
            bool deleted = await _objetoRepositorio.DeleteObjeto(id);
            return Ok(deleted);
        }

    }
}
