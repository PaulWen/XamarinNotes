using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Notes
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public List<Note> Notes { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        public MainPageViewModel()
        {
            Notes = new List<Note>();
            Notes.Add(new Note("Test"));
            Notes.Add(new Note("Test1"));
            Notes.Add(new Note("Test2"));
            Notes.Add(new Note("Test3"));
            Notes.Add(new Note("Test3"));

        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
