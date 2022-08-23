using MultidimensionMod.Projectiles.Typeless;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Typeless
{
	public class OmniGeode : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Omni Geode");
			Tooltip.SetDefault("A geode found after the spirits of lights and darkness have been released.\nA blacksmith can break this open for you, sadly, there is none.\nRight click to recieve hardmode cavern minerals.");
		}

		public override void SetDefaults()
		{
			Item.damage = 46;
			Item.width = 36;
			Item.height = 34;
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
			Item.shoot = ModContent.ProjectileType<OmniGeodeThrown>();
			Item.shootSpeed = 14f;
		}
	}
}