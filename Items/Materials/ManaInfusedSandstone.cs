using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Materials
{
	public class ManaInfusedSandstone : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mana Sandstone");
			Tooltip.SetDefault("A special type of stone, found inside of Lesser Sand Elementals, you can feel the magic flowing through it.\nLesser Sand Elementals are hostile against anyone who comes near their Desert." +
                "\nWho knows how the old desert people didnt get attacked by them, if it's the elementals being tamed or even created by them.");
		}

		public override void SetDefaults()
		{
			Item.width = 20;
			Item.height = 24;
			Item.maxStack = 999;
			Item.value = Item.sellPrice(copper: 32);
			Item.rare = ItemRarityID.Green;
		}

		public override void AddRecipes()
		{

		}
	}
}
