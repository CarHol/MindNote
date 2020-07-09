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
        }

        public Task<List<Topic>> GetNotesAsync()
        {
            return _database.Table<Topic>().ToListAsync();
        }

        public Task<Topic> GetNoteAsync(int id)
        {
            return _database.Table<Topic>()
                .Where(i => i.ID == id)
                .FirstOrDefaultAsync();
        }

        public Task<int> SaveNoteAsync(Topic topic)
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

        public Task<int> DeleteNoteAsync(Topic topic)
        {
            return _database.DeleteAsync(topic);
        }
    }
}
