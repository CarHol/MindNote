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
        ObservableCollection<Note> notes = new ObservableCollection<Note>();
        public ObservableCollection<Note> Notes { get { return notes; } }
        public CellPage()
        {
            InitializeComponent();
            
        }

        // TODO: Add items properly: https://stackoverflow.com/questions/43841962/how-to-add-list-items-to-a-listview-in-cwinform
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var topic = (Topic)BindingContext;
            //Title = topic.Title;
            //notes = topic.Notes;
            /*foreach (var note in notes)
            {
                Console.WriteLine(note.Text);
            }
            */

            //NoteView.ItemsSource = notes;
            NoteView.HasUnevenRows = true;

        }
    }


}