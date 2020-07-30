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
        Context context;
        View view;
        #endregion

        #region Constructors
        public AsyncHtmlImageGetter(View view, Context context)
        {
            this.context    = context;
            this.view       = view;
        }
        #endregion

        #region Interface implementations
        public Drawable GetDrawable(string source)
        {

            URLDrawable drawable = new URLDrawable();

            ImageGetterAsyncTask asyncTask = new ImageGetterAsyncTask(drawable, this);
            asyncTask.Execute(source);

            return drawable;
        }
        #endregion

        #region Tasks
        public class ImageGetterAsyncTask : AsyncTask
        {
            URLDrawable urlDrawable;
            AsyncHtmlImageGetter getter;

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
                getter.view.Invalidate();

                getter.view.SetMinimumHeight(getter.view.Height + drawable.IntrinsicHeight);

            }

            private Drawable FetchDrawable(string urlString)
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

            private Stream Fetch(string urlString)
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