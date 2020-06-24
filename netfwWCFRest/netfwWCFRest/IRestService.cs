using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace netfwWCFRest
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IRestService
    {
        [OperationContract]
        [WebGet(UriTemplate = "/PatientData/{patientName}")]
        string GetPatientData(string patientName);

        [OperationContract]
        [WebGet(UriTemplate = "/Something/{id}")]
        string GetSomething(string id);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/PatientData2/{patientName}")]
        string GetPatientData2(string patientName);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/Something/{id}")]
        string GetSomething2(string id);

        [OperationContract]
        [WebInvoke(Method = "GET",
                   RequestFormat = WebMessageFormat.Json,
                   ResponseFormat = WebMessageFormat.Json,
                   UriTemplate = "/PatientData3/{patientName}")]
        string GetPatientData3(string patientName);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "/Patients/{patientName}")]
        string UpdatePatientAllergy(string patientName);

        [OperationContract]
        [WebInvoke(UriTemplate = "UpdatePatient/{patientId}/{patientName}")]
        void UpdatePatient(string patientId, string patientName);

        [OperationContract]
        [WebGet]
        List<string> AllPatients();
    }
}
