using Exiled.Events.EventArgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

using API = Exiled.API.Features;
using Handlers = Exiled.Events.Handlers;

namespace SCP008.Handler
{
    public class Player
    {
        private readonly Config Config;
        private Random random = new Random((int)DateTime.UtcNow.Ticks);
        public Player(Config config)
        {
            Config = config;
            Handlers.Player.MedicalItemUsed += OnMedicalItemUsed;
            Handlers.Player.Hurting += OnHurting;
            Handlers.Player.Left += OnLeft;
            Handlers.Player.Died += OnDied;
        }

        private void OnDied(DiedEventArgs ev)
        {
            if(Config.RespawnDying && ev.Target.IsInfected())
            {
                ev.Target.Infect();
            }
            ev.Target.Cure();
        }

        private void OnLeft(LeftEventArgs ev)
        {
            ev.Player.Cure();
        }

        public void Unsubscribe()
        {
            Handlers.Player.MedicalItemUsed -= OnMedicalItemUsed;
            Handlers.Player.Hurting -= OnHurting;
            Handlers.Player.Left -= OnLeft;
            Handlers.Player.Died -= OnDied;
        }

        private void OnHurting(HurtingEventArgs ev)
        {
            if(ev.Attacker.Role == RoleType.Scp0492 && !(ev.Target.Team == Team.RIP || ev.Target.Team == Team.SCP))
            {
                if (random.NextDouble() < Config.InfectionChance)
                {
                    ev.Attacker.Infect(ev.Target, Config.InfectionTime);
                }
            }
        }

        private void OnMedicalItemUsed(UsedMedicalItemEventArgs ev)
        {
            if(ev.Player.IsInfected() && Config.HealItems.Contains(ev.Item))
            {
                ev.Player.Cure(ev.Item);
            }
        }
    }
}
