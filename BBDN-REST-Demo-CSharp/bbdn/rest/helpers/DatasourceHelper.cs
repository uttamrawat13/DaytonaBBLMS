using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BBDNRESTDemoCSharp;

namespace BBDNRESTDemoCSharp
{
    public class DatasourceHelper
    {
        public static Datasource GenerateObject()
        {
            Datasource datasource = new Datasource();

            datasource.externalId = Constants.DATASOURCE_ID;
            datasource.description = Constants.DATASOURCE_DESCRIPTION;

            return datasource;
        }
    }
}
