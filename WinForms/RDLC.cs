using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Reporting.WinForms;

namespace JunX.NET8.WinForms
{
    /// <summary>
    /// Provides utility methods for exporting RDLC reports to PDF format with validation and error handling.
    /// </summary>
    /// <remarks>
    /// The <c>RDLC</c> class encapsulates report rendering logic using <see cref="Microsoft.Reporting.WinForms.LocalReport"/>.
    /// It ensures that export paths include valid file names with extensions and handles exceptions during file generation.
    /// Intended for use in systems requiring automated or user-triggered report exports.
    /// </remarks>
    public class RDLC
    {
        /// <summary>
        /// Exports a specified RDLC report to a PDF file at the given path.
        /// </summary>
        /// <param name="RDLC_File">The <see cref="LocalReport"/> instance representing the RDLC report to render.</param>
        /// <param name="ExportPath">The full file path, including file name and extension, where the PDF will be saved.</param>
        /// <exception cref="ArgumentException">
        /// Thrown when <paramref name="ExportPath"/> does not contain a valid file name with an extension.
        /// </exception>
        /// <exception cref="IOException">
        /// Thrown when an error occurs during rendering or writing the PDF file to disk.
        /// </exception>
        /// <remarks>
        /// This method renders the RDLC report as a PDF and writes the resulting byte array to the specified file path.
        /// It validates that the export path includes a file name and extension before proceeding.
        /// </remarks>
        public static void ExportToPDF(LocalReport RDLC_File, string ExportPath)
        {
            if (!HasFileNameAndExtension(ExportPath))
                throw new ArgumentException("Parameter 'ExportPath' does not contain file name w/ file extension");

            try
            {
                byte[] pdfBytes = RDLC_File.Render("PDF", null);
                File.WriteAllBytes(ExportPath, pdfBytes);
            }
            catch(Exception e)
            {
                throw new IOException("An error occurred during exportation.", e);
            }
        }

        private static bool HasFileNameAndExtension(string path)
        {
            string fn = Path.GetFileName(path);
            return !string.IsNullOrWhiteSpace(fn) && Path.HasExtension(fn);
        }
    }
}
