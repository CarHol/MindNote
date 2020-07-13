using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;
namespace MindNote.Models
{
    [Table("note")]
    public class Note
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [ForeignKey(typeof(Topic))]
        public int TopicID { get; set; } 
        public string Text { get; set; } = "";
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
