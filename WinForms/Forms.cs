using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

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
        /// Sets the size of a collection of UI controls.
        /// </summary>
        /// <param name="Controls">The collection of controls to update.</param>
        /// <param name="Size">The size to apply to each control.</param>
        /// <remarks>
        /// Updates the <c>Size</c> property of each control in the collection to the specified <c>System.Drawing.Size</c> value.
        /// Useful for enforcing uniform layout dimensions, responsive design adjustments, or theme-based UI scaling.
        /// Ensure the collection is non-null and that each control is properly initialized before calling.
        /// </remarks>
        public static void SetSize(IEnumerable<Control> Controls, Size Size)
        {
            foreach (Control ctrl in Controls)
                ctrl.Size = Size;
        }
        /// <summary>
        /// Sets the size of multiple UI controls using corresponding <see cref="Size"/> values.
        /// </summary>
        /// <param name="Controls">The collection of controls to update.</param>
        /// <param name="Sizes">The collection of <see cref="Size"/>  values to apply, one per control.</param>
        /// <exception cref="ArgumentException">
        /// Thrown when the number of controls does not match the number of size values.
        /// </exception>
        /// <remarks>
        /// Updates the <see cref="Size"/>  property of each control in the collection using the corresponding <see cref="Size"/>  at the same index.
        /// Useful for dynamic layout adjustments, responsive UI scaling, or metadata-driven form rendering.
        /// Ensure both collections are non-null and aligned in length to avoid index mismatches.
        /// </remarks>
        public static void SetSizes(IEnumerable<Control> Controls, IEnumerable<Size> Sizes)
        {
            if (Controls.Count() != Sizes.Count())
                throw new ArgumentException("Collections size mismatch.");

            for (int i = 0; i < Controls.Count(); i++)
                Controls.ElementAt(i).Size = Sizes.ElementAt(i);
        }
        /// <summary>
        /// Sets the font of a collection of UI controls.
        /// </summary>
        /// <param name="Controls">The collection of controls to update.</param>
        /// <param name="Font">The font to apply to each control.</param>
        /// <remarks>
        /// Updates the <c>Font</c> property of each control in the collection to the specified <c>System.Drawing.Font</c> instance.
        /// Useful for enforcing consistent typography across grouped controls, applying theme-based styling, or dynamically adjusting font settings.
        /// Ensure the collection is non-null and that each control is properly initialized before calling.
        /// </remarks>
        public static void SetFont(IEnumerable<Control> Controls, Font Font)
        {
            foreach (Control ctrl in Controls)
                ctrl.Font = Font;
        }
        /// <summary>
        /// Sets the font of multiple UI controls using corresponding <see cref="Font"/> instances.
        /// </summary>
        /// <param name="Controls">The collection of controls to update.</param>
        /// <param name="Fonts">The collection of <see cref="Font"/> instances to apply, one per control.</param>
        /// <exception cref="ArgumentException">
        /// Thrown when the number of controls does not match the number of font instances.
        /// </exception>
        /// <remarks>
        /// Updates the <see cref="Font"/> property of each control in the collection using the corresponding <see cref="Font"/> at the same index.
        /// Useful for dynamic typography adjustments, theme-based styling, or metadata-driven UI rendering.
        /// Ensure both collections are non-null and aligned in length to avoid index mismatches.
        /// </remarks>
        public static void SetFonts(IEnumerable<Control> Controls, IEnumerable<Font> Fonts)
        {
            if(Controls.Count() != Fonts.Count())
                throw new ArgumentException("Collections size mismatch.");

            for (int i = 0; i < Controls.Count(); i++)
                Controls.ElementAt(i).Font = Fonts.ElementAt(i);
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
        /// Sets the display format for a collection of <see cref="DateTimePicker"/> controls.
        /// </summary>
        /// <param name="DateTimePickers">The collection of <see cref="DateTimePicker"/> controls to update.</param>
        /// <param name="Format">The <see cref="DateTimePickerFormat"/> value to apply to each control.</param>
        /// <remarks>
        /// Updates the <c>Format</c> property of each <see cref="DateTimePicker"/> in the collection to the specified format.
        /// Useful for enforcing consistent date/time presentation across grouped controls, especially in forms, reports, or region-specific UIs.
        /// Ensure the collection is non-null and that each control is properly initialized before calling.
        /// </remarks>
        public static void SetFormat(IEnumerable<DateTimePicker> DateTimePickers, DateTimePickerFormat Format)
        {
            foreach (DateTimePicker dtp in DateTimePickers)
                dtp.Format = Format;
        }
        /// <summary>
        /// Sets the selected date and time for a collection of <see cref="DateTimePicker"/> controls.
        /// </summary>
        /// <param name="DateTimePickers">The collection of <see cref="DateTimePicker"/> controls to update.</param>
        /// <param name="Value">The <see cref="DateTime"/> value to assign to each control.</param>
        /// <remarks>
        /// Updates the <c>Value</c> property of each <see cref="DateTimePicker"/> in the collection to the specified <see cref="DateTime"/>.
        /// Useful for initializing default timestamps, synchronizing form inputs, or applying consistent date values across grouped controls.
        /// Ensure the collection is non-null and that each control is properly initialized and within its valid range before calling.
        /// </remarks>
        public static void SetValue(IEnumerable<DateTimePicker> DateTimePickers, DateTime Value)
        {
            foreach (DateTimePicker dtp in DateTimePickers)
                dtp.Value = Value;
        }
        /// <summary>
        /// Sets a custom date and time format for a collection of DateTimePicker controls.
        /// </summary>
        /// <param name="DateTimePickers">The collection of DateTimePicker controls to update.</param>
        /// <param name="CustomFormat">The custom format string to apply to each control.</param>
        /// <exception cref="FormatException">
        /// Thrown when the format string is invalid or cannot be applied to one or more controls.
        /// </exception>
        /// <remarks>
        /// Updates the <c>CustomFormat</c> property of each DateTimePicker in the collection to the specified format string.
        /// Useful for applying localized, domain-specific, or user-defined date/time formats across grouped controls.
        /// Ensure the format string is valid and compatible with the control's current <c>Format</c> setting (typically <c>DateTimePickerFormat.Custom</c>).
        /// </remarks>
        public static void SetCustomFormat(IEnumerable<DateTimePicker> DateTimePickers, string CustomFormat)
        {
            try
            {
                foreach (DateTimePicker dtp in DateTimePickers)
                    dtp.CustomFormat = CustomFormat;
            }
            catch(FormatException fe)
            {
                throw new FormatException(fe.Message.ToString());
            }
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
       
        
        /// <summary>
        /// Adds a single data point to a chart series with the specified axis label, X value, and Y value.
        /// </summary>
        /// <param name="ChartSeries">The chart series to which the data point will be added.</param>
        /// <param name="AxisLabel">The label to display on the X-axis for this data point.</param>
        /// <param name="XValue">The numeric X value of the data point.</param>
        /// <param name="YValue">The numeric Y value of the data point.</param>
        /// <remarks>
        /// Creates a new <c>DataPoint</c> with the specified label and values, then appends it to the <c>Points</c> collection of the chart series.
        /// Useful for dynamically populating chart data in reporting modules, dashboards, or visual analytics.
        /// Ensure the chart series is initialized and configured before calling.
        /// Future overloads may support multiple Y values, custom formatting, or metadata tagging.
        /// </remarks>
        public static void AddSeriesPoint(Series ChartSeries, string AxisLabel, int XValue, double YValue)
        {
            DataPoint DP = new DataPoint();
            DP.AxisLabel = AxisLabel;
            DP.XValue = XValue;
            DP.YValues = new double[] { YValue };
            ChartSeries.Points.Add(DP);
        }
        /// <summary>
        /// Adds a single data point to a chart series with the specified axis label, X value, and multiple Y values.
        /// </summary>
        /// <param name="ChartSeries">The chart series to which the data point will be added.</param>
        /// <param name="AxisLabel">The label to display on the X-axis for this data point.</param>
        /// <param name="XValue">The numeric X value of the data point.</param>
        /// <param name="YValues">A collection of numeric Y values to assign to the data point.</param>
        /// <remarks>
        /// Creates a new <c>DataPoint</c> with the specified label and values, then appends it to the <c>Points</c> collection of the chart series.
        /// Useful for stacked charts, multi-dimensional plotting, or scenarios requiring multiple Y values per point.
        /// Ensure the chart series is initialized and that the Y value collection is non-null and properly structured.
        /// </remarks>
        public static void AddSeriesPoint(Series ChartSeries, string AxisLabel, int XValue, IEnumerable<double> YValues)
        {
            DataPoint DP = new DataPoint();
            DP.AxisLabel = AxisLabel;
            DP.XValue = XValue;
            DP.YValues = YValues.ToArray();
            ChartSeries.Points.Add(DP);
        }


        /// <summary>
        /// Sets the checked state of a collection of CheckBox controls.
        /// </summary>
        /// <param name="CheckBoxes">The collection of CheckBox controls to update.</param>
        /// <param name="IsChecked">A boolean value indicating whether the checkboxes should be checked.</param>
        /// <remarks>
        /// Updates the <c>Checked</c> property of each CheckBox in the collection to the specified value.
        /// Useful for toggling grouped options, enforcing defaults, or resetting form state in batch operations.
        /// Ensure the collection is non-null and that each control is properly initialized before calling.
        /// </remarks>
        public static void SetChecked(IEnumerable<CheckBox> CheckBoxes, bool IsChecked)
        {
            foreach (CheckBox chk in CheckBoxes)
                chk.Checked = IsChecked;
        }


        /// <summary>
        /// Sets the text alignment for a collection of Label controls.
        /// </summary>
        /// <param name="Labels">The collection of Label controls to update.</param>
        /// <param name="Alignment">The desired text alignment to apply.</param>
        /// <remarks>
        /// Updates the <c>TextAlign</c> property of each Label in the collection to the specified <c>ContentAlignment</c> value.
        /// Useful for enforcing consistent layout, adjusting visual hierarchy, or applying theme-based formatting across multiple labels.
        /// Ensure the collection is non-null and that each control is properly initialized before calling.
        /// </remarks>
        public static void SetTextAlign(IEnumerable<Label> Labels, ContentAlignment Alignment)
        {
            foreach (Label lbl in Labels)
                lbl.TextAlign = Alignment;
        }


        /// <summary>
        /// Sets the hexadecimal display mode for a collection of NumericUpDown controls.
        /// </summary>
        /// <param name="NumericUpDowns">The collection of NumericUpDown controls to update.</param>
        /// <param name="IsHexadecimal">A boolean value indicating whether to enable hexadecimal display mode.</param>
        /// <remarks>
        /// Updates the <c>Hexadecimal</c> property of each NumericUpDown in the collection to the specified value.
        /// Useful for toggling between decimal and hexadecimal input modes in batch, especially in developer tools, configuration panels, or diagnostic UIs.
        /// Ensure the collection is non-null and that each control is properly initialized before calling.
        /// </remarks>
        public static void SetHexadecimal(IEnumerable<NumericUpDown> NumericUpDowns, bool IsHexadecimal)
        {
            foreach (NumericUpDown nud in NumericUpDowns)
                nud.Hexadecimal = IsHexadecimal;
        }
        /// <summary>
        /// Sets the value of a collection of NumericUpDown controls.
        /// </summary>
        /// <param name="NumericUpDowns">The collection of NumericUpDown controls to update.</param>
        /// <param name="Value">The decimal value to assign to each control.</param>
        /// <remarks>
        /// Updates the <c>Value</c> property of each NumericUpDown in the collection to the specified value.
        /// Useful for initializing default values, resetting form inputs, or applying consistent numeric settings across grouped controls.
        /// Ensure the collection is non-null and that each control is properly initialized and within the valid range before calling.
        /// </remarks>
        public static void SetValue(IEnumerable<NumericUpDown> NumericUpDowns, decimal Value)
        {
            foreach (NumericUpDown nud in NumericUpDowns)
                nud.Value = Value;
        }
        /// <summary>
        /// Sets the number of decimal places for a collection of <see cref="NumericUpDown"/> controls.
        /// </summary>
        /// <param name="NumericUpDowns">The collection of <see cref="NumericUpDown"/> controls to update.</param>
        /// <param name="DecimalPlaces">The number of decimal places to display.</param>
        /// <remarks>
        /// Updates the <c>DecimalPlaces</c> property of each <see cref="NumericUpDown"/> in the collection to the specified value.
        /// Useful for enforcing consistent numeric precision across grouped inputs, especially in financial, scientific, or configuration forms.
        /// Ensure the collection is non-null and that each control is properly initialized before calling.
        /// </remarks>
        public static void SetDecimalPlaces(IEnumerable<NumericUpDown> NumericUpDowns, int DecimalPlaces)
        {
            foreach (NumericUpDown nud in NumericUpDowns)
                nud.DecimalPlaces = DecimalPlaces;
        }
        /// <summary>
        /// Sets the increment value for a collection of <see cref="NumericUpDown"/> controls.
        /// </summary>
        /// <param name="NumericUpDowns">The collection of <see cref="NumericUpDown"/> controls to update.</param>
        /// <param name="Increment">The decimal value to use as the increment step.</param>
        /// <remarks>
        /// Updates the <c>Increment</c> property of each <see cref="NumericUpDown"/> in the collection to the specified value.
        /// Useful for customizing input granularity across grouped controls, especially in configuration panels, scientific inputs, or financial forms.
        /// Ensure the collection is non-null and that each control is properly initialized before calling.
        /// </remarks>
        public static void SetIncrement(IEnumerable<NumericUpDown> NumericUpDowns, decimal Increment)
        {
            foreach (NumericUpDown nud in NumericUpDowns)
                nud.Increment = Increment;
        }
        /// <summary>
        /// Sets the maximum allowable value for a collection of NumericUpDown controls.
        /// </summary>
        /// <param name="NumericUpDowns">The collection of NumericUpDown controls to update.</param>
        /// <param name="Maximum">The maximum value to assign to each control.</param>
        /// <remarks>
        /// Updates the <c>Maximum</c> property of each NumericUpDown in the collection to the specified value.
        /// Useful for enforcing upper bounds across grouped inputs, especially in configuration panels, validation workflows, or domain-specific numeric ranges.
        /// Ensure the collection is non-null and that each control is properly initialized before calling.
        /// </remarks>
        public static void SetMaximum(IEnumerable<NumericUpDown> NumericUpDowns, decimal Maximum)
        {
            foreach (NumericUpDown nud in NumericUpDowns)
                nud.Maximum = Maximum;
        }
        /// <summary>
        /// Sets the minimum allowable value for a collection of NumericUpDown controls.
        /// </summary>
        /// <param name="NumericUpDowns">The collection of NumericUpDown controls to update.</param>
        /// <param name="Minimum">The minimum value to assign to each control.</param>
        /// <remarks>
        /// Updates the <c>Minimum</c> property of each NumericUpDown in the collection to the specified value.
        /// Useful for enforcing lower bounds across grouped inputs, especially in configuration panels, validation workflows, or domain-specific numeric ranges.
        /// Ensure the collection is non-null and that each control is properly initialized before calling.
        /// </remarks>
        public static void SetMinimum(IEnumerable<NumericUpDown> NumericUpDowns, decimal Minimum)
        {
            foreach (NumericUpDown nud in NumericUpDowns)
                nud.Minimum = Minimum;
        }
        /// <summary>
        /// Sets the thousands separator display mode for a collection of NumericUpDown controls.
        /// </summary>
        /// <param name="NumericUpDowns">The collection of NumericUpDown controls to update.</param>
        /// <param name="ThousandsSeparator">A boolean value indicating whether to enable thousands separator formatting.</param>
        /// <remarks>
        /// Updates the <c>ThousandsSeparator</c> property of each NumericUpDown in the collection to the specified value.
        /// Useful for improving numeric readability in financial, statistical, or configuration forms where large values are displayed.
        /// Ensure the collection is non-null and that each control is properly initialized before calling.
        /// </remarks>
        public static void SetThousandsSeparator(IEnumerable<NumericUpDown> NumericUpDowns, bool ThousandsSeparator)
        {
            foreach (NumericUpDown nud in NumericUpDowns)
                nud.ThousandsSeparator = ThousandsSeparator;
        }


        /// <summary>
        /// Sets the active link color for a collection of LinkLabel controls.
        /// </summary>
        /// <param name="LinkLabels">The collection of LinkLabel controls to update.</param>
        /// <param name="ActiveLinkColor">The color to apply when a link is actively being clicked.</param>
        /// <remarks>
        /// Updates the <c>ActiveLinkColor</c> property of each LinkLabel in the collection to the specified <see cref="Color"/>.
        /// Useful for customizing link behavior in themed UIs, accessibility enhancements, or branding-driven styling.
        /// Ensure the collection is non-null and that each control is properly initialized before calling.
        /// </remarks>
        public static void SetActiveLinkColor(IEnumerable<LinkLabel> LinkLabels, Color ActiveLinkColor)
        {
            foreach (LinkLabel lkl in LinkLabels)
                lkl.ActiveLinkColor = ActiveLinkColor;
        }
        /// <summary>
        /// Sets the disabled link color for a collection of LinkLabel controls.
        /// </summary>
        /// <param name="LinkLabels">The collection of LinkLabel controls to update.</param>
        /// <param name="DisabledLinkColor">The color to apply when a link is disabled.</param>
        /// <remarks>
        /// Updates the <c>DisabledLinkColor</c> property of each LinkLabel in the collection to the specified <see cref="Color"/>.
        /// Useful for customizing link appearance in disabled states, enhancing accessibility, or applying theme-based styling across multiple controls.
        /// Ensure the collection is non-null and that each control is properly initialized before calling.
        /// </remarks>
        public static void SetDisabledLinkColor(IEnumerable<LinkLabel> LinkLabels, Color DisabledLinkColor)
        {
            foreach (LinkLabel lkl in LinkLabels)
                lkl.DisabledLinkColor = DisabledLinkColor;
        }
        /// <summary>
        /// Sets the default link color for a collection of LinkLabel controls.
        /// </summary>
        /// <param name="LinkLabels">The collection of LinkLabel controls to update.</param>
        /// <param name="LinkColor">The color to apply to unvisited links.</param>
        /// <remarks>
        /// Updates the <c>LinkColor</c> property of each LinkLabel in the collection to the specified <see cref="Color"/>.
        /// Useful for customizing link appearance in themed UIs, accessibility enhancements, or branding-driven styling across multiple controls.
        /// Ensure the collection is non-null and that each control is properly initialized before calling.
        /// </remarks>
        public static void SetLinkColor(IEnumerable<LinkLabel> LinkLabels, Color LinkColor)
        {
            foreach (LinkLabel lkl in LinkLabels)
                lkl.LinkColor = LinkColor;
        }
        /// <summary>
        /// Sets the visited link color for a collection of LinkLabel controls.
        /// </summary>
        /// <param name="LinkLabels">The collection of LinkLabel controls to update.</param>
        /// <param name="VisitedLinkColor">The color to apply to links that have been visited.</param>
        /// <remarks>
        /// Updates the <c>VisitedLinkColor</c> property of each LinkLabel in the collection to the specified <see cref="Color"/>.
        /// Useful for customizing link appearance in post-navigation states, enhancing accessibility, or applying theme-based styling across multiple controls.
        /// Ensure the collection is non-null and that each control is properly initialized before calling.
        /// </remarks>
        public static void SetVisitedLinkColor(IEnumerable<LinkLabel> LinkLabels, Color VisitedLinkColor)
        {
            foreach (LinkLabel lkl in LinkLabels)
                lkl.VisitedLinkColor  = VisitedLinkColor;
        }
    }
}
