using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using FamousKiwisApp.ViewModels;

namespace FamousKiwisApp.Commands
{
    class GetAllKiwisCommand : ICommand
    {
        public AllKiwisCollection vm;

        public GetAllKiwisCommand(AllKiwisCollection vm)
        {
            this.vm = vm;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            MessageBox.Show("EXECUTE ALL KIWIS");
        }

        public event EventHandler CanExecuteChanged
        {

            add
            {

                CommandManager.RequerySuggested += value;
            }
            remove
            {

                CommandManager.RequerySuggested -= value;
            }
        }
    }
}
