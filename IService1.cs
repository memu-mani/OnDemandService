﻿using System;
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
               UriTemplate = "GetRepairTechnician/{type}")]
        [OperationContract]
        string GetRepairTechnician(string type);

        [WebInvoke(Method = "GET",
              BodyStyle = WebMessageBodyStyle.WrappedRequest,
              RequestFormat = WebMessageFormat.Json,
              ResponseFormat = WebMessageFormat.Json,
              UriTemplate = "GetNewFiosAgent")]
        [OperationContract]
        string GetNewFiosAgent();


        [WebInvoke(Method = "GET",
              BodyStyle = WebMessageBodyStyle.WrappedRequest,
              RequestFormat = WebMessageFormat.Json,
              ResponseFormat = WebMessageFormat.Json,
              UriTemplate = "GetCustomerLocation")]
        [OperationContract]
        string GetCustomerLocation();

        [WebInvoke(Method = "GET",
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "SetCustomerLocation/{location}")]
        [OperationContract]
        void SetCustomerLocation(string location);

        [WebInvoke(Method = "GET",
             BodyStyle = WebMessageBodyStyle.WrappedRequest,
             RequestFormat = WebMessageFormat.Json,
             ResponseFormat = WebMessageFormat.Json,
             UriTemplate = "GetTechLocation")]
        [OperationContract]
        string GetTechLocation();


        [WebInvoke(Method = "GET",
              BodyStyle = WebMessageBodyStyle.WrappedRequest,
              RequestFormat = WebMessageFormat.Json,
              ResponseFormat = WebMessageFormat.Json,
              UriTemplate = "GetAvialbleMessages/{id}")]
        [OperationContract]
        string GetAvialbleMessages(string id);

        [WebInvoke(Method = "GET",
             BodyStyle = WebMessageBodyStyle.WrappedRequest,
             RequestFormat = WebMessageFormat.Json,
             ResponseFormat = WebMessageFormat.Json,
             UriTemplate = "UpdateAppointment/{date}")]
        [OperationContract]
        string UpdateAppointment(string date);

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

    [DataContract]
    public class Message
    {
        [DataMember]
        public string ReuqestId;
        [DataMember]
        public string RequestDateTime;
        [DataMember]
        public string details;
        [DataMember]
        public string TechnicianLang;
        [DataMember]
        public string TechnicianLat;

    }

}

