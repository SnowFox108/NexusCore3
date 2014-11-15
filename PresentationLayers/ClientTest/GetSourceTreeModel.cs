using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NexusCore.Common.Data.Models.SourceTrees;
using NexusCore.Common.Infrastructure;
using NexusCore.Common.Services.SourceTreeServices;

namespace ClientTest
{
    public class GetSourceTreeModel
    {
        public GetSourceTreeModel()
        {
            var sourceTree = EngineContext.Instance.DiContainer.GetInstance<ISourceTreeService>();

            // Login Admin
            Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity("mike.zhang@admin.com", "Passport"), null);

            var tree = sourceTree.GetSourceTreeBuild();
            PrintSourceTree(tree, 0);
        }

        private void PrintSourceTree(SourceTreeModel sourceTree, int level)
        {
            string levelLine = "";
            for (int i = 0; i < level; i++)
                levelLine += "--";
            Console.WriteLine(string.Format("{0}{1}", levelLine, sourceTree.Name));

            if (sourceTree.ChildNodes != null)
            {
                foreach (var childSourceTree in sourceTree.ChildNodes.OrderBy(s => s.SortOrder))
                    PrintSourceTree(childSourceTree, level + 1);                    
            }
        }
    }
}
