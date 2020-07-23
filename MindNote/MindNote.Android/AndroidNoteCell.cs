using System.Threading.Tasks;
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
            SpannableStringBuilder ssb = new SpannableStringBuilder();
            

            //ContentText.Text = cell.Text;
            //ssb.Append(cell.Text);
            //ssb.SetSpan(new ImageSpan(context, Resource.Drawable.xamarin_logo), ssb.Length() - 1, ssb.Length(), 0);
            //ssb.Append(" POST TEXT");
            // Do layout stuff
            //string testString = "<h1>TestHeading</h1><p>This is some text with <a href=\"https://www.google.com\">link</a> included.</p>";
            ContentText.TextFormatted = HtmlCompat.FromHtml(cell.Text, HtmlCompat.FromHtmlModeLegacy);
            ContentText.MovementMethod = LinkMovementMethod.Instance;
            //ContentText.SetMovementMethod(LinkMovementMethod.getInstance());
            //ContentText.TextFormatted = ssb;
        }
    }
}