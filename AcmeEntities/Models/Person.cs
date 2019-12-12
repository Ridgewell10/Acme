using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AcmeEntities.Models
{
    [Table("Person")]
    public class Person : IEntity
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [StringLength(25, ErrorMessage = "First Name can't be longer than 60 characters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(50, ErrorMessage = "Name can't be longer than 50 characters")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Date Of Birth Required")]
        public DateTime BirthDate { get; set; }

    }
}
