using System;
using System.Collections.Generic;
using System.Text;

namespace InsuranceModule.DataContracts
{
    public class User
    {
        public string UserId { get; set; }
        public string InternalInsuranceNumber { get; set; }
        public string ExternalInsuranceNumber { get; set; }
    }
}
