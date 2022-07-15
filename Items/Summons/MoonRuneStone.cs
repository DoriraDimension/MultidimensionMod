using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Summons
{
	public class MoonRuneStone : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Moon Rune Stone");
			Tooltip.SetDefault("A rune only known inside the moon cult, it calls forth their insane leader.\nThis must be a very important artifact for the moon cult or else their leader wouldnt be so angry about you taking it.");
			ItemID.Sets.SortingPriorityBossSpawns[Item.type] = 12;
		}

		public override void SetDefaults()
		{
			Item.width = 26;
			Item.height = 30;
			Item.maxStack = 20;
			Item.value = Item.sellPrice(gold: 0);
			Item.rare = ItemRarityID.Yellow;
			Item.useAnimation = 30;
			Item.useTime = 30;
			Item.useStyle = ItemUseStyleID.HoldUp;
			Item.consumable = true;
		}

		public override bool CanUseItem(Player player)
		{
			return Main.hardMode && !NPC.AnyNPCs(NPCID.CultistBoss);
		}

		public override bool? UseItem(Player player)
		{
			NPC.SpawnOnPlayer(player.whoAmI, NPCID.CultistBoss);
			SoundEngine.PlaySound(SoundID.Roar, player.position);
			return true;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<DarkMatterClump>(), 3)
			.AddIngredient(ItemID.Ectoplasm, 2)
			.AddIngredient(ItemID.SoulofNight, 5)
			.AddIngredient(ItemID.BlueBrick, 10)
			.AddTile(134)
			.Register();

			CreateRecipe()
            .AddIngredient(ModContent.ItemType<DarkMatterClump>(), 3)
            .AddIngredient(ItemID.Ectoplasm, 2)
            .AddIngredient(ItemID.SoulofNight, 5)
            .AddIngredient(ItemID.PinkBrick, 10)
            .AddTile(134)
            .Register();

			CreateRecipe()
            .AddIngredient(ModContent.ItemType<DarkMatterClump>(), 3)
            .AddIngredient(ItemID.Ectoplasm, 2)
            .AddIngredient(ItemID.SoulofNight, 5)
            .AddIngredient(ItemID.GreenBrick, 10)
            .AddTile(134)
            .Register();
		}
	}
}