namespace ApartmentsAPI.Services.AuthServices.Contracts
{
    using ApartmentsAPI.Enums;
    public interface IPasswordHasher
    {
        public string HashPassword(string password);
        public PasswordVerificationResult VerifyHashedPassword(string hashedPassword, string password);
    }
}
