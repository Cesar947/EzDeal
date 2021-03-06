﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace Data.Interfaces
{
    public interface IRepositorioPublicacion : IRepositorioCRUD<Publicacion>
    {
        List<Publicacion> findByServicio(int codigo_servicio);
    }
}
