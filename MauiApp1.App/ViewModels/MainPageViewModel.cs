using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MauiApp1.App.ViewModels
{
    internal class MainPageViewModel : ContentPage, INotifyPropertyChanged
    {
        public MainPageViewModel()
        {
            AllNotes = new ObservableCollection<string>();
        }

        public ObservableCollection<string> AllNotes { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        string theNote;

        public string TheNote
        {
            get => theNote;
            set
            {
                theNote = value;
                var args = new PropertyChangedEventArgs(nameof(TheNote));

                PropertyChanged?.Invoke(this, args);
            }
        }

        public Command SaveCommand => new Command(() =>
        {
            AllNotes.Add(TheNote);

            TheNote = string.Empty;
        });

        public Command EraseCommand => new Command(() =>
        {
            TheNote = string.Empty;
        });
    }
}
