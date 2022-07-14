using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using ProductInspection.Services.Models;

namespace ProductInspection.Services
{
    /// <summary>
    /// Сервис по умолчанию для работы с данными через базу данных sqlServer
    /// </summary>
    public class DatabaseProductsService : IProductsService
    {
        /// <summary>
        /// Конфигурация БД
        /// </summary>
        private readonly DatabaseConfigurationModel dbConfig;
        public DatabaseProductsService(DatabaseConfigurationModel dbConfig)
        {
            this.dbConfig = dbConfig;
        }

        /// <summary>
        /// Возвращает список продуктов
        /// Правила отбора элементов:
        ///     1. Выбираются фактические поступления сырья, которые произошли после 24.12.2014
        ///     2. Выбираются данные с единицами измерения "Тонна"
        ///     3. И группа продуктов - 122
        /// </summary>
        /// <returns> Полученный список </returns>
        public List<ProductReport> GetIcomingProducts()
        {
            List<ProductReport> result = new List<ProductReport>();

            string connectionString = "Data Source=DESKTOP-OVT6BC6;Initial Catalog=test-eae;Integrated Security=True";
            string req = @"select FULLNAME, KSSSUNIT, DATETIMEFIXED from FACTLOAD
                                join FACTSOURCE on FACTLOAD.IDFACTLOAD = FACTSOURCE.IDFACTLOAD
                                join LPRODUCT on LPRODUCT.KSSSPROD = FACTSOURCE.KSSSPROD
                            where IDPRODUCTGROUP = 5 and KSSSUNIT = 122 and DATEDIFF(day, '2014-12-24', DATELOAD) > 0
                            order by FULLNAME, DATETIMEFIXED DESC; ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(req, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(new ProductReport
                            {
                                Fullname = reader.GetValue(0).ToString(),
                                KSSSUNIT = reader.GetValue(1).ToString(),
                                DateTime = DateTime.Parse(reader.GetValue(2).ToString())
                            });
                        }
                    }
                }
                connection.Close();
            }


            return result;
        }
    }
}
