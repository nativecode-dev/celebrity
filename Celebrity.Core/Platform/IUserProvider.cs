namespace Celebrity.Core.Platform
{
    using System.Security.Principal;
    using System.Threading.Tasks;

    public interface IUserProvider
    {
        Task<IPrincipal> GetCurrentPrincipalAsync();
    }
}