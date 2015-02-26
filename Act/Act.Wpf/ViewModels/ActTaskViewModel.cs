using Act.Domain.Contracts.Services;
using Act.Wpf.Commands;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Act.Wpf.ViewModels
{
    [ImplementPropertyChanged]
    public class ActTaskViewModel
    {
        //Binding Validation
        //https://msdn.microsoft.com/en-us/library/ms753962%28v=vs.110%29.aspx

        //private IActTaskService _service;        

        #region Ctor
        public ActTaskViewModel(/*IActTaskService service*/)
        {
            //this._service = service;
            //this.SaveCommand = new RelayCommand(a => SaveAction(), b => !string.IsNullOrEmpty(this.Title));
        }
        #endregion

        #region Properties
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? ParentId { get; set; }

        //public ICommand SaveCommand { get; set; }
        #endregion

        #region Methods
        //public void SaveAction()
        //{
        //    _service.SaveActTask(new Act.Domain.Models.ActTask(Title, Description)
        //    {
        //        //ParentId = null
        //    });
        //}

        public Act.Domain.Models.ActTask ToActTask()
        {
            return new Act.Domain.Models.ActTask(this.Title, this.Description) 
            {
                //ParentId = null
            };
        }
        #endregion
    }
}
