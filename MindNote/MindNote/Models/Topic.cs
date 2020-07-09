using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Xml;
using Newtonsoft.Json;
using SQLite;

namespace MindNote.Models
{
    public class Topic
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Title { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string NoteString { get; set; }
        public DateTime Date { get; set; }

        [Ignore]
        public ObservableCollection<Note> Notes {
            get {
                if (NoteString == null)
                {
                    return new ObservableCollection<Note>();
                }
                Console.WriteLine("\n\n\n\n\n" + NoteString + "\n\n\n\n\n\n");
                var newList = JsonConvert.DeserializeObject<List<Note>>(NoteString,
                        new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Objects });

                if (newList != null)
                {
                    foreach (var note in newList)
                        {
                            Console.WriteLine(note.Text);
                        }
                    return new ObservableCollection<Note>(newList);
                }
                else
                {
                    return new ObservableCollection<Note>();
                }
            }
                
        }
    }
}
