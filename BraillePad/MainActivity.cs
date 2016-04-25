using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using BraillePad.Core;

namespace BraillePad
{
    [Activity(Label = "BraillePad", MainLauncher = true, Icon = "@drawable/icon", Name = "com.davidwhitney.braillepad")]
    public class MainActivity : Activity
    {
        private Converter _conv;
        public Button Button => FindViewById<Button>(Resource.Id.MyButton);
        public EditText Source => FindViewById<EditText>(Resource.Id.editText1);
        public EditText Target => FindViewById<EditText>(Resource.Id.editText2);

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            _conv = new Converter();
            Button.Click += (sender, args) => Target.Text = _conv.Convert(Source.Text).ToString();

        }
    }
}

