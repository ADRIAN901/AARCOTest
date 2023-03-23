using ECOM.DBAccess.Nuget;
using ECOM.DBAccess.Nuget.Logic.Interfaces;
using ECOM.Template.DataBase.Interfaces;
using ECOM.Template.Models.ECOM;
using Microsoft.Extensions.Configuration;

namespace ECOM.Template.DataBase.Implement
{
    public class ECOM : IECOM
    {
        private readonly IDataAccess _dataAccess;
        private readonly IConfiguration _configuration;
        private string connectionString;
        public ECOM(IDataAccess dataAccess, IConfiguration configuration)
        {
            _dataAccess = dataAccess;
            _configuration = configuration;
            connectionString = _configuration.GetConnectionString("ECOM");
        }
        public async Task<ECPathGateway?> GetUrlPath(string pathSource)
        {            
            var oECPathGateway = _dataAccess.ExecuteStoredProcedure<ECPathGateway>("spGetPathGateways", connectionString, 
                new StoredProcedureParameter { Name = "pcPathSource", Value = pathSource});
            if (oECPathGateway != null)
                return oECPathGateway[0];
            
            return null;
        }
    }
}
