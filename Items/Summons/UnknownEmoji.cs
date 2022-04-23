using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Summons
{
	public class UnknownEmoji : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Unknown Emoji");
			Tooltip.SetDefault("A weird smiling pile of dark matter pulsing with energy.\nSummons Smiley at night, the leader of Darklings.\nWarning, boss is extremely unstable in multiplayer and will despawn in all cases.");
			ItemID.Sets.SortingPriorityBossSpawns[Item.type] = 13;
		}

		public override void SetDefaults()
		{
			Item.width = 24;
			Item.height = 22;
			Item.maxStack = 20;
			Item.rare = ItemRarityID.LightRed;
			Item.useAnimation = 45;
			Item.useTime = 45;
			Item.useStyle = ItemUseStyleID.HoldUp;
			Item.UseSound = SoundID.Item44;
			Item.consumable = true;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<DarkMatterClump>(), 10)
			.AddTile(26)
			.Register();
		}
	}
}