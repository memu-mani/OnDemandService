using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
                technicianList.Add(new Technician { Name = "Technician 2", Lat = "33.84659", Lang = "-84.35886", skill = "Fios Agent" });
                technicianList.Add(new Technician { Name = "Technician 3", Lat = "33.84659", Lang = "-84.35889", skill = "Fios Agent" });

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
                List<Message> Messages = new List<Message>();


                Messages.Add(new Message { ReuqestId = "PA093495733", RequestDateTime= DateTime.Now.AddDays(-1).ToShortDateString(), details="You have requested for equipment repair", TechnicianLat = "33.846553", TechnicianLang = "-84.35886"});
                Messages.Add(new Message { ReuqestId = "PA111111111", RequestDateTime = DateTime.Now.AddDays(-1).ToShortDateString(), details = "You have requested for Internet repair", TechnicianLat = "33.848553", TechnicianLang = "-84.35486" });


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
    }
}

