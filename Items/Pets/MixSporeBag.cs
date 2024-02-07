using MultidimensionMod.Buffs.Pets;
using MultidimensionMod.Projectiles.Pets;
using MultidimensionMod.Items.Mushrooms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using System;
using System.Collections.Generic;
using Terraria.DataStructures;

namespace MultidimensionMod.Items.Pets
{
    public class MixSporeBag : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.damage = 0;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useAnimation = 20;
            Item.useTime = 20;
            Item.width = 28;
            Item.height = 32;
            Item.noMelee = true;
            Item.shoot = ProjectileID.None;
            Item.buffType = ModContent.BuffType<BrothersBuff>();
            Item.value = Item.sellPrice(silver: 50);
            Item.rare = ItemRarityID.Green;
        }

        public override void UseStyle(Player player, Rectangle heldItemFrame)
        {
            if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
            {
                player.AddBuff(Item.buffType, 3600);
            }
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            List<int> pets = new List<int> { ModContent.ProjectileType<FeudalBab>(), ModContent.ProjectileType<MonarchBab>() };
            foreach (int they in pets)
                Projectile.NewProjectile(source, position, velocity, they, damage, knockback, player.whoAmI);
            return false;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<SusSporeBag>())
                .AddIngredient(ModContent.ItemType<SusGlowsporeBag>())
                .AddIngredient(ModContent.ItemType<Rainbow>())
                .AddTile(TileID.TinkerersWorkbench)
                .Register();
        }
    }
}