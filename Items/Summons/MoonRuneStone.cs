using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Summons
{
	public class MoonRuneStone : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Moon Rune Stone");
			Tooltip.SetDefault("A rune only known inside the moon cult, it calls forth their insane leader.\nThis must be a very important artifact for the moon cult or else their leader wouldnt be so angry about you taking it.");
			DisplayName.AddTranslation(GameCulture.German, "Mondrunen Stein");
			Tooltip.AddTranslation(GameCulture.German, "Eine Rune di nur innerhalb des Mond Kults bekannt ist, sie ruft ihren verrückten Anführer herbei.\nDies muss ein sehr wichtiges Artefakt für den Mondkult sein sonst würde ihr Anführer nicht so sauer werden wenn du es an dich nimmst.");
			ItemID.Sets.SortingPriorityBossSpawns[item.type] = 12;
		}

		public override void SetDefaults()
		{
			item.width = 26;
			item.height = 30;
			item.maxStack = 20;
			item.value = Item.sellPrice(gold: 0);
			item.rare = ItemRarityID.Yellow;
			item.useAnimation = 30;
			item.useTime = 30;
			item.useStyle = ItemUseStyleID.HoldingUp;
			item.consumable = true;
		}

		public override bool CanUseItem(Player player)
		{
			return Main.hardMode && !NPC.AnyNPCs(NPCID.CultistBoss);
		}

		public override bool UseItem(Player player)
		{
			NPC.SpawnOnPlayer(player.whoAmI, NPCID.CultistBoss);
			Main.PlaySound(SoundID.Roar, player.position, -50);
			return true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<DarkMatterClump>(), 3);
			recipe.AddIngredient(ItemID.Ectoplasm, 2);
			recipe.AddIngredient(ItemID.SoulofNight, 5);
			recipe.AddIngredient(ItemID.BlueBrick, 10);
			recipe.AddTile(134);
			recipe.SetResult(this);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<DarkMatterClump>(), 3);
			recipe.AddIngredient(ItemID.Ectoplasm, 2);
			recipe.AddIngredient(ItemID.SoulofNight, 5);
			recipe.AddIngredient(ItemID.PinkBrick, 10);
			recipe.AddTile(134);
			recipe.SetResult(this);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<DarkMatterClump>(), 3);
			recipe.AddIngredient(ItemID.Ectoplasm, 2);
			recipe.AddIngredient(ItemID.SoulofNight, 5);
			recipe.AddIngredient(ItemID.GreenBrick, 10);
			recipe.AddTile(134);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}