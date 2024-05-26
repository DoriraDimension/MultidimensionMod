using MultidimensionMod.Tiles.Biomes.ShroomForest;
using MultidimensionMod.Tiles.Biomes.Inferno;
using MultidimensionMod.Items.Placeables.Biomes.Inferno;
using MultidimensionMod.Items.Placeables.Biomes.ShroomForest;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

// This file contains ExampleSandBallProjectile, ExampleSandBallFallingProjectile, and ExampleSandBallGunProjectile.
// ExampleSandBallFallingProjectile and ExampleSandBallGunProjectile inherit from ExampleSandBallProjectile, allowing cleaner code and shared logic.
// ExampleSandBallFallingProjectile is the projectile that spawns when the ExampleSand tile falls.
// ExampleSandBallGunProjectile is the projectile that is shot by the Sandgun weapon.
// Both projectiles share the same aiStyle, ProjAIStyleID.FallingTile, but the AIType line in ExampleSandBallGunProjectile ensures that specific logic of the aiStyle is used for the sandgun projectile.
// It is possible to make a falling projectile not using ProjAIStyleID.FallingTile, but it is a lot of code.
namespace MultidimensionMod.Projectiles
{
    public abstract class SandBall : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.FallingBlockDoesNotFallThroughPlatforms[Type] = true;
            ProjectileID.Sets.ForcePlateDetection[Type] = true;
        }
    }

    public class MyceliumSandBall : SandBall
    {
        public override string Texture => "MultidimensionMod/Tiles/Biomes/ShroomForest/MyceliumSandBall";
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            ProjectileID.Sets.FallingBlockTileItem[Type] = new(ModContent.TileType<MyceliumSandPlaced>(), ModContent.ItemType<MyceliumSand>());
        }

        public override void SetDefaults()
        {
            // The falling projectile when compared to the sandgun projectile is hostile.
            Projectile.CloneDefaults(ProjectileID.EbonsandBallFalling);
        }
    }

    public class MyceliumSandBallGun : SandBall
    {
        public override string Texture => "MultidimensionMod/Tiles/Biomes/ShroomForest/MyceliumSandBall";
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            ProjectileID.Sets.FallingBlockTileItem[Type] = new(ModContent.TileType<MyceliumSandPlaced>());
        }

        public override void SetDefaults()
        {
            // The sandgun projectile when compared to the falling projectile has a ranged damage type, isn't hostile, and has extraupdates = 1.
            // Note that EbonsandBallGun has infinite penetration, unlike SandBallGun
            Projectile.CloneDefaults(ProjectileID.EbonsandBallGun);
            AIType = ProjectileID.EbonsandBallGun; // This is needed for some logic in the ProjAIStyleID.FallingTile code.
        }
    }

    public class TorchsandBall : SandBall
    {
        public override string Texture => "MultidimensionMod/Tiles/Biomes/Inferno/TorchsandBall";
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            ProjectileID.Sets.FallingBlockTileItem[Type] = new(ModContent.TileType<TorchsandPlaced>(), ModContent.ItemType<Torchsand>());
        }

        public override void SetDefaults()
        {
            // The falling projectile when compared to the sandgun projectile is hostile.
            Projectile.CloneDefaults(ProjectileID.EbonsandBallFalling);
        }
    }

    public class TorchsandBallGun : SandBall
    {
        public override string Texture => "MultidimensionMod/Tiles/Biomes/Inferno/TorchsandBall";
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            ProjectileID.Sets.FallingBlockTileItem[Type] = new(ModContent.TileType<MyceliumSandPlaced>());
        }

        public override void SetDefaults()
        {
            // The sandgun projectile when compared to the falling projectile has a ranged damage type, isn't hostile, and has extraupdates = 1.
            // Note that EbonsandBallGun has infinite penetration, unlike SandBallGun
            Projectile.CloneDefaults(ProjectileID.EbonsandBallGun);
            AIType = ProjectileID.EbonsandBallGun; // This is needed for some logic in the ProjAIStyleID.FallingTile code.
        }
    }
}