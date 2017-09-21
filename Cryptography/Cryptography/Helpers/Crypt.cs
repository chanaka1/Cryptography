using Chilkat;
using System;

namespace Cryptography.Helpers
{
    internal static class Crypt
    {
        private static volatile Crypt2 _instance;
        private static readonly object SyncRoot = new object();


        //This approach ensures that only one instance is created and only when the instance is needed.
        //Also, the variable is declared to be volatile to ensure that assignment to the instance variable 
        //completes before the instance variable can be accessed.
        //Lastly, this approach uses a syncRoot instance to lock on, rather than locking on the type itself, to avoid deadlocks.
        //This double-check locking approach solves the thread concurrency problems while avoiding an 
        //exclusive lock in every call to the Instance property method.It also allows you to delay instantiation
        //until the object is first accessed. In practice, an application rarely requires this type of implementation.
        public static Crypt2 Instance
        {
            get
            {
                if (_instance != null) return _instance;

                lock (SyncRoot)
                {
                    if (_instance == null)
                        _instance = new Crypt2();
                }

                return _instance;
            }
        }
    }
}
