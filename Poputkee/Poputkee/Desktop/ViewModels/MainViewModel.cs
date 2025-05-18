using Poputkee.Core.Models;
using Poputkee.Desktop.ViewModels;
using System.Windows.Controls;

/*
 * Пример
 * Т.к. в главном окне особо движухи то и не будет. 
 */

namespace Poputkee.Desktop.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private string _title;

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainViewModel()
        {
            Title = "Пример заголовка";
        }
    }
}
