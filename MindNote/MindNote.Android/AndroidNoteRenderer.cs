
using System;
using System.ComponentModel;
using Android.Content;
using Android.Views;
using Android.Widget;
using MindNote;
using MindNote.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(NoteCell), typeof(AndroidNoteRenderer))]
namespace MindNote.Droid
{
    class AndroidNoteRenderer : ViewCellRenderer
    {
        AndroidNoteCell cell;

        protected override Android.Views.View GetCellCore(Cell item, Android.Views.View convertView, ViewGroup parent, Context context)
        {
            var noteCell = (NoteCell)item;
            Console.WriteLine("\t\t" + noteCell.Text);

            cell = convertView as AndroidNoteCell;
            if (cell == null)
            {
                cell = new AndroidNoteCell(context, noteCell);
            }
            else
            {
                cell.NoteCell.PropertyChanged += OnNoteCellProprtyChanged;
            }

            noteCell.PropertyChanged += OnNoteCellProprtyChanged;
            cell.LongClickable = true;
            cell.LongClick += (s, ea) =>
            {
                if (noteCell != null)
                {
                    noteCell.LongPressedHandler?.Invoke(noteCell, ea);
                    var command = noteCell.LongpressCommand;// CustomImage.GetCommand(_view);  
                    command?.Execute(noteCell);

                }
            };
            cell.UpdateCell(noteCell);
            return cell;
        }

        void OnNoteCellProprtyChanged(object sender, PropertyChangedEventArgs e)
        {
            var noteCell = (NoteCell)sender;
            if (e.PropertyName == NoteCell.TextProperty.PropertyName)
            {
                cell.ContentText.Text = noteCell.Text;
            }

        }


    }
}