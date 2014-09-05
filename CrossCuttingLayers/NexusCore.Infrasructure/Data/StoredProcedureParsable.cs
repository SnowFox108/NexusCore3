using System.Data.Common;

namespace NexusCore.Infrasructure.Data
{
    public abstract class StoredProcedureParsable
    {
       abstract public void  DbReaderParser(DbDataReader reader);
    }
}
