﻿using Examen.ApplicationCore.Domain;
using Examen.ApplicationCore.Interfaces;
using System.Collections.Generic;

namespace Examen.ApplicationCore.Interfaces
{
    public interface ILivreService : IService<Livre>
    {
        Livre GetMostPrete();
    }
}
