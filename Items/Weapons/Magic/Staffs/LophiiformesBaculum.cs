using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MultidimensionMod.Items.Materials;
using MultidimensionMod.Projectiles.Magic;
using ReLogic.Content;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Magic.Staffs
{
	public class LophiiformesBaculum : ModItem
	{
		public int BlastCount = 0;
        private static Asset<Texture2D> Glow;
        public override void SetStaticDefaults()
		{
			Item.staff[Item.type] = true;
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            Glow = ModContent.Request<Texture2D>(Texture + "_Glow");
        }

		public override void SetDefaults()
		{
			Item.damage = 72;
			Item.DamageType = DamageClass.Magic;
			Item.mana = 16;
			Item.width = 52;
			Item.height = 52;
			Item.useTime = 46;
			Item.useAnimation = 46;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 2;
			Item.value = Item.sellPrice(0, 5, 50, 0);
			Item.rare = ItemRarityID.Yellow;
			Item.UseSound = SoundID.Item20;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<Lophiiformes>();
			Item.shootSpeed = 22f;
			Item.crit = 8;
		}

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			for (int i = 0; i < 4; i++)
			{
				Vector2 perturbedSpeed = new Vector2(velocity.X, velocity.Y).RotatedByRandom(MathHelper.ToRadians(25)); 																																																																											
				Projectile.NewProjectile(source, position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockback, player.whoAmI);
			}

			if (BlastCount == 2)
            {
				Projectile.NewProjectile(source, position.X, position.Y, velocity.X * 2, velocity.Y * 2, ModContent.ProjectileType<OceanicBolt>(), damage, knockback, player.whoAmI);
			}
			return false;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<AtlanteanTrident>())
			.AddIngredient(ModContent.ItemType<TidalQuartz>(), 5)
			.AddIngredient(ItemID.HallowedBar, 11)
			.AddTile(TileID.MythrilAnvil)
			.Register();
		}

		public override bool? UseItem(Player player)
		{
			BlastCount += 1;
			if (BlastCount >= 3)
			{
				BlastCount = 0;
			}
			return true;
		}

		public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
		{
			Texture2D texture = ModContent.Request<Texture2D>("MultidimensionMod/Items/Weapons/Magic/Staffs/LophiiformesBaculum_Glow").Value;
			spriteBatch.Draw
			(
				texture,
				new Vector2
				(
					Item.position.X - Main.screenPosition.X + Item.width * 0.5f,
					Item.position.Y - Main.screenPosition.Y + Item.height - texture.Height * 0.5f
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

        public override bool ModifyItemDraw(ref PlayerDrawSet drawInfo, ref DrawData drawData, ref DrawData? coloredDrawData, ref DrawData? glowmaskDrawData)
        {
            glowmaskDrawData = drawData with { texture = Glow.Value, color = Color.White };
            return true;
        }
    }
}