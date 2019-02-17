using System;
using System.Collections.Generic;
using InsuranceModule.Interfaces;
using InsuranceModule.DataContracts;
using System.Linq;

namespace InsuranceModule.Services
{
    public class InsuranceService
    {
        private readonly IInsuranceCoder _insuranceCoder;
        private readonly IEnumerable<InternalInsurance> _internalInsurances;
        private readonly IEnumerable<ExternalInsurance> _externalInsurances;

        public InsuranceService(IInsuranceCoder insuranceCoder,
            IEnumerable<InternalInsurance> internalInsurances,
            IEnumerable<ExternalInsurance> externalInsurances
            )
        {
            _insuranceCoder = insuranceCoder ?? throw new ArgumentNullException(nameof(_insuranceCoder));
            _internalInsurances = internalInsurances;
            _externalInsurances = externalInsurances;
        }

        public bool CheckInsurances(InsuranceInformation insuranceBase, string insuranceResult)
        {
            var externalInsurance =_insuranceCoder.Decode(insuranceResult);
            return externalInsurance.Equals(insuranceBase);
        }

        public string SendInsuranceInformation(string externalId, string internalId)
        {
            var externalInsurane = GetExternalInsurance(externalId);
            var internalInsurance = GetInternalInsurance(internalId);
            var insurance = _insuranceCoder.ExtractInsuranceData(externalInsurane, internalInsurance);
            return _insuranceCoder.Encode(insurance);
        }

        private InternalInsurance GetInternalInsurance(string internalId)
        {
            return _internalInsurances.FirstOrDefault(x => x.InsuranceNumber.Equals(internalId));
        }

        private ExternalInsurance GetExternalInsurance(string externalId)
        {
            return _externalInsurances.FirstOrDefault(x => x.ExternalInsuranceNumber.Equals(externalId));
        }
    }
}
