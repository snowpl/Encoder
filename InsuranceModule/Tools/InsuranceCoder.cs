using EncodingExtension;
using InsuranceModule.DataContracts;
using InsuranceModule.Interfaces;

namespace InsuranceModule.Tools
{
    public class InsuranceCoder : GeneralCoder<InsuranceInformation>, IInsuranceCoder
    {
        public InsuranceInformation ExtractInsuranceData(ExternalInsurance externalData, InternalInsurance internalData)
        {
            return new InsuranceInformation()
            {
                ExternalInsuranceNumber = externalData.ExternalInsuranceNumber,
                InsuranceNumber = internalData.InsuranceNumber,
                IsDiscountProtected = internalData.IsDiscountProtected,
                UserId = internalData.UserId,
                Price = externalData.Price
            };
        }
    }
}
