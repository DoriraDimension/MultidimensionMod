using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using System;
using MultidimensionMod.Common.Players;

namespace MultidimensionMod.Items.Accessories
{
    public class EggPouch : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 26;
            Item.height = 22;
            Item.accessory = true;
            Item.value = Item.sellPrice(0, 0, 50, 0);
            Item.rare = ItemRarityID.Green;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<MDPlayer>().EggPouch = true;
        }
    }
}