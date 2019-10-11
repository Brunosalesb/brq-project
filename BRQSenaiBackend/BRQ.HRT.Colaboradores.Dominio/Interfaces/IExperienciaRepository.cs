﻿using BRQ.HRT.Colaboradores.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace BRQ.HRT.Colaboradores.Dominio.Interfaces
{
    public interface IExperienciaRepository : IBaseRepository<Experiencia>
    {
        List<Experiencia> ListarExperienciasPorIdPessoa(int id);
    }
}
