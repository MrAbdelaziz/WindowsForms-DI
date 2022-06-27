using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WinForms_DI.Factory;
using WinForms_DI.Forms;
using WinForms_DI.Services;

namespace WinForms_DI
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            var formFactory = CompositionRoot();

            ApplicationConfiguration.Initialize();
            Application.Run(formFactory.CreateMain());
        }


        static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddTransient<IHelloWorldService, HelloWorldServiceImpl>();
                    services.AddTransient<Main>();
                });
        }
        static IFormFactory CompositionRoot()
        {
            // host
            var hostBuilder = CreateHostBuilder();
            var host = hostBuilder.Build();

            // container
            var serviceProvider = host.Services;

            // form factory
            var formFactory = new FormFactoryImpl(serviceProvider);
            FormFactory.SetProvider(formFactory);

            return formFactory;
        }


        public class FormFactoryImpl : IFormFactory
        {
            private IServiceProvider _serviceProvider;

            public FormFactoryImpl(IServiceProvider serviceProvider)
            {
                this._serviceProvider = serviceProvider;
            }

            public Main CreateMain()
            {
                return _serviceProvider.GetRequiredService<Main>();
            }

        }

    }
}