using MultidimensionMod.Items.Placeables;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace MultidimensionMod.Items.Weapons.Melee.Swords
{
	public class FishCleaver : ModItem
	{
		public override void SetStaticDefaults() 
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			ItemID.Sets.ShimmerTransformToItem[Type] = ModContent.ItemType<FishLegacy>();
		}

		public override void SetDefaults()
		{
			Item.damage = 82;
			Item.DamageType = DamageClass.Melee;
			Item.width = 86;
			Item.height = 86;
			Item.useTime = 32;
			Item.useAnimation = 32;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 8;
			Item.value = Item.sellPrice(0, 3, 35, 0);
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
			.AddIngredient(ItemID.RedSnapper, 3)
			.AddIngredient(ItemID.Trout, 3)
			.AddCondition(Condition.NearWater)
			.Register();
		}
	}
}