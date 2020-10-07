// <auto-generated>

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Tester.Integration.EfCore3.Single_context_many_files
{
    // UserInfo
    public class UserInfo
    {
        public int Id { get; set; } // Id (Primary key)

        // Reverse navigation

        /// <summary>
        /// Child UserInfoAttributes where [UserInfoAttributes].[PrimaryId] point to this entity (FK_UserInfoAttributes_PrimaryUserInfo)
        /// </summary>
        public virtual ICollection<UserInfoAttribute> UserInfoAttributes_PrimaryId { get; set; } // UserInfoAttributes.FK_UserInfoAttributes_PrimaryUserInfo

        /// <summary>
        /// Child UserInfoAttributes where [UserInfoAttributes].[SecondaryId] point to this entity (FK_UserInfoAttributes_SecondaryUserInfo)
        /// </summary>
        public virtual ICollection<UserInfoAttribute> UserInfoAttributes_SecondaryId { get; set; } // UserInfoAttributes.FK_UserInfoAttributes_SecondaryUserInfo

        public UserInfo()
        {
            UserInfoAttributes_PrimaryId = new List<UserInfoAttribute>();
            UserInfoAttributes_SecondaryId = new List<UserInfoAttribute>();
        }
    }

}
// </auto-generated>
