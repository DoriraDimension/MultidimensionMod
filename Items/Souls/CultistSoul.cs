using MultidimensionMod.Rarities.Souls;
using MultidimensionMod.Common.Systems;
using Terraria.DataStructures;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria.Localization;
using Microsoft.Xna.Framework.Graphics;
using MultidimensionMod.Base;
using Terraria.Audio;
using Terraria.Graphics.CameraModifiers;
using Terraria.GameContent;
using MultidimensionMod.Utilities;
using System;

namespace MultidimensionMod.Items.Souls
{
	public class CultistSoul : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(7, 8));
			ItemID.Sets.AnimatesAsSoul[Item.type] = true;
			ItemID.Sets.ItemIconPulse[Item.type] = true;
			ItemID.Sets.ItemNoGravity[Item.type] = true;
		}

		public override void SetDefaults()
		{
			Item.width = 40;
			Item.height = 40;
			Item.rare = ModContent.RarityType<CultistSoulRarity>();
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.UseSound = SoundID.Zombie89;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            if (Common.Systems.MemorySystem.summonedMoonSword)
            {
                TooltipLine line = new(Mod, "TTWithSword", Language.GetTextValue("Mods.MultidimensionMod.Items.CultistSoul.TTWithSword"))
                {
                    OverrideColor = Color.White
                };
                tooltips.Add(line);
            }
            else if (!Common.Systems.MemorySystem.summonedMoonSword)
            {
                TooltipLine line = new(Mod, "TTNoSword", Language.GetTextValue("Mods.MultidimensionMod.Items.CultistSoul.TTNoSword"))
                {
                    OverrideColor = Color.White
                };
                tooltips.Add(line);
            }
            if (Main.keyState.PressingShift())
            {
                TooltipLine line = new(Mod, "Lore", Language.GetTextValue("Mods.MultidimensionMod.Items.CultistSoul.Lore"))
                {
                };
                tooltips.Add(line);
            }
            else
            {
                TooltipLine line = new(Mod, "HoldShift", Language.GetTextValue("Mods.MultidimensionMod.MiscText.SpecialTooltips.Viewer"))
                {
                    OverrideColor = Color.Gray,
                };
                tooltips.Add(line);
            }
        }

        public override bool CanUseItem(Player player)
        {
            if (MemorySystem.summonedMoonSword)
            {
                return false;
            }
            return true;
        }

        public override bool? UseItem(Player player)
        {
            if (player.ownedProjectileCounts[ModContent.ProjectileType<GreatMoonlightManifest>()] < 1)
                Projectile.NewProjectile(player.GetSource_FromThis(), player.Center.X, player.Center.Y - 200, 0f, 0f, ModContent.ProjectileType<GreatMoonlightManifest>(), 0, 0f, player.whoAmI);
            return true;
        }

        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Texture2D texture = ModContent.Request<Texture2D>("MultidimensionMod/Items/Souls/CultistSoul").Value;
            Rectangle frame;
            frame = Main.itemAnimations[Item.type].GetFrame(texture, Main.itemFrameCounter[whoAmI]);
            Vector2 origin = frame.Size() / 2f;
            spriteBatch.Draw(texture, Item.Center - Main.screenPosition, frame, Color.White, rotation, origin, scale, SpriteEffects.None, 0f);
        }

    }

    internal class GreatMoonlightManifest : ModProjectile
    {
        public override string Texture => "MultidimensionMod/Items/Weapons/Magic/Others/GreatMoonlight";
        public override void SetStaticDefaults()
        {
        }

        public override void SetDefaults()
        {
            Projectile.width = 72;
            Projectile.height = 72;
            Projectile.penetrate = -1;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.timeLeft = 9000;
        }

        public override void OnKill(int timeLeft)
        {
            MemorySystem.summonedMoonSword = true;
            for (int i = 0; i < 10; i++)
            {
                int dustIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.MagicMirror, 0f, 0f, 100, default(Color), 2f);
                Main.dust[dustIndex].velocity *= 1.8f;
                Main.dust[dustIndex].alpha = 50;
                Main.dust[dustIndex].color = Color.MintCream;
            }
        }

        public override bool? CanCutTiles()
        {
            return false;
        }
        public override bool? CanDamage() => false;
        public int AppearTimer = 0;
        public float ShakeStrength = 0f;
        public float ShakeFrames = 0f;

        public override void AI()
        {
            Projectile.velocity.X = 0;
            Projectile.velocity.Y = 0;
            AppearTimer++;
            if (ShakeStrength >= 4f)
            {
                ShakeStrength = 4f;
            }
            if (ShakeFrames >= 5f)
            {
                ShakeFrames = 5f;
            }
            if (AppearTimer == 1)
            {
                Projectile.rotation += MathHelper.ToRadians(315f);
            }
            if (AppearTimer >= 60 && AppearTimer < 240)
            {
                if (!ModContent.GetInstance<MDConfig>().ScreenshakeDisable)
                {
                    ShakeStrength += 0.0050f;
                    ShakeFrames += 0.050f;
                    PunchCameraModifier modifier = new PunchCameraModifier(Projectile.Center, (Main.rand.NextFloat() * ((float)Math.PI * 2f)).ToRotationVector2(), ShakeFrames, ShakeStrength, 20, 500f, FullName);
                    Main.instance.CameraModifiers.Add(modifier);
                }
            }
            if (AppearTimer == 240)
            {
                Main.NewText(Language.GetTextValue("Mods.MultidimensionMod.MiscText.SoulConversation.Cultist.MoonSwordSpawn"), new Color(175, 75, 255));
                SoundEngine.PlaySound(SoundID.Thunder, Projectile.position);
                SoundEngine.PlaySound(SoundID.Zombie105, Projectile.position);
                for (int m = 0; m < 30; m++)
                {
                    int dustID = Dust.NewDust(new Vector2(Projectile.Center.X - 1, Projectile.Center.Y - 1), 2, 2, DustID.MagicMirror, 0f, 0f, 100, Color.White, 1.6f);
                    Main.dust[dustID].velocity = BaseUtility.RotateVector(default, new Vector2(6f, 0f), m / (float)30 * 6.28f);
                    Main.dust[dustID].noLight = false;
                    Main.dust[dustID].noGravity = true;
                }
            }
            if (AppearTimer >= 240)
            {
                Projectile.light = 1.8f;
            }
            if (AppearTimer == 360)
            {
                SoundEngine.PlaySound(SoundID.Zombie88, Projectile.position);
                int i = CombatText.NewText(Projectile.getRect(), Color.Cyan, Language.GetTextValue("Mods.MultidimensionMod.MiscText.SoulConversation.Cultist.MoonSword1"), false, false);
                Main.combatText[i].lifeTime = 120;
            }
            if (AppearTimer == 540)
            {
                SoundEngine.PlaySound(SoundID.Zombie90, Projectile.position);
                int i = CombatText.NewText(Projectile.getRect(), Color.Cyan, Language.GetTextValue("Mods.MultidimensionMod.MiscText.SoulConversation.Cultist.MoonSword2"), false, false);
                Main.combatText[i].lifeTime = 120;
            }
            if (AppearTimer == 720)
            {
                SoundEngine.PlaySound(SoundID.Zombie91, Projectile.position);
                int i = CombatText.NewText(Projectile.getRect(), Color.Cyan, Language.GetTextValue("Mods.MultidimensionMod.MiscText.SoulConversation.Cultist.MoonSword3"), false, false);
                Main.combatText[i].lifeTime = 120;
            }
            if (AppearTimer == 900)
            {
                SoundEngine.PlaySound(SoundID.Zombie90, Projectile.position);
                int i = CombatText.NewText(Projectile.getRect(), Color.Cyan, Language.GetTextValue("Mods.MultidimensionMod.MiscText.SoulConversation.Cultist.MoonSword4"), false, false);
                Main.combatText[i].lifeTime = 120;
            }
            if (AppearTimer == 1080)
            {
                SoundEngine.PlaySound(SoundID.Zombie105, Projectile.position);
                Item.NewItem(Projectile.GetSource_FromThis(), Projectile.position, Projectile.Size, ModContent.ItemType<Weapons.Magic.Others.GreatMoonlight>(), 1);
                Projectile.Kill();
            }
        }

        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;
            Texture2D glowTexture = ModContent.Request<Texture2D>("MultidimensionMod/Items/Weapons/Magic/Others/GreatMoonlight_Glow").Value;
            Vector2 position = Projectile.Center - Main.screenPosition;
            Rectangle rect = new(0, 0, texture.Width, texture.Height);
            Vector2 origin = new(texture.Width / 2f, texture.Height / 2f);
            if (AppearTimer >= 240)
            {
                Main.EntitySpriteDraw(texture, position, new Rectangle?(rect), Projectile.GetAlpha(lightColor), Projectile.rotation, origin, Projectile.scale, SpriteEffects.None, 0);
                Main.EntitySpriteDraw(glowTexture, position, new Rectangle?(rect), Color.White, Projectile.rotation, origin, Projectile.scale, SpriteEffects.None, 0);
            }
            return false;
        }
    }

    public class GMSP : ModPlayer
    {
        public override void ModifyScreenPosition()
        {
            if (MDHelper.AnyProjectiles(ModContent.ProjectileType<GreatMoonlightManifest>()))
            {
            }
        }
    }
}