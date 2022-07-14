using ProductInspection.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductInspection.Controls
{
    /// <summary>
    /// Интерфейс объектов, отслеживающих и реализующих смену ViewModel
    /// </summary>
    public interface INavigationStore
    {
        /// <summary>
        /// Активная ViewModel
        /// </summary>
        BaseViewModel CurrentViewModel { get; set; }

        /// <summary>
        /// Событие смены ViewModel
        /// </summary>
        event Action CurrentViewModelChanged;
    }
}
