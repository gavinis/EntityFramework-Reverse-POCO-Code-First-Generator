// <auto-generated>

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace V5Fred
{
    // Blah
    public class Blah
    {
        public int BlahId { get; set; } // BlahID (Primary key)

        // Reverse navigation

        /// <summary>
        /// Child Blahs (Many-to-Many) mapped by table [BlahBlahLink]
        /// </summary>
        public virtual ICollection<Blah> Blahs_BlahId2 { get; set; } // Many to many mapping

        /// <summary>
        /// Child Blahs (Many-to-Many) mapped by table [BlahBlahLink]
        /// </summary>
        public virtual ICollection<Blah> Blahs1 { get; set; } // Many to many mapping

        /// <summary>
        /// Child Blahs (Many-to-Many) mapped by table [BlahBlahLink_readonly]
        /// </summary>
        public virtual ICollection<Blah> Blahs2 { get; set; } // Many to many mapping

        /// <summary>
        /// Child Blahs (Many-to-Many) mapped by table [BlahBlahLink_readonly]
        /// </summary>
        public virtual ICollection<Blah> Blahs3 { get; set; } // Many to many mapping

        /// <summary>
        /// Child BlahBlahLinkV2 where [BlahBlahLink_v2].[BlahID] point to this entity (FK_BlahBlahLinkv2_Blah_ro)
        /// </summary>
        public virtual ICollection<BlahBlahLinkV2> BlahBlahLinkV2_BlahId { get; set; } // BlahBlahLink_v2.FK_BlahBlahLinkv2_Blah_ro

        /// <summary>
        /// Child BlahBlahLinkV2 where [BlahBlahLink_v2].[BlahID2] point to this entity (FK_BlahBlahLinkv2_Blah_ro2)
        /// </summary>
        public virtual ICollection<BlahBlahLinkV2> BlahBlahLinkV2_BlahId2 { get; set; } // BlahBlahLink_v2.FK_BlahBlahLinkv2_Blah_ro2

        /// <summary>
        /// Child Blargs (Many-to-Many) mapped by table [BlahBlargLink]
        /// </summary>
        public virtual ICollection<Blarg> Blargs { get; set; } // Many to many mapping

        public Blah()
        {
            BlahBlahLinkV2_BlahId = new List<BlahBlahLinkV2>();
            BlahBlahLinkV2_BlahId2 = new List<BlahBlahLinkV2>();
            Blahs1 = new List<Blah>();
            Blahs_BlahId2 = new List<Blah>();
            Blahs3 = new List<Blah>();
            Blahs2 = new List<Blah>();
            Blargs = new List<Blarg>();
        }
    }

}
// </auto-generated>