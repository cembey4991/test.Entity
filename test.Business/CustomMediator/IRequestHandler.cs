﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test.Business.CustomMediator
{
    public interface IRequestHandler<TRequest, TResponse> where TRequest :IRequest<TResponse>
    {
        Task<TResponse> Handle(TRequest request);
    }
}