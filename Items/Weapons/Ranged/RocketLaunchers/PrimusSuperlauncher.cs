using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MultidimensionMod.Projectiles.Ranged;
using ReLogic.Content;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Ranged.RocketLaunchers
{
	public class PrimusSuperlauncher : ModItem
	{
        private static Asset<Texture2D> Glow;
        public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            Glow = ModContent.Request<Texture2D>(Texture + "_Glow");
        }

		public override void SetDefaults()
		{
			Item.damage = 49;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 58;
			Item.height = 26;
			Item.useTime = 16;
			Item.useAnimation = 56;
			Item.reuseDelay = 45;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 6;
			Item.value = Item.sellPrice(0, 3, 0, 0);
			Item.rare = ItemRarityID.Pink;
			Item.autoReuse = true;
			Item.shoot = ProjectileID.PurificationPowder;
			Item.shootSpeed = 12f;
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			SoundEngine.PlaySound(new("MultidimensionMod/Sounds/Custom/LauncherShot"), player.position);
			return true;
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-8, 0);
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ItemID.HallowedBar, 13)
			.AddIngredient(ItemID.SoulofFright, 6)
			.AddTile(TileID.MythrilAnvil)
			.Register();
		}

		public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			type = Main.rand.Next(new int[] { ModContent.ProjectileType<PrimusVice>(), ModContent.ProjectileType<PrimusSaw>(), ModContent.ProjectileType<PrimusLaser>(), ModContent.ProjectileType<PrimusCannon>() });
		}

        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Texture2D texture = ModContent.Request<Texture2D>("MultidimensionMod/Items/Weapons/Ranged/RocketLaunchers/PrimusSuperlauncher_Glow").Value;
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
