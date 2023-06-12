using MultidimensionMod.Common.Globals.Items;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Summons
{
	public class MartianCellphone : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.width = 20;
			Item.height = 32;
			Item.rare = ItemRarityID.Yellow;
			Item.useAnimation = 45;
			Item.useTime = 45;
			Item.useStyle = ItemUseStyleID.HoldUp;
			Item.UseSound = SoundID.NPCHit39;
		}

		public override bool CanUseItem(Player player)
		{
			return Main.invasionType == 0;
		}

		public override bool? UseItem(Player player)
		{
			Main.StartInvasion(InvasionID.MartianMadness);
			return true;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddRecipeGroup(Recipes.Adamantitanium, 8)
			.AddIngredient(ItemID.LihzahrdPowerCell)
			.AddIngredient(ItemID.Nanites, 36)
			.AddTile(TileID.MythrilAnvil)
			.Register();
		}
	}
}
