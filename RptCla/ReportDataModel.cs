using System.Collections.Generic;

namespace RptCla
{
    public class ReportDataModelItem
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }

    public class ReportDataModel
    {
        public List<ReportDataModelItem> Items { get; set; }
    }
}
