using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace MCAuth.json
{
    [DataContract]
    class user
    {
        [DataMember(Order = 0, IsRequired = false)]
        public string id;
        [DataMember(Order = 1, IsRequired = false)]
        public properties[] properties;
    }

    [DataContract]
    class properties
    {
        [DataMember(Order = 0, IsRequired = false)]
        public string name;
        [DataMember(Order = 1, IsRequired = false)]
        public string value;
    }
}
