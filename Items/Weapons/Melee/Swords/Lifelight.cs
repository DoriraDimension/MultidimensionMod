using MultidimensionMod.Items.Materials;
using MultidimensionMod.Tiles;
using MultidimensionMod.Projectiles.Melee.Swords;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Terraria.Audio;
using Terraria.DataStructures;

namespace MultidimensionMod.Items.Weapons.Melee.Swords
{
	public class Lifelight : ModItem
	{

		public int Light;
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 36;
			Item.DamageType = DamageClass.Melee;
			Item.width = 62;
			Item.height = 62;
			Item.useTime = 19;
			Item.useAnimation = 19;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 3;
			Item.value = Item.sellPrice(0, 0, 46, 0);
			Item.rare = ItemRarityID.Orange;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.crit = 8;
			Item.shootSpeed = 20;
		}

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.NextBool(5))
			{
				Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.Demonite);
				Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.Enchanted_Gold);
			}
		}

		public override bool AltFunctionUse(Player player)
        {
			return true;
        }

		public override bool? UseItem(Player player)
        {
			Light++;
			if (Light >= 10)
            {
				Light = 10;
				SoundEngine.PlaySound(SoundID.NPCDeath7, player.position);

			}
			if (Light == 10)
            {

            }
			if (player.altFunctionUse == 2 && Light == 10)
            {
				Light = 0;
				Projectile.NewProjectile(player.GetSource_ItemUse(player.HeldItem), player.Center.X, player.Center.Y, 0f, -15f, ModContent.ProjectileType<LifelightSkywards>(), (int)((double)((float)Item.damage) * 0.7), 0f, Main.myPlayer);
			}
			return true;
        }

		public override bool CanUseItem(Player player)
		{
			if (player.altFunctionUse == 2)
			{
				Item.damage = 60;
				Item.noMelee = true;
				Item.noUseGraphic = true;
				if (Light != 10)
				{
					return false;
				}
			}
			else
			{
				SetDefaults();
				Item.noUseGraphic = false;
				Item.noMelee = false;
			}
			return base.CanUseItem(player);
		}

		public override void PostDrawInInventory(SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale)
        {
			if (Light == 10)
            {
				Texture2D texture = ModContent.Request<Texture2D>("MultidimensionMod/Items/Weapons/Melee/Swords/LifelightCharged").Value;
				spriteBatch.Draw(texture, position, null, drawColor, 0f, origin, scale, SpriteEffects.None, 0f);
			}
        }

		public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
		{
			if (Light == 10)
			{
				Texture2D texture = ModContent.Request<Texture2D>("MultidimensionMod/Items/Weapons/Melee/Swords/LifelightCharged").Value;
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
					Item.direction == 1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally,
					0f
				);
			}
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ItemID.LightsBane)
			.AddIngredient(ItemID.SunplateBlock, 15)
			.AddIngredient(ModContent.ItemType<PaleMatter>(), 4)
			.AddIngredient(ModContent.ItemType<Dimensium>(), 10)
			.AddTile(ModContent.TileType<DimensionalForge>())
			.Register();
		}
	}
}