using MultidimensionMod.Items.Materials;
using MultidimensionMod.Common.Globals;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Chat;
using Terraria.Localization;

namespace MultidimensionMod.Items.Summons
{
	public class MadnessCaller : ModItem
	{
		public override void SetStaticDefaults()
		{
			ItemID.Sets.SortingPriorityBossSpawns[Item.type] = 12;
		}

		public override void SetDefaults()
		{
			Item.width = 24;
			Item.height = 24;
			Item.maxStack = 20;
			Item.value = Item.sellPrice(gold: 0);
			Item.rare = ItemRarityID.Orange;
			Item.useAnimation = 30;
			Item.useTime = 30;
			Item.useStyle = ItemUseStyleID.EatFood;
			Item.UseSound = SoundID.Item2;
			Item.consumable = true;
		}

		public override bool CanUseItem(Player player)
		{
			return !MDWorld.MadnessMoon && !Main.dayTime;
		}

		public override bool? UseItem(Player player)
		{
			MDWorld.MadnessMoon = true;
			string status = "You feel your mind burned...";
			if (Main.netMode == NetmodeID.Server)
				ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral(status), Color.Gold);
			else if (Main.netMode == NetmodeID.SinglePlayer)
				Main.NewText(Language.GetTextValue(status), Color.Gold);
			return true;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<MadnessFragment>(), 10)
			.AddTile(134)
			.Register();
		}
	}
}