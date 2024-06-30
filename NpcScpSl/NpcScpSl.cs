using Exiled.API.Features;
using NpcScpSl.Configs;
using System;

namespace NpcScpSl
{
    public class NpcScpSl : Plugin<Config>
    {
        public override string Author => "Руслан0308c";
        public override string Name => "NpcScpSl";
        public override Version Version => new Version(1, 0, 0);
        public override Version RequiredExiledVersion => new Version(8, 9, 6);

        public static NpcScpSl Singleton { get; private set; }

        public override void OnEnabled()
        {
            Singleton = this;

            if (!Config.IsEnabled)
            {
                return;
            }

            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Singleton = null;

            base.OnDisabled();
        }
    }
}
