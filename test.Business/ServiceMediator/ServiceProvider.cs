﻿namespace test.Business.ServiceMediator
{
    public class ServiceProvider
    {
        private static IServiceProvider _serviceProvicer;
        public static IServiceProvider ServiceProvicer => _serviceProvicer;

        public static void SetInstance(IServiceProvider serviceProvider)
        {
            _serviceProvicer = serviceProvider;
        }
    }
}
