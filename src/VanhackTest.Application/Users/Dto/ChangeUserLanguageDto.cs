using System.ComponentModel.DataAnnotations;

namespace VanhackTest.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}