using StructureMap;
namespace InjectedLearning
{
    public static class ServiceLocator
    {
        private static ServiceLocatorProvider currentProvider = (ServiceLocatorProvider)(() => (IServiceLocator)new StructureMapServiceLocator((IContainer)new Container()));

        /// <summary>The current ambient container.</summary>
        public static IServiceLocator Current
        {
            get
            {
                return ServiceLocator.currentProvider();
            }
        }

        /// <summary>
        /// Sets the service locator provider to a service locator provider using the given service locator.
        /// </summary>
        /// <param name="serviceLocator">The container to use for the global service locator instance.</param>
        public static void SetLocator(IServiceLocator serviceLocator)
        {
            ServiceLocator.SetLocatorProvider((ServiceLocatorProvider)(() => serviceLocator));
        }

        /// <summary>
        /// Set the delegate that is used to retrieve the current container.
        /// </summary>
        /// <param name="newProvider">Delegate that, when called, will return
        /// the current ambient container.</param>
        public static void SetLocatorProvider(ServiceLocatorProvider newProvider)
        {
            ServiceLocator.currentProvider = newProvider;
        }

        /// <summary>
        /// Assigns a service reference using the service locator if not already assigned.
        /// This method is used internally by EPiServer to simplify optional service parameters.
        /// </summary>
        /// <typeparam name="TService">The type of service to retrieve.</typeparam>
        /// <param name="locator">The service locator instance to use.</param>
        /// <param name="potentiallyEmptyServiceReference">The object referenced that is checked for null before beeing assigned.</param>
        /// <returns>True if a service was assigned, otherwise null.</returns>
        public static bool AssignNullService<TService>(this IServiceLocator locator, ref TService potentiallyEmptyServiceReference)
        {
            if ((object)potentiallyEmptyServiceReference != null)
                return false;
            potentiallyEmptyServiceReference = locator.GetInstance<TService>();
            return true;
        }
    }
}
