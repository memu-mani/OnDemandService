using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace VerizonRepairService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {               

        [WebInvoke(Method = "GET",
               BodyStyle = WebMessageBodyStyle.WrappedRequest,
               RequestFormat = WebMessageFormat.Json,
               ResponseFormat = WebMessageFormat.Json,
               UriTemplate = "GetRepairTechnician/{0}")]
        [OperationContract]
        string GetRepairTechnician(string problemType);

        [WebInvoke(Method = "GET",
              BodyStyle = WebMessageBodyStyle.WrappedRequest,
              RequestFormat = WebMessageFormat.Json,
              ResponseFormat = WebMessageFormat.Json,
              UriTemplate = "GetInstallTechnician")]
        [OperationContract]
        string GetInstallTechnician();


        [WebInvoke(Method = "GET",
              BodyStyle = WebMessageBodyStyle.WrappedRequest,
              RequestFormat = WebMessageFormat.Json,
              ResponseFormat = WebMessageFormat.Json,
              UriTemplate = "GetCustomerLocation")]
        [OperationContract]
        string GetCustomerLocation();

        
    }


    [DataContract]
    public class Technician
    {
        [DataMember]
        public string Name;
        [DataMember]
        public string Lang;
        [DataMember]
        public string Lat;
        [DataMember]
        public string skill;

    }

    [DataContract]
    public class Customer
    {
        [DataMember]
        public string Name;
        [DataMember]
        public string Lang;
        [DataMember]
        public string Lat;
        [DataMember]
        public string ServiceType;

    }

}
