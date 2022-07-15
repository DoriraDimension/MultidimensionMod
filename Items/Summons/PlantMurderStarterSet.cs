using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Summons
{
	public class PlantMurderStarterSet : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Plant Murder Starter Set");
			Tooltip.SetDefault("Chop this little bulb to make the big plant very angry, now in a small starter pack for kids. No refund warranty.\nProduct is made and advertised by Dor Inc.\nSummons Plantera. ");
			ItemID.Sets.SortingPriorityBossSpawns[Item.type] = 12; 
		}

		public override void SetDefaults()
		{
			Item.width = 40;
			Item.height = 26;
			Item.maxStack = 20;
			Item.value = Item.sellPrice(gold: 0);
			Item.rare = ItemRarityID.Lime;
			Item.useAnimation = 30;
			Item.useTime = 30;
			Item.useStyle = ItemUseStyleID.HoldUp;
			Item.consumable = true;
		}

		public override bool CanUseItem(Player player)
		{
			return player.ZoneJungle && Main.hardMode && NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3 && !NPC.AnyNPCs(NPCID.Plantera);
		}

		public override bool? UseItem(Player player)
		{
			NPC.SpawnOnPlayer(player.whoAmI, NPCID.Plantera);
			SoundEngine.PlaySound(SoundID.Roar, player.position);
			return true;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ItemID.JungleSpores, 5)
			.AddIngredient(ItemID.Vine, 2)
			.AddIngredient(ItemID.CopperBar)
			.AddTile(134)
			.Register();

			CreateRecipe()
		    .AddIngredient(ItemID.JungleSpores, 5)
			.AddIngredient(ItemID.Vine, 2)
			.AddIngredient(ItemID.TinBar)
			.AddTile(134)
			.Register();
		}
	}
}