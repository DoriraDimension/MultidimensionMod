using Microsoft.Xna.Framework;
using MultidimensionMod.Common.Players;
using MultidimensionMod.Rarities;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.IO;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items
{
    public class RiftPatch : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 32;
            Item.rare = ItemRarityID.Pink;
            Item.value = 0;
        }

        public override void UpdateInventory(Player player)
        {
            if (Item.favorited)
            {
                player.GetModPlayer<MDPlayer>().IsRiftPatchActive = true;
            }
        }
    }
}