using System.Collections.Generic;

namespace NexusCore.Infrasructure.Data
{
    public interface IStoredProcedure
    {
        string StoredProcedureName { get; }
        IEnumerable<StoredProcedureParameter> GetParameters();
    }
}
