using Exiled.API.Features;
using SCP008.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCP008
{
    public static class Functions
    {
        public static readonly Dictionary<Player, Infection> InfectedPlayers = new Dictionary<Player, Infection>();
        public static bool Infect(this Player attacker, Player target, float duration = 30f)
        {
            if (!target.IsInfected())
            {
                InfectedPlayers.Add(target, new Infection(attacker, target, DateTime.UtcNow, duration));
                return true;
            }
            else
            {
                return false;
            }

        }
        public static void Infect(this Player target)
        {
            new Infection(null, target, DateTime.UtcNow, 0f);
        }

        public static bool IsInfected(this Player player)
        {
            return InfectedPlayers.ContainsKey(player);
        }

        public static void Cure(this Player player, ItemType item = ItemType.None)
        {
            if(InfectedPlayers.ContainsKey(player))
            {
                Infection infection = InfectedPlayers[player];
                infection.Cure(item);
            }
        }
    }
}
