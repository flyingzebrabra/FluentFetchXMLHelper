﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tofi9.FetchXml.ObjectModel
{
    [Serializable]
    public class ValueCondition : BaseCondition
    {
        //[XmlArrayItem(ElementName = "value", Namespace = "")]
        //public string[] Value { get; set; }

        public List<ValueConditionSection> values { get; set; }
    }
}