using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Xml;
using Newtonsoft.Json;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace MindNote.Models
{
    [Table("topic")]
    public class Topic
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }

        [OneToMany]
        public List<Note> Notes { get; set; } = new List<Note>();
    }
}
