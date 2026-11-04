using MultidimensionMod.Tiles.Ores;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using MultidimensionMod.Items.Materials;
using MultidimensionMod.Rarities;

namespace MultidimensionMod.Items.Placeables
{
    public class DimensiumBrick : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;
        }

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
            Item.consumable = true;
            Item.rare = ModContent.RarityType<AdminRarity>();
            Item.createTile = ModContent.TileType<DimensiumBrickPlaced>();
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<Dimensium>())
            .AddIngredient(ItemID.StoneBlock, 5)
            .AddTile(TileID.Furnaces)
            .Register();

            /*CreateRecipe()
            .AddIngredient(ModContent.ItemType<DimensiumBrickWall>(), 4)
            .AddTile(TileID.WorkBenches)
            .Register();*/
        }
    }
}