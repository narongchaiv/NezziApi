﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NezziApi.Interface
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
