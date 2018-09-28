using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backEnd.Models;

namespace backEnd.Actors.Messages
{
    public class UpdatePostActivityMessage
    {
        public IDBContextCreate IDBContextCreate { get; }
        public UpdatePostActivityMessage()
        {
        }

        public UpdatePostActivityMessage(IDBContextCreate idbContextCreate)
        {
            IDBContextCreate = idbContextCreate;
        }

    }
}
