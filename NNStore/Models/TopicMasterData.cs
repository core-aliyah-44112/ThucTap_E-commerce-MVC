using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NNStore.Context

{
    public partial class TopicMasterData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public int ParentId { get; set; }
        public int Orders { get; set; }
        public string MetaKey { get; set; }
        public string MetaDesc { get; set; }
        public int CreatedBy { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public int UpdatedBy { get; set; }
        public System.DateTime UpdatedAt { get; set; }
        public Nullable<int> Stutus { get; set; }
    }
}