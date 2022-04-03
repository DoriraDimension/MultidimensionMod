using MultidimensionMod.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Summons
{
	public class PlantMurderStarterSet : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Plant Murder Starter Set");
			Tooltip.SetDefault("Chop this little bulb to make the big plant very angry, now in a small starter pack for kids. No refund warranty.\nProduct is made and advertised by Dor Inc.\nSummons Plantera. ");
			DisplayName.AddTranslation(GameCulture.German, "Planzenmörder Starterset");
			Tooltip.AddTranslation(GameCulture.German, "Zerhack diese kleine Knospe um die große Pflanze sehr wütend zu machen, nun in einem kleinen Starterset für Kinder. Keine Geld zurück Garantie.\nProdukt wird hergestellt und beworben von Dor Inc.\nBeschwört Plantera.");
			ItemID.Sets.SortingPriorityBossSpawns[item.type] = 12; 
		}

		public override void SetDefaults()
		{
			item.width = 40;
			item.height = 26;
			item.maxStack = 20;
			item.value = Item.sellPrice(gold: 0);
			item.rare = ItemRarityID.Lime;
			item.useAnimation = 30;
			item.useTime = 30;
			item.useStyle = ItemUseStyleID.HoldingUp;
			item.consumable = true;
		}

		public override bool CanUseItem(Player player)
		{
			return player.ZoneJungle && Main.hardMode && NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3 && !NPC.AnyNPCs(NPCID.Plantera);
		}

		public override bool UseItem(Player player)
		{
			NPC.SpawnOnPlayer(player.whoAmI, NPCID.Plantera);
			Main.PlaySound(SoundID.Roar, player.position, 0);
			return true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.JungleSpores, 5);
			recipe.AddIngredient(ItemID.Vine, 2);
			recipe.AddIngredient(ItemID.CopperBar);
			recipe.AddTile(134);
			recipe.SetResult(this);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.JungleSpores, 5);
			recipe.AddIngredient(ItemID.Vine, 2);
			recipe.AddIngredient(ItemID.TinBar);
			recipe.AddTile(134);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}