using System;
using System.Collections.Generic;
using InsuranceModule.DataContracts;
using InsuranceModule.Services;
using InsuranceModule.Tools;
using Xunit;

namespace InsuranceModuleTests
{
    public class UnitTest1
    {
        private readonly InsuranceService _insuranceService;
        private readonly InsuranceCoder _insuranceCoder;
        private const string InsuranceHardCodedEncoded = "0A01311201311801220608A08D0618042A023158";
        public UnitTest1()
        {
            _insuranceCoder = new InsuranceCoder();
            var externalInsurances = new List<ExternalInsurance>()
            {
               CreateExternalInsurance("1X", 1000.00M),
               CreateExternalInsurance("X12", 1000.00M),
               CreateExternalInsurance("X12", 100.00M),
            };
            var internalInsurances = new List<InternalInsurance>()
            {
                CreateInternalInsurance("1", "1", isProtected: true),
                CreateInternalInsurance("1", "2", isProtected: true),
                CreateInternalInsurance("2", "1", isProtected: true),
                CreateInternalInsurance("2", "2", isProtected: true),
            };

        _insuranceService = new InsuranceService(_insuranceCoder, internalInsurances, externalInsurances);
        }

        [Fact(Skip = "This test will fail if we change anything")]
        public void IsuranceIsEncodedRight()
        {
            Assert.Equal(InsuranceHardCodedEncoded, _insuranceService.SendInsuranceInformation("1X", "1"));
        }

        [Fact]
        public void InsuranceIsCorrectlyEncoded()
        {
            var result = _insuranceService.SendInsuranceInformation("1X", "1");
            var externalData = CreateExternalInsurance("1X", 1000.00M);
            var internalData = CreateInternalInsurance("1", "1", isProtected: true);
            var insuranceBase = _insuranceCoder.ExtractInsuranceData(externalData, internalData);
            Assert.True(_insuranceService.CheckInsurances(insuranceBase, result));
            result = _insuranceService.SendInsuranceInformation("X12", "1");
            Assert.True(_insuranceService.CheckInsurances(insuranceBase, result));
        }
        
        private InternalInsurance CreateInternalInsurance(string number, string someId, bool isProtected)
        {
            return new InternalInsurance()
            {
                InsuranceNumber = number,
                UserId = someId,
                IsDiscountProtected = isProtected,
                ValidFrom = DateTime.UtcNow.AddDays(5),
                ValidTo = DateTime.UtcNow.AddDays(15)
            };
        }

        private ExternalInsurance CreateExternalInsurance(string insuranceNumber, decimal price)
        {
            return new ExternalInsurance()
            {
                Details = "some details",
                ExternalInsuranceNumber = insuranceNumber,
                Price = price
            };
        }
    }
}
