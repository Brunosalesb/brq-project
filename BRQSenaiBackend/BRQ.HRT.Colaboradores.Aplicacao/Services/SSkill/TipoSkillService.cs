﻿using AutoMapper;
using BRQ.HRT.Colaboradores.Aplicacao.Interfaces.ISkill;
using BRQ.HRT.Colaboradores.Aplicacao.ViewModels.TipoSkill;
using BRQ.HRT.Colaboradores.Dominio.Entidades;
using BRQ.HRT.Colaboradores.Dominio.Interfaces;
using System;
using System.Collections.Generic;

namespace BRQ.HRT.Colaboradores.Aplicacao.Services.SSkill
{
    public class TipoSkillService : ITipoSkillService
    {

        private readonly IMapper _mapper;
        private readonly ITipoSkillRepository _tipoSkillRepository;
        private readonly IPessoaRepository _pessoaRepository;

        public TipoSkillService(IMapper mapper, ITipoSkillRepository tipoSkillRepository, IPessoaRepository pessoaRepository)
        {
            _mapper = mapper;
            _tipoSkillRepository = tipoSkillRepository;
            _pessoaRepository = pessoaRepository;
        }

        public void Add(CadastroTipoSkillViewModel obj)
        {
            try
            {
                TipoSkill tipoSkill = _mapper.Map<TipoSkill>(obj);
                _tipoSkillRepository.Add(tipoSkill);
            }
            catch (Exception)
            {

                throw;
            }
        }
        
        IEnumerable<TipoSkillViewModel> ITipoSkillService.GetAll(int userId)
        {
            try
            {
                Dominio.Entidades.Pessoa pessoa= _mapper.Map<Dominio.Entidades.Pessoa>(_pessoaRepository.GetById(userId));

                return _mapper.Map<List<TipoSkillViewModel>>(pessoa.SkillPessoa);
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }

        IEnumerable<TipoSkillViewModel> ITipoSkillService.GetAll()
        {
            try
            {
                return _mapper.Map<List<TipoSkillViewModel>>(_tipoSkillRepository.GetAll());
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
    }
}
