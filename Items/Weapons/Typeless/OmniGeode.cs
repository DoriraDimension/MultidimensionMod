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

		public override bool CanRightClick()
		{
			return true;
		}

		public override void RightClick(Player player)
		{
			var source = player.GetSource_OpenItem(Type);
			int choice = Main.rand.Next(6);
			if (choice == 0)
			{
				player.QuickSpawnItem(source, ItemID.CobaltOre, 20);
			}
			else if (choice == 1)
			{
				player.QuickSpawnItem(source, ItemID.PalladiumOre, 20);
			}
			else if (choice == 2)
			{
				player.QuickSpawnItem(source, ItemID.OrichalcumOre, 20);
			}
			else if (choice == 3)
			{
				player.QuickSpawnItem(source, ItemID.MythrilOre, 20);
			}
			else if (choice == 4)
			{
				player.QuickSpawnItem(source, ItemID.AdamantiteOre, 20);
			}
			else if (choice == 5)
			{
				player.QuickSpawnItem(source, ItemID.TitaniumOre, 20);
			}
		}
	}
}