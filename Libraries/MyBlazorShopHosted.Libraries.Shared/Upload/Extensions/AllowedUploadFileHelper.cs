using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBlazorShopHosted.Libraries.Shared.Upload.Models;

namespace MyBlazorShopHosted.Libraries.Shared.Upload.Extensions
{
    public static class AllowedUploadFileHelper
    {
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

        private static int AllowedUploadFileSizeLimitBytes = 40960; // 40 kb

        public static List<string> ValidateFile(string filename, byte[] fileBytes, long fileLength)
        {
            var errors = new List<string>();

            // Get full file path
            var path = filename;

            var extension = Path.GetExtension(path);

            var allowedUploadFileType = AllowedUploadFileTypes.ToList().FirstOrDefault(s => s.FileExtension == extension);

            if (allowedUploadFileType == null)
            {
                errors.Add("The uploaded file extension is not an accepted extension");
            }
            else
            {
                var headerBytes = new byte[allowedUploadFileType.FileSignatures.Max(t => t.Length)];
                Array.Copy(fileBytes, headerBytes, allowedUploadFileType.FileSignatures.Max(t => t.Length));

                if (!allowedUploadFileType.FileSignatures.Any(sig => headerBytes.Take(sig.Length).SequenceEqual(sig)))
                {
                    errors.Add("The uploaded file is not valid");
                }                
            }

            if (fileLength > AllowedUploadFileSizeLimitBytes)
            {
                errors.Add("The uploaded file exceeds the maximum size limit");
            }

            return errors;
        }
    }
}
