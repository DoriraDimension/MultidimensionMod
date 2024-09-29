using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using MultidimensionMod.Projectiles.Magic;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using System.Linq;

namespace MultidimensionMod.Items.Weapons.Magic.Tomes
{
    public class AncientSwordArt : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.damage = 12;
            Item.DamageType = DamageClass.Magic;
            Item.width = 30;
            Item.height = 26;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useStyle = ItemUseStyleID.RaiseLamp;
            Item.noMelee = true;
            Item.mana = 5;
            Item.knockBack = 1.5f;
            Item.noUseGraphic = true;
            Item.value = Item.sellPrice(1, 2, 3, 4);
            Item.rare = ItemRarityID.White;
            Item.autoReuse = true;
            Item.UseSound = SoundID.Item1;
            Item.shoot = ModContent.ProjectileType<ArtSword>();
            Item.shootSpeed = 1f;
            Item.channel = true;
        }
        public override bool PreDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, ref float rotation, ref float scale, int whoAmI)
        {
            Lighting.AddLight(Item.Center, TorchID.Rainbow);
            return true;
        }
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Texture2D texture = ModContent.Request<Texture2D>("MultidimensionMod/Items/Weapons/Magic/Tomes/AncientSwordArt_Glow").Value;
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
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (!Main.projectile.Any(n => n.active && n.owner == player.whoAmI && n.type == ModContent.ProjectileType<AncientSwordArtHeld>()))
            {
                Projectile.NewProjectile(source, position, Vector2.Zero, ModContent.ProjectileType<AncientSwordArtHeld>(), 0, 0, player.whoAmI);
            }
            Projectile.NewProjectile(source, Main.MouseWorld, velocity, type, damage, knockback, player.whoAmI);
            return false;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.WoodenSword, 1)
            .AddIngredient(ItemID.Silk, 10)
            .AddIngredient(ItemID.Diamond, 2)
            .AddIngredient(ItemID.Amber, 2)
            .AddIngredient(ItemID.Ruby, 2)
            .AddIngredient(ItemID.Emerald, 2)
            .AddIngredient(ItemID.Sapphire, 2)
            .AddIngredient(ItemID.Topaz, 2)
            .AddIngredient(ItemID.Amethyst, 2)
            .AddTile(TileID.Loom)
            .Register();
        }
    }
}