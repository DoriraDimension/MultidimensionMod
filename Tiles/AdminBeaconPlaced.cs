using Humanizer;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MultidimensionMod.Common.Systems;
using MultidimensionMod.Dusts;
using MultidimensionMod.Items.Materials;
using MultidimensionMod.NPCs.Bosses.FeudalFungus;
using MultidimensionMod.NPCs.MushBiomes;
using MultidimensionMod.NPCs.TownNPCs;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace MultidimensionMod.Tiles
{
    public class AdminBeaconPlaced : ModTile
    {
        public static bool active = false;

        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
            TileObjectData.newTile.Origin = new Point16(1, 1);
            TileObjectData.newTile.Height = 3;
            TileObjectData.newTile.Width = 2;
            TileObjectData.newTile.CoordinateHeights = new[] { 16, 16, 18 };
            TileID.Sets.DisableSmartCursor[Type] = true;
            TileObjectData.addTile(Type);
            LocalizedText name = CreateMapEntryName();
            AddMapEntry(new Color(35, 189, 236), name);
            DustType = ModContent.DustType<DimensionDust1>();
            AnimationFrameHeight = 56;
        }

        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            if (active)
                num = 20;
            else
                num = 5;
        }

        public override bool RightClick(int i, int j)
        {
            Player player = Main.LocalPlayer;
            int dimensium = player.FindItem(ModContent.ItemType<Dimensium>());
            if (!active && dimensium >= 10)
            {
                player.inventory[dimensium].stack -= 10;
                if (!DownedSystem.metAdmin)
                {
                    Projectile.NewProjectile(new EntitySource_WorldEvent(), new Vector2(i * 16f, j * 16f - 200f), Vector2.Zero, ModContent.ProjectileType<AdminSpawnPortal>(), 0, 0f, Main.myPlayer, 0f);
                }
                active = true;
            }
            return true;
        }

        public override void KillTile(int i, int j, ref bool fail, ref bool effectOnly, ref bool noItem)
        {
            active = false;
        }

        public override void AnimateTile(ref int frame, ref int frameCounter)
        {
            if (active)
                frame = 1;
            else
                frame = 0;
        }
    }

    internal class AdminSpawnPortal : ModProjectile
    {
        public override string Texture => "MultidimensionMod/Projectiles/NoTexture";
        public override void SetDefaults()
        {
            Projectile.width = 50;
            Projectile.height = 50;
            Projectile.penetrate = -1;
            Projectile.hostile = false;
            Projectile.friendly = false;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.alpha = 255;
        }

        public override void OnSpawn(IEntitySource source)
        {
            SoundEngine.PlaySound(new("MultidimensionMod/Sounds/Custom/Magic"), Projectile.position);
        }
        public Entity entityTarget;
        private bool IsPortal = false;
        private int PortalTimer = 0;
        public override void AI()
        {
            PortalTimer++;
            if (PortalTimer < 180)
            {
                for (int i = 0; i < 10; i++)
                {
                    int dustIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, ModContent.DustType<DimensionDust1>(), 0f, 0f, 100, default(Color), 2f);
                    Main.dust[dustIndex].velocity *= 1.8f;
                    Main.dust[dustIndex].alpha = 50;
                }
            }
            if (PortalTimer >= 180)
            {
                Projectile.scale += 0.002f;
                Projectile.rotation += 0.002f;
            }
            if (PortalTimer == 180)
            {
                IsPortal = true;
                Projectile.velocity = Vector2.Zero;
            }
            if (PortalTimer == 320)
            {
                NPC.NewNPC(Projectile.GetSource_FromThis(), (int)Projectile.Center.X, (int)Projectile.Center.Y, ModContent.NPCType<AdminArrival>());
            }
            if (PortalTimer >= 380)
            {
                Projectile.Kill();
            }
        }

        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D texture = ModContent.Request<Texture2D>("MultidimensionMod/NPCs/TownNPCs/TarahaPortal").Value;
            Vector2 drawOrigin = new(texture.Width / 2, texture.Height / 2);
            var effects = Projectile.spriteDirection == 1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
            if (IsPortal)
            {
                Main.EntitySpriteDraw(texture, Projectile.Center - Main.screenPosition, null, Projectile.GetAlpha(Color.White), Projectile.rotation, drawOrigin, Projectile.scale, effects, 0);
            }
            return false;
        }
    }
}