using MasiniApi.Cars.Models;

namespace MasiniApi.Users.Dto;

public class UserResponse
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public int Age { get; set; }

    public List<Car> Cars { get; set; }
}