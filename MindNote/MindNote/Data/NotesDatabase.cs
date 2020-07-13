using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using MindNote.Models;
using System.Threading.Tasks;

namespace MindNote.Data
{
    public class NotesDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public NotesDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Topic>().Wait();
            _database.CreateTableAsync<Note>().Wait();
        }

        public Task<List<Topic>> GetTopicsAsync()
        {
            return _database.Table<Topic>().ToListAsync();
        }

        public Task<List<Note>> GetNotesAsync()
        {
            return _database.Table<Note>().ToListAsync();
        }

        public Task<List<Note>> GetNotesAsync(int topicId)
        {
            return _database.Table<Note>()
                .Where(i => i.TopicID == topicId)
                .ToListAsync();
        }

        public Task<Topic> GetTopicAsync(int id)
        {
            return _database.Table<Topic>()
                .Where(i => i.ID == id)
                .FirstOrDefaultAsync();
        }

        public Task<Note> GetNoteAsync(int id)
        {
            return _database.Table<Note>()
                .Where(i => i.ID == id)
                .FirstOrDefaultAsync();
        }

        public Task<int> SaveTopicAsync(Topic topic)
        {
            if (topic.ID != 0)
            {
                return _database.UpdateAsync(topic);
            }
            else
            {
                return _database.InsertAsync(topic);
            }
        }

        public Task<int> SaveNoteAsync(Note note)
        {
            if (note.ID != 0)
            {
                return _database.UpdateAsync(note);
            }
            else
            {
                return _database.InsertAsync(note);
            }
        }

        public Task<int> DeleteTopicAsync(Topic topic)
        {
            return _database.DeleteAsync(topic);
        }

        public Task<int> DeleteNoteAsync(Note note)
        {
            return _database.DeleteAsync(note);
        }
    }
}
