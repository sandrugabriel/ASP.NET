namespace MasiniApi.Users.Dto;

public class RegisterRequest
{
    public string Email { get; set; }
    
    public string Password { get; set; }
    
    public string Name { get; set; }
    
    public int Age { get; set; }
}