using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace netfwWCFwithMVC
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IWcfService
    {
        [OperationContract]
        List<Patient> GetPatients1();

        [OperationContract]
        List<Patient> GetPatients2();

        [OperationContract]
        List<Patient> GetPatients3();

        [OperationContract]
        List<Patient> GetPatients4();

        [OperationContract]
        string GetPatients5();

        [OperationContract]
        string GetPatients6();

        [OperationContract]
        Patient GetPatientDetails(int patientId);

        [OperationContract]
        string SomeSoapData(int id);

        [OperationContract]
        void ModifySoapData(int id);
    }
}
