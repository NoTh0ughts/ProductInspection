using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductInspection.ViewModel.Factory
{
    /// <summary>
    /// Тип модели
    /// 1. При добавлении новых ViewModel тут добавить ее название 
    /// 2. Далее добавить в контейнер зависимостей делегат ее создания и сам тип ViewModel
    /// 3. Вызвать фабричный делегат в <see cref="ViewModelFactory"/> для создания ViewModel
    /// 4. PROFIT!
    /// </summary>
    public enum ViewModelType
    {
        Main
    }

    /// <summary>
    /// Реализовывает работу по созданию новых объектов моделей представления
    /// </summary>
    internal class ViewModelFactory : IViewModelFactory
    {
        //Тут должны быть делегаты полученные из конструктора
        private readonly CreateViewModel<HomeViewModel> _createHomeViewModel;

        public ViewModelFactory(CreateViewModel<HomeViewModel> createHomeViewModel)
        {
            _createHomeViewModel = createHomeViewModel;
        }

        /// <summary>
        /// Создает ViewModel согласно указанному типу
        /// </summary>
        /// <param name="viewType"> Тип модели представления </param>
        /// <returns> Созданная ViewModel </returns>
        /// <exception cref="NotImplementedException"> Неизвестный тип к созданию </exception>
        public BaseViewModel CreateViewModel(ViewModelType viewType)
        {
            switch (viewType)
            {
                case ViewModelType.Main:
                    return _createHomeViewModel();
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
