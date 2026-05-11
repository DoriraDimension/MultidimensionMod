using MultidimensionMod.Items.Placeables;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using MultidimensionMod.Common.Players;
using System;
using Terraria.GameContent.UI.ResourceSets;
using MultidimensionMod.NPCs.Bosses.MushroomMonarch;
using Terraria.GameContent;
using Microsoft.Xna.Framework.Graphics;
using MultidimensionMod.Base;

namespace MultidimensionMod.Items.Weapons.Melee.Swords
{
    public class FishCleaver : ModItem
    {

        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            ItemID.Sets.ShimmerTransformToItem[Type] = ModContent.ItemType<FishLegacy>();
        }

        public override void SetDefaults()
        {
            Item.damage = 82;
            Item.DamageType = DamageClass.Melee;
            Item.width = 86;
            Item.height = 86;
            Item.useTime = 54;
            Item.useAnimation = 54;
            Item.useStyle = ItemUseStyleID.HiddenAnimation;
            Item.knockBack = 8;
            Item.value = Item.sellPrice(0, 3, 35, 0);
            Item.rare = ItemRarityID.LightRed;
            Item.autoReuse = true;
            Item.UseSound = SoundID.Item1;
            Item.crit = 8;
            Item.shoot = ModContent.ProjectileType<AquaticVisualSlashTrail>();

        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.BreakerBlade)
            .AddIngredient(ItemID.Bass, 3)
            .AddIngredient(ItemID.RedSnapper, 3)
            .AddIngredient(ItemID.Trout, 3)
            .AddCondition(Condition.NearWater)
            .Register();
        }

        public override bool CanUseItem(Player player)
        {

            if (player.whoAmI == Main.myPlayer)
            {
                player.AL().swingDir *= -1;
                player.AL().startingDirection = (player.Center - Main.MouseWorld).SafeNormalize(Vector2.UnitY);

            }


            return true;
        }

        private static float HeavySwingEase(float t) => (float)Math.Pow(2, 6 * (t - 1));



        public override void UseStyle(Player player, Rectangle heldItemFrame)
        {
            player.AL().progress = player.AL().swingDir == 1 ? MathHelper.Lerp(0f, 1f, HeavySwingEase((float)player.AL().Player.itemAnimation / player.AL().Player.itemAnimationMax)) : MathHelper.Lerp(1f, 0f, HeavySwingEase((float)player.AL().Player.itemAnimation / player.AL().Player.itemAnimationMax));

            if (player.Center.X + player.AL().startingDirection.X > player.Center.X)
                player.ChangeDir(-1);
            else
                player.ChangeDir(1);
            player.AL().currentArmRotation = player.AL().startingDirection.RotatedBy(-MathHelper.PiOver4).ToRotation() + (MathHelper.Pi * 1.5f) * player.AL().progress;
            player.AL().currentArmPosition = player.AL().Player.GetFrontHandPosition(Player.CompositeArmStretchAmount.Full, player.AL().currentArmRotation);
            player.itemLocation = player.AL().currentArmPosition;
            player.itemRotation = player.direction == 1 ? player.AL().currentArmRotation + MathHelper.PiOver4 * 3 : player.AL().currentArmRotation - MathHelper.PiOver4 * 3;
            player.SetCompositeArmFront(true, Player.CompositeArmStretchAmount.Full, player.AL().currentArmRotation);

            if (player.HeldItem.type == ModContent.ItemType<FishCleaver>())
                Dust.NewDust(player.AL().currentArmPosition + (MathHelper.PiOver2 + player.AL().currentArmRotation).ToRotationVector2() * Main.rand.Next(0, 129), 2, 2, DustID.WaterCandle);

        }

        public override void UseItemHitbox(Player player, ref Rectangle hitbox, ref bool noHitbox)
        {
            hitbox.Width = hitbox.Height = 128;
            hitbox.Location = ((player.AL().currentArmPosition - player.MountedCenter).SafeNormalize(Vector2.UnitY) * 64f + player.MountedCenter - hitbox.Size() / 2f).ToPoint();

        }

        public override void ModifyItemScale(Player player, ref float scale)
        {

            scale = 1f;

        }

    }

    public class AquaticVisualSlashTrail : ModProjectile
    {

        public override string Texture => "Terraria/Images/Projectile_" + ProjectileID.TerraBlade2;
        public override void SetStaticDefaults()
        {
            Main.projFrames[Type] = 4;
        }
        public override void SetDefaults()
        {
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.friendly = false;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.aiStyle = -1;

        }

        public override void OnSpawn(IEntitySource source)
        {
            Projectile.timeLeft = Main.player[Projectile.owner].itemAnimationMax;
        }

        public override void AI()
        {
            Player player = Main.player[Projectile.owner];



        }

        public override bool PreDraw(ref Color lightColor)
        {
            MDPlayer modPlayer = Main.player[Projectile.owner].GetModPlayer<MDPlayer>();

            Texture2D texture = TextureAssets.Projectile[Type].Value;

            if (Projectile.timeLeft > modPlayer.Player.itemAnimationMax - 5)
                return false;

            Main.EntitySpriteDraw(texture, modPlayer.currentArmPosition + modPlayer.currentArmRotation.ToRotationVector2() - Main.screenPosition + new Vector2(0, modPlayer.Player.gfxOffY), texture.Frame(1, 4), (Projectile.ai[0] == 0 ? Color.Aqua : Color.Turquoise) * MathHelper.SmoothStep(0f, 1f, (float)modPlayer.Player.itemAnimation / modPlayer.Player.itemAnimationMax), modPlayer.currentArmRotation + (modPlayer.swingDir == -1 ? MathHelper.PiOver4 : -MathHelper.PiOver4), texture.Frame(1, 4).Size() / 2f, 1.5f, modPlayer.swingDir == 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None);
            Main.EntitySpriteDraw(texture, modPlayer.currentArmPosition + modPlayer.currentArmRotation.ToRotationVector2() - Main.screenPosition + new Vector2(0, modPlayer.Player.gfxOffY), texture.Frame(1, 4), (Projectile.ai[0] == 0 ? Color.Blue : Color.Turquoise) * MathHelper.SmoothStep(0f, 1f, (float)modPlayer.Player.itemAnimation / modPlayer.Player.itemAnimationMax), modPlayer.currentArmRotation + (modPlayer.swingDir == -1 ? MathHelper.PiOver4 : -MathHelper.PiOver4), texture.Frame(1, 4).Size() / 2f, 1.25f, modPlayer.swingDir == 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None);
            Main.EntitySpriteDraw(texture, modPlayer.currentArmPosition + modPlayer.currentArmRotation.ToRotationVector2() - Main.screenPosition + new Vector2(0, modPlayer.Player.gfxOffY), texture.Frame(1, 4), (Projectile.ai[0] == 0 ? Color.Blue : Color.Turquoise) * MathHelper.SmoothStep(0f, 1f, (float)modPlayer.Player.itemAnimation / modPlayer.Player.itemAnimationMax), modPlayer.currentArmRotation + (modPlayer.swingDir == -1 ? MathHelper.PiOver4 : -MathHelper.PiOver4), texture.Frame(1, 4).Size() / 2f, 1f, modPlayer.swingDir == 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None);



            return false;
        }

    }

}