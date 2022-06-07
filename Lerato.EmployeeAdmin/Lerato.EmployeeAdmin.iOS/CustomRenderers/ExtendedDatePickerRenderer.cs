using System.ComponentModel;
using Lerato.EmployeeAdmin.CustomControls;
using Lerato.EmployeeAdmin.iOS.CustomRenderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ExtendedDatePicker), typeof(ExtendedDatePickerRenderer))]
namespace Lerato.EmployeeAdmin.iOS.CustomRenderers
{
    public sealed class ExtendedDatePickerRenderer : DatePickerRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.DatePicker> e)
        {
            base.OnElementChanged(e);

            var view = Element as ExtendedDatePicker;

            if (view != null)
            {
                SetFont(view);
                SetTextAlignment(view);
                SetNullableText(view);
                SetPlaceholder(view);
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            var view = (ExtendedDatePicker)Element;

            if (e.PropertyName == ExtendedDatePicker.FontProperty.PropertyName)
            {
                SetFont(view);
            }
            else if (e.PropertyName == ExtendedDatePicker.XAlignProperty.PropertyName)
            {
                SetTextAlignment(view);
            }
            else if (e.PropertyName == ExtendedDatePicker.NullableDateProperty.PropertyName)
            {
                SetNullableText(view);
            }
            else if (e.PropertyName == ExtendedDatePicker.PlaceholderProperty.PropertyName)
            {
                SetPlaceholder(view);
            }
        }

        private void SetTextAlignment(ExtendedDatePicker view)
        {
            switch (view.XAlign)
            {
                case TextAlignment.Center:
                    Control.TextAlignment = UITextAlignment.Center;
                    break;
                case TextAlignment.End:
                    Control.TextAlignment = UITextAlignment.Right;
                    break;
                case TextAlignment.Start:
                    Control.TextAlignment = UITextAlignment.Left;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Sets the font.
        /// </summary>
        /// <param name="view">The view.</param>
        private void SetFont(ExtendedDatePicker view)
        {
            if (view.Font != Font.Default)
            {
                Control.Font = view.Font.ToUIFont();
            }
        }

        /// <summary>
        /// Set text based on nullable value
        /// </summary>
        /// <param name="view"></param>
        private void SetNullableText(ExtendedDatePicker view)
        {
            if (view.NullableDate == null)
            {
                Control.Text = string.Empty;
            }
        }

        /// <summary>
        /// Set the placeholder
        /// </summary>
        /// <param name="view"></param>
        private void SetPlaceholder(ExtendedDatePicker view)
        {
            if (string.IsNullOrEmpty(Control.Text))
            {
                Control.Text = view.Placeholder;
            }
        }
    }
}