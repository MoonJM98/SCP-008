using Exiled.API.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCP008.Data
{
    public class InfectedEventArgs : EventArgs
    {
        public InfectedEventArgs(Player attacker, Player target)
        {
            Attacker = attacker;
            Target = target;
        }
        public Player Attacker { get; protected set; }
        public Player Target { get; protected set; }
    }
}
