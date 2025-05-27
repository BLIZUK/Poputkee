using Poputkee.Desktop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poputkee.Core.Interfaces
{
    public interface INavigationService
    {
        // Переход к ViewModel типа T
        void NavigateTo<T>() where T : BaseViewModel;

        // Возврат к предыдущему экрану
        void GoBack();

        public T GetViewModel<T>() where T : BaseViewModel;
    }
}
