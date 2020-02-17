using System;
using System.Collections.Generic;
using System.Globalization;

namespace InjectedLearning
{
    public abstract class ServiceLocatorImplBase : IServiceLocator, IServiceProvider
    {
        /// <summary>
        /// Implementation of <see cref="M:System.IServiceProvider.GetService(System.Type)" />.
        /// </summary>
        /// <param name="serviceType">The requested service.</param>
        /// <exception cref="T:EPiServer.ServiceLocation.ActivationException">if there is an error in resolving the service instance.</exception>
        /// <returns>The requested object.</returns>
        public virtual object GetService(Type serviceType)
        {
            return this.GetInstance(serviceType, (string)null);
        }

        /// <summary>
        /// Get an instance of the given <paramref name="serviceType" />.
        /// </summary>
        /// <param name="serviceType">Type of object requested.</param>
        /// <exception cref="T:EPiServer.ServiceLocation.ActivationException">if there is an error resolving
        /// the service instance.</exception>
        /// <returns>The requested service instance.</returns>
        public virtual object GetInstance(Type serviceType)
        {
            return this.GetInstance(serviceType, (string)null);
        }

        /// <summary>
        /// Get an instance of the given named <paramref name="serviceType" />.
        /// </summary>
        /// <param name="serviceType">Type of object requested.</param>
        /// <param name="key">Name the object was registered with.</param>
        /// <exception cref="T:EPiServer.ServiceLocation.ActivationException">if there is an error resolving
        /// the service instance.</exception>
        /// <returns>The requested service instance.</returns>
        public virtual object GetInstance(Type serviceType, string key)
        {
            try
            {
                return this.DoGetInstance(serviceType, key);
            }
            catch (Exception ex)
            {
                throw new Exception(this.FormatActivationExceptionMessage(ex, serviceType, key), ex);
            }
        }

        /// <summary>
        /// Tries to get an existing instance of the given <paramref name="serviceType" />.
        /// </summary>
        /// <param name="serviceType">Type of object requested.</param>
        /// <exception cref="T:EPiServer.ServiceLocation.ActivationException">if there is an error resolving
        /// <param name="instance">The requested service instance or null if it do not exist</param>
        /// the service instance.</exception>
        /// <returns>True if the instance was found</returns>
        public virtual bool TryGetExistingInstance(Type serviceType, out object instance)
        {
            return this.TryGetExistingInstance(serviceType, (string)null, out instance);
        }

        /// <summary>
        /// Tries to get an existing instance of the given named <paramref name="serviceType" />.
        /// </summary>
        /// <param name="serviceType">Type of object requested.</param>
        /// <param name="key">Name the object was registered with.</param>
        /// <param name="instance">The requested service instance or null if it do not exist</param>
        /// <exception cref="T:EPiServer.ServiceLocation.ActivationException">if there is an error resolving
        /// the service instance.</exception>
        /// <returns>True if the instance was found</returns>
        public virtual bool TryGetExistingInstance(Type serviceType, string key, out object instance)
        {
            return this.DoTryGetExistingInstance(serviceType, key, out instance);
        }

        /// <summary>
        /// Get all instances of the given <paramref name="serviceType" /> currently
        /// registered in the container.
        /// </summary>
        /// <param name="serviceType">Type of object requested.</param>
        /// <exception cref="T:EPiServer.ServiceLocation.ActivationException">if there is are errors resolving
        /// the service instance.</exception>
        /// <returns>A sequence of instances of the requested <paramref name="serviceType" />.</returns>
        public virtual IEnumerable<object> GetAllInstances(Type serviceType)
        {
            try
            {
                return this.DoGetAllInstances(serviceType);
            }
            catch (Exception ex)
            {
                throw new Exception(this.FormatActivateAllExceptionMessage(ex, serviceType), ex);
            }
        }

        /// <summary>
        /// Get an instance of the given <typeparamref name="TService" />.
        /// </summary>
        /// <typeparam name="TService">Type of object requested.</typeparam>
        /// <exception cref="T:EPiServer.ServiceLocation.ActivationException">if there is are errors resolving
        /// the service instance.</exception>
        /// <returns>The requested service instance.</returns>
        public virtual TService GetInstance<TService>()
        {
            return (TService)this.GetInstance(typeof(TService), (string)null);
        }

        /// <summary>
        /// Get an instance of the given named <typeparamref name="TService" />.
        /// </summary>
        /// <typeparam name="TService">Type of object requested.</typeparam>
        /// <param name="key">Name the object was registered with.</param>
        /// <exception cref="T:EPiServer.ServiceLocation.ActivationException">if there is are errors resolving
        /// the service instance.</exception>
        /// <returns>The requested service instance.</returns>
        public virtual TService GetInstance<TService>(string key)
        {
            return (TService)this.GetInstance(typeof(TService), key);
        }

        /// <summary>
        /// Tries to get an existing instance of the given <typeparamref name="TService" />.
        /// </summary>
        /// <typeparam name="TService">Type of object requested.</typeparam>
        /// <param name="instance">The requested service instance or null if it do not exist</param>
        /// <exception cref="T:EPiServer.ServiceLocation.ActivationException">if there is are errors resolving
        /// the service instance.</exception>
        /// <returns>True if the instance was found</returns>
        public virtual bool TryGetExistingInstance<TService>(out TService instance)
        {
            return this.TryGetExistingInstance<TService>((string)null, out instance);
        }

        /// <summary>
        /// Tries to get an existing instance of the given named <typeparamref name="TService" />.
        /// </summary>
        /// <typeparam name="TService">Type of object requested.</typeparam>
        /// <param name="key">Name the object was registered with.</param>
        /// <param name="instance">The requested service instance or null if it do not exist</param>
        /// <exception cref="T:EPiServer.ServiceLocation.ActivationException">if there is are errors resolving
        /// the service instance.</exception>
        /// <returns>True if the instance was found</returns>
        public virtual bool TryGetExistingInstance<TService>(string key, out TService instance)
        {
            object instance1;
            int num = this.DoTryGetExistingInstance(typeof(TService), key, out instance1) ? 1 : 0;
            instance = (TService)instance1;
            return num != 0;
        }

        /// <summary>
        /// Get all instances of the given <typeparamref name="TService" /> currently
        /// registered in the container.
        /// </summary>
        /// <typeparam name="TService">Type of object requested.</typeparam>
        /// <exception cref="T:EPiServer.ServiceLocation.ActivationException">if there is are errors resolving
        /// the service instance.</exception>
        /// <returns>A sequence of instances of the requested <typeparamref name="TService" />.</returns>
        public virtual IEnumerable<TService> GetAllInstances<TService>()
        {
            foreach (TService allInstance in this.GetAllInstances(typeof(TService)))
                yield return allInstance;
        }

        /// <summary>
        /// When implemented by inheriting classes, this method will do the actual work of resolving
        /// the requested service instance.
        /// </summary>
        /// <param name="serviceType">Type of instance requested.</param>
        /// <param name="key">Name of registered service you want. May be null.</param>
        /// <returns>The requested service instance.</returns>
        protected abstract object DoGetInstance(Type serviceType, string key);

        /// <summary>
        /// When implemented by inheriting classes, this method will look if the instance has been
        /// created and that it exists.
        /// </summary>
        /// <param name="serviceType">Type of instance requested.</param>
        /// <param name="key">Name of registered service you want. May be null.</param>
        /// <param name="instance">The requested service instance. Null if not existing</param>
        /// <returns>True if the instance was found</returns>
        protected abstract bool DoTryGetExistingInstance(Type serviceType, string key, out object instance);

        /// <summary>
        /// When implemented by inheriting classes, this method will do the actual work of
        /// resolving all the requested service instances.
        /// </summary>
        /// <param name="serviceType">Type of service requested.</param>
        /// <returns>Sequence of service instance objects.</returns>
        protected abstract IEnumerable<object> DoGetAllInstances(Type serviceType);

        /// <summary>
        /// Format the exception message for use in an <see cref="T:EPiServer.ServiceLocation.ActivationException" />
        /// that occurs while resolving a single service.
        /// </summary>
        /// <param name="actualException">The actual exception thrown by the implementation.</param>
        /// <param name="serviceType">Type of service requested.</param>
        /// <param name="key">Name requested.</param>
        /// <returns>The formatted exception message string.</returns>
        protected virtual string FormatActivationExceptionMessage(Exception actualException, Type serviceType, string key)
        {
            return string.Format((IFormatProvider)CultureInfo.CurrentUICulture, "tieng viet ActivationExceptionMessage", new object[2]
            {
        (object) serviceType.Name,
        (object) key
            });
        }

        /// <summary>
        /// Format the exception message for use in an <see cref="T:EPiServer.ServiceLocation.ActivationException" />
        /// that occurs while resolving multiple service instances.
        /// </summary>
        /// <param name="actualException">The actual exception thrown by the implementation.</param>
        /// <param name="serviceType">Type of service requested.</param>
        /// <returns>The formatted exception message string.</returns>
        protected virtual string FormatActivateAllExceptionMessage(Exception actualException, Type serviceType)
        {
            return string.Format((IFormatProvider)CultureInfo.CurrentUICulture, "tieng viet ActivationExceptionMessage", new object[1]
            {
        (object) serviceType.Name
            });
        }

        /// <summary>
        /// Satisfies the dependencies of the given service using setter injection.
        /// </summary>
        /// <param name="service">The object whose property depdenencies should be set.</param>
        public abstract void Buildup(object service);
    }
}
