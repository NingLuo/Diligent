﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diligent.BOL;

namespace Diligent.DAL.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        void Complete();
    }
}