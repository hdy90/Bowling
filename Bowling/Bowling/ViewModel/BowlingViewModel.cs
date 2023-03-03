using Bowling.Commands;
using Bowling.Model;
using Bowling.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private ObservableCollection<PlayerResults> _playerResults;        
        public ObservableCollection<PlayerResults> PlayerResults 
        {
            get => _playerResults; 
            set { _playerResults = value; OnPropertyChanged("PlayerResults"); } 
        }

        private string _filePath;
        public string FilePath
        {
            get => _filePath; 
            set { _filePath = value; OnPropertyChanged("FilePath"); }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public ICommand GetData { get { return new RelayCommand(GetDataFromFile, AlwaysTrue); } }
        public ICommand PickFile { get { return new RelayCommand(PickFileDialog, AlwaysTrue); } }


        public BowlingViewModel()
        {
            _playerResults = new ObservableCollection<PlayerResults>();
            _filePath = "Ścieżka do pliku";
        }

        private void GetDataFromFile()
        {            
            ImportService.ImportData(_playerResults, _filePath);            
        }  
        
        private void PickFileDialog()
        { 
            var dialog = new Microsoft.Win32.OpenFileDialog();            
            dialog.DefaultExt = ".txt";
            dialog.Filter = "Text documents (.txt)|*.txt";
            bool? result = dialog.ShowDialog();
            if (result == true)
            {
                FilePath = dialog.FileName;
                //FilePath = dialog.FileName;                
            }
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
