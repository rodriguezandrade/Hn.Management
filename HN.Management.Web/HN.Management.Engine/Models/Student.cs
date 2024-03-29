﻿
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HN.ManagementEngine.Models
{
    [Table("Student")]
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [MaxLength(40, ErrorMessage = "Email can't be longer than 40 characters")]
        [Column("Email", TypeName = "Varchar")]
        public string Email { get; set; }

        [Required(ErrorMessage = "FirstName is required")]
        [MaxLength(40, ErrorMessage = "FirstName can't be longer than 40 characters")]
        [Column("FirstName", TypeName = "Varchar")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LastName is required")]
        [MaxLength(40, ErrorMessage = "LastName can't be longer than 40 characters")]
        [Column("LastName", TypeName = "Varchar")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Image is required")]
        [MaxLength(500, ErrorMessage = "Image can't be longer than 500 characters")]
        [Column("Image", TypeName = "Varchar")]
        public string Image { get; set; }

        [ForeignKey("ProjectId")]
        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }
    }
}
