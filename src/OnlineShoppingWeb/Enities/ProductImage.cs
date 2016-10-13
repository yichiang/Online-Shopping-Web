using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace OnlineShoppingWeb.Enities
{
    public enum FileType {
        Photo
    }

    public class ProductImage
    {
        [Key]
        public int ImageId { get; set; }
        [StringLength(255)]
        public string FileName { get; set; }
        [StringLength(100)]
        public string ContentType { get; set; }
        public byte[] Content { get; set; }
        public FileType FileType { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set;}

     
    }
}
