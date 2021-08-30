using Exiled.API.Features;
using System.Collections.Generic;

namespace SCPSwap
{
    static class Globals
    {
        public static Dictionary<Player, Player> Requests = new Dictionary<Player, Player>(); // first - accepter; second - sender;
        public static bool allowed = true;
    }
}
