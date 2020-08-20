using Exiled.API.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCP008.Data
{
    public class InfectingEventArgs : InfectedEventArgs
    {
        public InfectingEventArgs(Player attacker, Player target) : base(attacker, target)
        {

        }
        public bool IsAllowed { get; set; } = true;
    }
}
