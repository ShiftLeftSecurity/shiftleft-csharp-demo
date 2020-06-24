using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Microsoft.Extensions.Logging;

namespace netfwWCFwithMVC
{
    // NOTE: In order to launch WCF Test Client for testing this service,
    // please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class WcfService : IWcfService
    {
        private ILogger _logger = new LoggerFactory().CreateLogger("WCFLogger");

        public List<Patient> GetPatients1()
        {
            var patient = new Patient();
            patient.PatientId = 123;
            patient.FirstName = "John";
            patient.LastName = "Silva";

            var patients = new List<Patient>() { patient };

            foreach (var p in patients)
                _logger.LogInformation("retrieve patient <getpatients3>: {0} {1}", p.FirstName, p.LastName);

            return patients.ToList();
        }

        public List<Patient> GetPatients2()
        {
            MedicalDBEntities entities = new MedicalDBEntities();
            //var patients = from a in entities.Patients select a;
            var patients = entities.Patients.Select(p => p);

            foreach (var p in patients)
                _logger.LogInformation("retrieve patient <getpatients2>: {0} {1}", p.FirstName, p.LastName);

            return patients.ToList();
        }

        public List<Patient> GetPatients3()
        {
            MedicalDBEntities entities = new MedicalDBEntities();
            var patients = entities.Patients.Select(p => p);

            foreach (var p in patients)
                _logger.LogInformation("retrieve patient <getpatients3>: {0} {1}", p.FirstName, p.LastName);

            return patients.ToList();
        }

        public List<Patient> GetPatients4()
        {
            MedicalDBEntities entities = new MedicalDBEntities();
            var patients = entities.Patients.Where(p => p.PatientId == 1);

            _logger.LogInformation("query for patient by ID: {0}", patients.Count());

            return patients.ToList();
        }

        public string GetPatients5()
        {
            MedicalDBEntities entities = new MedicalDBEntities();
            var patients = entities.Patients.Any(p => p.PatientId == 1);
            
            _logger.LogInformation("query for patient by ID: {0}", patients);

            return "got patient: " + patients;
        }

        public string GetPatients6()
        {
            MedicalDBEntities entities = new MedicalDBEntities();
            var patients = from a in entities.Patients where a.PatientId == 1 select a;
            
            _logger.LogInformation("query for patient by ID: {0}", patients);

            return "got patient by SQL: " + patients;
        }

        public Patient GetPatientDetails(int patientId)
        {
            MedicalDBEntities entities = new MedicalDBEntities();
            var patient = entities.Patients.Find(1);

            _logger.LogInformation("<wcf service> get details of patient ID {0}", patientId);

            return patient;
        }

        public string SomeSoapData(int id)
        {
            _logger.LogInformation("some soap data: {0}", id);
            return "some soap data" + id;
        }

        public void ModifySoapData(int id)
        {
            _logger.LogInformation("modify soap data: {0}", id);
        }
    }
}
