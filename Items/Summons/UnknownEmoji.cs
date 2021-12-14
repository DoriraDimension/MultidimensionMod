using MultidimensionMod.NPCs.Boss.Smiley;
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
			Tooltip.SetDefault("A weird smiling pile of dark matter pulsing with energy.\nSummons Smiley at night.\nWarning, boss is extremely unstable in multiplayer and will despawn in all cases.");
			ItemID.Sets.SortingPriorityBossSpawns[item.type] = 13;
		}

		public override void SetDefaults()
		{
			item.width = 24;
			item.height = 22;
			item.maxStack = 20;
			item.rare = ItemRarityID.LightRed;
			item.useAnimation = 45;
			item.useTime = 45;
			item.useStyle = ItemUseStyleID.HoldingUp;
			item.UseSound = SoundID.Item44;
			item.consumable = true;
		}

		public override bool CanUseItem(Player player)
		{
			return !Main.dayTime && !NPC.AnyNPCs(ModContent.NPCType<Smiley>());
		}

		public override bool UseItem(Player player)
		{
			NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<Smiley>());
			Main.PlaySound(SoundID.Roar, player.position, 0);
			return true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<DarkMatterClump>(), 10);
			recipe.AddTile(26);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}