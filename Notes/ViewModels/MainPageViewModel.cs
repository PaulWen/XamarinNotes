using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using PropertyChanged;
using Xamarin.Forms;

namespace Notes
{
    [AddINotifyPropertyChangedInterface]
    public class MainPageViewModel
    {
        private string _newNotes;
        public string NewNote
        {
            get { return _newNotes; }
            set
            {
                _newNotes = value;
                AddNewNote.ChangeCanExecute();
            }
        }

        public ObservableCollection<Note> Notes { get; }

        public Command AddNewNote { protected set; get; }
        public Command DiscardNewNote { protected set; get; }
        public Command<Note> DeleteNote { protected set; get; }


        public MainPageViewModel()
        {
            AddNewNote = new Command(OnAddNewNote, HasNewNote);
            DiscardNewNote = new Command(OnDiscardNewNote);
            DeleteNote = new Command<Note>(OnDeleteNote);

            NewNote = "";
            Notes = new ObservableCollection<Note>();

            Notes.Add(new Note("Test"));
            Notes.Add(new Note("Test1"));
            Notes.Add(new Note("Test2"));
            Notes.Add(new Note("Test3"));
            Notes.Add(new Note("Test3"));

        }

        private void OnAddNewNote()
        {
            Notes.Add(new Note(NewNote.Trim()));
            NewNote = "";
        }

        private bool HasNewNote()
        {
            return !string.IsNullOrWhiteSpace(NewNote);
        }

        private void OnDiscardNewNote()
        {
            NewNote = "";
        }

        private void OnDeleteNote(Note note)
        {
            Notes.Remove(note);
        }

    }
}
