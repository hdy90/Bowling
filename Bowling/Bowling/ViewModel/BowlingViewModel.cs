using Bowling.Commands;
using Bowling.Model;
using Bowling.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Bowling.ViewModel
{
    public class BowlingViewModel : INotifyPropertyChanged
    {
        private bool AlwaysTrue() { return true; }

        private List<PlayerResults> _playerResults;        
        public List<PlayerResults> PlayerResults 
        {
            get => _playerResults; 
            set { _playerResults = value; OnPropertyChanged("PlayerResults"); } 
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public ICommand GetData { get { return new RelayCommand(GetDataFromFile, AlwaysTrue); } }

        public BowlingViewModel()
        {
            _playerResults = new List<PlayerResults>();
        }

        private void GetDataFromFile()
        {
            ImportService.ImportData(_playerResults, "D:\\Programowanie\\Visual Studio\\Bowling\\seed.txt");
        }        

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
