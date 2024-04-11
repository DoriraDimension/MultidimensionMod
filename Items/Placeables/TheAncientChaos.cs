using MultidimensionMod.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using System;

namespace MultidimensionMod.Items.Placeables
{
    public class TheAncientChaos : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 44;
            Item.height = 44;
            Item.maxStack = 9999;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.rare = ItemRarityID.Expert;
            Item.value = Item.sellPrice(0, 0, 1, 0);
            Item.createTile = ModContent.TileType<TheAncientChaosPlaced>();
        }
    }
}