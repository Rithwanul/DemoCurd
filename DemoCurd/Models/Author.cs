using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoCurd.Models
{
    public class Author
    {
        [Key]
        [Column("author_id")]
        [Required]
        public int Id { get; set; }

        [Column("first_name")]
        [MaxLength(20)]
        [Required]
        public string FirstName { get; set; }

        [Column("last_name")]
        [MaxLength(40)]
        [Required]
        public string LastName { get; set; }

        [Column("phone")]
        [MaxLength(12)]
        [Required]
        public string Phone { get; set; }

        [Column("address")]
        [MaxLength(40)]
        public string Address { get; set; }

        [Column("city")]
        [MaxLength(20)]
        public string City { get; set; }

        [Column("state")]
        [MaxLength(2)]
        public string State { get; set; }

        [Column("zip")]
        [MaxLength(5)]
        public string Zip { get; set; }

        [Column("email_address")]
        [MaxLength(100)]
        public string EmailAddress { get; set; }

    }
}
