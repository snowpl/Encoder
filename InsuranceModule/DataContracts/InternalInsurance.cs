using System;

namespace InsuranceModule.DataContracts
{
    public class InternalInsurance
    {
        public string UserId { get; set; }
        public string InsuranceNumber { get; set; }
        public bool IsDiscountProtected { get; set; }
        public DateTime ValidTo { get; set; }
        public DateTime ValidFrom { get; set; }
    }
}
