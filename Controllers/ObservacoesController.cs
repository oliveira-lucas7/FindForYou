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
    public class ObservacoesController : ControllerBase
    {
        private readonly IObservacoesRepositorio _observacoesRepositorio;

        public ObservacoesController(IObservacoesRepositorio observacoesRepositorio)
        {
            _observacoesRepositorio = observacoesRepositorio;
        }

        [HttpGet("GetAllObservacoes")]
        public async Task<ActionResult<List<ObservacoesModel>>> GetAllObservacoes()
        {
            List<ObservacoesModel> observacao = await _observacoesRepositorio.GetAll();
            return Ok(observacao);
        }

        [HttpGet("GetObservacoesId/{id}")]
        public async Task<ActionResult<ObservacoesModel>> GetUserId(int id)
        {
            ObservacoesModel observacoes = await _observacoesRepositorio.GetById(id);
            return Ok(observacoes);
        }

        [HttpPost("CreateObservacoes")]
        public async Task<ActionResult<ObservacoesModel>> InsertObservacoes([FromBody] ObservacoesModel observacoesModel)
        {
            ObservacoesModel observacao = await _observacoesRepositorio.InsertObservacoes(observacoesModel);
            return Ok(observacao);
        }

        [HttpPut("UpdateObservacoes/{id:int}")]
        public async Task<ActionResult<ObservacoesModel>> UpdateObservacoes(int id, [FromBody] ObservacoesModel observacoesModel)
        {
            observacoesModel.ObservacoesId = id;
            ObservacoesModel observacao = await _observacoesRepositorio.UpdateObservacoes(observacoesModel, id);
            return Ok(observacao);
        }

        [HttpDelete("DeleteObservacoes/{id:int}")]
        public async Task<ActionResult<ObservacoesModel>> DeleteObservacoes(int id)
        {
            bool deleted = await _observacoesRepositorio.DeleteObservacoes(id);
            return Ok(deleted);
        }
    }
}
