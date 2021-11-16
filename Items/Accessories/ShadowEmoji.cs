using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Accessories
{
	public class ShadowEmoji : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Shadow Emoji");
			Tooltip.SetDefault("A shady smile gives you power.\nGrants +2 minion slots and increases minion damage by 5%.\nIncreases movement speed by 15% when below 30% health.");
			DisplayName.AddTranslation(GameCulture.German, "Schattenemoji");
			Tooltip.AddTranslation(GameCulture.German, "Ein schattiges Lächeln gibt dir Kraft.\nGibt +2 Minion Slots und erhöht Günstlingsschaden um 5%.\nErhöht Bewegungsgeschwindigkeit um 15% wenn unter 30% Leben.");
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(8, 5));
			ItemID.Sets.ItemNoGravity[item.type] = true;
		}

		public override void SetDefaults()
		{
			item.width = 58;
			item.height = 54;
			item.accessory = true;
			item.expert = true;
			item.value = Item.sellPrice(gold: 2);
			item.rare = ItemRarityID.Expert;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.maxMinions += 2;
			player.minionDamage += 0.5f;
			if (player.statLife <= player.statLifeMax2 * 0.3)
			{
				player.moveSpeed += 0.15f;
            }
		}
	}
}