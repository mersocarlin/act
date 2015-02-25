using Act.Domain.Contracts.Services;
using Act.Domain.Models;
using System.Windows;

namespace Act.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IActTaskService _service;

        public MainWindow(IActTaskService service)
        {
            InitializeComponent();
            this._service = service;

            for (int i = 0; i < 20; i++)
                _service.SaveActTask(new Domain.Models.ActTask("title " + i, "description " + i));
        }
    }
}
