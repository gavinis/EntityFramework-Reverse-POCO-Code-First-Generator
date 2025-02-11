// <auto-generated>
// ReSharper disable All

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Tester.Integration.EfCore2
{
    // Blarg
    public class Blarg
    {
        public int BlargId { get; set; } // BlargID (Primary key)

        // Reverse navigation

        /// <summary>
        /// Child BlahBlargLinks where [BlahBlargLink].[BlargID] point to this entity (FK_BlahBlargLink_Blarg)
        /// </summary>
        public ICollection<BlahBlargLink> BlahBlargLinks { get; set; } // BlahBlargLink.FK_BlahBlargLink_Blarg

        public Blarg()
        {
            BlahBlargLinks = new List<BlahBlargLink>();
        }
    }

}
// </auto-generated>
