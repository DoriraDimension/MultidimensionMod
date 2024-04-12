using MultidimensionMod.Tiles.Biomes.Inferno;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace MultidimensionMod.Items.Placeables.Biomes.Inferno
{
    public class TorchAsh : ModItem
    {
        public override void SetDefaults()
        {

            Item.width = 16;
            Item.height = 16;
            Item.maxStack = 9999;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.rare = ItemRarityID.White;
            Item.value = 0;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<TorchAshPlaced>(); //put your CustomBlock Tile name
        }

        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Volcanic Ash");
        }
    }
}
