using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Microsoft.Extensions.Logging;

namespace netfwWCFRest
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class RestService : IRestService
    {
        private ILogger _logger = new LoggerFactory().CreateLogger("<wcf rest>");

        public List<string> AllPatients()
        {
            var patients = new List<string>();
            patients.Add("abc");
            patients.Add("xyz");

            _logger.LogInformation("retrieve patient list {0} \n {1}", patients[0], patients[1]);

            return patients;
        }

        public string GetPatientData(string patientName)
        {
            var data = "patient data";
            _logger.LogInformation("patient data {0} - {1}", patientName, data);
            return data;
        }

        public string GetSomething(string id)
        {
            var data = "some data";
            _logger.LogInformation("some data {0} - {1}", id, data);
            return data;
        }
    
        public string GetSomething2(string id)
        {
            var data = "some data 2";
            _logger.LogInformation("some data 2 {0} - {1}", id, data);
            return data;
        }

        public string GetPatientData2(string patientName)
        {
            var data = "data of patient 2";
            _logger.LogInformation("patient data {0} - {1}", patientName, data);
            return data;
        }

        public string GetPatientData3(string patientName)
        {
            var data = "data of patient 3";
            _logger.LogInformation("patient 3 data {0} - {1}", patientName, data);
            return data;
        }

        public void UpdatePatient(string patientId, string patientName)
        {
            _logger.LogInformation("update id and name {0} - {1}", patientName, patientId);
        }

        public string UpdatePatientAllergy(string patientName)
        {
            _logger.LogInformation("patient allergy {0} - {1}", patientName, "whatever");
            return "update done";
        }
    }
}
