namespace Veranda.Service.User.Api.Data.Entities;

public class User
{
    public long Id { get; set; }
    public Guid PublicId { get; set; }
    public string Email { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
}
