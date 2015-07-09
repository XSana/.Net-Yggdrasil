using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace MCAuth.json
{
    [DataContract]
    class selectedProfile
    {
        [DataMember(Order = 0, IsRequired = false)]
        public string name = "";
        [DataMember(Order = 1, IsRequired = false)]
        public string id = "";
    }
}
