using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlazorShopHosted.Libraries.Shared.Upload.Models
{
    public class AllowedUploadFileType
    {
        // The extension of the file
        public string FileExtension { get; }

        /// <summary>
        /// A list of allowed file signatures for the extension
        /// </summary>
        public List<byte[]> FileSignatures { get; }

        /// <summary>
        /// Creates a new instance of <see cref="AllowedUploadFileType"/>
        /// </summary>
        /// <param name="fileExtension">The extension of the file</param>
        /// <param name="fileSignatures">A list of allowed file signatures for the extension</param>
        public AllowedUploadFileType(string fileExtension, List<byte[]> fileSignatures)
        {
            FileExtension = fileExtension;
            FileSignatures = fileSignatures;
        }
    }
}
