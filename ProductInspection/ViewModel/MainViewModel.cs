using ProductInspection.Commands;
using ProductInspection.Controls;
using ProductInspection.MVVM.ViewModel.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProductInspection.ViewModel
{

    /// <summary>
    /// Главная ViewModel, меняет другие модели представления с помощью UpdateCurrentViewModelCommand
    /// </summary>
    public class MainViewModel : BaseViewModel
    {
        /// <summary>
        /// Фабрика моделей представления
        /// </summary>
        private readonly IViewModelFactory _viewModelFactory;

        /// <summary>
        /// Сервис навигации приложение
        /// </summary>
        private readonly INavigationStore _navigationStore;

        /// <summary>
        /// Активная модель представления
        /// </summary>
        public BaseViewModel CurrentViewModel => _navigationStore.CurrentViewModel;

        /// <summary>
        /// Команда смены модели представления
        /// </summary>
        public ICommand UpdateCurrentViewModelCommand { get; }

        public MainViewModel(IViewModelFactory viewModelFactory, 
                             INavigationStore navigationStore)
        {
            _viewModelFactory = viewModelFactory;
            _navigationStore = navigationStore;

            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;

            UpdateCurrentViewModelCommand =
                new UpdateCurrentViewModelCommand(_viewModelFactory, navigationStore);
            UpdateCurrentViewModelCommand.Execute(ViewModelType.Main);
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
