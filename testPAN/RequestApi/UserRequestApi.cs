using System.ComponentModel.DataAnnotations;

namespace testPAN.RequestApi
{
    public class UserRequestApi
    {
        [Required(ErrorMessage = "Обязательное поле для заполнения")]
        [Range(100000000,999999999, ErrorMessage = "Длинна унп 9 цифр")]
        public int pan { get; set; }

        [Required(ErrorMessage = "Обязательное поле для заполнения")]
        [EmailAddress(ErrorMessage = "Не валидный email")]
        public string email { get;set; }

    }
}
