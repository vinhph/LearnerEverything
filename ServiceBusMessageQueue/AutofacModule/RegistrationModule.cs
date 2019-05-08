

using Autofac;
using Magnum.Extensions;
using MassTransit;
using MassTransit.Log4NetIntegration;
using MassTransit.Logging;

namespace ServiceBusMessageQueue.AutofacModule
{
    public class RegistrationModule : Module
    {
        #region Fields

        private readonly bool registerConsumers;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="RegistrationModule"/> class.
        /// </summary>
        /// <param name="registerConsumers">if set to <c>true</c> [register consumers].</param>
        public RegistrationModule(bool registerConsumers = false)
        {
            this.registerConsumers = registerConsumers;
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Loads the specified builder.
        /// </summary>
        /// <param name="builder">The builder.</param>
        protected override void Load(ContainerBuilder builder)
        {

            builder.Register(
                c => ServiceBusFactory.New(
                    sbc =>
                    {
                        // other configuration options
                        sbc.UseMsmq(configurator => configurator.VerifyMsmqConfiguration());

                        sbc.UseXmlSerializer();
                        sbc.EnableMessageTracing();

                        sbc.ReceiveFrom(QueueUtility.QueueName);

                        //var container = AdvanceOfMassTransit.container;
                        //Subscribe dựa vào việc load từ container những class nào kế thừa IConsumer để làm
                        //sẽ tương đương:
                        //sbc.Subscribe(x =>
                        //{
                        //    x.Consumer<StudentConsumer>();
                        //});
                        //Subscribe tự theo dõi nếu có queue nào cùng kiểu thì chạy luôn function Consume(IConsumeContext<T> message) của class đó

                        sbc.Subscribe(x => x.LoadFrom(c.Resolve<ILifetimeScope>()));
                        sbc.SetConcurrentConsumerLimit(1);

                        // sbc.UseControlBus();
                    })).As<IServiceBus>().SingleInstance();

            if (registerConsumers)
            {

                builder.RegisterAssemblyTypes(GetType().Assembly)
                    .Where(t => t.Implements<IConsumer>())
                    .PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies)
                    .InstancePerDependency()
                    .AsSelf();
            }

        }

        #endregion
    }
}
