using MultidimensionMod.Base;
using MultidimensionMod.Common.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.ModLoader;

namespace MultidimensionMod.Items
{
    public class FogLantern : ModItem
    {

        public override void SetDefaults()
        {
            Item.width = 33;
            Item.height = 42;
            Item.accessory = true;
            Item.value = 0;
        }

        public override void UpdateEquip(Player player)
        {
            player.AL().FogLantern = true;
        }
    }
}
