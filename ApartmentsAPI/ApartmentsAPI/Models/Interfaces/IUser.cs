namespace ApartmentsAPI.Models.Interfaces
{

    public interface IUser:IId
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string Username { get; set; }
        string Password { get; set; }
        string Token { get; set; }
    }
}
