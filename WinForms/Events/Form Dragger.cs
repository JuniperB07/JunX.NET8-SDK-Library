using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JunX.NET8.WinForms.Events
{
    /// <summary>
    /// Provides drag-to-move functionality for borderless or custom-styled WinForms forms.
    /// </summary>
    /// <remarks>
    /// This class enables manual repositioning of a form by tracking mouse events and updating the form's location.
    /// It is typically used to simulate native window dragging behavior when <c>FormBorderStyle</c> is set to <c>None</c>.
    /// Attach the <c>MouseDown</c>, <c>MouseMove</c>, and <c>MouseUp</c> handlers to a control that acts as the draggable header.
    /// </remarks>
    public class FormDragger
    {
        private readonly Form _form;
        private bool _dragging;
        private Point _cursorPoint;
        private Point _formPoint;

        /// <summary>
        /// Initializes a new instance of the <see cref="FormDragger"/> class and binds it to the specified form.
        /// </summary>
        /// <param name="MyForm">
        /// The <see cref="Form"/> instance to enable drag-to-move behavior on. This form's position will be updated based on mouse movement.
        /// </param>
        /// <remarks>
        /// This constructor prepares the internal state for tracking drag operations. To activate dragging, wire the <c>MouseDown</c>, <c>MouseMove</c>, and <c>MouseUp</c>
        /// events of a header control (e.g., a <see cref="Panel"/> or <see cref="Label"/>) to the corresponding methods of this instance.
        /// </remarks>
        public FormDragger(Form MyForm)
        {
            _form = MyForm;
            _dragging = false;
        }

        /// <summary>
        /// Initiates the drag operation by capturing the current cursor position and form location.
        /// </summary>
        /// <param name="sender">
        /// The source of the <see cref="MouseEventArgs"/> event, typically the control acting as the draggable header.
        /// </param>
        /// <param name="e">
        /// The <see cref="MouseEventArgs"/> instance containing the event data for the mouse press.
        /// </param>
        /// <remarks>
        /// This method sets the internal drag state to active and records the initial cursor and form positions.
        /// It should be wired to the <c>MouseDown</c> event of a control used for dragging the form.
        /// </remarks>
        public void MouseDown(object? sender, MouseEventArgs? e)
        {
            _dragging = true;
            _cursorPoint = Cursor.Position;
            _formPoint = _form.Location;
        }

        /// <summary>
        /// Updates the form's position based on the current cursor movement while dragging is active.
        /// </summary>
        /// <param name="sender">
        /// The source of the <see cref="MouseEventArgs"/> event, typically the control being dragged.
        /// </param>
        /// <param name="e">
        /// The <see cref="MouseEventArgs"/> instance containing the event data for the mouse movement.
        /// </param>
        /// <remarks>
        /// This method calculates the difference between the current cursor position and the initial drag point,
        /// then repositions the form accordingly. It should be wired to the <c>MouseMove</c> event of the draggable control.
        /// </remarks>
        public void MouseMove(object? sender, MouseEventArgs? e)
        {
            if (_dragging)
            {
                Point diff = Point.Subtract(Cursor.Position, new Size(_cursorPoint));
                _form.Location = Point.Add(_formPoint, new Size(diff));
            }
        }

        /// <summary>
        /// Terminates the drag operation by resetting the internal drag state.
        /// </summary>
        /// <param name="sender">
        /// The source of the <see cref="MouseEventArgs"/> event, typically the control used for dragging.
        /// </param>
        /// <param name="e">
        /// The <see cref="MouseEventArgs"/> instance containing the event data for the mouse release.
        /// </param>
        /// <remarks>
        /// This method should be wired to the <c>MouseUp</c> event of the draggable control. It signals the end of a drag-to-move interaction,
        /// preventing further form repositioning until a new <c>MouseDown</c> event occurs.
        /// </remarks>
        public void MouseUp(object? sender, MouseEventArgs? e)
        {
            _dragging = false;
        }
    }

    /// <summary>
    /// Provides generic drag-to-move functionality for a specified WinForms form using any control of type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">
    /// The type of <see cref="Control"/> used to initiate the drag operation. This control must support mouse events.
    /// </typeparam>
    /// <remarks>
    /// This class enables manual repositioning of a form by wiring mouse events to a designated control. It is especially useful for borderless forms
    /// or custom-styled headers where native window dragging is unavailable. The drag behavior is activated automatically upon instantiation,
    /// with no need for manual event binding.
    /// </remarks>
    public class FormDragger<T> where T: Control
    {
        private readonly Form _form;
        private readonly T _control;
        private bool _dragging;
        private Point _cursorPoint;
        private Point _formPoint;

        /// <summary>
        /// Initializes a new instance of the <see cref="FormDragger{T}"/> class and wires drag-to-move behavior to the specified control.
        /// </summary>
        /// <param name="MyForm">
        /// The <see cref="Form"/> instance to be repositioned during drag operations.
        /// </param>
        /// <param name="Control">
        /// The control of type <typeparamref name="T"/> that will serve as the draggable surface. Mouse events from this control will trigger form movement.
        /// </param>
        /// <remarks>
        /// This constructor automatically attaches <c>MouseDown</c>, <c>MouseMove</c>, and <c>MouseUp</c> event handlers to the provided control.
        /// It enables manual form repositioning, typically used for borderless or custom-styled forms in WinForms applications.
        /// </remarks>
        public FormDragger(Form MyForm, T Control)
        {
            _form = MyForm;
            _control = Control;
            _dragging = false;

            _control.MouseDown += MouseDown;
            _control.MouseMove += MouseMove;
            _control.MouseUp += MouseUp;
        }

        private void MouseDown(object? sender, MouseEventArgs? e)
        {
            _dragging = true;
            _cursorPoint = Cursor.Position;
            _formPoint = _form.Location;
        }
        private void MouseMove(object? sender, MouseEventArgs? e)
        {
            if (_dragging)
            {
                Point diff = Point.Subtract(Cursor.Position, new Size(_cursorPoint));
                _form.Location = Point.Add(_formPoint, new Size(diff));
            }
        }
        private void MouseUp(object? sender, MouseEventArgs? e)
        {
            _dragging = false;
        }
    }
}
