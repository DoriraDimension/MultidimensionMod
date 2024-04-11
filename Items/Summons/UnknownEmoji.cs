using MultidimensionMod.Items.Materials;
using MultidimensionMod.NPCs.Bosses.Smiley;
using MultidimensionMod.Tiles.Furniture.VoidMatter;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using Terraria.GameContent.Creative;

namespace MultidimensionMod.Items.Summons
{
	public class UnknownEmoji : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			ItemID.Sets.SortingPriorityBossSpawns[Item.type] = 13;
		}

		public override void SetDefaults()
		{
			Item.width = 24;
			Item.height = 22;
			Item.maxStack = 9999;
			Item.rare = ItemRarityID.LightRed;
			Item.useAnimation = 45;
			Item.useTime = 45;
			Item.useStyle = ItemUseStyleID.HoldUp;
			Item.UseSound = SoundID.Item44;
			Item.consumable = true;
		}

		public override bool CanUseItem(Player player)
		{
			return !Main.dayTime && !NPC.AnyNPCs(ModContent.NPCType<Smiley>());
		}

		public override bool? UseItem(Player player)
		{
			NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<Smiley>());
			SoundEngine.PlaySound(SoundID.Roar, player.position);
			return true;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<DarkMatterClump>(), 10)
			.AddTile(ModContent.TileType<EmptyKingsFabricatorPlaced>())
			.Register();
		}
	}
}