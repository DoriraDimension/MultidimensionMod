using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace MultidimensionMod.Items.Weapons.Melee.Swords
{
	public class TyphoonDragon : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 77;
			Item.DamageType = DamageClass.Melee;
			Item.width = 98;
			Item.height = 120;
			Item.useTime = 26;
			Item.useAnimation = 26;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 6;
			Item.value = Item.sellPrice(0, 5, 0, 0);
			Item.rare = ItemRarityID.Yellow;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.shoot = ProjectileID.MiniSharkron;
			Item.shootSpeed = 11f;
			Item.crit = 12;
		}

		public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
		{
			Projectile.NewProjectile(Item.GetSource_ItemUse(player.HeldItem), target.position.X + 0f + (float)Main.rand.Next(0, 151), player.position.Y + 0f, 0f, -6f, ProjectileID.MiniSharkron, (int)((double)(float)Item.damage), Main.myPlayer);
			Projectile.NewProjectile(Item.GetSource_ItemUse(player.HeldItem), target.position.X + 0f + (float)Main.rand.Next(0, 151), player.position.Y + 0f, 0f, -6f, ProjectileID.MiniSharkron, (int)((double)(float)Item.damage), Main.myPlayer);
		}

		public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
		{
			Texture2D texture = ModContent.Request<Texture2D>("MultidimensionMod/Items/Weapons/Melee/Swords/TyphoonDragon_Glow").Value;
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
	}
}