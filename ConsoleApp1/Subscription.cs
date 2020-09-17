using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class Subscription
    {
        public enum Status
        {
            Temporary,
                Financial,
                Suspended
        }

        public DateTime? PaidUpTo { get; set; }

        public Status CurrentStatus
        {
            get
            {
                if ( this.PaidUpTo.HasValue == false )
                {
                    return Status.Temporary;
                }
                if ( this.PaidUpTo > DateTime.Today )
                {
                    return Status.Financial;
                }

                else
                    return Status.Suspended;


            }


        }

    }
}
