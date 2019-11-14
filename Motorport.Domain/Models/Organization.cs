using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Motorport.Domain.Models
{
    public class Organization
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(20)]
        public string Ruc { get; set; }
        [Required, MaxLength(50)]
        public string BussinessName { get; set; }
        public string ThumbnailImage { get; set; }
        #region "Common Fields"
        public DateTime CreatedAt { get; set; }

        [MaxLength(50)]
        public string CreatedBy { get; set; }

        public DateTime ModifiedAt { get; set; }

        [MaxLength(50)]
        public string ModifiedBy { get; set; }

        public bool Active { get; set; }
        #endregion
    }
}
