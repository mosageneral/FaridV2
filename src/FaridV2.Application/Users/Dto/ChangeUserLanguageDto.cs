using System.ComponentModel.DataAnnotations;

namespace FaridV2.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}