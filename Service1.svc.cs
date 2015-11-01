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
                    technicianList.Add(new Technician { Name = "Technician 1", Lat = "33.846543", Lang = "-84.35884", skill = "equipment service" });
                    technicianList.Add(new Technician { Name = "Technician 2", Lat = "33.846553", Lang = "-84.35887", skill = "equipment service" });
                    technicianList.Add(new Technician { Name = "Technician 3", Lat = "33.846553", Lang = "-84.35888", skill = "equipment service" });
                }

                else if (type == "repairTv")
                {
                    technicianList.Add(new Technician { Name = "Technician 1", Lat = "32.84659", Lang = "-83.35686", skill = "equipment service" });
                    technicianList.Add(new Technician { Name = "Technician 2", Lat = "31.846553", Lang = "-84.35886", skill = "equipment service" });
                    technicianList.Add(new Technician { Name = "Technician 3", Lat = "30.846653", Lang = "-83.366125", skill = "equipment service" });
                }
                else if (type == "repairSpeed")
                {
                    technicianList.Add(new Technician { Name = "Technician 1", Lat = "32.84659", Lang = "-83.35686", skill = "equipment service" });
                    technicianList.Add(new Technician { Name = "Technician 2", Lat = "31.846553", Lang = "-84.35886", skill = "equipment service" });
                    technicianList.Add(new Technician { Name = "Technician 3", Lat = "30.846653", Lang = "-83.366125", skill = "equipment service" });
                }
                else if (type == "repairRouter")
                {
                    technicianList.Add(new Technician { Name = "Technician 1", Lat = "32.84659", Lang = "-83.35686", skill = "equipment service" });
                    technicianList.Add(new Technician { Name = "Technician 2", Lat = "31.846553", Lang = "-84.35886", skill = "equipment service" });
                    technicianList.Add(new Technician { Name = "Technician 3", Lat = "30.846653", Lang = "-83.366125", skill = "equipment service" });
                }

                DataContractJsonSerializer serializer = new DataContractJsonSerializer(technicianList.GetType());
                MemoryStream memoryStream = new MemoryStream();
                serializer.WriteObject(memoryStream, technicianList);


                string json = Encoding.Default.GetString(memoryStream.ToArray());
                return json;

            }catch( Exception  ex)
            {
                return "No Technician availabe";
            }                     
        }
        public string GetNewFiosAgent()
        {
            try
            {
                List<Technician> technicianList = new List<Technician>();

                technicianList.Add(new Technician { Name = "Technician 1", Lat = "33.84659", Lang = "-84.35680", skill = "Fios Agent" });
                technicianList.Add(new Technician { Name = "Technician 2", Lat = "33.84655", Lang = "-84.35886", skill = "Fios Agent" });
                technicianList.Add(new Technician { Name = "Technician 3", Lat = "33.84663", Lang = "-84.35889", skill = "Fios Agent" });
                technicianList.Add(new Technician { Name = "Technician 2", Lat = "33.84651", Lang = "-84.35885", skill = "Fios Agent" });
                technicianList.Add(new Technician { Name = "Technician 3", Lat = "33.84489", Lang = "-84.35889", skill = "Fios Agent" });

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
                
                List<Customer> customer = new List<Customer>();


                customer.Add(new Customer { Name = "Home", Lat = "33.846553", Lang = "-84.35886", ServiceType = "TV - DATA -FDV" });
            

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


                customer.Add(new Technician { Name = "Home", Lat = "33.846553", Lang = "-84.35886" });


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
    }
}

