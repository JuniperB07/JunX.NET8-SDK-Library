using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.Windows.Forms;
using Syncfusion.Windows.Forms.Tools;
using Syncfusion.Windows.Forms.Chart;
using Syncfusion.Windows.Forms.Grid;
using Syncfusion.Windows.Forms.Schedule;
using Syncfusion.Windows.Forms.Tools.Controls.StatusBar;
using Syncfusion.Windows.Forms.Tools.MultiColumnTreeView;
using Syncfusion.Windows.Forms.Tools.XPMenus;
using Syncfusion.WinForms.Controls;
using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataPager;
using Syncfusion.WinForms.Input;
using Syncfusion.WinForms.ListView;

namespace JunX.NET8.Syncfusion
{
    /// <summary>
    /// Provides additional functionality in manipulating <c>Syncfusion Controls</c>.
    /// </summary>
    public partial class SFusion
    {
        #region ComboBoxAdv Operations
        /// <summary>
        /// Clears the item collections of a set of <see cref="ComboBoxAdv"/> controls.
        /// </summary>
        /// <param name="ComboBoxAdvs">The collection of <see cref="ComboBoxAdv"/> controls to clear.</param>
        /// <remarks>
        /// Removes all items from each <c><see cref="ComboBoxAdv.Items"/></c> collection in the provided set.
        /// Useful for resetting dropdowns during form initialization, dynamic filtering, or state transitions.
        /// Ensure the collection is non-null and that each ComboBox is properly initialized before calling.
        /// </remarks>
        public static void ClearComboBoxAdvs(IEnumerable<ComboBoxAdv> ComboBoxAdvs)
        {
            foreach (ComboBoxAdv cmba in ComboBoxAdvs)
                cmba.Items.Clear(); 
        }
        /// <summary>
        /// Populates a <see cref="ComboBoxAdv"/> with a collection of string items.
        /// </summary>
        /// <param name="ComboBoxAdv">The <see cref="ComboBoxAdv"/> control to populate.</param>
        /// <param name="Items">The collection of string items to add.</param>
        /// <remarks>
        /// Clears existing items and adds each string from the provided collection to the <c><see cref="ComboBoxAdv.Items"/></c>.
        /// Useful for dynamic dropdown population based on user input, data sources, or application state.
        /// Ensure the <see cref="ComboBoxAdv"/> is initialized and the item collection is non-null before calling.
        /// </remarks>
        public static void FillComboBoxAdv(ComboBoxAdv ComboBoxAdv, IEnumerable<string> Items)
        {
            ComboBoxAdv.Items.Clear();
            foreach (string item in Items)
                ComboBoxAdv.Items.Add(item);
        }
        /// <summary>
        /// Populates multiple <see cref="ComboBoxAdv"/> controls with corresponding collections of string items.
        /// </summary>
        /// <param name="ComboBoxAdvs">The collection of <see cref="ComboBoxAdv"/> controls to populate.</param>
        /// <param name="ItemsArray">
        /// A collection of item collections, where each inner <c>IEnumerable&lt;string&gt;</c> corresponds to one <see cref="ComboBoxAdv"/>.
        /// </param>
        /// <remarks>
        /// Clears all ComboBoxes before populating them. Each <see cref="ComboBoxAdv"/> receives the item set at the matching index in <paramref name="ItemsArray"/>.
        /// Useful for dynamic form initialization, multi-field filtering, or metadata-driven dropdown population.
        /// Ensure both collections are non-null and aligned in length to avoid index mismatches.
        /// Future overloads may support value/display pairs, object binding, or filtered population.
        /// </remarks>
        public static void FillComboBoxAdvs(IEnumerable<ComboBoxAdv> ComboBoxAdvs, IEnumerable<IEnumerable<string>> ItemsArray)
        {
            int index = 0;
            ComboBoxAdv[] cmbArray = ComboBoxAdvs.ToArray();
            ClearComboBoxAdvs(cmbArray);

            foreach (IEnumerable<string> Items in ItemsArray)
            {
                foreach (string Item in Items)
                    cmbArray[index].Items.Add(Item);
                index++;
            }
        }
        /// <summary>
        /// Appends a collection of string items to an existing <see cref="ComboBoxAdv"/> without clearing its current contents.
        /// </summary>
        /// <param name="ComboBoxAdv">The <see cref="ComboBoxAdv"/> control to append items to.</param>
        /// <param name="Items">The collection of string items to add.</param>
        /// <remarks>
        /// Adds each string from the provided collection to the <c><see cref="ComboBoxAdv.Items"/></c> list.
        /// Unlike <c><see cref="FillComboBoxAdv(ComboBoxAdv, IEnumerable{string})"/></c>, this method preserves existing items and performs a non-destructive update.
        /// Useful for incremental population, dynamic filtering, or merging multiple data sources.
        /// Ensure the ComboBox is initialized and the item collection is non-null before calling.
        /// Future overloads may support object binding, display/value pairs, or duplicate filtering.
        /// </remarks>
        public static void AppendComboBoxAdv(ComboBoxAdv ComboBoxAdv, IEnumerable<string> Items)
        {
            foreach (string Item in Items)
                ComboBoxAdv.Items.Add(Item);
        }
        /// <summary>
        /// Appends collections of string items to multiple <see cref="ComboBoxAdv"/> controls without clearing existing contents.
        /// </summary>
        /// <param name="ComboBoxAdvs">The collection of <see cref="ComboBoxAdv"/> controls to append items to.</param>
        /// <param name="ItemsArray">
        /// A collection of item collections, where each inner <c>IEnumerable&lt;string&gt;</c> corresponds to one <see cref="ComboBoxAdv"/>.
        /// </param>
        /// <remarks>
        /// Adds each string from the corresponding item set to the matching ComboBox at the same index.
        /// Unlike <see cref="FillComboBoxAdvs(IEnumerable{ComboBoxAdv}, IEnumerable{IEnumerable{string}})"/>, this method preserves existing items and performs a non-destructive update.
        /// Useful for incremental population, merging data sources, or dynamic UI updates across multiple dropdowns.
        /// Ensure both collections are non-null and aligned in length to avoid index mismatches.
        /// Future overloads may support object binding, display/value pairs, or duplicate filtering.
        /// </remarks>
        public static void AppendComboBoxAdvs(IEnumerable<ComboBoxAdv> ComboBoxAdvs, IEnumerable<IEnumerable<string>> ItemsArray)
        {
            int index = 0;

            foreach (IEnumerable<string> Items in ItemsArray)
            {
                foreach (string Item in Items)
                    ComboBoxAdvs.ElementAt(index).Items.Add(Item);
                index++;
            }
        }
        /// <summary>
        /// Removes one or more specified items from the item collections of multiple <see cref="ComboBoxAdv"/> controls.
        /// </summary>
        /// <param name="ComboBoxAdvs">An enumerable collection of <see cref="ComboBoxAdv"/> controls to process.</param>
        /// <param name="Item">A parameter array of items to remove from each <see cref="ComboBoxAdv"/> if present.</param>
        /// <remarks>
        /// This method iterates through each <see cref="ComboBoxAdv"/> in the provided collection and attempts to remove each specified item
        /// from the control's <see cref="ComboBoxBaseDataBound.ObjectCollection"/>. Items that are not found are silently ignored.
        /// </remarks>
        public static void RemoveItem(IEnumerable<ComboBoxAdv> ComboBoxAdvs, params object[] Item)
        {
            foreach (ComboBoxAdv cmb in ComboBoxAdvs)
            {
                foreach (object i in Item)
                    if (cmb.Items.Contains(i))
                        cmb.Items.Remove(i);
            }
        }
        /// <summary>
        /// Removes one or more specified items from the <see cref="ComboBoxAdv"/> control.
        /// </summary>
        /// <param name="ComboBoxAdv">The <see cref="ComboBoxAdv"/> control from which items will be removed.</param>
        /// <param name="Item">An array of items to remove from the control.</param>
        public static void RemoveItem(ComboBoxAdv ComboBoxAdv, params object[] Item)
        {
            foreach (object i in Item)
            {
                ComboBoxAdv.Items.Remove(i);
            }
        }
        #endregion

        #region DateTimePickerAdv Operations
        /// <summary>
        /// Sets the maximum selectable date for a collection of <see cref="DateTimePickerAdv"/> controls.
        /// </summary>
        /// <param name="DTPAs">The collection of <see cref="DateTimePickerAdv"/> controls to update.</param>
        /// <param name="MaxValue">The maximum date to apply to each control.</param>
        /// <remarks>
        /// Updates the <c><see cref="DateTimePickerAdv.MaxValue"/></c> property of each <see cref="DateTimePickerAdv"/> in the collection.
        /// Useful for enforcing date constraints across multiple inputs, such as limiting future selections or aligning with business rules.
        /// Ensure the collection is non-null and that each control is properly initialized before calling.
        /// </remarks>
        public static void SetMaxValue(IEnumerable<DateTimePickerAdv> DTPAs, DateTime MaxValue)
        {
            foreach (DateTimePickerAdv dtp in DTPAs)
                dtp.MaxValue = MaxValue;
        }
        /// <summary>
        /// Sets the minimum selectable date for a collection of <see cref="DateTimePickerAdv"/> controls.
        /// </summary>
        /// <param name="DTPAs">The collection of <see cref="DateTimePickerAdv"/> controls to update.</param>
        /// <param name="MinValue">The minimum date to apply to each control.</param>
        /// <remarks>
        /// Updates the <c><see cref="DateTimePickerAdv.MinValue"/></c> property of each <see cref="DateTimePickerAdv"/> in the collection.
        /// Useful for enforcing date constraints across multiple inputs, such as limiting past selections or aligning with business rules.
        /// Ensure the collection is non-null and that each control is properly initialized before calling.
        /// </remarks>
        public static void SetMinValue(IEnumerable<DateTimePickerAdv> DTPAs, DateTime MinValue)
        {
            foreach (DateTimePickerAdv dtp in DTPAs)
                dtp.MinValue = MinValue;
        }
        /// <summary>
        /// Sets the display format for a collection of <see cref="DateTimePickerAdv"/> controls.
        /// </summary>
        /// <param name="DTPAs">The collection of <see cref="DateTimePickerAdv"/> controls to update.</param>
        /// <param name="Format">The <see cref="DateTimePickerFormat"/> value to apply to each control.</param>
        /// <remarks>
        /// Updates the <c><see cref="DateTimePickerAdv.Format"/></c> property of each <see cref="DateTimePickerAdv"/> in the collection to the specified format.
        /// Useful for enforcing consistent date/time presentation across grouped controls, especially in forms, reports, or region-specific UIs.
        /// Ensure the collection is non-null and that each control is properly initialized before calling.
        /// </remarks>
        public static void SetFormat(IEnumerable<DateTimePickerAdv> DTPAs, DateTimePickerFormat Format)
        {
            foreach (DateTimePickerAdv dtp in DTPAs)
                dtp.Format = Format;
        }
        /// <summary>
        /// Sets the selected date and time for a collection of <see cref="DateTimePickerAdv"/> controls.
        /// </summary>
        /// <param name="DTPAs">The collection of <see cref="DateTimePickerAdv"/> controls to update.</param>
        /// <param name="Value">The <see cref="DateTime"/> value to assign to each control.</param>
        /// <remarks>
        /// Updates the <c><see cref="DateTimePickerAdv.Value"/></c> property of each <see cref="DateTimePickerAdv"/> in the collection to the specified <see cref="DateTime"/>.
        /// Useful for initializing default timestamps, synchronizing form inputs, or applying consistent date values across grouped controls.
        /// Ensure the collection is non-null and that each control is properly initialized and within its valid range before calling.
        /// </remarks>
        public static void SetValue(IEnumerable<DateTimePickerAdv> DTPAs, DateTime Value)
        {
            foreach (DateTimePickerAdv dtp in DTPAs)
                dtp.Value = Value;
        }
        /// <summary>
        /// Sets a custom date and time format for a collection of <see cref="DateTimePickerAdv"/> controls.
        /// </summary>
        /// <param name="DTPAs">The collection of <see cref="DateTimePickerAdv"/> controls to update.</param>
        /// <param name="CustomFormat">The custom format string to apply to each control.</param>
        /// <exception cref="FormatException">
        /// Thrown when the format string is invalid or cannot be applied to one or more controls.
        /// </exception>
        /// <remarks>
        /// Updates the <c><see cref="DateTimePickerAdv.CustomFormat"/></c> property of each <see cref="DateTimePickerAdv"/> in the collection to the specified format string.
        /// Useful for applying localized, domain-specific, or user-defined date/time formats across grouped controls.
        /// Ensure the format string is valid and compatible with the control's current <c><see cref="DateTimePickerAdv.Format"/></c> setting (typically <c><see cref="DateTimePickerFormat.Custom"/></c>).
        /// </remarks>
        public static void SetCustomFormat(IEnumerable<DateTimePickerAdv> DTPAs, string CustomFormat)
        {
            try
            {
                foreach (DateTimePickerAdv dtp in DTPAs)
                    dtp.CustomFormat = CustomFormat;
            }
            catch (FormatException fe)
            {
                throw new FormatException(fe.Message.ToString());
            }
        }
        /// <summary>
        /// Configures a <see cref="DateTimePickerAdv"/> control with minimum and maximum date boundaries, and optionally sets its initial value.
        /// </summary>
        /// <param name="DTPA">The <see cref="DateTimePickerAdv"/> control to configure.</param>
        /// <param name="MinValue">The earliest selectable date.</param>
        /// <param name="MaxValue">The latest selectable date.</param>
        /// <param name="Value">An optional initial value to assign to the control.</param>
        public static void Setup(DateTimePickerAdv DTPA, DateTime MinValue, DateTime MaxValue, DateTime? Value = null)
        {
            DTPA.MinValue = MinValue;
            DTPA.MaxValue = MaxValue;

            if (Value != null)
                DTPA.Value = Value.Value;
        }
        /// <summary>
        /// Configures a collection of <see cref="DateTimePickerAdv"/> controls with minimum and maximum date boundaries, and optionally sets their initial values.
        /// </summary>
        /// <param name="DTPAs">The collection of <see cref="DateTimePickerAdv"/> controls to configure.</param>
        /// <param name="MinValue">The earliest selectable date for each control.</param>
        /// <param name="MaxValue">The latest selectable date for each control.</param>
        /// <param name="Value">An optional initial value to assign to each control.</param>
        public static void Setup(IEnumerable<DateTimePickerAdv> DTPAs, DateTime MinValue, DateTime MaxValue, DateTime? Value = null)
        {
            foreach (DateTimePickerAdv dtp in DTPAs)
            {
                dtp.MinValue = MinValue;
                dtp.MaxValue = MaxValue;

                if (Value != null)
                    dtp.Value = Value.Value;
            }
        }
        #endregion
    }
}
