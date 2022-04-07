namespace MyDeal.TechTest.Services
{
    public interface IUserService
    {
        Task<User?> GetUserDetails(string userId);
    }
}
