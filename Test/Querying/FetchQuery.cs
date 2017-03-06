﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Intergen.FetchXml.ObjectModel;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Tofi9.FetchXml.ObjectModel;

namespace Intergen.FetchXml.Querying
{
    public class FetchQuery
    {
        FetchXmlObject fetch;

        public FetchQuery(string entity)
        {
            fetch = new FetchXmlObject
            {
                Entity = new FetchEntity { Name = entity }
            };
        }

        public FetchQuery AllAttributes()
        {
            fetch.Entity.Attributes.Add(new AllAttributes());
            return this;
        }

        public FetchQuery Attributes(params string[] attributes)
        {
            fetch.Entity.Attributes.AddRange(attributes.Select(x => new Tofi9.FetchXml.ObjectModel.Attribute { Name = x }));
            return this;
        }

        public FetchQuery Filter(Action<FetchFilter> filterFn)
        {
            var filter = fetch.Entity.Filter;
            if (filter == null)
            {
                fetch.Entity.Filter = filter = new Filter();
            }

            FetchFilter.Apply(filter, filterFn);

            return this;
        }

        public override string ToString()
        {
            return this.fetch.ToString();
        }

        public IReadOnlyList<Entity> RetrieveMultiple(IOrganizationService service)
        {
            var fetch = this.ToString();
            var result = service.RetrieveMultiple(new FetchExpression(fetch)).Entities.ToList();
            return result;
        }
    }
}
