using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MindNote.Services;
using SQLite;
using System.IO;
using MindNote.Data;
using MindNote.Models;

namespace MindNote
{
    public partial class App : Application
    {

        static NotesDatabase database;
        static IMindNoteModel model;

        public static NotesDatabase Database {
            get {
                if (database == null)
                {
                    database = new NotesDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Topics2.db3"));
                }
                return database;
            }
        }

        public static IMindNoteModel Model {
            get {
                if (database == null)
                {
                    model = new MindNoteModel(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Topics2.db3"));
                }
                return model;
            }
        }

        public object NavigationService { get; set; }

        public App()
        {
            InitializeComponent();
            
            MainPage = new NavigationPage(new NotesPage(Model));
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        public async void NavigateToTopic(string topicName)
        {
            Topic topic = model.GetTopicAsync(topicName).Result;
            if (topic != null && topic.Title.Equals(topicName))
            {
                await MainPage.Navigation.PushAsync(new CellPage(model)
                {
                    BindingContext = topic
                });
            }
        }

        
    }
}
