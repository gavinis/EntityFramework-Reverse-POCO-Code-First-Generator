// <auto-generated>

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Tester.Integration.EfCore3.Multi_context_many_filesAppleDbContext
{
    // Foo
    public class Stafford_Foo
    {
        public int id { get; set; } // id (Primary key)

        // Foreign keys

        /// <summary>
        /// Parent Stafford_Boo pointed by [Foo].([id]) (FK_Foo_Boo)
        /// </summary>
        public virtual Stafford_Boo Stafford_Boo { get; set; } // FK_Foo_Boo
    }

}
// </auto-generated>
