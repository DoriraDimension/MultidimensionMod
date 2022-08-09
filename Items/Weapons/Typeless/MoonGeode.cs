using MultidimensionMod.Projectiles.Typeless;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Typeless
{
	public class MoonGeode : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Moon Geode");
			Tooltip.SetDefault("A geode found in the space layer after the lord of the moon fell.\nA blacksmith can break this open for you, sadly, there is none.\nRight click to recieve Luminite.");
		}

		public override void SetDefaults()
		{
			Item.damage = 111;
			Item.width = 24;
			Item.height = 22;
			Item.rare = ItemRarityID.Red;
			Item.maxStack = 9999;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.DamageType = DamageClass.Generic;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.noMelee = true;
			Item.consumable = true;
			Item.knockBack = 2;
			Item.noUseGraphic = true;
			Item.UseSound = SoundID.Item1;
			Item.shoot = ModContent.ProjectileType<MoonGeodeThrown>();
			Item.shootSpeed = 14f;
		}
	}
}