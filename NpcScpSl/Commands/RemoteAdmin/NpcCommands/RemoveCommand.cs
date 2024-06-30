using CommandSystem;
using Exiled.API.Features;
using Exiled.Permissions.Extensions;
using System;

namespace NpcScpSl.Commands.RemoteAdmin.NpcCommands
{
    internal class RemoveCommand : ICommand
    {
        public string Command => "remove";

        public string[] Aliases { get; } = { "rm", "del" };

        public string Description => "Удаляет Npc";

        public bool SanitizeResponse => false;

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!sender.CheckPermission($"{NpcCommand.Prefix}.{Command}"))
            {
                response = NpcCommand.NotPermissionMessage;
                return false;
            }

            if (arguments.Count == 0)
            {
                response = "Заполните эти аргументы [id]";
                return false;
            }

            int playerId = Int32.Parse(arguments.At(0));

            if (!Player.Get(playerId).IsNPC)
            {
                response = "Этот игрок не npc!";
                return false;
            }

            Npc.Get(arguments.At(0)).Destroy();

            response = "Npc удален";

            return true;
        }
    }
}
