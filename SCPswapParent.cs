using CommandSystem;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCPSwap
{
    [CommandHandler(typeof(ClientCommandHandler))]
    public class SCPSwapParent : ParentCommand
    {
        public SCPSwapParent() => LoadGeneratedCommands();
        public override string Command => "SCPSwap";

        public override string[] Aliases => new string[] { "scp" };

        public override string Description => "Swaps SCPs.";

        public override void LoadGeneratedCommands()
        {
            RegisterCommand(DotScp.Instance);
            RegisterCommand(DotAccept.Instance);
        }

        protected override bool ExecuteParent(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            response = "Use: .scpswap request <SCP Number>";
            return false; 
        }
    }
}
