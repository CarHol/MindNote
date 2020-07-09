using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xamarin.Forms;
using MindNote.Models;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;

namespace MindNote
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotesPage : ContentPage
    {
        public NotesPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            Console.WriteLine("Test");
            listView.ItemsSource = await App.Database.GetNotesAsync();
        }

        async void OnNoteAddedClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NoteEntryPage
            {
                BindingContext = new Topic()
            });
        }

        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                /*
                await Navigation.PushAsync(new NoteEntryPage
                {
                    BindingContext = e.SelectedItem as Topic
                });
                */

                /*await Navigation.PushAsync(new CellPage()
                    {
                        BindingContext = e.SelectedItem as Topic
                    }
                );
                */

                var topic = e.SelectedItem as Topic;
                for (int i = 0; i < 50; i++)
                {
                    Console.WriteLine("TEST");
                }
                /*
                foreach (var note in topic.Notes)
                {
                    if (note != null) Console.WriteLine(note.Text);
                };
                */
                try
                {
                    await Navigation.PushAsync(new CellPage()
                        {
                            BindingContext = topic as Topic
                        }
                    );
                }
                catch (Exception ex)
                {
                    Console.Write(ex.ToString());
                }
                
                

            }
        }

        async void OnLayoutTestSelected(object sender, EventArgs e)
        {
            string[] texts = new string[]{ "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo",
                "Text2",
                "Text3",
                "Text4" };
            List<Note> notes = new List<Note>();
            foreach (var text in texts)
            {
                notes.Add(new Note() { Text = text });
            }
            

            var textlist = new ObservableCollection<Note>(notes);
            var testTopic = new Topic()
            {
                //Notes = textlist
            };

            await Navigation.PushAsync(new CellPage()
                {
                    BindingContext = testTopic
                }
            );
        }
    }
}