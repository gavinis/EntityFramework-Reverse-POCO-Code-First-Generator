// <auto-generated>

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace V5EfrpgTest
{
    // v_Articles
    public class WVN_VArticle
    {
        public int? PkArticle { get; set; } // PK_Article
        public Guid? FkFactory { get; set; } // FK_Factory
        public int? FkArticleLevel { get; set; } // FK_ArticleLevel
        public int? FkParentArticle { get; set; } // FK_ParentArticle
        public string Code { get; set; } // Code (length: 20)
        public string FullCode { get; set; } // FullCode (length: 100)
    }

}
// </auto-generated>
