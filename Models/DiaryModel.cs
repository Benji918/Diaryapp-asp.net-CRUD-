using System.ComponentModel.DataAnnotations;

namespace Diaryapp.Models
{
    public class DiaryModel
    {
       
        public int Id { get; set; }
        [Required(ErrorMessage="Please enter a Title!")]
        //[StringLength(maximumLength:50, MinimumLength=3, ErrorMessage ="String length must be between 3 and 50!")]
        public string Title { get; set; } = string.Empty;
        [Required]
        public string Content { get; set; } = string.Empty;
        [Required]
        public DateTime Created_at { get; set; } = DateTime.Now;

    }
}

