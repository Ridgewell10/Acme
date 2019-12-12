using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcmeEntities.Models
{
    [Table("Employee")]
    public class Employee : IEntity
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [ForeignKey("PersonId")]
        public int PersonId { get; set; }

        [Required(ErrorMessage = "EmpNumber is required")]
        [StringLength(25, ErrorMessage = "EmpNumber can't be longer than 16 characters")]
        public string EmpNumber { get; set; }

        [Required(ErrorMessage = "Start Date is required")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime EmployedDate { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}}", ApplyFormatInEditMode = true)]
        public DateTime? Terminated { get; set; }


    }
}
