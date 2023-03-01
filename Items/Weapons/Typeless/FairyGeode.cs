using MultidimensionMod.Items.Accessories;
using MultidimensionMod.Projectiles.Typeless;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Typeless
{
	public class FairyGeode : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Fairy Geode");
			// Tooltip.SetDefault("A geode found in the Hallow.\nA blacksmith can break this open for you, sadly, there is none.\nRight click to recieve Hallow minerals.");
		}

		public override void SetDefaults()
		{
			Item.damage = 53;
			Item.width = 28;
			Item.height = 28;
			Item.rare = ItemRarityID.LightRed;
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
			Item.shoot = ModContent.ProjectileType<FairyGeodeThrown>();
			Item.shootSpeed = 14f;
		}
	}
}