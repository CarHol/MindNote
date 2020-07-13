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
    public partial class NoteEntryPage : ContentPage
    {
        private IMindNoteModel model;

        public NoteEntryPage(IMindNoteModel model)
        {
            InitializeComponent();
            this.model = model;
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var note = (Note)BindingContext;

            note.Date = DateTime.UtcNow;
            await model.SaveNoteAsync(note);

            await Navigation.PopAsync();
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var note = (Note)BindingContext;
            await model.DeleteNoteAsync(note);
            await Navigation.PopAsync();
        }
    }
}