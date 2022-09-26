﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test.Business.CustomMediator
{
    public interface IMediator
    {
        Task<TResponse> Send<TResponse>(IRequest<TResponse> request);
    }
}
