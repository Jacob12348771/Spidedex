using Spidedex.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spidedex.Services
{
    public interface IDataAccessService
    {
        Task<IEnumerable<Spider>> GetSpidersAsync(string userDetails);
        Task<bool> AddUpdateSpiderAsync(Spider spider);
        Task<bool> DeleteSpiderAsync(int spiderId);
        Task<Spider> GetSpiderAsync(int spiderId);
    }
}
