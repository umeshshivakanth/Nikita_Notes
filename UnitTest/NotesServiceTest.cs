using Moq;
using NUnit.Framework;
using NotesApplication.Models;
using NotesApplication.Repositories;
using NotesApplication.Services;
using System;
using System.Collections.Generic;

namespace UnitTest
{
    public  class NotesServiceTest
    {

        private Mock<INoteRepository> _repoMock;
        private NoteService _service;

        [SetUp]
        public void Setup()
        {
            _repoMock = new Mock<INoteRepository>();
            _service = new NoteService(_repoMock.Object);
        }

        [Test]
        public void GetAllNotes_ShouldReturnAllNotes()
        {
            
            var notes = new List<Note>
            {
                new Note { Id = 1, Title = "Note1" },
                new Note { Id = 2, Title = "Note2" }
            };
            _repoMock.Setup(r => r.GetAll()).Returns(notes);

          
            var result = _service.GetAllNotes();

   
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual("Note1", result[0].Title);
        }

        [Test]
        public void GetNote_ShouldReturnCorrectNote()
        {
            var note = new Note { Id = 1, Title = "Test Note" };
            _repoMock.Setup(r => r.GetById(1)).Returns(note);

            var result = _service.GetNote(1);

            Assert.IsNotNull(result);
            Assert.AreEqual("Test Note", result.Title);
        }


        [Test]
        public void UpdateNote_ShouldCallRepositoryUpdate()
        {
            var note = new Note { Id = 1, Title = "Updated Note" };

            _service.UpdateNote(note);

            _repoMock.Verify(r => r.Update(note), Times.Once);
        }

        [Test]
        public void DeleteNote_ShouldCallRepositoryDelete()
        {
            var noteId = 1;

            _service.DeleteNote(noteId);

            _repoMock.Verify(r => r.Delete(noteId), Times.Once);
        }

    }
}
