using Exiled.API.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCP008.Data
{
    public class CuredEventArgs : EventArgs
    {
        public CuredEventArgs(Player player, ItemType item)
        {
            Player = player;
            Item = item;
        }
        public Player Player { get; protected set; }
        public ItemType Item { get; protected set; }
    }
}
