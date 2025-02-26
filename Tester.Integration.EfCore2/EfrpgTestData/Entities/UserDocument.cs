// <auto-generated>
// ReSharper disable All

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Tester.Integration.EfCore2
{
    // User_Document
    public class UserDocument
    {
        public int Id { get; set; } // ID (Primary key)
        public int UserId { get; set; } // UserID
        public int CreatedByUserId { get; set; } // CreatedByUserID

        // Foreign keys

        /// <summary>
        /// Parent User pointed by [User_Document].([CreatedByUserId]) (FK_User_Document_User1)
        /// </summary>
        public User CreatedByUser { get; set; } // FK_User_Document_User1

        /// <summary>
        /// Parent User pointed by [User_Document].([UserId]) (FK_User_Document_User)
        /// </summary>
        public User User_UserId { get; set; } // FK_User_Document_User
    }

}
// </auto-generated>
