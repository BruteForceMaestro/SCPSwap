using Exiled.API.Features;
using Server = Exiled.Events.Handlers.Server;

namespace SCPSwap
{
    sealed public class Main : Plugin<Config>
    {
        EventHandlers EventHandler = new EventHandlers();

        public override void OnEnabled()
        {
            base.OnEnabled();
            EventHandler = new EventHandlers();
            Server.RoundStarted += EventHandler.RoundStart;
        }

        public override void OnDisabled()
        {
            base.OnDisabled();
            EventHandler = null;
            Server.RoundStarted -= EventHandler.RoundStart;
        }
    }
}
