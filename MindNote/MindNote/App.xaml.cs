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

        static IMindNoteModel model;

        public static IMindNoteModel Model {
            get {
                if (model == null)
                {
                    var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MindNote.db3");
                    model = new MindNoteModel(dbPath);
                }
                return model;
            }
        }


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

        // TODO: Handle case when linked topic does not exist
        public async void NavigateToTopic(string topicName)
        {
            Topic topic = await model.GetTopicAsync(topicName);
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
