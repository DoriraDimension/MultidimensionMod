using Terraria.ID;
using Terraria.ModLoader;


namespace MultidimensionMod.Items.Armor
{
    [AutoloadEquip(EquipType.Legs)]
	public class BogwoodLeggings : ModItem
	{
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Bogwood Boots");
        }

        public override void SetDefaults()
        {
            Item.width = 26;
            Item.height = 18;
            Item.value = 100;
            Item.rare = ItemRarityID.White;
            Item.defense = 1;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<Placeables.Biomes.Mire.Bogwood>(), 25)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
    }
}