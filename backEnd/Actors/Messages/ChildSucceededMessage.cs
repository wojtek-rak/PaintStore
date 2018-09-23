using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backEnd.Actors.Messages
{
    public class ChildSucceededMessage
    {
        public String FromWho { get; }

        public ChildSucceededMessage(string nameOfActor)
        {
            FromWho = nameOfActor;
        }
    }
}
