using Markdig;
using MindNote.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MindNote
{
    public partial class NoteWebView : ContentPage
    {
        private IMindNoteModel model;

        public NoteWebView(IMindNoteModel model)
        {
            InitializeComponent();
            this.model = model;
            var htmlSource = new HtmlWebViewSource();
            var result = Markdown.ToHtml("# A Header \n\nThis is a text with some *emphasis*");
            //htmlSource.Html = "<html><body style=\"margin:0;\"><h1>Xamarin.Forms</h1><p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce nibh urna, commodo quis vulputate ut, fermentum et felis. Mauris vestibulum turpis convallis posuere mollis. Nullam malesuada neque non elit rhoncus, sed mattis massa ultrices. Fusce nec efficitur massa. Ut nec sollicitudin libero, non tincidunt diam. Vivamus at dui arcu. Aenean dictum, risus vitae vehicula porttitor, est sapien tristique arcu, at lacinia tellus nulla ac urna. Vivamus et faucibus metus. Donec metus nibh, pulvinar sed turpis vel, vestibulum tincidunt purus. Vestibulum tincidunt lorem ut neque vulputate, ac ornare sem dictum.</p><p>Nullam non velit consectetur, gravida eros ut, volutpat metus. Vestibulum ultrices fermentum justo, ut consequat elit. Integer imperdiet lectus diam, a laoreet dolor convallis dignissim. Fusce vitae erat mi. Morbi urna sem, pharetra nec suscipit vitae, elementum in diam. In gravida ornare augue, ac commodo massa finibus ac. Donec porta ante velit, porta sodales ligula scelerisque pulvinar. Sed ultricies vehicula vulputate. Sed vel accumsan diam, a semper urna. Nulla tempor quis quam ac sodales. Etiam eget odio eget felis mattis dignissim. Quisque lacinia lacinia posuere. Mauris eu placerat arcu.</p></body></html>";
            htmlSource.Html = $"<html><body>{result}</body></html>";
            webView.Source = htmlSource;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var topic = (Topic)BindingContext;
            Title = topic.Title;
            var notes = await model.GetNotesAsync(topic.ID);
            string styleString = @"
                .noteDiv {
                    border-style: sold green;
                }
                div {
                    border-style: solid;
                    border-color: green;
                }
            ";
            var htmlNotes = ParseNotes(notes);
            var htmlString = ConcatenateNotes(htmlNotes);
            var htmlSource = new HtmlWebViewSource();
            //var result = Markdown.ToHtml("# A Header \n\nThis is a text with some *emphasis*");
            htmlSource.Html = $"<html><head><style>{styleString}</style></head><body>{htmlString}</body></html>";
            webView.Source = htmlSource;
        }

        private List<HtmlNote> ParseNotes(List<Note> notes)
        {
            List<HtmlNote> htmlNotes = new List<HtmlNote>();
            foreach (var note in notes)
            {
                htmlNotes.Add(item: new HtmlNote(note));
            }

            return htmlNotes;
        }

        private string ConcatenateNotes(List<HtmlNote> notes)
        {
            StringBuilder strBuild = new StringBuilder();
            foreach (var note in notes)
            {
                strBuild.Append(note.HtmlText);
            }
            var htmlDivs = strBuild.ToString();

            return $"<div id=parentDiv>{htmlDivs}</div>";
        }

        protected class HtmlNote
        {
            private string NoteDivClassName = "noteDiv";
            // Note from which to generate markdown HTML
            Note BaseNote { get; set; }
            // Generated HTML
            public string HtmlText {
                get {
                    string parsed = Markdown.ToHtml(BaseNote.Text);
                    Console.WriteLine(parsed);
                    return $"<div class={NoteDivClassName} id={BaseNote.ID}>{parsed}</div>";
                }
            }

            // Constructor
            public HtmlNote(Note note)
            {
                this.BaseNote = note;
            }
        }


    }

}
