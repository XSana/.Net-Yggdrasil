﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

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
            if (user != null)
            {
                StringBuilder twitchData = new StringBuilder();
                twitchData.Append("{\"");
                twitchData.Append(user.properties[0].name);
                twitchData.Append("\":[\"").Append(user.properties[0].value);
                twitchData.Append("\"]}");
                return twitchData.ToString();
            }
            else
                return null;
        }
    }
}
