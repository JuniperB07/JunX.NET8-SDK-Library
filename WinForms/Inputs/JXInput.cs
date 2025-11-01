using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JunX.NET8.WinForms.Inputs
{
    /// <summary>
    /// Provides a unified interface for displaying modal input dialogs and retrieving user input in various formats.
    /// </summary>
    /// <remarks>
    /// The <c>JXInput</c> class centralizes input collection through stylized modal dialogs, supporting text, combo box, date/time, and numeric input modes.
    /// Each <c>Show</c> method blocks execution until the user responds, returning the input value or a default fallback.
    /// Internally, the result is stored in a shared <c>result</c> property and interpreted based on the expected return type.
    /// </remarks>
    public class JXInput
    {
        internal static object? result { get; set; }

        /// <summary>
        /// Displays a modal text input dialog with a specified prompt, caption, and optional default value.
        /// </summary>
        /// <param name="Text">The prompt or instruction displayed to the user.</param>
        /// <param name="Caption">The title of the input dialog window.</param>
        /// <param name="Value">An optional default value to pre-fill the input field.</param>
        /// <returns>
        /// The user's input as a trimmed <see cref="string"/> if provided; otherwise, an empty string.
        /// Returns <c>null</c> only if the internal result is explicitly set to <c>null</c> and not converted.
        /// </returns>
        /// <remarks>
        /// This method blocks execution until the user confirms or cancels the dialog. The result is retrieved from a shared static field
        /// and returned as a string if it contains non-whitespace content. Empty or whitespace-only input returns an empty string.
        /// </remarks>
        public static string? Show(string Text, string Caption, string Value = "")
        {
            InputBox IB = new InputBox(Text, Caption, Value);
            IB.ShowDialog();

            return !string.IsNullOrWhiteSpace(result?.ToString()) ? result.ToString() : "";
        }

        /// <summary>
        /// Displays a modal combo box input dialog with a specified prompt, caption, default value, and optional item list.
        /// </summary>
        /// <param name="Text">The prompt or instruction displayed to the user.</param>
        /// <param name="Caption">The title of the input dialog window.</param>
        /// <param name="Value">An optional default value to pre-select in the combo box.</param>
        /// <param name="Items">An optional collection of string items to populate the combo box.</param>
        /// <returns>
        /// The user's selected input as a trimmed <see cref="string"/> if provided; otherwise, an empty string.
        /// </returns>
        /// <remarks>
        /// This method blocks execution until the user confirms or cancels the dialog. The result is retrieved from a shared static field
        /// and returned as a string if it contains non-whitespace content. Empty or whitespace-only input returns an empty string.
        /// </remarks>
        public static string? Show(string Text, string Caption, string Value = "", IEnumerable<string>? Items = null)
        {
            InputCMB ICMB = new InputCMB(Text, Caption, Value, Items);
            ICMB.ShowDialog();

            return !string.IsNullOrWhiteSpace(result?.ToString()) ? result.ToString() : "";
        }

        /// <summary>
        /// Displays a modal date/time picker dialog with a specified prompt, caption, default value, and optional date constraints.
        /// </summary>
        /// <param name="Text">The prompt or instruction displayed to the user.</param>
        /// <param name="Caption">The title of the input dialog window.</param>
        /// <param name="Value">An optional default value to pre-select in the date picker.</param>
        /// <param name="MinDate">An optional minimum date that restricts the earliest selectable value.</param>
        /// <param name="MaxDate">An optional maximum date that restricts the latest selectable value.</param>
        /// <returns>
        /// The user's selected <see cref="DateTime"/> value if valid; otherwise, <see cref="DateTime.MinValue"/>.
        /// </returns>
        /// <remarks>
        /// This method blocks execution until the user confirms or cancels the dialog. The result is retrieved from a shared static field
        /// and parsed as a <see cref="DateTime"/>. If parsing fails or the input is empty, <see cref="DateTime.MinValue"/> is returned.
        /// </remarks>
        public static DateTime Show(string Text, string Caption, DateTime? Value = null, DateTime? MinDate = null, DateTime? MaxDate = null)
        {
            InputDTP IDTP = new InputDTP(Text, Caption, Value, MinDate, MaxDate);
            IDTP.ShowDialog();

            return
                !string.IsNullOrWhiteSpace(result?.ToString())
                ? DateTime.TryParse(result?.ToString(), out DateTime parsed)
                    ? parsed
                    : DateTime.MinValue
                : DateTime.MinValue;
        }

        /// <summary>
        /// Displays a modal numeric input dialog with a specified prompt, caption, default value, and optional numeric constraints.
        /// </summary>
        /// <param name="Text">The prompt or instruction displayed to the user.</param>
        /// <param name="Caption">The title of the input dialog window.</param>
        /// <param name="Value">An optional default value to pre-fill the numeric input field.</param>
        /// <param name="Minimum">An optional minimum value that restricts the lowest allowed input.</param>
        /// <param name="Maximum">An optional maximum value that restricts the highest allowed input.</param>
        /// <param name="Increment">An optional increment value that defines the step size for adjustment.</param>
        /// <returns>
        /// The user's input converted to <see cref="decimal"/> if provided; otherwise, <c>0</c>.
        /// </returns>
        /// <remarks>
        /// This method blocks execution until the user confirms or cancels the dialog. The result is retrieved from a shared static field
        /// and converted to <see cref="decimal"/>. If the result is <c>null</c>, the method returns <c>0</c> as a fallback.
        /// </remarks>
        public static decimal? Show(string Text, string Caption, decimal? Value = null, decimal? Minimum = null, decimal? Maximum = null, decimal? Increment = null)
        {
            InputNUD INUD = new InputNUD(Text, Caption, Value, Minimum, Maximum, Increment);
            INUD.ShowDialog();

            return result != null
                ? Convert.ToDecimal(result)
                : 0;
        }
    }
}
