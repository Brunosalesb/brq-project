﻿using System;
using BRQ.HRT.Colaboradores.Aplicacao.Interfaces;
using BRQ.HRT.Colaboradores.Aplicacao.ViewModels;
using BRQ.HRT.Colaboradores.Aplicacao.ViewModels.Skill;
using BRQ.HRT.Colaboradores.Dominio.Entidades;
using BRQ.HRT.Colaboradores.Dominio.Interfaces;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;

namespace BRQ.HRT.Colaboradores.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        private readonly ISkillService _mapperSkill;
        private readonly ISkillRepository _skillRepository;
        private readonly IPessoaRepository _pessoaRepository;


        public SkillsController(ISkillService mapperSkill, ISkillRepository skillRepository, IPessoaRepository pessoaRepository)
        {
            _mapperSkill = mapperSkill;
            _skillRepository = skillRepository;
            _pessoaRepository = pessoaRepository;
        }

        [EnableQuery]
        [HttpGet]
        public IActionResult ListarSkills()
        {
            try
            {
                return Ok(_mapperSkill.GetAll());
            }
            catch (Exception ex)
            {

                return BadRequest(new{ Erro = ex.ToString()});
            }
        }

        [EnableQuery]
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            try
            {
                Skill skillBuscada = _skillRepository.GetById(id);
                if (skillBuscada == null)
                {
                    return NotFound(new { Mensagem = $"A skill com id {id} não foi encontrada" });
                }

                return Ok(_skillRepository.GetById(id));
            }
            catch (Exception ex)
            {

                return BadRequest(new { Erro = ex.ToString() });
            }
        }

        [EnableQuery]
        [HttpGet("usuario/{id}")]
        public IActionResult ListarTodasPorIdPessoa(int id)
        {
            try
            {
                Pessoa pessoaBuscada = _pessoaRepository.GetById(id);
                if (pessoaBuscada == null)
                {
                    return NotFound(new { Mensagem = $"A pessoa com id: {id} não foi encontrada!" });
                }
                return Ok(_mapperSkill.GetAll(id));
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [EnableQuery]
        [HttpPost]
        public IActionResult CadastrarSkill(CadastroSkillViewModel skill)
        {
            try
            {
                _mapperSkill.Add(skill);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(new { Erro = ex.ToString() });
            }
        }

        [EnableQuery]
        [HttpPut("{id}")]
        public IActionResult EditarSkill(int id, SkillViewModel skill)
        {
            try
            {
                Skill skillBuscada = _skillRepository.GetById(id);
                if (skillBuscada == null)
                {
                    NotFound(new { Mensagem = $"Skill não foi encontrada" });
                }
                _mapperSkill.Update(skill);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { Erro = ex.ToString() });
            }
        }

    }
}