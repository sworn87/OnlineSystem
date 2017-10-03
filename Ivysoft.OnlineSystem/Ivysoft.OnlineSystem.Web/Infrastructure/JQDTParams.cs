using System.Collections.Generic;

namespace Ivysoft.OnlineSystem.Web.Infrastructure
{
    public class JQDTParams
    {
        public int draw { get; set; }

        public int start { get; set; }
        public int length { get; set; }

        public JQDTColumnSearch  /*Dictionary<string, string>*/ search { get; set; }

        public List<JQDTColumnOrder/*Dictionary<string, string>*/> order { get; set; }

        public List<JQDTColumn/*Dictionary<string, string>*/> columns { get; set; }
    }
}