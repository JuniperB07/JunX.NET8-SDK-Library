using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace JunX.NET8.WinForms.Events
{
    /// <summary>
    /// Represents event data for a property value change, providing access to both the old and new values.
    /// </summary>
    public class PropertyValueChangedEventArgs<T> : EventArgs
    {
        /// <summary>
        /// Gets the previous value of the property before the change occurred.
        /// </summary>
        public T OldValue { get; }
        /// <summary>
        /// Gets the new value of the property after the change occurred.
        /// </summary>
        public T NewValue { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PropertyValueChangedEventArgs{T}"/> class with the specified old and new values.
        /// </summary>
        /// <param name="SetOldValue">The previous value before the change.</param>
        /// <param name="SetNewValue">The new value after the change.</param>
        public PropertyValueChangedEventArgs(T SetOldValue, T SetNewValue)
        {
            OldValue = SetOldValue;
            NewValue =  SetNewValue;
        }
    }

    /// <summary>
    /// Represents event data for a value type (struct) change, providing access to the old and new values.
    /// </summary>
    public class StructChangedEventArgs<T> : EventArgs where T: struct
    {
        /// <summary>
        /// Gets the previous value of the struct before the change occurred.
        /// </summary>
        public T OldValue { get; }
        /// <summary>
        /// Gets the new value of the struct after the change occurred.
        /// </summary>
        public T NewValue { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="StructChangedEventArgs{T}"/> class with the specified old and new values.
        /// </summary>
        /// <param name="SetOldValue">The previous value of the struct before the change.</param>
        /// <param name="SetNewValue">The new value of the struct after the change.</param>
        public StructChangedEventArgs(T SetOldValue, T SetNewValue)
        {
            OldValue = SetOldValue;
            NewValue = SetNewValue;
        }
    }
}
