using MultidimensionMod.Rarities.Souls;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using System;

namespace MultidimensionMod.Items.Souls
{
    public class GlowshroomSoul : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            ItemID.Sets.ItemIconPulse[Item.type] = true;
            ItemID.Sets.ItemNoGravity[Item.type] = true;
        }

        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 24;
            Item.rare = ModContent.RarityType<GlowshroomSoulRarity>();
        }
    }
}