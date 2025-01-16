using MultidimensionMod.Items.Materials;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Mono.Cecil;
using MultidimensionMod.Common.Players;

namespace MultidimensionMod.Items.Weapons.Melee.Swords
{
    public class FishronCleaver : FishCleaver
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.damage = 97;
            Item.DamageType = DamageClass.Melee;
            Item.width = 98;
            Item.height = 94;
            Item.useTime = 54;
            Item.useAnimation = 54;
            Item.useStyle = ItemUseStyleID.HiddenAnimation;
            Item.knockBack = 9;
            Item.value = Item.sellPrice(0, 5, 0, 0);
            Item.rare = ItemRarityID.Yellow;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.crit = 9;
            Item.shoot = ModContent.ProjectileType<AquaticVisualSlashTrail>();
        }


        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            for (int i = 0; i < 8; i++)
            {
                Vector2 Velocity = player.DirectionTo(target.Center).RotatedByRandom(MathHelper.ToRadians(30));
                Velocity *= 15f - Main.rand.NextFloat(5f);
                Projectile.NewProjectileDirect(Item.GetSource_OnHit(target), player.Center, Velocity, ProjectileID.FlaironBubble, (int)((double)((float)Item.damage) * 0.4), 0f, player.whoAmI);
            }
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Projectile.NewProjectile(source, position, velocity, type, damage, knockback, player.whoAmI, 1);


            return false;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<FishCleaver>())
            .AddIngredient(ModContent.ItemType<TidalQuartz>(), 15)
            .AddCondition(Condition.NearWater)
            .Register();
        }
    }
}