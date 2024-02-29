using MultidimensionMod.Items.Materials;
using MultidimensionMod.Common.Players;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using static Terraria.ModLoader.ModContent;


namespace MultidimensionMod.Items.Armor
{
    class MushiumCapDraw : PlayerDrawLayer
    {
        public override bool GetDefaultVisibility(PlayerDrawSet drawInfo) => drawInfo.drawPlayer.head == EquipLoader.GetEquipSlot(Mod, nameof(MushiumHat), EquipType.Head) && drawInfo.drawPlayer.GetModPlayer<MDPlayer>().IndigoMode;

        public override Position GetDefaultPosition() => new AfterParent(PlayerDrawLayers.Head);

        protected override void Draw(ref PlayerDrawSet drawInfo)
        {
            Texture2D texture = Request<Texture2D>("MultidimensionMod/Items/Armor/MushiumHatIndigo_Head").Value;

            Vector2 pos = new Vector2((int)(drawInfo.Position.X - Main.screenPosition.X) + ((drawInfo.drawPlayer.width - drawInfo.drawPlayer.bodyFrame.Width) / 2), (int)(drawInfo.Position.Y - Main.screenPosition.Y) + drawInfo.drawPlayer.height - drawInfo.drawPlayer.bodyFrame.Height + 4) + drawInfo.drawPlayer.headPosition + drawInfo.rotationOrigin;
            DrawData drawData = new DrawData(texture, pos, drawInfo.drawPlayer.bodyFrame, drawInfo.headGlowColor, drawInfo.drawPlayer.headRotation, drawInfo.rotationOrigin, 1f, drawInfo.playerEffect, 0)
            { shader = drawInfo.cHead };

            drawInfo.DrawDataCache.Add(drawData);
        }
    }

    class MushiumBodyDraw : PlayerDrawLayer
    {
        public override bool GetDefaultVisibility(PlayerDrawSet drawInfo) => drawInfo.drawPlayer.body == EquipLoader.GetEquipSlot(Mod, nameof(MushiumShirt), EquipType.Body) && drawInfo.drawPlayer.GetModPlayer<MDPlayer>().IndigoMode;

        public override Position GetDefaultPosition() => new AfterParent(PlayerDrawLayers.Torso);

        protected override void Draw(ref PlayerDrawSet drawInfo)
        {
            Texture2D texture = Request<Texture2D>("MultidimensionMod/Items/Armor/MushiumShirtIndigo_Body").Value;

            if (drawInfo.drawPlayer.invis)
                return;

            Vector2 pos = new Vector2((int)(drawInfo.Position.X - Main.screenPosition.X - (drawInfo.drawPlayer.bodyFrame.Width / 2) + (drawInfo.drawPlayer.width / 2)), (int)(drawInfo.Position.Y - Main.screenPosition.Y + drawInfo.drawPlayer.height - drawInfo.drawPlayer.bodyFrame.Height + 2)) + drawInfo.drawPlayer.bodyPosition + drawInfo.rotationOrigin;
            Vector2 bobOff = Main.OffsetsPlayerHeadgear[drawInfo.drawPlayer.bodyFrame.Y / drawInfo.drawPlayer.bodyFrame.Height] * drawInfo.drawPlayer.gravDir;
            if (drawInfo.drawPlayer.gravDir == -1)
                bobOff.Y += 4;

            if (drawInfo.usesCompositeTorso)
            {
                DrawData drawData = new DrawData(texture, pos + bobOff, drawInfo.compTorsoFrame, drawInfo.bodyGlowColor, drawInfo.drawPlayer.bodyRotation, drawInfo.rotationOrigin, 1f, drawInfo.playerEffect)
                { shader = drawInfo.cBody };

                drawInfo.DrawDataCache.Add(drawData);
            }
            else
            {
                DrawData drawData = new DrawData(texture, pos + bobOff, drawInfo.drawPlayer.bodyFrame, drawInfo.bodyGlowColor, drawInfo.drawPlayer.bodyRotation, drawInfo.rotationOrigin, 1f, drawInfo.playerEffect, 0)
                { shader = drawInfo.cBody };

                drawInfo.DrawDataCache.Add(drawData);
            }
        }
    }

    class MushiumArmDraw : PlayerDrawLayer
    {
        public override bool GetDefaultVisibility(PlayerDrawSet drawInfo) => drawInfo.drawPlayer.body == EquipLoader.GetEquipSlot(Mod, nameof(MushiumShirt), EquipType.Body) && drawInfo.drawPlayer.GetModPlayer<MDPlayer>().IndigoMode;

        public override Position GetDefaultPosition() => new AfterParent(PlayerDrawLayers.ArmOverItem);

        protected override void Draw(ref PlayerDrawSet drawInfo)
        {
            Texture2D texture = Request<Texture2D>("MultidimensionMod/Items/Armor/MushiumShirtIndigo_Body").Value;

            if (drawInfo.drawPlayer.invis)
                return;

            Vector2 bobOff = Main.OffsetsPlayerHeadgear[drawInfo.drawPlayer.bodyFrame.Y / drawInfo.drawPlayer.bodyFrame.Height] * drawInfo.drawPlayer.gravDir;
            if (drawInfo.drawPlayer.gravDir == -1)
                bobOff.Y += 4;

            if (drawInfo.usesCompositeTorso)
            {
                static Vector2 GetCompositeOffset_FrontArm(ref PlayerDrawSet drawinfo) => new(-5 * ((!drawinfo.playerEffect.HasFlag(SpriteEffects.FlipHorizontally)) ? 1 : (-1)), 0f);

                Vector2 pos = new Vector2((int)(drawInfo.Position.X - Main.screenPosition.X - (drawInfo.drawPlayer.bodyFrame.Width / 2) + (drawInfo.drawPlayer.width / 2)), (int)(drawInfo.Position.Y - Main.screenPosition.Y + drawInfo.drawPlayer.height - drawInfo.drawPlayer.bodyFrame.Height + 2)) + drawInfo.drawPlayer.bodyPosition + (drawInfo.drawPlayer.bodyFrame.Size() / 2);
                pos += GetCompositeOffset_FrontArm(ref drawInfo);

                Vector2 bodyVect = drawInfo.bodyVect + GetCompositeOffset_FrontArm(ref drawInfo);
                Vector2 shoulderPos = pos + drawInfo.frontShoulderOffset;
                if (drawInfo.compFrontArmFrame.X / drawInfo.compFrontArmFrame.Width >= 7)
                    pos += new Vector2((!drawInfo.playerEffect.HasFlag(SpriteEffects.FlipHorizontally)) ? 1 : (-1), (!drawInfo.playerEffect.HasFlag(SpriteEffects.FlipVertically)) ? 1 : (-1));

                float rotation = drawInfo.drawPlayer.bodyRotation + drawInfo.compositeFrontArmRotation;
                DrawData drawData = new DrawData(texture, pos + bobOff, drawInfo.compFrontArmFrame, drawInfo.bodyGlowColor, rotation, bodyVect, 1f, drawInfo.playerEffect)
                { shader = drawInfo.cBody };

                drawInfo.DrawDataCache.Add(drawData);

                if (!drawInfo.hideCompositeShoulders)
                {
                    DrawData drawData2 = new DrawData(texture, shoulderPos + bobOff, drawInfo.compFrontShoulderFrame, drawInfo.bodyGlowColor, drawInfo.drawPlayer.bodyRotation, bodyVect, 1f, drawInfo.playerEffect)
                    { shader = drawInfo.cBody };

                    drawInfo.DrawDataCache.Add(drawData2);
                }
            }
            else
            {
                Vector2 pos = new Vector2((int)(drawInfo.Position.X - Main.screenPosition.X - (drawInfo.drawPlayer.bodyFrame.Width / 2) + (drawInfo.drawPlayer.width / 2)), (int)(drawInfo.Position.Y - Main.screenPosition.Y + drawInfo.drawPlayer.height - drawInfo.drawPlayer.bodyFrame.Height + 2)) + drawInfo.drawPlayer.bodyPosition + drawInfo.rotationOrigin;
                DrawData drawData = new DrawData(texture, pos + bobOff, drawInfo.drawPlayer.bodyFrame, drawInfo.bodyGlowColor, drawInfo.drawPlayer.bodyRotation, drawInfo.rotationOrigin, 1f, drawInfo.playerEffect, 0)
                { shader = drawInfo.cBody };

                drawInfo.DrawDataCache.Add(drawData);
            }
        }
    }

    class MushiumLegDraw : PlayerDrawLayer
    {
        public override bool GetDefaultVisibility(PlayerDrawSet drawInfo) => drawInfo.drawPlayer.legs == EquipLoader.GetEquipSlot(Mod, nameof(MushiumPants), EquipType.Legs) && drawInfo.drawPlayer.GetModPlayer<MDPlayer>().IndigoMode;

        public override Position GetDefaultPosition() => new AfterParent(PlayerDrawLayers.Leggings);

        protected override void Draw(ref PlayerDrawSet drawInfo)
        {
            Texture2D texture = Request<Texture2D>("MultidimensionMod/Items/Armor/MushiumPantsIndigo_Legs").Value;

            if (drawInfo.drawPlayer.invis || drawInfo.isSitting)
                return;

            if (drawInfo.drawPlayer.shoe != 15 || drawInfo.drawPlayer.wearsRobe)
            {
                Vector2 pos = new Vector2((int)(drawInfo.Position.X - Main.screenPosition.X - (drawInfo.drawPlayer.legFrame.Width / 2) + (drawInfo.drawPlayer.width / 2)), (int)(drawInfo.Position.Y - Main.screenPosition.Y + drawInfo.drawPlayer.height - drawInfo.drawPlayer.legFrame.Height + 4)) + drawInfo.drawPlayer.legPosition + drawInfo.rotationOrigin;
                DrawData drawData = new DrawData(texture, pos, drawInfo.drawPlayer.legFrame, drawInfo.legsGlowColor, drawInfo.drawPlayer.legRotation, drawInfo.rotationOrigin, 1f, drawInfo.playerEffect, 0)
                { shader = drawInfo.cLegs };

                drawInfo.DrawDataCache.Add(drawData);
            }
        }
    }
}