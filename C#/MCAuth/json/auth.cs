using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Windows.Forms;

namespace MCAuth.json
{
    [DataContract]
    class auth
    {
        [DataMember(Order = 0, IsRequired = true)]
        public string accessToken;
        [DataMember(Order = 1, IsRequired = true)]
        public string clientToken;
        [DataMember(Order = 2, IsRequired = false)]
        public selectedProfile selectedProfile;
        [DataMember(Order = 3, IsRequired = false)]
        public user user;
        
        /// <summary>
        /// 取twitch传递参数
        /// </summary>
        /// <param name="user">auth.user</param>
        /// <returns>成功返回传递参数，失败返回nul</returns>
        public String twitch(user user)
        {
            if (user.properties != null)
            {
                StringBuilder twitchData = new StringBuilder();
                twitchData.Append("{\"").Append(user.properties[0].name).Append("\":[\"").Append(user.properties[0].value).Append("\"]}");
                return twitchData.ToString();
            }
            else
                return null;
        }
    }
}
