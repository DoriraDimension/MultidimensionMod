using Microsoft.Xna.Framework;
using Mono.Cecil;
using MultidimensionMod.Buffs.Minions;
using MultidimensionMod.Projectiles.Summon.Minions;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Summon
{
    public class EaterStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Souleater Staff");
            //Tooltip.SetDefault(@"Summons an Eater to fight with you");
        }

        public override void SetDefaults()
        {
            Item.useStyle = 1;
            Item.shoot = ModContent.ProjectileType<EaterMinion>();
            Item.damage = 40;
            Item.width = 32;
            Item.height = 32;
            Item.UseSound = SoundID.Item44;
            Item.useAnimation = 30;
            Item.useTime = 30;
            Item.noMelee = true;
            Item.value = Item.sellPrice(0, 1, 0, 0);
            Item.knockBack = 5f;
            Item.rare = ItemRarityID.Green;
            Item.DamageType = DamageClass.Summon;
            Item.buffType = ModContent.BuffType<EaterMinionBuff>();
            Item.mana = 5;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            player.AddBuff(Item.buffType, 2);

            position = Main.MouseWorld;
            var projectile = Projectile.NewProjectileDirect(source, position, velocity, type, damage, knockback, Main.myPlayer);
            projectile.originalDamage = Item.damage;
            return false;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.DemoniteBar, 12)
            .AddTile(TileID.Anvils)
            .Register();
        }
    }
}