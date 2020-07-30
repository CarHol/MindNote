using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace MindNote.Droid.RenderingTools
{
    class URLDrawable : BitmapDrawable
    {
        public Drawable drawable { get; set; } = null;

        public override void Draw(Canvas canvas)
        {
            if (drawable != null)
            {
                drawable.Draw(canvas);
            }
        }
    }
}