using Act.Domain.Contracts.Services;
using Act.Wpf.ViewModels;
using System;
using System.Windows;

namespace Act.Wpf.Views
{
    /// <summary>
    /// Interaction logic for ActTaskView.xaml
    /// </summary>
    public partial class ActTaskView : Window
    {
        private IActTaskService _service;
        private ActTaskViewModel _viewModel;

        public ActTaskView(IActTaskService service)
        {
            InitializeComponent();
            this._service = service;
            _viewModel = new ActTaskViewModel();
            this.DataContext = _viewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _service.SaveActTask(_viewModel.ToActTask());
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
