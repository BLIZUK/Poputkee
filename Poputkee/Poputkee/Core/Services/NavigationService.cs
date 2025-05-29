using Microsoft.Extensions.DependencyInjection;
using Poputkee.Core.Interfaces;
using Poputkee.Desktop.ViewModels.MainMenu;
using Poputkee.Desktop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Poputkee.Core.Services
{
    public class NavigationService : INavigationService
    {
        private readonly IServiceProvider _serviceProvider;
        private Stack<BaseViewModel> _navigationStack = new();

        public NavigationService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        // Переход к новой ViewModel
        public void NavigateTo<T>() where T : BaseViewModel
        {
            var viewModel = _serviceProvider.GetRequiredService<T>();
            _navigationStack.Push(viewModel);

            // Пример: обновление CurrentView в MainWindowViewModel
            var mainVm = _serviceProvider.GetRequiredService<MainWindowViewModel>();
            Debug.WriteLine($">>> Переход к: {typeof(T).Name}");
            mainVm.CurrentView = viewModel;
        }

        // Возврат назад
        public void GoBack()
        {
            if (_navigationStack.Count > 1)
            {
                _navigationStack.Pop();
                var previousVm = _navigationStack.Peek();

                var mainVm = _serviceProvider.GetRequiredService<MainWindowViewModel>();
                mainVm.CurrentView = previousVm;
            }
        }

        public T GetViewModel<T>() where T : BaseViewModel
        {
            return _serviceProvider.GetRequiredService<T>();
        }
    }
}
