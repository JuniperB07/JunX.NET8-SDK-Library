using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace JunX.NET8.WinForms
{
    /// <summary>
    /// Provides generic helper methods for extracting and manipulating WinForms controls of a specific type.
    /// </summary>
    /// <typeparam name="T">The control type to extract, constrained to <c>System.Windows.Forms.Control</c>.</typeparam>
    /// <remarks>
    /// This class is designed for batch operations on WinForms controls, such as recursive extraction and filtering.
    /// Additional methods may be added to support styling, state toggling, or metadata-driven manipulation.
    /// Intended for use in modular UI frameworks where reusable control logic is required.
    /// </remarks>
    public static class ControlHelper<T> where T: Control
    {
        /// <summary>
        /// Recursively extracts controls of type <typeparamref name="T"/> from a container, optionally filtered by name prefix.
        /// </summary>
        /// <param name="Container">The root control container to search within.</param>
        /// <param name="NamePrefix">
        /// Optional prefix to filter control names. If empty or whitespace, all controls of type <typeparamref name="T"/> are returned.
        /// </param>
        /// <returns>A collection of controls of type <typeparamref name="T"/> found within the container hierarchy.</returns>
        /// <remarks>
        /// This method traverses the control tree recursively, collecting all controls of type <typeparamref name="T"/>.
        /// If a <paramref name="NamePrefix"/> is provided, only controls whose <c>Name</c> starts with the prefix are included.
        /// Designed for metadata-driven UI extraction, batch styling, and dynamic form logic.
        /// Future overloads or filters may be added to support tag-based extraction, visibility constraints, or custom predicates.
        /// </remarks>
        public static IEnumerable<T> Extract(Control Container, string NamePrefix = "")
        {
            List<T> controls = new List<T>();

            if (string.IsNullOrWhiteSpace(NamePrefix))
            {
                foreach(Control ctrl in Container.Controls)
                {
                    if (ctrl is T typedControl)
                        controls.Add(typedControl);

                    if (ctrl.HasChildren)
                        controls.AddRange(Extract(ctrl));
                }
                return controls;
            }
            else
            {
                foreach(Control ctrl in Container.Controls)
                {
                    if (ctrl is T typedControl && ctrl.Name.StartsWith(NamePrefix))
                        controls.Add(typedControl);

                    if (ctrl.HasChildren)
                        controls.AddRange(Extract(ctrl, NamePrefix));
                }
                return controls;
            }
        }
    }
}
