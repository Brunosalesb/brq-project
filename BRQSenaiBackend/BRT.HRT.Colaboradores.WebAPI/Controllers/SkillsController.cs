﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BRQ.HRT.Colaboradores.Aplicacao.Interfaces;
using BRQ.HRT.Colaboradores.Aplicacao.Interfaces.Skill;
using BRQ.HRT.Colaboradores.Aplicacao.ViewModels;
using BRQ.HRT.Colaboradores.Aplicacao.ViewModels.Skill;
using BRQ.HRT.Colaboradores.Dominio.Entidades;
using BRQ.HRT.Colaboradores.Dominio.Interfaces;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BRQ.HRT.Colaboradores.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        private readonly ICadastroSkillService _mapperCadastroSkill;
        private readonly ISkillService _mapperSkill;
        private readonly ISkillRepository _skillRepository;
        private readonly IPessoaRepository _pessoaRepository;


        public SkillsController(ICadastroSkillService mapperCadSkill, ISkillService mapperSkill, ISkillRepository skillRepository, IPessoaRepository pessoaRepository)
        {
            _mapperCadastroSkill = mapperCadSkill;
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
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [EnableQuery]
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            try
            {
                Skill skillBuscada = _skillRepository.GetById(id.ToString());
                if (skillBuscada == null)
                {
                    return NotFound(new { Mensagem = $"A skill com id {id} não foi encontrada"});
                }

                return Ok(_mapperSkill.GetById(id.ToString()));
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        //[EnableQuery]
        //[HttpGet("usuario/{id}")]
        //public IActionResult ListarTodasPorIdPessoa(int id)
        //{
        //    try
        //    {
        //        Pessoa pessoaBuscada = _pessoaRepository.GetById(id.ToString());
        //        if (pessoaBuscada == null)
        //        {
        //            return NotFound(new { Mensagem = $"A pessoa com id: {id} não foi encontrada!" });
        //        }
        //        return Ok(_mapperSkill.GetAll(id.ToString()));
        //    }
        //    catch (Exception)
        //    {

        //        return BadRequest();
        //    }
        //}

        [EnableQuery]
        [HttpDelete("id")]
        public IActionResult DeletarSkill(int id)
        {
            try
            {
                Skill skillBuscada = _skillRepository.GetById(id.ToString());
                if (skillBuscada == null)
                {
                    return NotFound(new { Mensagem = $"A skill {id} não foi encontrada" });
                }

                _skillRepository.Remove(id.ToString());
                return Ok();
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
                _mapperCadastroSkill.Add(skill);
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [EnableQuery]
        [HttpPut("{id}")]
        public IActionResult EditarSkill(int id,SkillViewModel skill)
        {
            try
            {
                Skill skillBuscada = _skillRepository.GetById(id.ToString());
                if (skillBuscada == null)
                {
                    return NotFound(new{ Mensagem = $"A skill {id} não foi encontrada"});
                }
                _mapperSkill.Update(id.ToString(),skill);
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

    }
}