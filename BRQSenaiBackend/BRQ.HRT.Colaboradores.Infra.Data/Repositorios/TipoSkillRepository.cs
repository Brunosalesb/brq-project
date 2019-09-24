﻿using BRQ.HRT.Colaboradores.Dominio.Entidades;
using BRQ.HRT.Colaboradores.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BRQ.HRT.Colaboradores.Infra.Data.Repositorios
{
    public class TipoSkillRepository : ITipoSkillRepository
    {
        public void CadastrarTipoSKill(string nome)
        {
            throw new NotImplementedException();
        }

        public void DeletarTipoSkill(int id)
        {
            throw new NotImplementedException();
        }

        public void EditarTipoSKill(int id, string nome)
        {
            throw new NotImplementedException();
        }

        public List<TipoSkill> ListarTipoSkill()
        {
            using (ContextoColaboradores ctx = new ContextoColaboradores())
            {
                return ctx.TipoSkill.ToList();
            }
        }
    }
}
