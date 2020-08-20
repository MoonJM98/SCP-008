using Exiled.API.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCP008.Data
{
    public class CuringEventArgs : CuredEventArgs
    {
        public CuringEventArgs(Player player, ItemType item) : base(player, item)
        {

        }
        public bool IsAllowed { get; set; } = true;
    }
}
