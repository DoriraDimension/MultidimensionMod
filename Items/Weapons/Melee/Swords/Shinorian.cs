using MultidimensionMod.Projectiles.Melee.Swords;
using MultidimensionMod.Rarities;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Melee.Swords
{
	public class Shinorian : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Hex Rapier");
			// Tooltip.SetDefault("A cursed thrusting sword empowered by malicious runes.\nThe curses that were laid onto this weapon are ancient and have no counterspell,\nthe hex isnt at its peak though and as such wont be able to cause any overly major harm\nOne should still beware of its power, as it is a forbidden artifact after all");
		}

		public override void SetDefaults()
		{
			Item.damage = 28;
			Item.DamageType = DamageClass.Melee;
			Item.width = 56;
			Item.height = 56;
			Item.useTime = 8;
			Item.useAnimation = 8;
			Item.useStyle = ItemUseStyleID.Rapier;
			Item.knockBack = 2;
			Item.value = Item.sellPrice(silver: 78);
			Item.rare = ModContent.RarityType<ForbiddenArtifact>();
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.noMelee = true;
			Item.noUseGraphic = true;
			Item.crit = 5;
			Item.shoot = ModContent.ProjectileType<HexStab>();
			Item.shootSpeed = 3.50f;
		}

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.NextBool(3))
			{
				Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, (72));
			}
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ItemID.UnicornHorn)
			.AddIngredient(ItemID.Obsidian, 18)
			.AddIngredient(ItemID.SoulofFright, 6)
			.AddTile(TileID.MythrilAnvil)
			.Register();
		}
	}
}