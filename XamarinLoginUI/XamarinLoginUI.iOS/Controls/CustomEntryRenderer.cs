﻿using CoreAnimation;
using CoreGraphics;
using System;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XamarinLoginUI.Controls;
using XamarinLoginUI.iOS.Controls;

[assembly: ExportRenderer(typeof(EntryControl), typeof(CustomEntryRenderer))]
namespace XamarinLoginUI.iOS.Controls
{
    public class CustomEntryRenderer : EntryRenderer
    {
        private CALayer _underlineColor;
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            _underlineColor = null;

            if (e.NewElement != null)
            {
                var view = (EntryControl)Element;

                Control.LeftView = new UIView(new CGRect(0f, 0f, 9f, 20f));
                Control.LeftViewMode = UITextFieldViewMode.Always;

                Control.KeyboardAppearance = UIKeyboardAppearance.Dark;
                Control.ReturnKeyType = UIReturnKeyType.Done;
                // Radius for the curves  
                Control.Layer.CornerRadius = Convert.ToSingle(view.CornerRadius);
                // Thickness of the Border Color  
                Control.Layer.BorderColor = view.BorderColor.ToCGColor();
                // Thickness of the Border Width  
                Control.Layer.BorderWidth = view.BorderWidth;
                Control.ClipsToBounds = true;

                if (!view.HideUnderline)
                {
                    Control.BorderStyle = UITextBorderStyle.None;
                    Control.Layer.CornerRadius = 10;
                    Control.TextColor = UIColor.White;
                }

                _underlineColor = new CALayer
                {
                    BorderColor = view.UnderlineColor.ToCGColor(),
                    BackgroundColor = view.UnderlineColor.ToCGColor(),
                    Frame = new CGRect(0, Frame.Height / 2, Frame.Width * 2, 1f)
                };

                Control.Layer.AddSublayer(_underlineColor);
            }
        }
    }
}