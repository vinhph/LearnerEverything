using Topshelf;

namespace TopshelfService
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(hostConfig =>
            {
                hostConfig.Service<MyWindowsService>(serviceConfig =>
                {
                    serviceConfig.ConstructUsing(() => new MyWindowsService());                    
                    serviceConfig.WhenStarted(s => s.Start());
                    serviceConfig.WhenStopped(s => s.Stop());
                });
                hostConfig.RunAsLocalSystem();
                hostConfig.SetDescription("Sample Topshelf Host");                   //7
                hostConfig.SetDisplayName("TopshelfService");                                  //8
                hostConfig.SetServiceName("TopshelfService");
            });
        }
    }
}
