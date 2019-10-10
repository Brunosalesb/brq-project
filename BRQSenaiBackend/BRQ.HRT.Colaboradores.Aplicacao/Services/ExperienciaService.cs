﻿using AutoMapper;
using BRQ.HRT.Colaboradores.Aplicacao.Interfaces;
using BRQ.HRT.Colaboradores.Aplicacao.ViewModels;
using BRQ.HRT.Colaboradores.Aplicacao.ViewModels.Experiencia;
using BRQ.HRT.Colaboradores.Dominio.Entidades;
using BRQ.HRT.Colaboradores.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BRQ.HRT.Colaboradores.Aplicacao.Services
{
    public class ExperienciaService : IExperienciaService
    {
        private readonly IMapper _mapper;

        private readonly IPessoaRepository _pessoaRepository;

        private readonly IExperienciaRepository _experienciaRepository;

        public ExperienciaService(IMapper mapper, IPessoaRepository pessoaRepository, IExperienciaRepository experienciaRepository )
        {
            _mapper = mapper;
            _pessoaRepository = pessoaRepository;
            _experienciaRepository = experienciaRepository;
        }

        public void Add(CadastroExperienciaViewModel obj)
        {

            try
            {
                Experiencia exp = _mapper.Map<Experiencia>(obj);
                _experienciaRepository.Add(exp);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        /// <summary>
        /// Metodo que converte Para ViewModel
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IEnumerable<ExperienciaViewModel> GetAll(int userId)
        {
            try
            {
                Dominio.Entidades.Pessoa pessoa = _mapper.Map<Dominio.Entidades.Pessoa>(_pessoaRepository.GetById(userId));

                return _mapper.Map<List<ExperienciaViewModel>>(pessoa.Experiencia);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<ExperienciaViewModel> GetAll()
        {
            try
            {
                return _mapper.Map<List<ExperienciaViewModel>>(_experienciaRepository.GetAll());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ExperienciaViewModel GetById(int id)
        {
            return _mapper.Map<ExperienciaViewModel>(_experienciaRepository.GetById(id));
        }

        public void Update(ExperienciaViewModel obj)
        {
            BRQ.HRT.Colaboradores.Dominio.Entidades.Experiencia exp = _mapper.Map<BRQ.HRT.Colaboradores.Dominio.Entidades.Experiencia>(obj);
            _experienciaRepository.Update(exp);
        }

    }
}