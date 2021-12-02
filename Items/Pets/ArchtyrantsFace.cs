using MultidimensionMod.Buffs.Pets;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Pets
{
	public class ArchtyrantsFace : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Archtyrant's Face");
			Tooltip.SetDefault("Summons the head of Archtyrant Ignaen Moyasu.");
			DisplayName.AddTranslation(GameCulture.German, "Erztyrann's Gesicht");
			Tooltip.AddTranslation(GameCulture.German, "Beschwört den Kopf von Erztyrann Ignaen Moyasu.");
		}

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.ZephyrFish);
			item.shoot = ModContent.ProjectileType<Projectiles.Pets.IgnaenHead>();
			item.buffType = ModContent.BuffType<Buffs.Pets.IgnaenHeadBuff>();
			item.width = 82;
			item.height = 62;
			item.value = Item.sellPrice(silver: 40);
			item.rare = ItemRarityID.Orange;
		}

		public override void UseStyle(Player player)
		{
			if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
			{
				player.AddBuff(item.buffType, 3600, true);
			}
		}
	}
}