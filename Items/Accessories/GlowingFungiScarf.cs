using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MultidimensionMod.Buffs.Debuffs;
using MultidimensionMod.Buffs.Minions;
using MultidimensionMod.Common.Players;
using MultidimensionMod.Items.Materials;
using MultidimensionMod.Projectiles;
using MultidimensionMod.Projectiles.Summon.Minions;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Accessories
{
	public class GlowingFungiScarf : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.width = 30;
			Item.height = 46;
			Item.accessory = true;
			Item.value = Item.sellPrice(0, 0, 80, 0);
			Item.rare = ItemRarityID.Pink;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
            player.GetModPlayer<MDPlayer>().Symbio = true;
            Lighting.AddLight((int)(player.Center.X / 16f), (int)(player.Center.Y / 16f), 0.15f, 0.6f, 0.8f);
            player.GetModPlayer<MDPlayer>().SymbioAuraIsVisible = !hideVisual;
		}

        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Texture2D texture = ModContent.Request<Texture2D>("MultidimensionMod/Items/Accessories/GlowingFungiScarf_Glow").Value;
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

        public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<GlowingMushmatter>(), 12)
            .AddIngredient(ItemID.SoulofLight, 10)
            .AddIngredient(ItemID.SoulofMight, 7)
			.AddTile(TileID.MythrilAnvil)
			.Register();
		}
	}

    internal class SymbiosisAura :  ModProjectile
    {
        public override string Texture => "MultidimensionMod/ExtraTextures/Aura";
        public override void SetDefaults()
        {
            Projectile.width = 300;
            Projectile.height = 300;
            Projectile.penetrate = -1;
            Projectile.hostile = false;
            Projectile.friendly = false;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.alpha = 255;
        }
        public override void AI()
        {
            Player player = Main.player[Projectile.owner];
            Rectangle rectangle = new Rectangle((int)Projectile.position.X, (int)Projectile.position.Y, Projectile.width, Projectile.height);
            for (int e = 0; e < Main.maxNPCs; e++)
            {
                NPC npc = Main.npc[e];
                if (rectangle.Intersects(npc.Hitbox))
                {
                    npc.AddBuff(ModContent.BuffType<Illuminated>(), 360);
                    npc.AddBuff(ModContent.BuffType<SymbiosisTag>(), 360);
                }
            }
            if (player != null)
            {
                if (player.active)
                    Projectile.Center = player.Center;
            }

            Projectile.timeLeft = 10;
            Projectile.velocity *= 0;
            Projectile.localAI[0]++;
            if (Projectile.localAI[0] < 60)
            {
                if (Projectile.localAI[0] < 30)
                    Projectile.alpha -= 5;
                else
                    Projectile.alpha += 5;
                Projectile.scale += 0.002f;
            }
            else
            {
                Projectile.alpha = 255;
                Projectile.scale = 1;
                Projectile.Kill();
            }
            float baseScale = 0.5f;
            float pulseSpeed = 0.08f;
            float pulseAmount = 0.1f;

            Projectile.scale = baseScale +
                MathF.Sin((float)Main.GameUpdateCount * pulseSpeed) * pulseAmount;
        }

        public override bool PreDraw(ref Color lightColor)
        {
            Player player = Main.player[Projectile.owner];
            Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;
            Vector2 position = Projectile.Center - Main.screenPosition;
            Rectangle rect = new(0, 0, texture.Width, texture.Height);
            Vector2 origin = new(texture.Width / 2f, texture.Height / 2f);
            if (player.GetModPlayer<MDPlayer>().SymbioAuraIsVisible)
                Main.EntitySpriteDraw(texture, position, new Rectangle?(rect), Projectile.GetAlpha(Color.Blue), Projectile.rotation, origin, Projectile.scale, SpriteEffects.None, 0);

            return false;
        }
    }
}