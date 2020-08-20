using Exiled.API.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCP008
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; }

        public List<ItemType> HealItems { get; set; } = new List<ItemType>()
        {
            ItemType.Medkit,
            ItemType.SCP500
        };

        public float InfectionTime { get; set; } = 30f;
        public float InfectionChance { get; set; } = 0.2f;
        public bool RespawnDying { get; set; } = false;
    }
}
