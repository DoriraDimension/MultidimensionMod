using Microsoft.Xna.Framework;
using MultidimensionMod.Rarities;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items
{
    public class HerbGuide : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 32;
            Item.rare = ItemRarityID.Green;
            Item.value = 0;
        }
    }
}