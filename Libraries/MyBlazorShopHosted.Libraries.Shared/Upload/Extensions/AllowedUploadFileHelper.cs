using MyBlazorShopHosted.Libraries.Shared.Upload.Models;

namespace MyBlazorShopHosted.Libraries.Shared.Upload.Extensions
{
    public static class AllowedUploadFileHelper
    {
        /// <summary>
        /// The allowed upload file types, which include the file extension, and allowed header bytes
        /// </summary>
        private static AllowedUploadFileType[] AllowedUploadFileTypes = new AllowedUploadFileType[] {
                    new AllowedUploadFileType(".jpg", new List<byte[]>
                    {
                        new byte[] { 0xff, 0xd8, 0xff, 0xdb },
                        new byte[] { 0xff, 0xd8, 0xff, 0xe0, 0x00, 0x10, 0x4a, 0x46, 0x49, 0x46, 0x00, 0x01 },
                        new byte[] { 0xff, 0xd8, 0xff, 0xee },
                        new byte[] { 0xff, 0xd8, 0xff, 0xe1 },
                        new byte[] { 0xff, 0xd8, 0xff, 0xe0 }
                    })
                    };

        /// <summary>
        /// The allowed upload file size limit (in bytes)
        /// </summary>
        private static int AllowedUploadFileSizeLimitBytes = 40960; // 40 kb

        /// <summary>
        /// Validate the file to ensure it can be uploaded.
        /// </summary>
        /// <param name="filename">The name of the file</param>
        /// <param name="fileBytes">The bytes that make up the file</param>
        /// <param name="fileLength">The length of the file</param>
        /// <returns>An upload file result, which it passed validation and any errors that it returned.</returns>
        public static AllowedUploadFileResult ValidateFile(string filename, byte[] fileBytes, long fileLength)
        {
            var errors = new List<string>();

            // Get full file path
            var path = filename;

            var extension = Path.GetExtension(path);

            // Get allowed types based on the file extension
            var allowedUploadFileType = AllowedUploadFileTypes.ToList().FirstOrDefault(s => s.FileExtension == extension);

            if (allowedUploadFileType == null)
            {
                // Not allowed file upload extension type.
                errors.Add("The uploaded file extension is not an accepted extension");
            }
            else
            {
                // Get the first number of bytes of the file to validate against the allowed upload file types
                var headerFileBytes = new byte[allowedUploadFileType.FileSignatures.Max(t => t.Length)];
                Array.Copy(fileBytes, headerFileBytes, allowedUploadFileType.FileSignatures.Max(t => t.Length));

                if (!allowedUploadFileType.FileSignatures.Any(sig => headerFileBytes.Take(sig.Length).SequenceEqual(sig)))
                {
                    // Header bytes don't validate against the allowed upload type, so throw an error.
                    errors.Add("The uploaded file is not valid");
                }
            }

            if (fileLength > AllowedUploadFileSizeLimitBytes)
            {
                // File upload exceeds the maximum size, so throw error.
                errors.Add("The uploaded file exceeds the maximum size limit");
            }

            return new AllowedUploadFileResult(!errors.Any(), errors);
        }
    }
}
