using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spidedex.Helper
{
    public class NetworkConnectivity
    {
        public static bool IsConnected()
        {
            NetworkAccess accessType = Connectivity.Current.NetworkAccess;

            if (accessType == NetworkAccess.Internet)
            {
                return true;
            } else
            {
                return false;
            }
        }
    }
}
