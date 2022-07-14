using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProductInspection.Commands
{
    /// <summary>
    /// Задает поведение команд программы
    /// С помощью производных классов отделяется логика работы кнопок и переходов 
    /// от реализации ViewModel
    /// </summary>
    public abstract class BaseCommand : ICommand
    {
        /// <summary>
        /// Событие изменения состояния возможности активации
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Может ли выполнена команда с заданым параметром
        /// </summary>
        /// <param name="parameter"> аргумент команды </param>
        /// <returns> результат проверки </returns>
        public virtual bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Выполнить команду
        /// </summary>
        /// <param name="parameter"> аргумент команды </param>
        public abstract void Execute(object parameter);

        protected void OnCanExecutedChanged()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }
    }
}
