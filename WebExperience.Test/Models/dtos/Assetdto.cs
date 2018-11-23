using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebExperience.Test.Models.dtos
{
    public class Assetdto
    {
        [Key]
        public Guid asset_id { get; set; }

        [Required]
        [StringLength(255)]
        public string file_name { get; set; }

        [Required]
        [StringLength(255)]
        public string mime_type { get; set; }

        [Required]
        [StringLength(255)]
        public string created_by { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        [StringLength(255)]
        public string email { get; set; }

        [Required]
        [StringLength(255)]
        public string country { get; set; }

        [Required]
        public string description { get; set; }
        public bool isNew { get; set; }
    }
}