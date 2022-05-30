using MultidimensionMod.Items.Materials;
using MultidimensionMod.Items.Souls;
using MultidimensionMod.Projectiles.Magic;
using MultidimensionMod.Dusts;
using MultidimensionMod.Tiles;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Magic.Others
{
	public class GreatMoonlight : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Great Moonlight");
			Tooltip.SetDefault("The blue crystal blade is composed only of light.\nThe lunatic Cultist is a insane fanatic of the moon and so stole this legendary blade to use it himself,\ntho the Great Moonlight seems to not belong in this world and instead obeys an otherworldly moon.");
		}

		public override void SetDefaults()
		{
			Item.damage = 100;
			Item.DamageType = DamageClass.Magic;
			Item.width = 72;
			Item.height = 72;
			Item.useTime = 61;
			Item.useAnimation = 30;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 6;
			Item.autoReuse = true;
			Item.value = Item.sellPrice(gold: 4);
			Item.rare = ItemRarityID.Cyan;
			Item.UseSound = SoundID.Item1;
			Item.shoot = ModContent.ProjectileType<MoonlightWave>();
			Item.shootSpeed = 15f;
		}

		public override void ModifyTooltips(List<TooltipLine> list)
		{
			foreach (TooltipLine Item in list)
			{
				if (Item.Mod == "Terraria" && Item.Name == "ItemName")
				{
					Item.OverrideColor = MDRarity.BossItem;
				}
			}
		}

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			for (int i = 0; i < 3; i++)
			{
				int dustIndex = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, (ModContent.DustType<Moondust>()));
				Main.dust[dustIndex].noGravity = true;
				Main.dust[dustIndex].alpha = 50;
			}
		}

		public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
		{
			Texture2D texture = ModContent.Request<Texture2D>("MultidimensionMod/Items/Magic/Others/GreatMoonlight_Glow").Value;
			spriteBatch.Draw
			(
				texture,
				new Vector2
				(
					Item.position.X - Main.screenPosition.X + Item.width * 0.5f,
					Item.position.Y - Main.screenPosition.Y + Item.height - texture.Height * 0.5f + 2f
				),
				new Rectangle(0, 0, texture.Width, texture.Height),
				Color.White,
				rotation,
				texture.Size() * 0.5f,
				scale,
				SpriteEffects.None,
				0f
			);
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<CultistSoul>())
			.AddIngredient(ModContent.ItemType<Dimensium>(), 20)
			.AddTile(ModContent.TileType<DimensionalForge>())
			.Register();
		}
	}
}