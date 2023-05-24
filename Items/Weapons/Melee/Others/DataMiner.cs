using MultidimensionMod.Projectiles.Melee.Others;
using MultidimensionMod.Rarities;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace MultidimensionMod.Items.Weapons.Melee.Others
{
	public class DataMiner : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 7000;
			Item.DamageType = DamageClass.Melee;
			Item.width = 20;
			Item.height = 12;
			Item.useTime = 5;
			Item.useAnimation = 5;
			Item.channel = true;
			Item.noUseGraphic = true;
			Item.noMelee = true;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 2;
			Item.value = Item.sellPrice(1, 0, 0, 0);
			Item.rare = ModContent.RarityType<DoriraRarity>();
			Item.UseSound = SoundID.Item23;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<DataMinerProj>();
			Item.shootSpeed = 20f;
			Item.crit = 77;
		}
	}
}