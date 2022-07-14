using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductInspection.ViewModel.Factory
{
    /// <summary>
    /// Создает новую модель представлений
    /// Позволяет задать правила создания модели из DI
    /// </summary>
    /// <typeparam name="TViewModel"> ViewModel к созданию </typeparam>
    /// <returns> Созданная ViewModel </returns>
    public delegate TViewModel CreateViewModel<TViewModel>() where TViewModel : BaseViewModel;
}
