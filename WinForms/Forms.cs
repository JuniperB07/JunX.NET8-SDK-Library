using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JunX.NET8.WinForms
{
    /// <summary>
    /// Provides additional functionality in manipulating <c>System.Windows.Forms Controls</c>.
    /// </summary>
    public static class Forms
    {
        /// <summary>
        /// Enables or disables a collection of WinForms controls.
        /// </summary>
        /// <param name="Controls">The collection of controls to update.</param>
        /// <param name="IsEnabled">True to enable the controls; false to disable them.</param>
        /// <remarks>
        /// Applies the specified enabled state to each control in the collection.
        /// Useful for toggling interactivity during form workflows, such as loading states or permission checks.
        /// Defensive usage is recommended: ensure the collection is non-null and contains initialized controls.
        /// </remarks>
        public static void SetEnabled(IEnumerable<Control> Controls, bool IsEnabled)
        {
            foreach(Control C in Controls)
                C.Enabled = IsEnabled;
        }
        /// <summary>
        /// Sets the background color of a collection of WinForms controls.
        /// </summary>
        /// <param name="Controls">The collection of controls to update.</param>
        /// <param name="BackColor">The background color to apply to each control.</param>
        /// <remarks>
        /// Applies the specified background color to each control in the collection.
        /// Useful for theming, highlighting, or dynamically adjusting UI appearance based on application state.
        /// Ensure the collection is non-null and that controls are initialized before calling.
        /// </remarks>
        public static void SetBackColor(IEnumerable<Control> Controls, Color BackColor)
        {
            foreach(Control C in Controls)
                C.BackColor = BackColor;
        }
        /// <summary>
        /// Sets the foreground color of a collection of WinForms controls.
        /// </summary>
        /// <param name="Controls">The collection of controls to update.</param>
        /// <param name="ForeColor">The foreground color to apply to each control.</param>
        /// <remarks>
        /// Applies the specified foreground color to each control in the collection.
        /// Useful for theming, accessibility adjustments, or dynamic UI feedback based on application state.
        /// Ensure the collection is non-null and that controls are initialized before calling.
        /// </remarks>
        public static void SetForeColor(IEnumerable<Control> Controls, Color ForeColor)
        {
            foreach(Control C in Controls)
                C.ForeColor = ForeColor;
        }
        /// <summary>
        /// Sets the visibility of a collection of UI controls.
        /// </summary>
        /// <param name="Controls">The collection of controls to update.</param>
        /// <param name="IsVisible">A boolean value indicating whether the controls should be visible.</param>
        /// <remarks>
        /// Updates the <c>Visible</c> property of each control in the collection to the specified value.
        /// Useful for toggling visibility of grouped UI elements during form transitions, conditional workflows, or batch layout updates.
        /// Ensure the collection is non-null and that each control is properly initialized before calling.
        /// </remarks>
        public static void SetVisible(IEnumerable<Control> Controls, bool IsVisible)
        {
            foreach (Control ctrl in Controls)
                ctrl.Visible = IsVisible;
        }
        /// <summary>
        /// Clears the text of a collection of WinForms controls.
        /// </summary>
        /// <param name="Controls">The collection of controls whose text should be cleared.</param>
        /// <remarks>
        /// Sets the <c>Text</c> property of each control in the collection to an empty string.
        /// Useful for resetting form inputs, labels, or dynamic UI elements during initialization or cleanup routines.
        /// Ensure the collection is non-null and that controls are initialized before calling.
        /// </remarks>
        public static void ClearText(IEnumerable<Control> Controls)
        {
            foreach (Control C in Controls)
                C.Text = string.Empty;
        }
        /// <summary>
        /// Clears the item collections of a set of ComboBox controls.
        /// </summary>
        /// <param name="ComboBoxes">The collection of ComboBox controls to clear.</param>
        /// <remarks>
        /// Removes all items from each <c>ComboBox.Items</c> collection in the provided set.
        /// Useful for resetting dropdowns during form initialization, dynamic filtering, or state transitions.
        /// Ensure the collection is non-null and that each ComboBox is properly initialized before calling.
        /// </remarks>
        public static void ClearComboBoxes(IEnumerable<ComboBox> ComboBoxes)
        {
            foreach (ComboBox cmb in ComboBoxes)
                cmb.Items.Clear();
        }
        /// <summary>
        /// Populates a ComboBox with a collection of string items.
        /// </summary>
        /// <param name="ComboBox">The ComboBox control to populate.</param>
        /// <param name="Items">The collection of string items to add.</param>
        /// <remarks>
        /// Clears existing items and adds each string from the provided collection to the <c>ComboBox.Items</c>.
        /// Useful for dynamic dropdown population based on user input, data sources, or application state.
        /// Ensure the ComboBox is initialized and the item collection is non-null before calling.
        /// </remarks>
        public static void FillComboBox(ComboBox ComboBox, IEnumerable<string> Items)
        {
            ComboBox.Items.Clear();
            foreach (string item in Items)
                ComboBox.Items.Add(item);
        }
        /// <summary>
        /// Populates multiple ComboBox controls with corresponding collections of string items.
        /// </summary>
        /// <param name="ComboBoxes">The collection of ComboBox controls to populate.</param>
        /// <param name="ItemsArray">
        /// A collection of item collections, where each inner <c>IEnumerable&lt;string&gt;</c> corresponds to one ComboBox.
        /// </param>
        /// <remarks>
        /// Clears all ComboBoxes before populating them. Each ComboBox receives the item set at the matching index in <paramref name="ItemsArray"/>.
        /// Useful for dynamic form initialization, multi-field filtering, or metadata-driven dropdown population.
        /// Ensure both collections are non-null and aligned in length to avoid index mismatches.
        /// Future overloads may support value/display pairs, object binding, or filtered population.
        /// </remarks>
        public static void FillComboBoxes(IEnumerable<ComboBox> ComboBoxes, IEnumerable<IEnumerable<string>> ItemsArray)
        {
            int index = 0;
            ComboBox[] cmbArray = ComboBoxes.ToArray();
            ClearComboBoxes(cmbArray);

            foreach(IEnumerable<string> Items in ItemsArray)
            {
                foreach (string Item in Items)
                    cmbArray[index].Items.Add(Item);
                index++;
            }
        }
        /// <summary>
        /// Appends a collection of string items to an existing ComboBox without clearing its current contents.
        /// </summary>
        /// <param name="ComboBox">The ComboBox control to append items to.</param>
        /// <param name="Items">The collection of string items to add.</param>
        /// <remarks>
        /// Adds each string from the provided collection to the <c>ComboBox.Items</c> list.
        /// Unlike <c>FillComboBox</c>, this method preserves existing items and performs a non-destructive update.
        /// Useful for incremental population, dynamic filtering, or merging multiple data sources.
        /// Ensure the ComboBox is initialized and the item collection is non-null before calling.
        /// Future overloads may support object binding, display/value pairs, or duplicate filtering.
        /// </remarks>
        public static void AppendComboBox(ComboBox ComboBox, IEnumerable<string> Items)
        {
            foreach(string Item in Items)
                ComboBox.Items.Add(Item);
        }
        /// <summary>
        /// Appends collections of string items to multiple ComboBox controls without clearing existing contents.
        /// </summary>
        /// <param name="ComboBoxes">The collection of ComboBox controls to append items to.</param>
        /// <param name="ItemsArray">
        /// A collection of item collections, where each inner <c>IEnumerable&lt;string&gt;</c> corresponds to one ComboBox.
        /// </param>
        /// <remarks>
        /// Adds each string from the corresponding item set to the matching ComboBox at the same index.
        /// Unlike <c>FillComboBoxes</c>, this method preserves existing items and performs a non-destructive update.
        /// Useful for incremental population, merging data sources, or dynamic UI updates across multiple dropdowns.
        /// Ensure both collections are non-null and aligned in length to avoid index mismatches.
        /// Future overloads may support object binding, display/value pairs, or duplicate filtering.
        /// </remarks>
        public static void AppendComboBoxes(IEnumerable<ComboBox> ComboBoxes, IEnumerable<IEnumerable<string>> ItemsArray)
        {
            int index = 0;
            
            foreach(IEnumerable<string> Items in ItemsArray)
            {
                foreach (string Item in Items)
                    ComboBoxes.ElementAt(index).Items.Add(Item);
                index++;
            }
        }
        /// <summary>
        /// Clears the item collections of a set of ListBox controls.
        /// </summary>
        /// <param name="ListBoxes">The collection of ListBox controls to clear.</param>
        /// <remarks>
        /// Removes all items from each <c>ListBox.Items</c> collection in the provided set.
        /// Useful for resetting list-based UI elements during form initialization, filtering, or cleanup routines.
        /// Ensure the collection is non-null and that each ListBox is properly initialized before calling.
        /// Future overloads may support selection resets, filtered clearing, or metadata-driven item retention.
        /// </remarks>
        public static void ClearListBoxes(IEnumerable<ListBox> ListBoxes)
        {
            foreach (ListBox lst in ListBoxes)
                lst.Items.Clear();
        }
        /// <summary>
        /// Populates a ListBox with a collection of string items, replacing any existing content.
        /// </summary>
        /// <param name="ListBox">The ListBox control to populate.</param>
        /// <param name="Items">The collection of string items to add.</param>
        /// <remarks>
        /// Clears the existing <c>Items</c> collection before adding each string from the provided set.
        /// Useful for dynamic list population during form initialization, filtering, or data-driven updates.
        /// Ensure the ListBox is initialized and the item collection is non-null before calling.
        /// Future overloads may support object binding, display/value pairs, or filtered population.
        /// </remarks>
        public static void FillListBox(ListBox ListBox, IEnumerable<string> Items)
        {
            ListBox.Items.Clear();
            foreach (string Item in Items)
                ListBox.Items.Add(Item);
        }
        /// <summary>
        /// Populates multiple ListBox controls with corresponding collections of string items, replacing any existing content.
        /// </summary>
        /// <param name="ListBoxes">The collection of ListBox controls to populate.</param>
        /// <param name="ItemsArray">
        /// A collection of item collections, where each inner <c>IEnumerable&lt;string&gt;</c> corresponds to one ListBox.
        /// </param>
        /// <remarks>
        /// Clears each ListBox before populating it with the corresponding item set at the same index in <paramref name="ItemsArray"/>.
        /// Useful for dynamic form initialization, multi-list filtering, or metadata-driven UI population.
        /// Ensure both collections are non-null and aligned in length to avoid index mismatches.
        /// Future overloads may support object binding, display/value pairs, or filtered population.
        /// </remarks>
        public static void FillListBoxes(IEnumerable<ListBox> ListBoxes, IEnumerable<IEnumerable<string>> ItemsArray)
        {
            int index = 0;

            foreach(IEnumerable<string> Items in ItemsArray)
            {
                FillListBox(ListBoxes.ElementAt(index), Items);
                index++;
            }
        }
        /// <summary>
        /// Appends a collection of string items to an existing ListBox without clearing its current contents.
        /// </summary>
        /// <param name="ListBox">The ListBox control to append items to.</param>
        /// <param name="Items">The collection of string items to add.</param>
        /// <remarks>
        /// Adds each string from the provided collection to the <c>ListBox.Items</c> list.
        /// Unlike <c>FillListBox</c>, this method preserves existing items and performs a non-destructive update.
        /// Useful for incremental population, dynamic filtering, or merging multiple data sources into a single list.
        /// Ensure the ListBox is initialized and the item collection is non-null before calling.
        /// </remarks>
        public static void AppendListBox(ListBox ListBox, IEnumerable<string> Items)
        {
            foreach (string Item in Items)
                ListBox.Items.Add(Item);
        }
        /// <summary>
        /// Appends collections of string items to multiple ListBox controls without clearing existing contents.
        /// </summary>
        /// <param name="ListBoxes">The collection of ListBox controls to append items to.</param>
        /// <param name="ItemsArray">
        /// A collection of item collections, where each inner <c>IEnumerable&lt;string&gt;</c> corresponds to one ListBox.
        /// </param>
        /// <remarks>
        /// Adds each string from the corresponding item set to the matching ListBox at the same index in <paramref name="ItemsArray"/>.
        /// Unlike <c>FillListBoxes</c>, this method preserves existing items and performs a non-destructive update.
        /// Useful for incremental population, merging data sources, or dynamic UI updates across multiple list controls.
        /// Ensure both collections are non-null and aligned in length to avoid index mismatches.
        /// </remarks>
        public static void AppendListBoxes(IEnumerable<ListBox> ListBoxes, IEnumerable<IEnumerable<string>> ItemsArray)
        {
            int index = 0;

            foreach(IEnumerable<string> Items in ItemsArray)
            {
                AppendListBox(ListBoxes.ElementAt(index), Items);
                index++;
            }
        }
        /// <summary>
        /// Sets the maximum selectable date for a collection of DateTimePicker controls.
        /// </summary>
        /// <param name="DateTimePickers">The collection of DateTimePicker controls to update.</param>
        /// <param name="MaxDate">The maximum date to apply to each control.</param>
        /// <remarks>
        /// Updates the <c>MaxDate</c> property of each DateTimePicker in the collection.
        /// Useful for enforcing date constraints across multiple inputs, such as limiting future selections or aligning with business rules.
        /// Ensure the collection is non-null and that each control is properly initialized before calling.
        /// </remarks>
        public static void SetMaxDate(IEnumerable<DateTimePicker> DateTimePickers, DateTime MaxDate)
        {
            foreach (DateTimePicker dtp in DateTimePickers)
                dtp.MaxDate = MaxDate;
        }
        /// <summary>
        /// Sets the minimum selectable date for a collection of DateTimePicker controls.
        /// </summary>
        /// <param name="DateTimePickers">The collection of DateTimePicker controls to update.</param>
        /// <param name="MinDate">The minimum date to apply to each control.</param>
        /// <remarks>
        /// Updates the <c>MinDate</c> property of each DateTimePicker in the collection.
        /// Useful for enforcing date constraints across multiple inputs, such as limiting past selections or aligning with business rules.
        /// Ensure the collection is non-null and that each control is properly initialized before calling.
        /// </remarks>
        public static void SetMinDate(IEnumerable<DateTimePicker> DateTimePickers, DateTime MinDate)
        {
            foreach (DateTimePicker dtp in DateTimePickers)
                dtp.MinDate = MinDate;
        }
        /// <summary>
        /// Clears the data sources of a collection of DataGridView controls.
        /// </summary>
        /// <param name="DataGridViews">The collection of DataGridView controls to clear.</param>
        /// <remarks>
        /// Sets the <c>DataSource</c> property of each DataGridView to <c>null</c>, effectively detaching any bound data.
        /// Useful for resetting grids during form transitions, data refreshes, or cleanup routines.
        /// Ensure the collection is non-null and that each control is properly initialized before calling.
        /// </remarks>
        public static void ClearDataSources(IEnumerable<DataGridView> DataGridViews)
        {
            foreach (DataGridView dgv in DataGridViews)
                dgv.DataSource = null;
        }
        /// <summary>
        /// Assigns data sources to a collection of DataGridView controls using corresponding DataTable instances.
        /// </summary>
        /// <param name="DataGridViews">The collection of DataGridView controls to bind.</param>
        /// <param name="DataTables">
        /// A collection of DataTable instances, each corresponding to a DataGridView at the same index.
        /// </param>
        /// <exception cref="ArgumentException">
        /// Thrown when the number of DataGridViews does not match the number of DataTables.
        /// </exception>
        /// <remarks>
        /// Binds each DataGridView to its corresponding DataTable by setting the <c>DataSource</c> property.
        /// Useful for initializing or refreshing multiple grids in parallel with distinct datasets.
        /// Ensure both collections are non-null and aligned in length to avoid mismatches.
        /// Future overloads may support <c>DataSourceMetadata</c>, <c>BindingSource</c>, or dictionary-based mapping.
        /// </remarks>
        public static void SetDataSources(IEnumerable<DataGridView> DataGridViews, IEnumerable<DataTable> DataTables)
        {
            if (DataGridViews.Count() != DataTables.Count())
                throw new ArgumentException("Collections count mismatch.");

            for (int i = 0; i < DataGridViews.Count(); i++)
                DataGridViews.ElementAt(i).DataSource = DataTables.ElementAt(i);
        }

    }
}
