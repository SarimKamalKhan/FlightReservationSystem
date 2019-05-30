using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace DataTransferObjects
{
    public class TransactionResultsDTO
    {
        [Serializable]
        [DataContract]
        public class TransactionResultDTO
        {
            [DataMember]
            public string ResponseCode { get; set; }

            [DataMember]
            public string ResponseDescription { get; set; }

            [DataMember]
            public string TransactionReferenceNumber { get; set; }

            [DataMember]
            public bool IsSuccessful { get; set; }
            [DataMember]
            public string AdditionalData { get; set; }

            [DataMember]
            public string IsRedirect { get; set; }

        }
    }
}
