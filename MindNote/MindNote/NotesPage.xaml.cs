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
        private IMindNoteModel model;
        public NotesPage(IMindNoteModel model)
        {
            InitializeComponent();
            this.model = model;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await model.GetTopicsAsync();
        }

        async void OnTopicAddedTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TopicEntryPage(model)
            {
                BindingContext = new Topic()
            });
        }

        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                var topic = e.SelectedItem as Topic;
                try
                {
                    await Navigation.PushAsync(new CellPage(model)
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

    }
}