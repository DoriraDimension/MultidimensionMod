using MultidimensionMod.Projectiles.Magic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace MultidimensionMod.Items.Weapons.Magic.Others
{
	public class SmileySmile : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 36;
			Item.DamageType = DamageClass.Magic;
			Item.width = 28;
			Item.height = 26;
			Item.useTime = 17;
			Item.useAnimation = 17;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.mana = 5;
			Item.knockBack = 1;
			Item.value = Item.sellPrice(0, 1, 0, 0);
			Item.rare = ItemRarityID.Orange;
			Item.UseSound = SoundID.DD2_SonicBoomBladeSlash;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<DarkBolt>();
			Item.shootSpeed = 35f;
		}
	}
}
