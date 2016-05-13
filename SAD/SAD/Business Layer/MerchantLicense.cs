using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAD
{
    class MerchantLicense
    {
        private DateTime issuanceDate;
        private DateTime expirationDate;
        private string licenseNumber;
        private License license;
        public MerchantLicense(DateTime iDate, DateTime eDate, string licenseNum, License license)
        {
            issuanceDate = iDate;
            expirationDate = eDate;
            licenseNumber = licenseNum;
            this.license = license;
        }
    }
}
