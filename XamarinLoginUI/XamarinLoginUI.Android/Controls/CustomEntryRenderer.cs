using Android.Content;
using Android.Content.Res;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Text;
using Android.Util;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XamarinLoginUI.Controls;
using XamarinLoginUI.Droid.Controls;

[assembly: ExportRenderer(typeof(EntryControl), typeof(CustomEntryRenderer))]
namespace XamarinLoginUI.Droid.Controls
{
    public class CustomEntryRenderer : EntryRenderer
    {
        public CustomEntryRenderer(Context context) : base(context)
        { }
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
            {
                var view = (EntryControl)Element;
                if (view.IsCurvedCornersEnabled)
                {
                    // creating gradient drawable for the curved background  
                    var _gradientBackground = new GradientDrawable();
                    _gradientBackground.SetShape(ShapeType.Rectangle);
                    _gradientBackground.SetColor(view.BackgroundColor.ToAndroid());

                    // Thickness of the stroke line  
                    _gradientBackground.SetStroke(view.BorderWidth, view.BorderColor.ToAndroid());

                    // Radius for the curves  
                    _gradientBackground.SetCornerRadius(
                        DpToPixels(this.Context, Convert.ToSingle(view.CornerRadius)));

                    // set the background of the   
                    Control.SetBackground(_gradientBackground);

                    // Set padding for the internal text from border  
                    Control.SetPadding(
                        (int)DpToPixels(this.Context, Convert.ToSingle(12)), Control.PaddingTop,
                        (int)DpToPixels(this.Context, Convert.ToSingle(12)), Control.PaddingBottom);
                }

                if (view.HideUnderline)
                {
                    //GradientDrawable gd = new GradientDrawable();
                    //gd.SetColor(global::Android.Graphics.Color.Transparent);
                    this.Control.SetBackgroundColor(global::Android.Graphics.Color.Transparent);
                    this.Control.SetRawInputType(InputTypes.TextFlagNoSuggestions);
                    //Control.SetHintTextColor(ColorStateList.ValueOf(global::Android.Graphics.Color.Transparent));
                }

                Control.BackgroundTintList = ColorStateList.ValueOf(view.UnderlineColor.ToAndroid());
                /*if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
                    Control.BackgroundTintList = ColorStateList.ValueOf(view.UnderlineColor.ToAndroid());
                else
                    Control.Background.SetColorFilter(Color.White, PorterDuff.Mode.SrcAtop);*/

            }
        }
        public static float DpToPixels(Context context, float valueInDp)
        {
            DisplayMetrics metrics = context.Resources.DisplayMetrics;
            return TypedValue.ApplyDimension(ComplexUnitType.Dip, valueInDp, metrics);
        }
    }
}