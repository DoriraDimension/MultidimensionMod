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
			DisplayName.SetDefault("Burning Antler");
			Tooltip.SetDefault("Summons the head of Archtyrant Ignaen Moyasu.\nIt is nothing more than a magic construct, made to look like Ignaen's head, having his actual head would be cruel.");
			DisplayName.AddTranslation(GameCulture.German, "Brennedes Geweih");
			Tooltip.AddTranslation(GameCulture.German, "Beschwört den Kopf von Erztyrann Ignaen Moyasu.\nEs ist nichts weiter als ein magisches Konstrukt, gemacht um wie Ignaens Kopf auszusehen, seinen richtigen Kopf zu haben wäre grausam.");
		}

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.ZephyrFish);
			item.shoot = ModContent.ProjectileType<Projectiles.Pets.IgnaenHead>();
			item.buffType = ModContent.BuffType<Buffs.Pets.IgnaenHeadBuff>();
			item.width = 42;
			item.height = 32;
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