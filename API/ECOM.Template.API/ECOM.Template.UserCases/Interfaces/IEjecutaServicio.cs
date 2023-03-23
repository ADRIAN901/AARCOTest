using ECOM.Utils.Nuget.Models;

namespace ECOM.Template.UserCases.Interfaces
{
    public interface IEjecutaServicio
    {
        Task<HttpResponseMessage> GeneraPeticion(object requestOrder, string pathExecute, int httpVerb, Dictionary<string, IEnumerable<string>> Headers);
        Task<HttpResponseMessage> GeneraPeticion(object requestOrder, string pathExecute, HttpVerb httpVerb, Dictionary<string, IEnumerable<string>> Headers);
    }
}
