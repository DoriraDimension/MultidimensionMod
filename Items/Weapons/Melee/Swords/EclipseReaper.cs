using MultidimensionMod.Projectiles.Melee.Swords;
using MultidimensionMod.Items.Materials;
using MultidimensionMod.Tiles;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Melee.Swords
{
	public class EclipseReaper : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Hidden Sun Soulcaller");
			Tooltip.SetDefault("A scythe from a well hidden and now extinct civilisation, it was once a ordinary weapon,\ndecorated with a bright white extension to show off the connection to their very own sun.\nThough the scythe was retrieved and modified to now be able to summon the souls of the long lost residents.");
		}

		public override void SetDefaults()
		{
			Item.damage = 62;
			Item.DamageType = DamageClass.Melee;
			Item.width = 72;
			Item.height = 56;
			Item.useTime = 41;
			Item.useAnimation = 41;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 6;
			Item.autoReuse = true;
			Item.value = Item.sellPrice(gold: 10);
			Item.rare = ItemRarityID.Lime;
			Item.UseSound = SoundID.Item71;
			Item.crit = 10;
			Item.shoot = ModContent.ProjectileType<HiddenSunScythe>();
			Item.shootSpeed = 15f;
		}

		public override void ModifyTooltips(List<TooltipLine> list)
		{
			foreach (TooltipLine Item in list)
			{
				if (Item.Mod == "Terraria" && Item.Name == "ItemName")
				{
					Item.OverrideColor = MDRarity.ForbiddenArtifact;
				}
			}
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ItemID.DeathSickle)
			.AddIngredient(ModContent.ItemType<DarkMatterClump>(), 16)
			.AddIngredient(ItemID.Ectoplasm, 6)
			.AddIngredient(ModContent.ItemType<MadnessFragment>(), 10)
			.AddIngredient(ModContent.ItemType<Blight2>())
			.AddIngredient(ModContent.ItemType<Dimensium>(), 17)
			.AddTile(ModContent.TileType<DimensionalForge>())
			.Register();
		}
	}
}