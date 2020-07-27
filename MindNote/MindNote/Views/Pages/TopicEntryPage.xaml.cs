using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MindNote.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MindNote
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TopicEntryPage : ContentPage
    {
        private IMindNoteModel model;
        public TopicEntryPage(IMindNoteModel model)
        {
            InitializeComponent();
            this.model = model;
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var topic = (Topic)BindingContext;

            topic.Date = DateTime.UtcNow;
            await model.SaveTopicAsync(topic);

            await Navigation.PopAsync();
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var topic = (Topic)BindingContext;

            string[] texts = new string[]{ "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo",
                "TEXT2",
                "Text3",
                "Text4" };
            List<Note> notes = new List<Note>();
            foreach (var text in texts)
            {
                notes.Add(new Note() { Text = text });
            }
            var textlist = new ObservableCollection<Note>(notes);
            //topic.Notes = textlist;

            await App.Database.DeleteTopicAsync(topic);
            await Navigation.PopAsync();
        }
    }
}