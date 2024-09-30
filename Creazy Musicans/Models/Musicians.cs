using System.ComponentModel.DataAnnotations;

namespace Creazy_Musicans.Models
{
    public class Musicians
    {
        [Required (ErrorMessage ="Bu alanı doldurmak zorunludur")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Bu alanı doldurmak zorunludur")]
        public int Id { get; set; }

        [StringLength(50,ErrorMessage ="1 ile 50 karakter arası giriniz")]
        public string  Job { get; set; }

        [StringLength (100,ErrorMessage ="100 karakterden fazla karakter girişi yapılamaz ")]
        public string Feature { get; set; }
        public bool  IsDelete { get; set; }
    }
}
