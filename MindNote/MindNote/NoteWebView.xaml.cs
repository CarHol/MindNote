using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace MindNote
{
    public partial class NoteWebView : ContentPage
    {
        public NoteWebView()
        {
            InitializeComponent();
            var htmlSource = new HtmlWebViewSource();
            htmlSource.Html = "<html><body style=\"margin:0;\"><h1>Xamarin.Forms</h1><p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce nibh urna, commodo quis vulputate ut, fermentum et felis. Mauris vestibulum turpis convallis posuere mollis. Nullam malesuada neque non elit rhoncus, sed mattis massa ultrices. Fusce nec efficitur massa. Ut nec sollicitudin libero, non tincidunt diam. Vivamus at dui arcu. Aenean dictum, risus vitae vehicula porttitor, est sapien tristique arcu, at lacinia tellus nulla ac urna. Vivamus et faucibus metus. Donec metus nibh, pulvinar sed turpis vel, vestibulum tincidunt purus. Vestibulum tincidunt lorem ut neque vulputate, ac ornare sem dictum.</p><p>Nullam non velit consectetur, gravida eros ut, volutpat metus. Vestibulum ultrices fermentum justo, ut consequat elit. Integer imperdiet lectus diam, a laoreet dolor convallis dignissim. Fusce vitae erat mi. Morbi urna sem, pharetra nec suscipit vitae, elementum in diam. In gravida ornare augue, ac commodo massa finibus ac. Donec porta ante velit, porta sodales ligula scelerisque pulvinar. Sed ultricies vehicula vulputate. Sed vel accumsan diam, a semper urna. Nulla tempor quis quam ac sodales. Etiam eget odio eget felis mattis dignissim. Quisque lacinia lacinia posuere. Mauris eu placerat arcu.</p></body></html>";
            webView.Source = htmlSource;
        }
    }
}
