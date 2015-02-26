using Act.Business.Services;
using Act.Data.Repository;
using Act.Domain.Contracts.Repositories;
using Act.Domain.Contracts.Services;
using Act.Wpf.Views;
using Microsoft.Practices.Unity;
using System.Windows;

namespace Act.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            IUnityContainer container = new UnityContainer();
            container.RegisterType<IActTaskRepository, ActTaskRepository>();
            container.RegisterType<IActTaskService, ActTaskService>();
            //MainWindow window = container.Resolve<MainWindow>();
            ActTaskView window = container.Resolve<ActTaskView>();
            window.Show();
        }

       
    }
}
