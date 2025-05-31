using Microsoft.Extensions.DependencyInjection;
using Poputkee.Core.Interfaces;
using Poputkee.Desktop.ViewModels;
using System;
using System.Collections.Generic;

namespace Poputkee.Core.Services
{
    public class NavigationService : INavigationService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly Stack<BaseViewModel> _navigationStack = new();

        public event Action CurrentViewChanged;
        public BaseViewModel CurrentView { get; private set; }

        public NavigationService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void NavigateTo<T>() where T : BaseViewModel
        {
            var viewModel = _serviceProvider.GetRequiredService<T>();
            _navigationStack.Push(viewModel);
            CurrentView = viewModel;
            CurrentViewChanged?.Invoke();
        }

        public void GoBack()
        {
            if (_navigationStack.Count > 1)
            {
                _navigationStack.Pop();
                CurrentView = _navigationStack.Peek();
                CurrentViewChanged?.Invoke();
            }
        }

        public T GetViewModel<T>() where T : BaseViewModel
        {
            return _serviceProvider.GetRequiredService<T>();
        }
    }
}