﻿using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.Support.V4.Text;
using Android.Text;
using Android.Text.Method;
using Android.Text.Style;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using MindNote;
using MindNote.Droid;
//using MindNote.Droid.Movement;
using System.Collections.Generic;

namespace MindNote.Droid
{
    internal class AndroidNoteCell : LinearLayout, INativeElementView
    {
        // Fields
        public NoteCell NoteCell { get; private set; }
        public Element Element => NoteCell;
        Context context;

        // Elements
        public TextView ContentText { get; set; }
        // Constructor
        public AndroidNoteCell(Context context, NoteCell cell) : base(context)
        {
            NoteCell = cell;
            this.context = context;

            var view = (context as Activity).LayoutInflater.Inflate(Resource.Layout.AndroidNoteCell, null);
            ContentText = view.FindViewById<TextView>(Resource.Id.ContentText);
            
            AddView(view);
        }

        public void UpdateCell(NoteCell cell)
        {
            
            ContentText.TextFormatted = HtmlCompat.FromHtml(cell.Text, HtmlCompat.FromHtmlModeLegacy);
            ContentText.MovementMethod = LinkMovementMethod.Instance;
        }

    }
}