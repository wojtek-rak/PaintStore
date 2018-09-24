using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backEnd.Models;

namespace backEnd.Actors.Services
{
    public class ActivityManager
    {
        private PaintStoreContext ctx;

        public ActivityManager(PaintStoreContext ctx)
        {
            this.ctx = ctx;
            Console.WriteLine(ctx);
            throw new System.ArgumentException("Parameter cannot be null", "original");
        }

    }
}
