using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StructureMap;

namespace InjectedLearning
{    
    public class ServiceFactory : IServiceFactory
    {
        private readonly IContainer _container;

        public ServiceFactory(IContainer container)
        {
            _container = container;
        }

        public TEntity GetService<TEntity>() where TEntity : class
        {
            return _container.GetInstance<TEntity>();
        }
    }
}
