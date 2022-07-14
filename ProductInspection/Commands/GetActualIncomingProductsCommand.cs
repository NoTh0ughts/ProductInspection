using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductInspection.MVVM.ViewModel;
using ProductInspection.Services;
using ProductInspection.Services.Models;

namespace ProductInspection.Commands
{
    /// <summary>
    /// Выполняет получение актуальных продуктов и обновляет таблицу
    /// </summary>
    public class GetActualIncomingProductsCommand : BaseCommand
    {
        /// <summary>
        /// Ссылка на отображаемую коллекцию продуктов
        /// </summary>
        public ObservableCollection<ProductReport> Result { get; set; }

        /// <summary>
        /// Сервис взаимодействия с источниками данных
        /// </summary>
        public IProductsService Service { get; }

        public GetActualIncomingProductsCommand(ObservableCollection<ProductReport> result,
                                                IProductsService service)
        {
            Result = result;
            Service = service;
        }


        public override void Execute(object parameter)
        {
            // Обновляем таблицу удаляя устаревшие данные
            Result.Clear();

            // И заносим актуальные
            foreach (var product in Service.GetIcomingProducts())
            {
                Result.Add(product);
            }
        }
    }
}
