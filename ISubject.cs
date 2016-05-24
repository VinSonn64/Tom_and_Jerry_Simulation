using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomandJerrySimulation
{
    interface ISubject
    {
        void Attach(IObserver o);
        void Deatach(IObserver o);
        void Notify();
    }

    public interface IObserver
    {
        void ObserverUpdate(Object sender, Object message);
    }
    }

