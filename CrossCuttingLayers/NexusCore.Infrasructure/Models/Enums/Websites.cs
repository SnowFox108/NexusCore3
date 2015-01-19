using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusCore.Infrasructure.Models.Enums
{
    public enum WebsiteSettingDataType
    {
        Null, // the value is wrong
        Id, // the value is Guid point to other data value
        Value // the value is directly to use
    }
}
