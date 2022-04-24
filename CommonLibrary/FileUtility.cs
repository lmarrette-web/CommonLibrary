using System;
using System.IO;

namespace Helpers
{
    /// <summary>
    /// Handle various file operations
    /// </summary>
    public class FileUtility
    {
        /// <summary>
        /// Renames input file by changing the extension to the new extension
        /// </summary>
        /// <param name="inputFileName">File to Process including the path</param>
        /// <param name="newExtension">The new extension for the file sent</param>
        /// <returns></returns>
        public string ChangeFileExtension(
            string inputFileName,
            string newExtension)
        {
            var newFileName = string.Empty;
            if (!string.IsNullOrEmpty(inputFileName) && !string.IsNullOrEmpty(newExtension))
            {

                var oldExtension = Path.GetExtension(inputFileName);
                newFileName = inputFileName.Replace(oldExtension, newExtension);
            }

            return newFileName;
        }

        /// <summary>
        /// Appends the current date to the file name submitted
        /// </summary>
        /// <param name="inputFile">File To Rename</param>
        /// <returns>File Name plus date as yyyy-MM-dd</returns>
        public string AddDateToFileName(
            string inputFile)
        {
            return inputFile + " - " + DateTime.Now.ToString("yyyy-MM-dd");
        }

        /// <summary>
        /// Moves file from the current folder to an archive folder
        /// </summary>
        /// <param name="fileName">File to Move without the folder </param>
        /// <param name="currentFolder">Current file location</param>
        /// <param name="archiveFolder">Archive destination folder</param>
        public void ArchiveFile(
            string fileName,
            string currentFolder,
            string archiveFolder)
        {
            FileInfo fileToMove = new FileInfo(currentFolder + fileName);
            string fileNameOnly = Path.GetFileNameWithoutExtension(fileToMove.Name);
            string extension = fileToMove.Extension;
            string destinationFile = archiveFolder + fileNameOnly + " - " + DateTime.Now.ToString("yyyy-MM-dd") + extension;
            fileToMove.MoveTo(destinationFile);
        }


    }
}