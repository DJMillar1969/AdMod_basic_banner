using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms.Platform.Android;
using Android.Gms.Ads;
using Xamarin.Forms;
using AdMod_basic_banner.Controls;
using AdMod_basic_banner.Droid.Helpers;


[assembly: ExportRenderer(typeof(AdMod_basic_banner.Controls.AdControlView), typeof(AdMod_basic_banner.Droid.Helpers.AdViewRenderer))]
namespace AdMod_basic_banner.Droid.Helpers
{
    
    public class AdViewRenderer : ViewRenderer<Controls.AdControlView, AdView>
	{
		public AdViewRenderer(Context context) : base(context) { }

		protected override void OnElementChanged(ElementChangedEventArgs<AdControlView> e)
		{
			base.OnElementChanged(e);

			if (e.NewElement != null && Control == null)
				SetNativeControl(CreateAdView());
		}

		protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);

			if (e.PropertyName == nameof(AdView.AdUnitId))
				Control.AdUnitId = "ca-app-pub-3940256099942544/6300978111";
		}

		private AdView CreateAdView()
		{
			var adView = new AdView(Context)
			{
				AdSize = AdSize.Banner,
				AdUnitId = "ca-app-pub-3940256099942544/6300978111"
		};

			adView.LayoutParameters = new LinearLayout.LayoutParams(LayoutParams.MatchParent, LayoutParams.MatchParent);

			adView.LoadAd(new AdRequest.Builder().Build());

			return adView;
		}
	}
}