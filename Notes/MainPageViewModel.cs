using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace Notes
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private string _newNotes;
        public string NewNote
        {
            get { return _newNotes; }
            set
            {
                _newNotes = value;
                AddNote.ChangeCanExecute();
            }
        }

        public ObservableCollection<Note> Notes { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        public Command AddNote { protected set; get; }
        public Command DiscardNote { protected set; get; }


        public MainPageViewModel()
        {
            AddNote = new Command(AddNewNote, CanAddNewNote);

            NewNote = "";
            Notes = new ObservableCollection<Note>();


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


        private void AddNewNote()
        {
            Notes.Add(new Note(NewNote.Trim()));
            NewNote = "";
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NewNote"));
        }

        private bool CanAddNewNote()
        {
            return !string.IsNullOrWhiteSpace(NewNote);
        }
    }
}
