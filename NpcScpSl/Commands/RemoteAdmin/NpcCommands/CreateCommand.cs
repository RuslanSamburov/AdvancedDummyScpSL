using CommandSystem;
using Exiled.API.Features;
using Exiled.Permissions.Extensions;
using NpcScpSl.Utils;
using System;
using RoleTypeId = PlayerRoles.RoleTypeId;

namespace NpcScpSl.Commands.RemoteAdmin.NpcCommands
{
    internal class CreateCommand : ICommand
    {
        public string Command => "create";

        public string[] Aliases { get; } = { "cr", "spawn" };

        public string Description => "Создает Npc";

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
                response = "Заполните эти аргументы [name] [classId](Default: Tutorial)";
                return false;
            }

            response = "Npc создан";

            RoleTypeId roleTypeId = arguments.Count >=2 ? (RoleTypeId)EnumHelper.GetEnumValue<RoleTypeId>(arguments.At(1)) : RoleTypeId.Tutorial;

            Npc.Spawn(arguments.At(0), roleTypeId);

            return true;
        }
    }
}
