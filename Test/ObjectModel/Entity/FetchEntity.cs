﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ACME.FluentFetchXMLHelper.Model
{
    [Serializable]
    public class FetchEntity
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlElement("filter")]
        public Filter Filter { get; set; }

        [XmlElement("all-attributes", typeof(AllAttributes))]
        [XmlElement("attribute", typeof(Attribute))]
        public List<Attribute> Attributes { get; } = new List<Attribute>();
    }

    [Serializable]
    public class Attribute
    {
        [XmlAttribute("name")]
        public string Name { get; set; }
    }


    [Serializable]
    public class AllAttributes : Attribute
    {
    }

}
