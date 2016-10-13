using Microsoft.AspNet.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace OnlineShoppingWeb.Enities
{
    public enum FileType
    {
        Avatar = 1, Photo
    }
    public class File: IFormFile
    {
        public int FileId { get; set; }
        [StringLength(255)]
        public string FileName { get; set; }
        [StringLength(100)]
        public string ContentType { get; set; }
        public byte[] Content { get; set; }
        public FileType FileType { get; set; }
        public int UserId { get; set; }
        public virtual User User
        {
            get; set;
        }

        public string ContentDisposition
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IHeaderDictionary Headers
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public long Length
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Stream OpenReadStream()
        {
            throw new NotImplementedException();
        }
    }
}
