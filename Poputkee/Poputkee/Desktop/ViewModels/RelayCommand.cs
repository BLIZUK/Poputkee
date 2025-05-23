using System;
using System.Windows.Input;

namespace Poputkee.Desktop.ViewModels
{
    /// <summary>
    /// Реализация ICommand для делегирования вызовов
    /// </summary>
    public class RelayCommand : ICommand
    {
        #region Fields

        private readonly Action<object> _execute;
        private readonly Func<object, bool> _canExecute;

        #endregion

        #region Constructors

        /// <summary>
        /// Создает новую команду
        /// </summary>
        /// <param name="execute">Действие для выполнения</param>
        /// <param name="canExecute">Функция проверки возможности выполнения</param>
        /// <exception cref="ArgumentNullException">Если execute равен null</exception>
        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        #endregion

        #region ICommand Implementation

        /// <summary>
        /// Проверяет возможность выполнения команды
        /// </summary>
        public bool CanExecute(object parameter)
        {
            return _canExecute?.Invoke(parameter) ?? true;
        }

        /// <summary>
        /// Выполняет команду
        /// </summary>
        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        /// <summary>
        /// Событие изменения состояния команды
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        #endregion

        //--------------------------------------------------------------> NEW
        /// <summary>
        /// Ручное обновление состояния:
        /// </summary>
        public void RaiseCanExecuteChanged()
        {
            CommandManager.InvalidateRequerySuggested();
        }
        //--------------------------------------------------------------> NEW
    }
}