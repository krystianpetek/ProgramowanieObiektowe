using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_MSDN_Inheritance
{
    internal class WorkItem : System.Object
    {
        private static int currentID;
        protected int ID { get; set; }
        protected string Title { get; set; }
        protected string Description { get; set; }
        protected TimeSpan jobLength { get; set; }
        public WorkItem()
        {
            ID = 0;
            Title = "Default title";
            Description = "Default description";
            jobLength = new TimeSpan();
        }
        public WorkItem(string title, string desc, TimeSpan joblen)
        {
            this.ID = GetNextID();
            this.Title = title;
            this.Description = desc;
            this.jobLength = joblen;
        }
        static WorkItem() =>  currentID = 0;
        protected int GetNextID() => ++currentID;
        public void Update(string title, TimeSpan joblen)
        {
            this.Title = title;
            this.jobLength = joblen;
        }
        public override string ToString() => $"{this.ID} - {this.Title}";

    }
}
