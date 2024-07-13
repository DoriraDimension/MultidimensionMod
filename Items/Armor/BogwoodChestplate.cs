using Terraria.ID;
using Terraria.ModLoader;


namespace MultidimensionMod.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    public class BogwoodChestplate : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Bogwood Chestplate");
        }

        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 20;
            Item.value = 2000;
            Item.rare = ItemRarityID.White;
            Item.defense = 2;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<Placeables.Biomes.Mire.Bogwood>(), 30)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
    }
}