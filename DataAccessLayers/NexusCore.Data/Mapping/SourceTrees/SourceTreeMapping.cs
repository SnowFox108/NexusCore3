using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NexusCore.Common.Data.Entities.SourceTrees;

namespace NexusCore.Data.Mapping.SourceTrees
{
    public class SourceTreeMapping : EntityTypeConfiguration<SourceTree>
    {
        public SourceTreeMapping()
        {
            HasOptional(s => s.Parent)
                .WithMany(p => p.ChildNodes)
                .Map(s => s.MapKey("ParentId"))
                .WillCascadeOnDelete(false);
        }
    }
}
