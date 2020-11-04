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
        private string _newTitle;
        public string NewTitle
        {
            get { return _newTitle; }
            set
            {
                _newTitle = value;
                AddNewNote.ChangeCanExecute();
            }
        }

        private string _newNote;
        public string NewNote
        {
            get { return _newNote; }
            set
            {
                _newNote = value;
                AddNewNote.ChangeCanExecute();
            }
        }

        public ObservableCollection<Note> Notes { get; }

        public Command AddNewNote { private set; get; }
        public Command DiscardNewNote { private set; get; }
        public Command<Note> DeleteNote { private set; get; }


        public MainPageViewModel()
        {
            AddNewNote = new Command(OnAddNewNote, CanAddNewNote);
            DiscardNewNote = new Command(OnDiscardNewNote);
            DeleteNote = new Command<Note>(OnDeleteNote);

            NewTitle = "";
            NewNote = "";
            Notes = new ObservableCollection<Note>();

            // Setup sample data
            Notes.Add(new Note("Problems in Computer Science", "There are 2 hard problems in computer science: cache invalidation, naming things, and off-by-1 errors."));
            Notes.Add(new Note("One Identity System", "The goal should be to create one distributed identity system based on standards and open source technologies just as one internet exists today: Owned by anyone, used by everyone, and based on a self-sustainable ecosystem."));
            Notes.Add(new Note("UI Design", "A user interface is like a joke. If you have to explain it, it's not that good."));
            Notes.Add(new Note("Making Glass", "Basically anything that melts can be made into glass. You just have to cool off a molten material before its molecules have time to realign into what they were before being melted."));
            Notes.Add(new Note("Honey", "Honey does not spoil. You could feasibly eat 3000 year old honey."));
        }

        private void OnAddNewNote()
        {
            Notes.Insert(0, new Note(NewTitle.Trim(), NewNote.Trim()));
            NewTitle = "";
            NewNote = "";
        }

        private bool CanAddNewNote()
        {
            return !string.IsNullOrWhiteSpace(NewTitle) && !string.IsNullOrWhiteSpace(NewNote);
        }

        private void OnDiscardNewNote()
        {
            NewTitle = "";
            NewNote = "";
        }

        private void OnDeleteNote(Note note)
        {
            Notes.Remove(note);
        }
    }
}
