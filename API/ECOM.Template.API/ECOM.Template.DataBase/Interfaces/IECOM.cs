using ECOM.Template.Models.ECOM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECOM.Template.DataBase.Interfaces
{
    public interface IECOM
    {
        Task<ECPathGateway?> GetUrlPath(string pathOrigin);
    }
}
