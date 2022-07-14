using ProductInspection.Controls;
using ProductInspection.MVVM.ViewModel.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductInspection.Commands
{
    /// <summary>
    /// Обновляет текущую ViewModel
    /// </summary>
    public class UpdateCurrentViewModelCommand : BaseCommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly INavigationStore _navigator;
        private readonly IViewModelFactory _viewModelFactory;

        public UpdateCurrentViewModelCommand(IViewModelFactory viewModelFactory,
                                             INavigationStore navigator)
        {
            _viewModelFactory = viewModelFactory;
            _navigator = navigator;
        }


        public override void Execute(object parameter)
        {
            // Сменить ViewModel на ...
            if (parameter is ViewModelType viewType)
            {
                _navigator.CurrentViewModel = _viewModelFactory.CreateViewModel(viewType);
            }
        }
    }
}
