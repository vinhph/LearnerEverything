using StructureMap;
using System;
using System.Collections.Generic;

namespace InjectedLearning
{
    public class StructureMapServiceLocator : ServiceLocatorImplBase
    {
        private IContainer container;

        /// <summary>
        /// Creates a new instance of <see cref="T:EPiServer.ServiceLocation.StructureMapServiceLocator" /></summary>
        /// <param name="container">
        /// </param>
        public StructureMapServiceLocator(IContainer container)
        {
            this.container = container;
        }

        /// <summary>
        /// When implemented by inheriting classes, this method will do the actual work of resolving
        /// the requested service instance.
        /// </summary>
        /// <param name="serviceType">Type of instance requested.</param>
        /// <param name="key">Name of registered service you want. May be null.</param>
        /// <returns>The requested service instance.</returns>
        protected override object DoGetInstance(Type serviceType, string key)
        {
            if (string.IsNullOrEmpty(key))
                return this.container.GetInstance(serviceType);
            return this.container.GetInstance(serviceType, key);
        }

        /// <summary>
        /// When implemented by inheriting classes, this method will look if the instance has been
        /// created and that it exists.
        /// </summary>
        /// <param name="serviceType">Type of instance requested.</param>
        /// <param name="key">Name of registered service you want. May be null.</param>
        /// <param name="instance">The requested service instance or null if it do not exist</param>
        /// <returns>True if the instance was found</returns>
        protected override bool DoTryGetExistingInstance(Type serviceType, string key, out object instance)
        {
            instance = !string.IsNullOrEmpty(key) ? this.container.TryGetInstance(serviceType, key) : this.container.TryGetInstance(serviceType);
            return instance != null;
        }

        /// <summary>
        /// When implemented by inheriting classes, this method will do the actual work of
        /// resolving all the requested service instances.
        /// </summary>
        /// <param name="serviceType">Type of service requested.</param>
        /// <returns>Sequence of service instance objects.</returns>
        protected override IEnumerable<object> DoGetAllInstances(Type serviceType)
        {
            foreach (object allInstance in this.container.GetAllInstances(serviceType))
                yield return allInstance;
        }

        /// <summary>
        /// Satisfies the dependencies of the given service using setter injection.
        /// </summary>
        /// <param name="service">The object whose property depdenencies should be set.</param>
        public override void Buildup(object service)
        {
            this.container.BuildUp(service);
        }
    }
}
