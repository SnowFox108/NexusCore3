﻿using System;
using NexusCore.Infrasructure.Models.Enums;

namespace NexusCore.Infrasructure.Attributes
{
    public class SettingDataTypeAttribute : Attribute
    {
        public WebsiteSettingDataType DataType { get; set; }

        public SettingDataTypeAttribute(WebsiteSettingDataType dataType)
        {
            DataType = dataType;
        }
    }
}
