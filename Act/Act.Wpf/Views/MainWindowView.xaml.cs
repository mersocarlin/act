using Act.Domain.Contracts.Services;
using Act.Wpf.ViewModels;
using System.Windows;
using System.Linq;
using Newtonsoft.Json;
using System.IO;

namespace Act.Wpf.Views
{
    /// <summary>
    /// Interaction logic for MainWindowView.xaml
    /// </summary>
    public partial class MainWindowView : Window
    {
        private IActTaskService _service;
        private MainWindowViewModel _viewModel;
        //private ActTaskViewModel _viewModel;

        public MainWindowView(IActTaskService service)
        {
            InitializeComponent();
            this._service = service;
            this._viewModel = new MainWindowViewModel();
            this.DataContext = this._viewModel;
        }

        private void UpdateData()
        {
            var list = _service.GetActTasks();
            _viewModel.ActList = string.Join("\n", (from el in list select el.ToString()));
        }

        private void AddItem_Click(object sender, RoutedEventArgs e)
        {
            var actTaskView = new ActTaskView(_service);
            var result = actTaskView.ShowDialog();
            if (!result.HasValue || !result.Value)
                return;
            UpdateData();
        }

        private void Window_Closed(object sender, System.EventArgs e)
        {
            JsonSerializer serializer = new JsonSerializer();
            
            using (StreamWriter sw = new StreamWriter(System.AppDomain.CurrentDomain.BaseDirectory + "actdb.json"))
            {
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    serializer.Serialize(writer, _service.GetActTasks());
                }
            }
        }
    }
}
