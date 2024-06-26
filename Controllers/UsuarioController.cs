﻿using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        [HttpGet("GetAllUsuario")]
        public async Task<ActionResult<List<UsuarioModel>>> GetAllUsuario()
        {
            List<UsuarioModel> usuarios = await _usuarioRepositorio.GetAll();
            return Ok(usuarios);
        }

        [HttpGet("GetUsuarioId/{id}")]
        public async Task<ActionResult<UsuarioModel>> GetUsuarioId(int id)
        {
            UsuarioModel usuario = await _usuarioRepositorio.GetById(id);
            return Ok(usuario);
        }

        [HttpPost("CreateUsuario")]
        public async Task<ActionResult<UsuarioModel>> InsertUsuario([FromBody] UsuarioModel usuarioModel)
        {
            UsuarioModel usuario = await _usuarioRepositorio.InsertUsuario(usuarioModel);
            return Ok(usuario);
        }

        [HttpPut("UpdateUsuario/{id:int}")]
        public async Task<ActionResult<UsuarioModel>> UpdateUsuario(int id, [FromBody] UsuarioModel usuarioModel)
        {
            usuarioModel.UsuarioId = id;
            UsuarioModel user = await _usuarioRepositorio.UpdateUsuario(usuarioModel, id);
            return Ok(user);
        }

        [HttpDelete("DeleteSeller/{id:int}")]
        public async Task<ActionResult<UsuarioModel>> DeleteUsuario(int id)
        {
            bool deleted = await _usuarioRepositorio.DeleteUsuario(id);
            return Ok(deleted);
        }

        [HttpPost("Login")]
        public async Task<ActionResult<dynamic>> Login ([FromBody] LoginModel userModel)
        {
            if (string.IsNullOrEmpty(userModel.UsuarioEmail) || string.IsNullOrEmpty(userModel.UsuarioSenha)) 
            { 
                return BadRequest("Email e Senha são obrigatórios");
            }
            UsuarioModel userLogin = await _usuarioRepositorio.GetByEmail(userModel.UsuarioEmail);

            if (userLogin == null) 
            { 
                return BadRequest(new {sucess = false});
            }

            bool isPasswordCorrect = userLogin.UsuarioSenha == userModel.UsuarioEmail;

            if (isPasswordCorrect) 
            {
                return Ok(new { sucess = true, user = userLogin});
            }
            else
            {
                return Unauthorized(new { sucess = false });
            }
        }

    }
}
