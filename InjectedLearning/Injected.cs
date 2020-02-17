using System;

namespace InjectedLearning
{
    [Serializable]
    public struct Injected<T> where T : class
    {
        [NonSerialized] private ServiceAccessor<T> _accessor;
        [NonSerialized] private T _service;

        /// <summary>
        /// Initializes an instance with a specific service accessor.
        /// </summary>
        /// <param name="accessor">The accessor delegate to use for retrieving the service.</param>
        public Injected(ServiceAccessor<T> accessor)
        {
            this._service = default(T);
            this._accessor = accessor;
        }

        /// <summary>
        /// Initializes an instance with a specific service accessor.
        /// </summary>
        /// <param name="service">The service instance to use.</param>
        public Injected(T service)
        {
            this._service = service;
            this._accessor = (ServiceAccessor<T>) null;
        }

        /// <summary>
        /// Gets or sets an accessor delegate that can be used to retrieve the service that should be injected.
        /// </summary>
        /// <remarks>
        ///   <para>
        ///           Setting this property will also affect the Service property.
        ///       </para>
        /// </remarks>
        public ServiceAccessor<T> Accessor
        {
            get
            {
                if (this._accessor != null)
                    return this._accessor;
                if ((object) this._service == null)
                    return new ServiceAccessor<T>(ServiceLocator.Current.GetInstance<T>);
                T service = this._service;
                this._accessor = (ServiceAccessor<T>) (() => service);
                return this._accessor;
            }
            set
            {
                this._accessor = value;
                this._service = default(T);
            }
        }

        /// <summary>
        /// Gets or sets the service instance that should be injected.
        /// </summary>
        /// <remarks>
        ///   <para>
        ///           Setting this property will also affect the Accessor property.
        ///       </para>
        ///   <para>
        ///           If not set this property is lazily resolved when first used.
        ///       </para>
        /// </remarks>
        public T Service
        {
            get
            {
                T service = this._service;
                if ((object) service != null)
                    return service;
                return this._service = this.Accessor();
            }
            set
            {
                this._service = value;
                this._accessor = (ServiceAccessor<T>) null;
            }
        }
    }
}