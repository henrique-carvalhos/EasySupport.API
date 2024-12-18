namespace EasySupport.Core.Services
{
    public interface IAuthService
    {
        string GenereteJwtToken(string email, string role);
        string ComputeSha256Hash(string password);
    }
}
