using System;

namespace CineTrack.Core
{
    public static class StatusDataChanged
    {
        public static event Action OnStatusUpdated;

        public static void Raise()
        {
            OnStatusUpdated?.Invoke(); 
        }
    }
}
