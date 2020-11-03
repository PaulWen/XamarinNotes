using System;
using Notes;
using NUnit.Framework;

namespace Notes.UnitTests.ViewModels
{
    [TestFixture]
    public class MainPageViewModelTest
    {
        private MainPageViewModel ViewModel;

        [SetUp]
        public void BeforeEachTest()
        {
            ViewModel = new MainPageViewModel();
        }

        [Test]
        public void AddNewNoteOnAddButtonClicked()
        {
            ViewModel.NewNote = "New Note";
            int initialNumberofNotes = ViewModel.Notes.Count;

            ViewModel.AddNewNote.Execute(null);

            Assert.AreEqual(initialNumberofNotes + 1, ViewModel.Notes.Count);
        }

        [Test]
        public void DiscardNewNoteOnDiscardButtonClicked()
        {
            ViewModel.NewNote = "New Note";

            ViewModel.DiscardNewNote.Execute(null);

            Assert.IsEmpty(ViewModel.NewNote);
        }

        [Test]
        public void DeleteNoteOnDeleteButtonClicked()
        {
            Note note = new Note("Test Note");
            ViewModel.Notes.Add(note);

            ViewModel.DeleteNote.Execute(note);

            Assert.IsFalse(ViewModel.Notes.Contains(note));
        }
    }
}
