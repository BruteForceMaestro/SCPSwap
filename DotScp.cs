using System;
using CommandSystem;
using Exiled.API.Features;
using System.Linq;
using System.Collections.Generic;

namespace SCPSwap
{
    public class DotScp : ICommand
    {
        Player SenderPlayer;

        /// <inheritdoc/>
        public string Command { get; } = "request";

        public static DotScp Instance { get; } = new DotScp();

        /// <inheritdoc/>
        public string[] Aliases { get; } = new string[] { "req" };

        /// <inheritdoc/>
        public string Description { get; } = "Swaps SCPs.";

        /// <inheritdoc/>

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            CommandSender cmd_sender = (CommandSender)sender;
            IEnumerable<Player> player_list = Player.List;
            string hint = "An exchange request has been sent to you!Enter.scp accept or .scp yes in console to accept.";
            string fail_response = "Use .scpswap request <SCP Number>";

            SenderPlayer = Player.Get(cmd_sender.SenderId);

            if (arguments.Count == 0 || arguments.Count > 1)
            {
                response = fail_response;
                return false;
            }

            else if (!Globals.allowed)
            {
                response = "Too late for changing SCP";
                return false;
            }

            else if (!SenderPlayer.IsScp)
            {
                response = "You need to be an SCP to execute this command";
                return false;
            }

            else if (arguments.ElementAt(0) == "079")
            {
                foreach (Player player in player_list)
                {
                    if (SenderPlayer.Role == RoleType.Scp079)
                    {
                        response = "You are already this type of SCP";
                        return false;
                    }
                    if (player.Role == RoleType.Scp079)
                    {
                        player.ShowHint(hint, duration: 15);
                        Globals.Requests.Add(player, SenderPlayer);
                        response = "There is already an SCP of this type present! Sending Exchange Request...";
                        return true;
                    }
                }

                SenderPlayer.SetRole(RoleType.Scp079);
                response = "Changing roles...";
                return true;
            }

            else if (arguments.ElementAt(0) == "096")
            {
                foreach (Player player in player_list)
                {
                    if (SenderPlayer.Role == RoleType.Scp096)
                    {
                        response = "You are already this type of SCP";
                        return false;
                    }
                    if (player.Role == RoleType.Scp096)
                    {
                        player.ShowHint(hint, duration: 15);
                        response = "There is already an SCP of this type present! Sending Exchange Request...";
                        Globals.Requests.Add(player, SenderPlayer);
                        return true;
                    }
                }

                SenderPlayer.SetRole(RoleType.Scp096);
                response = "Changing roles...";
                return true;
            }

            else if (arguments.ElementAt(0) == "049")
            {
                foreach (Player player in player_list)
                {
                    if (SenderPlayer.Role == RoleType.Scp049)
                    {
                        response = "You are already this type of SCP";
                        return false;
                    }
                    if (player.Role == RoleType.Scp049)
                    {
                        player.ShowHint(hint, duration: 15);
                        Globals.Requests.Add(player, SenderPlayer);
                        response = "There is already an SCP of this type present! Sending Exchange Request...";
                        return true;
                    }
                }

                SenderPlayer.SetRole(RoleType.Scp049);
                response = "Changing roles...";
                return true;
            }

            else if (arguments.ElementAt(0) == "106")
            {
                foreach (Player player in player_list)
                {
                    if (SenderPlayer.Role == RoleType.Scp106)
                    {
                        response = "You are already this type of SCP";
                        return false;
                    }
                    if (player.Role == RoleType.Scp106)
                    {
                        player.ShowHint(hint, duration: 15);
                        Globals.Requests.Add(player, SenderPlayer);
                        response = "There is already an SCP of this type present! Sending Exchange Request...";
                        return true;
                    }
                }

                SenderPlayer.SetRole(RoleType.Scp106);
                response = "Changing roles...";
                return true;
            }

            else if (arguments.ElementAt(0) == "939")
            {
                foreach (Player player in player_list)
                {
                    if (SenderPlayer.Role.Is939())
                    {
                        response = "You are already this type of SCP";
                        return false;
                    }
                    if (player.Role == RoleType.Scp93989 || player.Role == RoleType.Scp93953)
                    {
                        foreach (Player scp in player_list)
                        {
                            if (scp.Role.Is939() && scp != player)
                            {
                                response = "There are already SCPs of this type present! Sending Exchange Request...";
                                Globals.Requests.Add(player, SenderPlayer);
                                player.ShowHint(hint, duration: 15);
                                return true;
                            }
                            
                        }
                        SenderPlayer.SetRole(RoleType.Scp93953);
                        response = "Changing roles...";
                        return true;

                    }
                }

                SenderPlayer.SetRole(RoleType.Scp93953);
                response = "Changing roles...";
                return true;
            }

            else if (arguments.ElementAt(0) == "173")
            {
                foreach (Player player in player_list)
                {
                    if (SenderPlayer.Role == RoleType.Scp173)
                    {
                        response = "You are already this type of SCP";
                        return false;
                    }
                    if (player.Role == RoleType.Scp173)
                    {
                        response = "There is already an SCP of this type present! Sending Exchange Request...";
                        Globals.Requests.Add(player, SenderPlayer);
                        player.ShowHint(hint, duration: 15);
                        return true;
                    }
                }

                SenderPlayer.SetRole(RoleType.Scp173);
                response = "Changing roles...";
                return true;
            }

            response = fail_response;
            return false;

        }
    }
}
