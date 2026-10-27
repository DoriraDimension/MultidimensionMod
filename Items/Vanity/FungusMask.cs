using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MultidimensionMod.Common.Players;
using MultidimensionMod.Items.Armor;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MultidimensionMod.Items.Vanity
{
    [AutoloadEquip(EquipType.Head)]
    public class FungusMask : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 26;
            Item.value = Item.sellPrice(0, 0, 60, 0);
            Item.rare = ItemRarityID.Green;
            Item.vanity = true;
            ArmorIDs.Head.Sets.DrawHead[Item.headSlot] = false;

        }

        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Texture2D texture = ModContent.Request<Texture2D>("MultidimensionMod/Items/Materials/FungusMask_Glow").Value;
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

    class FungusMaskGlow : PlayerDrawLayer
    {
        public override Position GetDefaultPosition() => new AfterParent(PlayerDrawLayers.Head);

        protected override void Draw(ref PlayerDrawSet drawInfo)
        {
            Texture2D texture = Request<Texture2D>("MultidimensionMod/Items/Vanity/FungusMask_HeadGlow").Value;

            Vector2 pos = new Vector2((int)(drawInfo.Position.X - Main.screenPosition.X) + ((drawInfo.drawPlayer.width - drawInfo.drawPlayer.bodyFrame.Width) / 2), (int)(drawInfo.Position.Y - Main.screenPosition.Y) + drawInfo.drawPlayer.height - drawInfo.drawPlayer.bodyFrame.Height + 4) + drawInfo.drawPlayer.headPosition + drawInfo.rotationOrigin;
            DrawData drawData = new DrawData(texture, pos, drawInfo.drawPlayer.bodyFrame, Color.White, drawInfo.drawPlayer.headRotation, drawInfo.rotationOrigin, 1f, drawInfo.playerEffect, 0)
            { shader = drawInfo.cHead };

            drawInfo.DrawDataCache.Add(drawData);
        }
    }
}