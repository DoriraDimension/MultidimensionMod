using MultidimensionMod.Tiles.Ores;
using MultidimensionMod.Items.Placeables.Biomes.Mire;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Materials
{
    public class AbyssiumBar : ModItem
    {
        public override void SetDefaults()
        {

            Item.width = 30;
            Item.height = 24;
            Item.maxStack = 9999;
			Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.value = 16000;
            Item.rare = ItemRarityID.Green;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<AbyssiumBarPlaced>();
			
        }

        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Abyssus Ingot");
            //Tooltip.SetDefault("An ingot forged from Dreadsoil Ore, it has dark coloring, with a dark red aura pulsing around it, like the unknown presence of something in the murky waters.");
        }

		public override void AddRecipes()
        {                                                   
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<Abyssium>(), 3)
            .AddTile(TileID.Furnaces)
            .Register();
        }
    }
}
