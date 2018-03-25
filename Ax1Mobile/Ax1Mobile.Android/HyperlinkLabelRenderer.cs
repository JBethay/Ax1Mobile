using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Text.Util;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Ax1Mobile.Droid;
using Ax1Mobile;

[assembly: ExportRenderer(typeof(HyperlinkLabel), typeof(HyperlinkLabelRenderer))]
namespace Ax1Mobile.Droid
{
#pragma warning disable CS0618 // Type or member is obsolete
    public class HyperlinkLabelRenderer: LabelRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            Linkify.AddLinks(Control, MatchOptions.All);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete
}