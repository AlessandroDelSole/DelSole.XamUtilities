using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DelSole.XamUtilities.Behaviors
{
    /// <summary>
    /// Validate an Entry and highlights in red the placeholder if 
    /// it is empty
    /// </summary>
    public class FieldEmptyValidatorBehavior : BaseValidatorBehavior<Entry>
    {
        protected override void OnAttachedTo(Entry bindable)
        {
            bindable.TextChanged += HandleTextChanged;
            if (Validation.ValidationErrors == null) Validation.ValidationErrors = new Dictionary<object, string>();
            // TextChanged isn't raised at first time, so manually adding an error
            if (bindable.IsVisible == true)
                Validation.ValidationErrors.Add(bindable, "Field cannot be empty");
            else
            {
                if (Validation.ValidationErrors.Keys.Contains(bindable)) Validation.ValidationErrors.Remove(bindable);
            }
        }

        /// <summary>
        /// Perform the validation logic
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void HandleTextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                IsValid = !string.IsNullOrWhiteSpace(e.NewTextValue);
                var entry = (Entry)sender;
                if (IsValid)
                {
                    entry.PlaceholderColor = Color.Default;
                    entry.Placeholder = "";
                    if (Validation.ValidationErrors.Keys.Contains(sender))
                    {
                        Validation.ValidationErrors.Remove(sender);
                    }
                    return;
                }
                else
                {
                    entry.PlaceholderColor = Color.Red;
                    entry.Placeholder = "Field cannot be empty";
                    if (Validation.ValidationErrors.Keys.Contains(sender))
                    {
                        return;
                    }
                    else
                    {
                        Validation.ValidationErrors.Add(sender, "Field cannot be empty");
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            bindable.TextChanged -= HandleTextChanged;
        }
    }
}
