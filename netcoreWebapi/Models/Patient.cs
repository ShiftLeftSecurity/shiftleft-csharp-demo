using System;

namespace netcoreWebapi
{
    public class Patient
    {
        public Patient()
        {}

        public long Id { get; set; }

        public int PatientId { get; set; }

        public string PatientFirstName { get; set; }

        public string PatientLastName { get; set; }

        public int PatientWeight { get; set; }

        public int PatientHeight { get; set; }
    }
}
