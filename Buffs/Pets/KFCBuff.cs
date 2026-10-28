using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MultidimensionMod.Biomes;
using MultidimensionMod.Buffs.Debuffs;
using MultidimensionMod.Common.Globals;
using MultidimensionMod.Projectiles.Pets;
using ReLogic.Content;
using Terraria;
using Terraria.DataStructures;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Buffs.Pets
{
    public class KFCBuff : ModBuff
    {
        public static readonly int FrameCount = 2;
        public static readonly string AnimationSheetPath = "MultidimensionMod/Buffs/Pets/KFCBuff";
        private Asset<Texture2D> buffChange;
        public override void SetStaticDefaults()
        {
            Main.buffNoTimeDisplay[Type] = true;
            Main.vanityPet[Type] = true;
            buffChange = ModContent.Request<Texture2D>(AnimationSheetPath);
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.buffTime[buffIndex] = 18000;

            int projType = ModContent.ProjectileType<KFCPet>();
            if (player.whoAmI == Main.myPlayer && player.ownedProjectileCounts[projType] <= 0)
            {
                var entitySource = player.GetSource_Buff(buffIndex);
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.Center, Vector2.Zero, projType, 0, 0f, player.whoAmI);
            }
        }

        public override void ModifyBuffText(ref string buffName, ref string tip, ref int rare)
        {
            if (Main.bloodMoon || Main.eclipse || MDWorld.MadnessMoon)
            {
                buffName = Language.GetTextValue("Mods.MultidimensionMod.Buffs.KFCBuff.EldritchName");
                tip = Language.GetTextValue("Mods.MultidimensionMod.Buffs.KFCBuff.EldritchTooltip");
            }
        }

        public override bool PreDraw(SpriteBatch spriteBatch, int buffIndex, ref BuffDrawParams drawParams)
        {
            Texture2D Texture = buffChange.Value;
            if (Main.bloodMoon || Main.eclipse || MDWorld.MadnessMoon)
            {
                Rectangle rectangle = Texture.Frame(verticalFrames: FrameCount, frameY: 1);
                drawParams.Texture = Texture;
                drawParams.SourceRectangle = rectangle;
            }
            else
            {
                Rectangle rectangle = Texture.Frame(verticalFrames: FrameCount, frameY: 0);
                drawParams.Texture = Texture;
                drawParams.SourceRectangle = rectangle;
            }
            return true;
        }
    }
}