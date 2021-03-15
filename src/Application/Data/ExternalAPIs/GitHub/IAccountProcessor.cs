using CNode.Domain.Models;
using System.Threading.Tasks;

namespace CNode.Application.Data.ExternalAPIs.GitHub
{
    public interface IAccountProcessor
    {
        Task<AuthToken> GetTokenAsync(string code);
    }
}
