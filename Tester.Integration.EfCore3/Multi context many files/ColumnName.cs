// <auto-generated>

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Tester.Integration.EfCore3.Multi_context_many_filesCherry
{
    // ColumnNames
    /// <summary>
    /// This is to document the
    /// table with poor column name choices
    /// </summary>
    public class ColumnName
    {
        [ExampleForTesting("abc")]
        [CustomRequired]
        public int Dollar { get; set; } // $ (Primary key)

        [ExampleForTesting("def")]
        [CustomSecurity(SecurityEnum.Readonly)]
        public int? Pound { get; set; } // £
        public int? StaticField { get; set; } // static
        public int? Day { get; set; } // readonly
    }

}
// </auto-generated>
