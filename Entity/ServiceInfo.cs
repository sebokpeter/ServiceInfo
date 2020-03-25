using System;

namespace ServiceInfo
{
    public class ServiceInfo
    {
        [Flags]
        public enum State
        {
            Running,
            Paused
        }
        // Get or set a unique identifier for this service
        public int Id { get; set; }

        // Get or set Url address for this service
        public String Url { get; set; }

        // Get or set the priority of the service
        public int Priority { get; set; }

        // Get or set the state of the service
        public State ServiceState { get; set; }
    }
}
