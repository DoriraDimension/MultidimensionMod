using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Melee.Swords
{
	public class FishCleaver : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Fish Cleaver");
			Tooltip.SetDefault("Fish -Phiakitti 2021.");
		}

		public override void SetDefaults()
		{
			Item.damage = 61;
			Item.DamageType = DamageClass.Melee;
			Item.width = 86;
			Item.height = 86;
			Item.useTime = 36;
			Item.useAnimation =36;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 6;
			Item.value = Item.sellPrice(silver: 70);
			Item.rare = ItemRarityID.LightRed;
			Item.autoReuse = true;
			Item.UseSound = SoundID.Item1;
			Item.crit = 8;
		}

		public override void AddRecipes() 
		{
			CreateRecipe()
			.AddIngredient(ItemID.BreakerBlade)
			.AddIngredient(ItemID.Bass, 3)
			.AddIngredient(ItemID.AtlanticCod, 3)
			.AddIngredient(ItemID.PrincessFish, 3)
			.AddIngredient(ItemID.RedSnapper, 3)
			.AddIngredient(ItemID.Trout, 3)
			.AddCondition(Recipe.Condition.NearWater)
			.Register();
		}
	}
}