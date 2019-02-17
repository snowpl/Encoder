using EncodingExtension;
using InsuranceModule.DataContracts;

namespace InsuranceModule.Interfaces
{
    public interface IInsuranceCoder : IGeneralCoder<InsuranceInformation>
    {
        InsuranceInformation ExtractInsuranceData(ExternalInsurance externalData, InternalInsurance internalData);
    }
}
