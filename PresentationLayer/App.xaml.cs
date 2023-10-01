using Autofac;
using DataAccessLayer.IONetwork;
using DataAccessLayer.Utils.Interfaces;
using DomainLayer;
using DomainLayer.Utils.Interfaces;
using PresentationLayer.EventObservers;
using PresentationLayer.MVVM.ViewModels;
using PresentationLayer.MVVM.Views;
using PresentationLayer.Utils.Interfaces;
using ServiceLayer;
using ServiceLayer.Interfaces;
using System;
using System.Windows;

namespace PresentationLayer
{
    public partial class App : Application
    {
        IMainWindowViewModel _mainWindowViewModel;
        public App()
        {
            ConfigureDependencyInjectionContainer();
            Console.WriteLine(System.Threading.Thread.CurrentThread.ManagedThreadId);
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
        }
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            MainWindowView mainWindowView = new MainWindowView(_mainWindowViewModel);
            if(mainWindowView != null)
            {
                mainWindowView.Show();
            }
        }

        #region Helper Methods
        private void ConfigureDependencyInjectionContainer()
        {
            ContainerBuilder builder = new ContainerBuilder();

            //Service Layer
            builder.RegisterType<DnsProvider>().As<IDnsProvider>();
            builder.RegisterType<InputValidator>().As<IInputValidator>();
            builder.RegisterType<ObjectCreator>().As<IObjectCreator>();

            //Data Access Layer
            builder.RegisterType<SerializationProvider>().As<ISerializationProvider>();
            builder.RegisterType<StreamProvider>().As<IStreamProvider>();

            //Domain Layer
            builder.RegisterType<ChatRoomManager>().As<IChatRoomManager>().SingleInstance();
            builder.RegisterType<ClientAction>().As<IClientAction>().SingleInstance();
            builder.RegisterType<MessageDispatcher>().As<IMessageDispatcher>();
            builder.RegisterType<ServerManager>().As<IServerManager>().SingleInstance();
            builder.RegisterType<Transmitter>().As<ITransmitter>();


            //Presentation Layer
            builder.RegisterType<ChatRoomObserver>().As<IChatRoomObserver>().SingleInstance();

            
            builder.RegisterType<AllChatRoomsViewModel>().As<IAllChatRoomsViewModel>().SingleInstance();
            builder.RegisterType<AllServerUsersViewModel>().As<IAllServerUsersViewModel>().SingleInstance();
            builder.RegisterType<MainWindowViewModel>().As<IMainWindowViewModel>().SingleInstance();
            builder.RegisterType<ServerViewModel>().As<IServerViewModel>().SingleInstance();
            builder.RegisterType<SingleChatRoomViewModel>().As<ISingleChatRoomViewModel>();

            Autofac.IContainer newContainer = builder.Build();

            ILifetimeScope newScope = newContainer.BeginLifetimeScope();
            _mainWindowViewModel = newScope.Resolve<IMainWindowViewModel>();

        }

        #endregion Helper Methods
    }
}
