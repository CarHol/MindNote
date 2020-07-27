using MindNote.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MindNote
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CellPage : ContentPage
    {
        //ObservableCollection<Note> notes = new ObservableCollection<Note>();
        //public ObservableCollection<Note> Notes { get { return notes; } }
        private IMindNoteModel model;
        public CellPage(IMindNoteModel model)
        {
            InitializeComponent();
            this.model = model;
            
        }

        // TODO: Add items properly: https://stackoverflow.com/questions/43841962/how-to-add-list-items-to-a-listview-in-cwinform
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var topic = (Topic)BindingContext;
            Title = topic.Title;
            var notes = await model.GetNotesAsync(topic.ID);
            /*foreach (var note in notes)
            {
                Console.WriteLine(note.Text);
            }
            */

            NoteView.ItemsSource = notes;
            NoteView.HasUnevenRows = true;

        }

        protected async void OnNoteAddTapped(object sender, EventArgs e)
        {
            var topic = (Topic)BindingContext;
            await Navigation.PushAsync(new NoteEntryPage(model)
            {
                BindingContext = new Note()
                {
                    TopicID = topic.ID
                }
            });
        }

        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {

                var note = e.SelectedItem as Note;
                try
                {
                    await Navigation.PushAsync(new NoteEntryPage(model)
                    {
                        BindingContext = note as Note
                    }
                    );
                }
                catch (Exception ex)
                {
                    Console.Write(ex.ToString());
                }
            }
        }

        async void NoteCell_LongPressed(object sender, EventArgs e)
        {
            if (sender != null && ((NoteCell)sender).Text.Length > 0)
            {
                
                var noteCell = (sender) as NoteCell;
                var note = noteCell.BindingContext as Note;
                try
                {
                    await Navigation.PushAsync(new NoteEntryPage(model)
                    {
                        BindingContext = note
                    }
                    );
                }
                catch (Exception ex)
                {
                    Console.Write(ex.ToString());
                }
            }
        }



    }


}