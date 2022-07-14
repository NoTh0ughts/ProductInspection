using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductInspection.ViewModel.Factory
{
    /// <summary>
    /// Задает интерфейс взаимодействия с фабрикой ViewModel`й
    /// </summary>
    public interface IViewModelFactory
    {
        BaseViewModel CreateViewModel(ViewModelType viewType);
    }
}
