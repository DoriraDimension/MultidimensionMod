using MultidimensionMod.Rarities.Souls;
using MultidimensionMod.Common.Systems;
using MultidimensionMod.NPCs.Friendly;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Terraria.DataStructures;
using Terraria.Localization;

namespace MultidimensionMod.Items.Souls
{
	public class WallSoul : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			ItemID.Sets.ItemIconPulse[Item.type] = true;
			ItemID.Sets.ItemNoGravity[Item.type] = true;
		}

		public override void SetDefaults()
		{
			Item.width = 28;
			Item.height = 30;
			Item.useStyle = ItemUseStyleID.HoldUp;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.rare = ModContent.RarityType<WallSoulRarity>();
			Item.shoot = ModContent.ProjectileType<Arguement>();
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			if (DownedSystem.listenedToNonsense)
			{
				return false;
			}
            return true;
		}

        public override bool CanUseItem(Player player)
        {
            if (DownedSystem.metAdel && DownedSystem.metVertrarius)
            {
                return false;
            }
            return true;
        }

        public override bool? UseItem(Player player)
        {
            if (player.ZoneHallow && !DownedSystem.metAdel && DownedSystem.listenedToNonsense && !NPC.AnyNPCs(ModContent.NPCType<AdelSpirit>()))
            {
                NPC.NewNPC(Item.GetSource_FromThis(), (int)player.Center.X + 200, (int)player.Center.Y, ModContent.NPCType<AdelSpirit>());
            }
            if (player.ZoneUnderworldHeight && !DownedSystem.metVertrarius && DownedSystem.listenedToNonsense && !NPC.AnyNPCs(ModContent.NPCType<VertrariusSpirit>()))
            {
                NPC.NewNPC(Item.GetSource_FromThis(), (int)player.Center.X + 200, (int)player.Center.Y, ModContent.NPCType<VertrariusSpirit>());
            }
            return true;
        }

		public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
		{
			Texture2D texture = ModContent.Request<Texture2D>("MultidimensionMod/Items/Souls/WallSoul").Value;
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

	public class Arguement : ModProjectile
	{
        public override string Texture => "MultidimensionMod/Projectiles/NoTexture";
        public int ArguementTimer = 0;

		public override void SetDefaults()
		{
			Projectile.height = 2;
			Projectile.width = 2;
			Projectile.penetrate = -1;
			Projectile.netImportant = true;
		}
		public override void AI()
		{
			Player player = Main.LocalPlayer;
            Projectile.position = player.Center;
            ArguementTimer++;
            if (!DownedSystem.listenedToNonsense)
            {
                if (ArguementTimer == 120)
                {
                    int i = CombatText.NewText(player.getRect(), MDColors.AdelText, Language.GetTextValue("Mods.MultidimensionMod.SoulConversation.WallofFlesh.Arguement1"), true, false);
                    Main.combatText[i].lifeTime = 180;
                }
                if (ArguementTimer == 360)
                {
                    CombatText.NewText(player.getRect(), Color.Orange, Language.GetTextValue("Mods.MultidimensionMod.SoulConversation.WallofFlesh.Arguement2"), true, false);
                }
                if (ArguementTimer == 540)
                {
                    CombatText.NewText(player.getRect(), Color.Orange, Language.GetTextValue("Mods.MultidimensionMod.SoulConversation.WallofFlesh.Arguement3"), true, false);
                }
                if (ArguementTimer == 660)
                {
                    CombatText.NewText(player.getRect(), MDColors.AdelText, Language.GetTextValue("Mods.MultidimensionMod.SoulConversation.WallofFlesh.Arguement4"), true, false);
                }
                if (ArguementTimer == 840)
                {
                    CombatText.NewText(player.getRect(), MDColors.AdelText, Language.GetTextValue("Mods.MultidimensionMod.SoulConversation.WallofFlesh.Arguement5"), true, false);
                }
                if (ArguementTimer == 960)
                {
                    CombatText.NewText(player.getRect(), Color.Orange, Language.GetTextValue("Mods.MultidimensionMod.SoulConversation.WallofFlesh.Arguement6"), true, false);
                }
                if (ArguementTimer == 1020)
                {
                    int i =CombatText.NewText(player.getRect(), Color.Orange, Language.GetTextValue("Mods.MultidimensionMod.SoulConversation.WallofFlesh.Arguement7"), true, false);
                    Main.combatText[i].lifeTime = 180;
                }
                if (ArguementTimer == 1200)
                {
                    CombatText.NewText(player.getRect(), MDColors.AdelText, Language.GetTextValue("Mods.MultidimensionMod.SoulConversation.WallofFlesh.Arguement8"), true, false);
                }
                if (ArguementTimer == 1380)
                {
                    int i = CombatText.NewText(player.getRect(), MDColors.AdelText, Language.GetTextValue("Mods.MultidimensionMod.SoulConversation.WallofFlesh.Arguement9"), true, false);
                    Main.combatText[i].lifeTime = 180;
                }
                if (ArguementTimer == 1560)
                {
                    CombatText.NewText(player.getRect(), Color.Orange, Language.GetTextValue("Mods.MultidimensionMod.SoulConversation.WallofFlesh.Arguement10"), true, false);
                }
                if (ArguementTimer == 1740)
                {
                    CombatText.NewText(player.getRect(), MDColors.AdelText, Language.GetTextValue("Mods.MultidimensionMod.SoulConversation.WallofFlesh.Arguement11"), true, false);
                }
                if (ArguementTimer == 1920)
                {
                    CombatText.NewText(player.getRect(), MDColors.AdelText, Language.GetTextValue("Mods.MultidimensionMod.SoulConversation.WallofFlesh.Arguement12"), true, false);
                }
                if (ArguementTimer == 2100)
                {
                    int i = CombatText.NewText(player.getRect(), Color.Orange, Language.GetTextValue("Mods.MultidimensionMod.SoulConversation.WallofFlesh.Arguement13"), true, false);
                    Main.combatText[i].lifeTime = 180;
                }
                if (ArguementTimer == 2340)
                {
                    CombatText.NewText(player.getRect(), MDColors.AdelText, Language.GetTextValue("Mods.MultidimensionMod.SoulConversation.WallofFlesh.Arguement14"), true, false);
                }
                if (ArguementTimer == 2520)
                {
                    CombatText.NewText(player.getRect(), MDColors.AdelText, Language.GetTextValue("Mods.MultidimensionMod.SoulConversation.WallofFlesh.Arguement15"), true, false);
                }
                if (ArguementTimer == 2580)
                {
                    CombatText.NewText(player.getRect(), Color.Orange, Language.GetTextValue("Mods.MultidimensionMod.SoulConversation.WallofFlesh.Arguement16"), true, false);
                }
                if (ArguementTimer >= 2581)
                {
                    NPC.SetEventFlagCleared(ref DownedSystem.listenedToNonsense, -1);
                    ArguementTimer = 2881;
                    Projectile.Kill();
                }
            }
        }
	}
}