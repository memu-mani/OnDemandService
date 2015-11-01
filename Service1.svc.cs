using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Caching;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml;

namespace VerizonRepairService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        //    public string GetData(int value)
        //    {
        //        return string.Format("You entered: {0}", value);
        //    }

        //    public CompositeType GetDataUsingDataContract(CompositeType composite)
        //    {
        //        if (composite == null)
        //        {
        //            throw new ArgumentNullException("composite");
        //        }
        //        if (composite.BoolValue)
        //        {
        //            composite.StringValue += "Suffix";
        //        }
        //        return composite;
        //    }
        public string GetRepairTechnician(string type)
        {
            try
            {
                List<Technician> technicianList = new List<Technician>();

                if (type == "repairPhone")
                {
                    technicianList.Add(new Technician { Name = "Technician 1", Lat = "80.24434500000006", Lang = "12.971105", skill = "equipment service" });
                    technicianList.Add(new Technician { Name = "Technician 1", Lat = "80.24433510000005", Lang = "12.981106", skill = "equipment service" });
                    technicianList.Add(new Technician { Name = "Technician 1", Lat = "80.24432520000006", Lang = "12.975006", skill = "equipment service" });
                }

                else if (type == "repairTv")
                {
                    technicianList.Add(new Technician { Name = "Technician 1", Lat = "80.24434500000006", Lang = "12.971105", skill = "equipment service" });
                    technicianList.Add(new Technician { Name = "Technician 1", Lat = "80.24433510000005", Lang = "12.981106", skill = "equipment service" });
                }
                else if (type == "repairSpeed")
                {
                    technicianList.Add(new Technician { Name = "Technician 1", Lat = "80.24434500000006", Lang = "12.972105", skill = "equipment service" });
                    technicianList.Add(new Technician { Name = "Technician 1", Lat = "80.24433500000006", Lang = "12.971105", skill = "equipment service" });
                    technicianList.Add(new Technician { Name = "Technician 1", Lat = "80.24432500045606", Lang = "12.974105", skill = "equipment service" });
                }
                else if (type == "repairRouter")
                {
                    technicianList.Add(new Technician { Name = "Technician 1", Lat = "80.24434500000006", Lang = "12.971105", skill = "equipment service" });
                }

                DataContractJsonSerializer serializer = new DataContractJsonSerializer(technicianList.GetType());
                MemoryStream memoryStream = new MemoryStream();
                serializer.WriteObject(memoryStream, technicianList);


                string json = Encoding.Default.GetString(memoryStream.ToArray());
                return json;

            }
            catch (Exception ex)
            {
                return "";
            }                     
        }
        public string GetNewFiosAgent()
        {
            try
            {
                List<Technician> technicianList = new List<Technician>();

                technicianList.Add(new Technician { Name = "Technician 1", Lat = "80.24434500000010", Lang = "12.97105", skill = "Fios Agent" });
                technicianList.Add(new Technician { Name = "Technician 2", Lat = "80.24434500000546", Lang = "12.971105", skill = "Fios Agent" });

                DataContractJsonSerializer serializer = new DataContractJsonSerializer(technicianList.GetType());
                MemoryStream memoryStream = new MemoryStream();
                serializer.WriteObject(memoryStream, technicianList);


                string json = Encoding.Default.GetString(memoryStream.ToArray());
                return json;

            }
            catch (Exception ex)
            {
                return "No Agent availabe";
            }
        }

        public string GetCustomerLocation()
        {
            try
            {
                Customer customer = GetCustomerFromCache();
                if (customer == null)
                {
                    customer = new Customer() { Name = "Home", Lat = "80.24434500000006", Lang = "12.971105", ServiceType = "TV - DATA -FDV" };
                    AddCustomerToCache(customer);
                }

                DataContractJsonSerializer serializer = new DataContractJsonSerializer(customer.GetType());
                MemoryStream memoryStream = new MemoryStream();
                serializer.WriteObject(memoryStream, customer);


                string json = Encoding.Default.GetString(memoryStream.ToArray());
                return json;
            }
            catch (Exception ex)
            {
                return "No Service at availabe";
            }
        }

        public void SetCustomerLocation(string location)
        {
            try
            {
                var lanLat = location.Split(new char[] { '|' });

                var customer  = new Customer() { Name = "John Smith", Lat = lanLat[0], Lang = lanLat[0], ServiceType = "TV - DATA -FDV" };

                AddCustomerToCache(customer);
            }
            catch (Exception ex)
            {
               
            }
        }

        public string GetAvialbleMessages(string id)
        {
            
            try
            {
                List<Message> messages = GetMessageFromCache();

                if (messages == null)
                {
                    var msg = new Message { ReuqestId = "NA", RequestDateTime = DateTime.Now.ToShortDateString(), details = "No Messages" };
                    messages = new List<Message>();
                    messages.Add(msg);
                }

                DataContractJsonSerializer serializer = new DataContractJsonSerializer(messages.GetType());
                MemoryStream memoryStream = new MemoryStream();
                serializer.WriteObject(memoryStream, messages);


                string json = Encoding.Default.GetString(memoryStream.ToArray());
                return json;

            }
            catch (Exception ex)
            {
                return "No Service at availabe";
            }

        }

        public string UpdateAppointment(string date)
        {
            try
            {
                if (date != null)
                {
                    var msg = new Message { ReuqestId = "PA093495733", RequestDateTime = DateTime.Now.ToShortDateString(), details = "New Order created. Appointemt Time :"+ date , TechnicianLat = "33.846553", TechnicianLang = "-84.35886" };
                    if(date== "now")
                    { msg = new Message { ReuqestId = "PA093495733", RequestDateTime = DateTime.Now.ToShortDateString(), details = "New Order created. Appointemt Time :" + DateTime.Now.AddHours(2), TechnicianLat = "33.846553", TechnicianLang = "-84.35886" }; }
                    AddToMessageCache(msg);
                }

                List<Message> Messages = GetMessageFromCache();

                DataContractJsonSerializer serializer = new DataContractJsonSerializer(Messages.GetType());
                MemoryStream memoryStream = new MemoryStream();
                serializer.WriteObject(memoryStream, Messages);

                string json = Encoding.Default.GetString(memoryStream.ToArray());
                return json;

            }
            catch (Exception ex)
            {
                return "No Service at availabe";
            }

        }


        public string GetTechLocation()
        {
            try
            {

                List<Technician> customer = new List<Technician>();


                customer.Add(new Technician { Name = "Home", Lat = "80.24434500000006", Lang = "12.971105" });


                DataContractJsonSerializer serializer = new DataContractJsonSerializer(customer.GetType());
                MemoryStream memoryStream = new MemoryStream();
                serializer.WriteObject(memoryStream, customer);


                string json = Encoding.Default.GetString(memoryStream.ToArray());
                return json;

            }
            catch (Exception ex)
            {
                return "No Service at availabe";
            }
        }

        private void AddToMessageCache(Message msg)
        {
            ObjectCache cache = MemoryCache.Default;

            CacheItemPolicy policy = new CacheItemPolicy();

            List<Message> messages = cache["Messages"] as List<Message>;
            if(messages == null)
            {
                messages = new List<Message>();
               
            }
            messages.Add(msg);

            //cache.Set("Messages", messa
            cache.Add("Messages", messages, DateTimeOffset.MaxValue);
        }

        private List<Message> GetMessageFromCache()
        {
            ObjectCache cache = MemoryCache.Default;

            CacheItemPolicy policy = new CacheItemPolicy();

            List<Message> messages = cache["Messages"] as List<Message>;
            return messages;
        }

        private Customer GetCustomerFromCache()
        {
            ObjectCache cache = MemoryCache.Default;

            CacheItemPolicy policy = new CacheItemPolicy();

            Customer customer = cache["Customer"] as Customer;
            return customer;
;
        }

        private void AddCustomerToCache(Customer customer)
        {
            ObjectCache cache = MemoryCache.Default;

            CacheItemPolicy policy = new CacheItemPolicy();

            cache.Add("Customer", customer, DateTimeOffset.MaxValue);
        }
    }
}

