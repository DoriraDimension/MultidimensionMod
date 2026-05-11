using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using System;
using MultidimensionMod.Tiles.Ores;

namespace MultidimensionMod.Items.Materials
{
    public class Iridul : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 25;
        }

        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 18;
            Item.maxStack = 9999;
            Item.value = Item.sellPrice(0, 0, 50, 0);
            Item.rare = ItemRarityID.LightRed;
            Item.DefaultToPlaceableTile(ModContent.TileType<IridulPlaced>());
        }
    }
}