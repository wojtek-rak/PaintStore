using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;
using Akka.Actor;
using backEnd.Actors.Messages;
using backEnd.Models;

namespace backEnd.Actors.Services
{
    public interface IActivityManagerStartup
    {
        void RunManager();
    }
    public class ActivityManager : IActivityManagerStartup
    {
        private const int SecondCalcActivityInterval = 3600;

        private readonly IActorRef supervisorActor;
        private readonly UpdatePostActivityMessage message;
        private IObservable<long> syncMailObservable;
        private IDisposable subscription = null;

        

        public ActivityManager( IActorRef supervisorActor)
        {
            this.supervisorActor = supervisorActor;
        }

        public void RunManager()
        {
            syncMailObservable = Observable.Interval(TimeSpan.FromSeconds(SecondCalcActivityInterval));
            subscription = syncMailObservable.Subscribe(s => supervisorActor.Tell(new UpdatePostActivityMessage()));
        }
    }
}
