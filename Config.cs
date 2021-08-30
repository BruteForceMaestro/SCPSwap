using Exiled.API.Interfaces;

namespace SCPSwap
{
    sealed public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public float accept_time_sec { get; set; } = 60f;
    }
}
