//using ECOM.Template.Models;
using ECOM.Utils.Nuget.Models;

namespace ECOM.Template.Services.Interfaces
{
    public interface ICallService
    {
        Task<HttpResponseMessage> CallService(object requestOrder, string pathExecute, HttpVerb httpVerb, Dictionary<string, IEnumerable<string>> Headers);
    }
}
