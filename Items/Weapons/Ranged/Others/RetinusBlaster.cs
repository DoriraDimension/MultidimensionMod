using MultidimensionMod.Projectiles.Ranged;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace MultidimensionMod.Items.Weapons.Ranged.Others
{
    public class RetinusBlaster : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.DamageType = DamageClass.Ranged;
            Item.damage = 34;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.useTime = 40;
            Item.useAnimation = 40;
            Item.knockBack = 0f;
            Item.UseSound = null;
            Item.width = 80;
            Item.height = 38;
            Item.value = Item.sellPrice(0, 2, 0, 0);
            Item.autoReuse = true;
            Item.noMelee = true;
            Item.noUseGraphic = true;
            Item.channel = true;
            Item.rare = ItemRarityID.Pink;
            Item.shoot = ModContent.ProjectileType<RetinusBlasterHoldOut>();
            Item.shootSpeed = 15f;
            Item.crit = 30;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            return player.ownedProjectileCounts[Item.shoot] < 1;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.HallowedBar, 15)
            .AddIngredient(ItemID.SoulofSight, 8)
            .AddTile(TileID.MythrilAnvil)
            .Register();
        }

        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Texture2D texture = ModContent.Request<Texture2D>("MultidimensionMod/Items/Weapons/Ranged/Others/RetinusBlaster_Glow").Value;
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