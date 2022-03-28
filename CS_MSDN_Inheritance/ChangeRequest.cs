using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_MSDN_Inheritance
{
    internal class ChangeRequest : WorkItem
    {
        protected int originalItemID { get; set; }
        public ChangeRequest() { }
        public ChangeRequest(string title, string desc, TimeSpan joblen, int originalID)
        {
            this.ID = GetNextID();
            this.Title = title;
            this.Description = desc;
            this.jobLength = joblen;
            this.originalItemID = originalID;
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
