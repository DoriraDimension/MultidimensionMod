using MultidimensionMod.Items.Materials;
using MultidimensionMod.Projectiles.Ranged;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Magic.Guns
{
	public class Retilazor : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Retilazor");
			Tooltip.SetDefault("Fires 4 lazors per shot.");
			DisplayName.AddTranslation(GameCulture.German, "Retilazor");
			Tooltip.AddTranslation(GameCulture.German, "Verschießt 4 Lazor per Schuss.");
		}

		public override void SetDefaults()
		{
			item.damage = 56;
			item.magic = true;
			item.width = 38;
			item.height = 28;
			item.useTime = 10;
			item.useAnimation = 35;
			item.reuseDelay = 20;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true;
			item.value = Item.sellPrice(gold: 3);
			item.rare = ItemRarityID.Pink;
			item.UseSound = SoundID.Item33;
			item.mana = 11;
			item.autoReuse = true;
			item.shoot = ModContent.ProjectileType<RedLazor>();
			item.shootSpeed = 35f;
			item.crit = 4;
		}
	}
}