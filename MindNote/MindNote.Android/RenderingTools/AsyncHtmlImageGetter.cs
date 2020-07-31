using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.Net.Http;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.IO;
using Java.Lang;
using Java.Net;
using Org.Apache.Http;
using Org.Apache.Http.Client.Methods;
using Org.Apache.Http.Impl.Client;
using static Android.Text.Html;

namespace MindNote.Droid.RenderingTools
{
    /// <summary>
    /// An asynchronous image getter for online image sources. The solution is a C# port of the methods suggested 
    /// by Michael Spector here: https://stackoverflow.com/a/6343299/13540302
    /// </summary>
    class AsyncHtmlImageGetter : Java.Lang.Object, IImageGetter
    {
        #region Fields
        Context Context { get; set; }
        View View { get; set; }
        #endregion

        #region Constructors
        public AsyncHtmlImageGetter(View view, Context context)
        {
            Context    = context;
            View       = view;
        }
        #endregion

        #region Interface implementations
        public Drawable GetDrawable(string source)
        {
            // Target drawable object to be udpated once the data has been fetched asynchronously
            URLDrawable drawable = new URLDrawable();

            // Fetch the image asynchronously and load into drawable when done
            ImageGetterAsyncTask asyncTask = new ImageGetterAsyncTask(drawable, this);
            asyncTask.Execute(source);

            // Return Drawable object which will be updated once the async task finishes
            return drawable;
        }
        #endregion

        #region Tasks
        /// <summary>
        /// Helper class to fetch image data in the background
        /// </summary>
        protected class ImageGetterAsyncTask : AsyncTask
        {
            private URLDrawable urlDrawable;
            private AsyncHtmlImageGetter getter;

            public ImageGetterAsyncTask(URLDrawable urlDrawable, AsyncHtmlImageGetter getter)
            {
                this.urlDrawable = urlDrawable;
                this.getter = getter;
            }
            protected override Java.Lang.Object DoInBackground(params Java.Lang.Object[] @params)
            {
                string source = (string)@params[0];
                return FetchDrawable(source);
            }

            protected override void OnPostExecute(Java.Lang.Object result)
            {
                Drawable drawable = (Drawable)result;
                urlDrawable.SetBounds(0, 0, 0 + drawable.IntrinsicWidth * 10, 0 + drawable.IntrinsicHeight * 10);
                urlDrawable.drawable = drawable;
                getter.View.Invalidate();

                getter.View.SetMinimumHeight(getter.View.Height + drawable.IntrinsicHeight);

            }

            protected Drawable FetchDrawable(string urlString)
            {
                try
                {
                    Stream stream = Fetch(urlString);
                    Drawable drawable = Drawable.CreateFromStream(stream, "src");
                    drawable.SetBounds(0, 0, 0 + drawable.IntrinsicWidth * 10, 0 + drawable.IntrinsicHeight * 10);
                    return drawable;
                }
                catch (System.Exception e)
                {
                    System.Console.WriteLine(e.StackTrace);
                    return null;
                }
            }

            protected Stream Fetch(string urlString)
            {
                URL url = new URL(urlString);
                HttpURLConnection urlConnection = (HttpURLConnection)url.OpenConnection();
                var stream = urlConnection.InputStream;

                return stream;
            }
        }
        #endregion

    }
}