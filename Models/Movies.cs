using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission06_LamoreauxAbe.Models
{
    public class Movies
    {
        [Key]
        [Required]
        public int MovieId { get; set; }

        [Required]
        public string Title { get; set; }

        public string? Director { get; set; }

        [Required]
        [Range(1888, int.MaxValue)] //force the year the first movie came out to be the only possible low answer
        public int Year { get; set; }

        [ForeignKey("CategoryId")]
        public int? CategoryId { get; set; } //This used to be genre, now is used for a foreign key
        //public Categories? Category { get; set; } I don't think this is neccesary, being used in the other table

        [Required]
        public string Rating { get; set; }
        //This one is not required
        [Required]
        public int Edited { get; set; }
        //This one is not required
        public string? LentTo { get; set; }

        [Required]
        public int CopiedToPlex { get; set; }

        //This one is not required
        public string? Notes { get; set;}



    }
}
