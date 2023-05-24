using MultidimensionMod.Projectiles.Typeless;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace MultidimensionMod.Items.Weapons.Typeless
{
	public class OmniGeode : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 20;
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