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
            Console.WriteLine("INCOMING INTENT");
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
            Android.Net.Uri data = Intent.Data;
            if (savedInstanceState == null && Intent?.Data != null)
            {
                OpenDeepLink(Intent.Data);
            }
        }


        protected override void OnNewIntent(Intent intent)
        {
            Console.WriteLine("NEW INTENT WOOOW");
            base.OnNewIntent(intent);

            if (intent?.Data != null)
            {
                OpenDeepLink(intent.Data);
            }
        }

        private async void OpenDeepLink(Android.Net.Uri data)
        {
            Console.WriteLine("NEW DEEP LINK: " + data.PathSegments[0]);
            ((App)App.Current).NavigateToTopic(data.PathSegments[0]);
           /*
            ((App)App.Current).NavigationService.NavigateByPushAsync("HomeModule/UrlDisplayPageView", true, () =>
            {
                Messenger.Default.Send(new SendUrlMessage() { Url = "http://cms.leoncountyfl.gov/eitest/index.asp?type=mapp", Name = "Critical Updates" });
            });
            */
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }


    }
}