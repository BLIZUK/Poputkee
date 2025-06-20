﻿using Poputkee.Desktop.ViewModels;

namespace Poputkee.Core.Interfaces
{
    public interface INavigationService
    {
        event Action CurrentViewChanged;
        BaseViewModel CurrentView { get; }
        void NavigateTo<T>() where T : BaseViewModel;
        void GoBack();
        T GetViewModel<T>() where T : BaseViewModel;
    }
}