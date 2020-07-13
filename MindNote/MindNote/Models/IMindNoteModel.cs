using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MindNote.Models
{
    public interface IMindNoteModel
    {
        Task<List<Note>> GetNotesAsync();
        Task<List<Note>> GetNotesAsync(int topicId);
        Task<List<Topic>> GetTopicsAsync();
        Task<Note> GetNoteAsync(int id);
        Task<Topic> GetTopicAsync(int id);
        Task SaveTopicAsync(Topic topic);
        Task SaveNoteAsync(Note note);
        Task DeleteNoteAsync(Note note);
        Task DeleteTopicAsync(Topic topic);
    }
}
