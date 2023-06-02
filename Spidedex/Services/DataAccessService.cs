using Spidedex.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spidedex.Services
{
    internal class DataAccessService : IDataAccessService
    {
        public Task<bool> AddUpdateSpiderAsync(Spider spider)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteSpiderAsync(int spiderId)
        {
            throw new NotImplementedException();
        }

        public Task<Spider> GetSpiderAsync(int spiderId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Spider>> GetSpidersAsync(string userDetails)
        {
            throw new NotImplementedException();
        }
    }
}
