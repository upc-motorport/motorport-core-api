using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Motorport.Domain.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string FirstName { get; set; }

        [Required, MaxLength(100)]
        public string MyProperty { get; set; }

        [Required, MaxLength(100)]
        public string ShortName { get; set; }

        [MaxLength(20)]
        public string IdentificationNumber { get; set; }

        
        public int UserId { get; set; }

        public User User { get; set; }

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
