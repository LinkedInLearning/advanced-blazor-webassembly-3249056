using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlazorShopHosted.Libraries.Shared.Upload.Models
{
    public class AllowedUploadFileResult
    {
        /// <summary>
        /// Whether the result is successful
        /// </summary>
        public bool Success { get; }

        /// <summary>
        /// A list of errors
        /// </summary>
        public List<string>? Errors { get; }

        /// <summary>
        /// A new instance of <see cref="AllowedUploadFileResult"/>
        /// </summary>
        /// <param name="success">Whether the result is successful</param>
        /// <param name="errors">A list of errors</param>
        public AllowedUploadFileResult(bool success, List<string>? errors = null)
        {
            Success = success;
            Errors = errors;
        }
    }
}
