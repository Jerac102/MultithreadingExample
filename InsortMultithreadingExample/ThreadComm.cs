using System.Threading;

namespace InsortMultithreadingExample
{
    public static class ThreadComm
    {
        private static object myObj = new object();
        static bool paused;
        public static bool Paused
        {
            get { lock (myObj) { return paused; } }
            set { lock (myObj) { paused = value; } }
        }

        static bool stopped;
        public static bool Stopped
        {
            get { lock (myObj) { return stopped; } }
            set { lock (myObj) { stopped = value; } }
        }

        public static ManualResetEvent ManualResetEvent = new ManualResetEvent(false);
    }
}
