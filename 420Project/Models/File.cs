using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _420Project;
using System.ComponentModel.DataAnnotations;

namespace _420Project.Models
{
    public class File
    {
        public int Id { get; set; }
        [StringLength(255)]
        public string FileName { get; set; }
        [StringLength(100)]
        public string ContentType { get; set; }
        public FileType FileType { get; set; }
        public byte[] Content { get; set; }
       

    }
}