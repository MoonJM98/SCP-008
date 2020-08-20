using Exiled.API.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCP008
{
    public class Plugin : Exiled.API.Features.Plugin<Config>
    {
        public override string Author => "MoonJM";
        public override PluginPriority Priority => PluginPriority.Default;
        public override string Name => "SCP-008";
        public override string Prefix => "SCP-008";
        public override Version RequiredExiledVersion => base.RequiredExiledVersion;
        public override Version Version => new Version(0, 0, 1);
        private Handler.Player player;
        public bool EventActivated
        {
            get => EventActivated;
            set
            {
                if (EventActivated != value)
                {
                    if (EventActivated)
                    {
                        UnregisterEvents();
                        EventActivated = false;
                    }
                    else
                    {
                        RegisterEvents();
                        EventActivated = true;
                    }
                }
            }
        }

        public override void OnEnabled()
        {
            base.OnEnabled();

            EventActivated = true;
        }

        private void RegisterEvents()
        {
            player = new Handler.Player(Config);
        }

        private void UnregisterEvents()
        {
            player.Unsubscribe();
        }
    }
}
