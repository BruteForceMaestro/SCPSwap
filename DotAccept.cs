using CommandSystem;
using Exiled.API.Features;
using System;
using System.Collections.Generic;

namespace SCPSwap
{
    public class DotAccept : ICommand
    {
        Player SenderPlayer;
        public string Command { get; } = "accept";

        public static DotAccept Instance { get; } = new DotAccept();

        /// <inheritdoc/>
        public string[] Aliases { get; } = new string[] { "yes" };

        /// <inheritdoc/>
        public string Description { get; } = "Swaps SCPs.";


        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            CommandSender cmd_sender = (CommandSender)sender;
            SenderPlayer = Player.Get(cmd_sender.SenderId);
            if (!Globals.allowed)
            {
                response = "Too late for changing SCP";
                return false;
            }

            try
            {
                RoleType old_role = Globals.Requests[SenderPlayer].Role;
                Globals.Requests[SenderPlayer].SetRole(SenderPlayer.Role);
                SenderPlayer.SetRole(old_role);
                response = "Changing roles...";
                return true;
            }
            catch (Exception ex)
            {
                if (ex is KeyNotFoundException || ex is ArgumentNullException)
                {
                    response = "No request is being sent at this moment to you";
                    return false;
                }

                else
                {
                    throw;
                }
                
            }
            
        }
    }
}
