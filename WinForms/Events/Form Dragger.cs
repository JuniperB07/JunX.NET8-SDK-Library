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
        private readonly Control? _control;
        private bool _dragging;
        private Point _cursorPoint;
        private Point _formPoint;

        /// <summary>
        /// Initializes a new instance of the <see cref="FormDragger{T}"/> class and optionally wires drag-to-move behavior to the specified control.
        /// </summary>
        /// <param name="MyForm">
        /// The <see cref="Form"/> instance to be repositioned during drag operations.
        /// </param>
        /// <param name="Control">
        /// An optional <see cref="Control"/> that serves as the draggable surface. If provided, mouse events will be automatically linked to enable form dragging.
        /// </param>
        /// <remarks>
        /// This constructor prepares the internal drag state and invokes <c>DragEventLinker()</c> to bind mouse events if a control is supplied.
        /// It supports flexible usage where the control can be assigned later or omitted entirely for manual event wiring.
        /// </remarks>
        public FormDragger(Form MyForm, Control? Control = null)
        {
            _form = MyForm;
            _control = Control;
            _dragging = false;
            DragEventLinker();
        }

        private void DragEventLinker()
        {
            if (_control != null)
            {
                _control.MouseDown += MouseDown;
                _control.MouseMove += MouseMove;
                _control.MouseUp += MouseUp;
            }
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
}