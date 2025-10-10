namespace PresentationLayer.Models.AccountViewModel
{
    public class ResetPasswordViewModel
    {
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        [Required, DataType(DataType.Password), Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string Token { get; set; } // مهم علشان نقدر نتحقق من صلاحية الرابط
    }
}
