using System.ComponentModel.DataAnnotations;

namespace BlogProjectUI.Models
{
    public class UserSignInViewModel
    {
        [Required(ErrorMessage ="Lütfen kullanıcı adını giriniz")]
        public string username { get; set; }

        [Required(ErrorMessage ="lütfen şifrenizi giriniz")]
        public string password { get; set; }
    }
}
