using System.Data;

namespace NexusCore.Infrasructure.Data
{
    public class StoredProcedureParameter
    {
        public string Name { get; private set; }
        public DbType DbType { get; private set; }
        public object Value { get; private set; }

        public StoredProcedureParameter(string name, DbType type, object value)
        {
            this.Name = name;
            this.DbType = type;
            this.Value = value;
        }
    }
}
