using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InjectedLearning
{
    public interface IServiceLocator : IServiceProvider
    {
        /// <summary>
        /// Get an instance of the given <paramref name="serviceType" />.
        /// </summary>
        /// <param name="serviceType">Type of object requested.</param>
        /// <exception cref="T:EPiServer.ServiceLocation.ActivationException">if there is an error resolving
        /// the service instance.</exception>
        /// <returns>The requested service instance.</returns>
        object GetInstance(Type serviceType);

        /// <summary>
        /// Tries to get an existing instance of the given <paramref name="serviceType" />.
        /// </summary>
        /// <param name="serviceType">Type of object requested.</param>
        /// <exception cref="T:EPiServer.ServiceLocation.ActivationException">if there is an error resolving
        /// <param name="instance">The requested service instance or null if it do not exist</param>
        /// the service instance.</exception>
        /// <returns>True if the instance was found</returns>
        bool TryGetExistingInstance(Type serviceType, out object instance);

        /// <summary>
        /// Get all instances of the given <paramref name="serviceType" /> currently
        /// registered in the container.
        /// </summary>
        /// <param name="serviceType">Type of object requested.</param>
        /// <exception cref="T:EPiServer.ServiceLocation.ActivationException">if there is are errors resolving
        /// the service instance.</exception>
        /// <returns>A sequence of instances of the requested <paramref name="serviceType" />.</returns>
        IEnumerable<object> GetAllInstances(Type serviceType);

        /// <summary>
        /// Get an instance of the given <typeparamref name="TService" />.
        /// </summary>
        /// <typeparam name="TService">Type of object requested.</typeparam>
        /// <exception cref="T:EPiServer.ServiceLocation.ActivationException">if there is are errors resolving
        /// the service instance.</exception>
        /// <returns>The requested service instance.</returns>
        TService GetInstance<TService>();

        /// <summary>
        /// Tries to get an existing instance of the given <typeparamref name="TService" />.
        /// </summary>
        /// <typeparam name="TService">Type of object requested.</typeparam>
        /// <param name="instance">The requested service instance or null if it do not exist</param>
        /// <exception cref="T:EPiServer.ServiceLocation.ActivationException">if there is are errors resolving
        /// the service instance.</exception>
        /// <returns>True if the instance was found</returns>
        bool TryGetExistingInstance<TService>(out TService instance);

        /// <summary>
        /// Get all instances of the given <typeparamref name="TService" /> currently
        /// registered in the container.
        /// </summary>
        /// <typeparam name="TService">Type of object requested.</typeparam>
        /// <exception cref="T:EPiServer.ServiceLocation.ActivationException">if there is are errors resolving
        /// the service instance.</exception>
        /// <returns>A sequence of instances of the requested <typeparamref name="TService" />.</returns>
        IEnumerable<TService> GetAllInstances<TService>();

        /// <summary>
        /// Tries to get an existing instance of the given named <paramref name="serviceType" />.
        /// </summary>
        /// <param name="serviceType">Type of object requested.</param>
        /// <param name="key">Name the object was registered with.</param>
        /// <param name="instance">The requested service instance or null if it do not exist</param>
        /// <exception cref="T:EPiServer.ServiceLocation.ActivationException">if there is an error resolving
        /// the service instance.</exception>
        /// <returns>True if the instance was found</returns>
        bool TryGetExistingInstance(Type serviceType, string key, out object instance);

        /// <summary>
        /// Get an instance of the given named <typeparamref name="TService" />.
        /// </summary>
        /// <typeparam name="TService">Type of object requested.</typeparam>
        /// <param name="key">Name the object was registered with.</param>
        /// <exception cref="T:EPiServer.ServiceLocation.ActivationException">if there is are errors resolving
        /// the service instance.</exception>
        /// <returns>The requested service instance.</returns>
        TService GetInstance<TService>(string key);

        /// <summary>
        /// Tries to get an existing instance of the given named <typeparamref name="TService" />.
        /// </summary>
        /// <typeparam name="TService">Type of object requested.</typeparam>
        /// <param name="key">Name the object was registered with.</param>
        /// <param name="instance">The requested service instance or null if it do not exist</param>
        /// <exception cref="T:EPiServer.ServiceLocation.ActivationException">if there is are errors resolving
        /// the service instance.</exception>
        /// <returns>True if the instance was found</returns>
        bool TryGetExistingInstance<TService>(string key, out TService instance);

        /// <summary>
        /// Get an instance of the given named <paramref name="serviceType" />.
        /// </summary>
        /// <param name="serviceType">Type of object requested.</param>
        /// <param name="key">Name the object was registered with.</param>
        /// <exception cref="T:EPiServer.ServiceLocation.ActivationException">if there is an error resolving
        /// the service instance.</exception>
        /// <returns>The requested service instance.</returns>
        object GetInstance(Type serviceType, string key);

        /// <summary>
        /// Satisfies the dependencies of the given service using setter injection.
        /// </summary>
        /// <param name="service">The object whose property depdenencies should be set.</param>
        void Buildup(object service);
    }
}
