using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using ProductInspection.Commands;
using System.Windows.Input;
using ProductInspection.Services.Models;
using ProductInspection.Services;

namespace ProductInspection.ViewModel
{
    /// <summary>
    /// Модель основного экрана
    /// </summary>
    public class HomeViewModel : BaseViewModel
    {
        /// <summary>
        /// Список полученных продуктов
        /// </summary>
        public ObservableCollection<ProductReport> Products { get; set; } = new ObservableCollection<ProductReport>();
        
        /// <summary>
        /// Комманда обновления таблицы
        /// </summary>
        public GetActualIncomingProductsCommand GetActualIncomingProductsCommand { get; }

        public HomeViewModel(IProductsService service)
        {
            GetActualIncomingProductsCommand = new GetActualIncomingProductsCommand(Products,service);
        }
    }
}
