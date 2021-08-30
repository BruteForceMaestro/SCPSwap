using Exiled.API.Features;
using MEC;

namespace SCPSwap
{
    class EventHandlers
    {
        Config config = new Config();
        public void RoundStart()
        {
            foreach (Player player in Player.List)
            {
                if (player.IsScp)
                {
                    player.ShowHint("You can request to change SCPs \nby typing in your console .scp req <SCP Number>", duration: 15);
                }
            }
            void method() => changeAccept();
            Timing.CallDelayed(config.accept_time_sec, method);
        }

        void changeAccept()
        {
            
            Globals.allowed = false;
        }
    }
}
