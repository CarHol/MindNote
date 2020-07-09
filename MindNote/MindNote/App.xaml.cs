using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MindNote.Services;
using SQLite;
using System.IO;
using MindNote.Data;

namespace MindNote
{
    public partial class App : Application
    {

        static NotesDatabase database;

        public static NotesDatabase Database {
            get {
                if (database == null)
                {
                    database = new NotesDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Topics2.db3"));
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();
            
            MainPage = new NavigationPage(new NotesPage());
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
    }
}
