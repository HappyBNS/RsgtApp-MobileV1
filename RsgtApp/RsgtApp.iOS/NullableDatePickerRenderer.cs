﻿using System;
using System.Collections.Generic;
using UIKit;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using Date1.iOS;
using System.ComponentModel;

[assembly: ExportRenderer(typeof(Date1.Controls.NullableDatePicker), typeof(NullableDatePickerRenderer))]
namespace Date1.iOS
{
    public class NullableDatePickerRenderer : DatePickerRenderer
    {

        protected override void OnElementChanged(ElementChangedEventArgs<DatePicker> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null && this.Control != null)
            {
                this.AddClearButton();

                this.Control.BorderStyle = UITextBorderStyle.Line;
                Control.Layer.BorderColor = UIColor.LightGray.CGColor;
                Control.Layer.BorderWidth = 1;

                var entry = (Date1.Controls.NullableDatePicker)this.Element; // Added on 20220801
                                                                             //var entry = (NullableDatePicker.Controls.NullableDatePicker)this.Element; // Commented on 20220801
                if (!entry.NullableDate.HasValue)
                {
                    this.Control.Text = entry.PlaceHolder;
                }

                if (Device.Idiom == TargetIdiom.Tablet)
                {
                    this.Control.Font = UIFont.SystemFontOfSize(25);
                }
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == Xamarin.Forms.DatePicker.DateProperty.PropertyName || e.PropertyName == Xamarin.Forms.DatePicker.FormatProperty.PropertyName)
            {
                //var entry = (NullableDatePicker.Controls.NullableDatePicker)this.Element; // Commented on 20220801
                var entry = (Date1.Controls.NullableDatePicker)this.Element;   // Added on 20220801

                // If we are updating the format to the placeholder then just update the text and return
                if (this.Element.Format == entry.PlaceHolder)
                {
                    this.Control.Text = entry.PlaceHolder;
                    return;
                }
            }

            base.OnElementPropertyChanged(sender, e);
        }



        private void AddClearButton()
        {
            var originalToolbar = this.Control.InputAccessoryView as UIToolbar;

            if (originalToolbar != null && originalToolbar.Items.Length <= 2)
            {
                var clearButton = new UIBarButtonItem("Clear", UIBarButtonItemStyle.Plain, ((sender, ev) =>
                {
                    //NullableDatePicker.Controls.NullableDatePicker baseDatePicker = this.Element as NullableDatePicker.Controls.NullableDatePicker;
                    Date1.Controls.NullableDatePicker baseDatePicker = this.Element as Date1.Controls.NullableDatePicker;
                    this.Element.Unfocus();
                    this.Element.Date = DateTime.Now;
                    baseDatePicker.CleanDate();

                }));

                var newItems = new List<UIBarButtonItem>();
                foreach (var item in originalToolbar.Items)
                {
                    newItems.Add(item);
                }

                newItems.Insert(0, clearButton);

                originalToolbar.Items = newItems.ToArray();
                originalToolbar.SetNeedsDisplay();
            }

        }








	}
}