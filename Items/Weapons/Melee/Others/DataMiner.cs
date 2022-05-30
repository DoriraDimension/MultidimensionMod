using System.Collections.Generic;
using MultidimensionMod.Projectiles.Melee.Others;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Melee.Others
{
	public class DataMiner : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Data Miner");
			Tooltip.SetDefault("The dimensional gods allmight drill, used by him to tear rifts into the dimensions.\nInflicts Electrified.");
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
			Item.value = Item.sellPrice(platinum: 1);
			Item.rare = -12;
			Item.UseSound = SoundID.Item23;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<DataMinerProj>();
			Item.shootSpeed = 20f;
			Item.crit = 77;
		}

		public override void ModifyTooltips(List<TooltipLine> list)
		{
			foreach (TooltipLine Item in list)
			{
				if (Item.Mod == "Terraria" && Item.Name == "ItemName")
				{
					Item.OverrideColor = MDRarity.Dorira;
				}
			}
		}
	}
}