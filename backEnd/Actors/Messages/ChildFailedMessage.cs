using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backEnd.Actors.Messages
{
    public class ChildFailedMessage
    {
        public string FromWho { get; }

        public ChildFailedMessage(string fromWho)
        {
            FromWho = fromWho;
        }

        
    }
}
