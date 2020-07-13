using MindNote.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MindNote.Models
{
    class MindNoteModel : IMindNoteModel
    {
        private NotesDatabase _db;

        // Constructor
        public MindNoteModel(string dbPath)
        {
            _db = new NotesDatabase(dbPath);
        }

        public Task DeleteNoteAsync(Note note)
        {
            return _db.DeleteNoteAsync(note);
        }

        public Task DeleteTopicAsync(Topic topic)
        {
            return _db.DeleteTopicAsync(topic);
        }

        public Task<Note> GetNoteAsync(int id)
        {
            return _db.GetNoteAsync(id);
        }

        public Task<List<Note>> GetNotesAsync()
        {
            return _db.GetNotesAsync();
        }

        public Task<List<Note>> GetNotesAsync(int topicId)
        {
            return _db.GetNotesAsync(topicId);
        }

        public Task<Topic> GetTopicAsync(int id)
        {
            return _db.GetTopicAsync(id);
        }

        public Task<List<Topic>> GetTopicsAsync()
        {
            return _db.GetTopicsAsync();
        }

        public Task SaveNoteAsync(Note note)
        {
            return _db.SaveNoteAsync(note);
        }

        public Task SaveTopicAsync(Topic topic)
        {
            return _db.SaveTopicAsync(topic);
        }
    }
}
