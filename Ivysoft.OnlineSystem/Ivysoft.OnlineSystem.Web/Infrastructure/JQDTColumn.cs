namespace Ivysoft.OnlineSystem.Web.Infrastructure
{
    public class JQDTColumn
    {
        public string data { get; set; }

        public string name { get; set; }

        public bool searchable { get; set; }

        public bool orderable { get; set; }

        public JQDTColumnSearch search { get; set; }
    }
}