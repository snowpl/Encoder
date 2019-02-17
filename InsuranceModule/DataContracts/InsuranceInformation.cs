using System;
using ProtoBuf;

namespace InsuranceModule.DataContracts
{
    [ProtoContract]

    public class InsuranceInformation : IEquatable<InsuranceInformation>
    {
        [ProtoMember(1)]
        public string UserId { get; set; }
        [ProtoMember(2)]
        public string InsuranceNumber { get; set; }
        [ProtoMember(3)]
        public bool IsDiscountProtected { get; set; }
        [ProtoMember(4)]
        public decimal Price { get; set; }
        [ProtoMember(5)]
        public string ExternalInsuranceNumber { get; set; }
        

        public override bool Equals(object value)
        {
            if (Object.ReferenceEquals(null, value))
            {
                return false;
            }

            if (Object.ReferenceEquals(this, value))
            {
                return true;
            }

            if (value.GetType() != this.GetType())
            {
                return false;
            }

            return IsEqual((InsuranceInformation)value);
        }

        public bool Equals(InsuranceInformation insurance)
        {
            if (Object.ReferenceEquals(null, insurance))
            {
                return false;
            }
            
            if (Object.ReferenceEquals(this, insurance))
            {
                return true;
            }
            
            return IsEqual(insurance);
        }
        
        private bool IsEqual(InsuranceInformation insurance)
        {
            return Decimal.Equals(Price, insurance.Price)
                && String.Equals(UserId, insurance.UserId)
                && String.Equals(InsuranceNumber, insurance.InsuranceNumber)
                && Boolean.Equals(IsDiscountProtected, insurance.IsDiscountProtected);
        }


        public override int GetHashCode()
        {
            unchecked
            {
                // Choose large primes to avoid hashing collisions
                const int HashingBase = (int)2166136261;
                const int HashingMultiplier = 16777619;
                
                int hash = HashingBase;

                hash = (hash * HashingMultiplier) ^ (!Object.ReferenceEquals(null, Price) ? Price.GetHashCode() : 0);
                hash = (hash * HashingMultiplier) ^ (!Object.ReferenceEquals(null, UserId) ? UserId.GetHashCode() : 0);
                hash = (hash * HashingMultiplier) ^ (!Object.ReferenceEquals(null, InsuranceNumber) ? InsuranceNumber.GetHashCode() : 0);
                hash = (hash * HashingMultiplier) ^ (!Object.ReferenceEquals(null, IsDiscountProtected) ? IsDiscountProtected.GetHashCode() : 0);

                return hash;
            }
        }
    }
}
