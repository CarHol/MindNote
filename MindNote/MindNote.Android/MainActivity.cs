using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Net;

namespace MindNote.Droid
{
    [Activity(Label = "MindNote", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, LaunchMode = LaunchMode.SingleTask, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    //[IntentFilter(new[] { Intent },
    //Categories = new[] { Intent.CategoryDefault },
    //DataScheme = "MindNote")]
    [IntentFilter(new string[] { "android.intent.action.VIEW", },
                  DataScheme = "mindnote",
                  Categories = new string[] { "android.intent.category.DEFAULT" })]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());

            // Handle deep link if present
            Android.Net.Uri data = Intent.Data;
            if (savedInstanceState == null && Intent?.Data != null)
            {
                OpenDeepLink(Intent.Data);
            }
        }


        protected override void OnNewIntent(Intent intent)
        {
            base.OnNewIntent(intent);

            if (intent?.Data != null)
            {
                OpenDeepLink(intent.Data);
            }
        }

        private void OpenDeepLink(Android.Net.Uri data)
        {
            ((App)App.Current).NavigateToTopic(data.PathSegments[0]);
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }


    }
}