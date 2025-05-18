using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Poputkee.Desktop.ViewModels
{
    class BookRideView: BaseViewModel
    {
        public DateTime SelectedDate { get; set; }
        public ICommand SearchRidesCommand { get; }
    }
}
