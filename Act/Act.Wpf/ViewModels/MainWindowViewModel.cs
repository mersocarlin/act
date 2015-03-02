using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Act.Wpf.ViewModels
{
    [ImplementPropertyChanged]
    public class MainWindowViewModel
    {
        public string ActList { get; set; }
    }
}
