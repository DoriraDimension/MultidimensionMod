using MultidimensionMod.Projectiles.Typeless;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Typeless
{
	public class SandstoneGeode : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sandstone Geode");
			Tooltip.SetDefault("A geode found in the desert.\nA blacksmith can break this open for you, sadly, there is none.\nRight click to recieve desert minerals.");
		}

		public override void SetDefaults()
		{
			Item.damage = 29;
			Item.width = 28;
			Item.height = 22;
			Item.rare = ItemRarityID.Blue;
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
			Item.shoot = ModContent.ProjectileType<SandstoneGeodeThrown>();
			Item.shootSpeed = 14f;
		}
	}
}