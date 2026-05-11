using MultidimensionMod.Rarities.Souls;
using MultidimensionMod.Common.Systems;
using Terraria.DataStructures;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria.Localization;
using Microsoft.Xna.Framework.Graphics;

namespace MultidimensionMod.Items.Souls
{
	public class CultistSoul : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(7, 8));
			ItemID.Sets.AnimatesAsSoul[Item.type] = true;
			ItemID.Sets.ItemIconPulse[Item.type] = true;
			ItemID.Sets.ItemNoGravity[Item.type] = true;
		}

		public override void SetDefaults()
		{
			Item.width = 40;
			Item.height = 40;
			Item.rare = ModContent.RarityType<CultistSoulRarity>();
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.UseSound = SoundID.Zombie89;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            if (Common.Systems.MemorySystem.summonedMoonSword)
            {
                TooltipLine line = new(Mod, "TTWithSword", Language.GetTextValue("Mods.MultidimensionMod.Items.CultistSoul.TTWithSword"))
                {
                    OverrideColor = Color.White
                };
                tooltips.Add(line);
            }
            else if (!Common.Systems.MemorySystem.summonedMoonSword)
            {
                TooltipLine line = new(Mod, "TTNoSword", Language.GetTextValue("Mods.MultidimensionMod.Items.CultistSoul.TTNoSword"))
                {
                    OverrideColor = Color.White
                };
                tooltips.Add(line);
            }
            if (Main.keyState.PressingShift())
            {
                TooltipLine line = new(Mod, "Lore", Language.GetTextValue("Mods.MultidimensionMod.Items.CultistSoul.Lore"))
                {
                };
                tooltips.Add(line);
            }
            else
            {
                TooltipLine line = new(Mod, "HoldShift", Language.GetTextValue("Mods.MultidimensionMod.SpecialTooltips.Viewer"))
                {
                    OverrideColor = Color.Gray,
                };
                tooltips.Add(line);
            }
        }

        public override bool CanUseItem(Player player)
        {
            if (MemorySystem.summonedMoonSword)
            {
                return false;
            }
            return true;
        }

        public override bool? UseItem(Player player)
        {
            if (player.ownedProjectileCounts[ModContent.ProjectileType<GreatMoonlightManifest>()] < 1)
                Projectile.NewProjectile(player.GetSource_FromThis(), player.Center.X, player.Center.Y - 200, 0f, 0f, ModContent.ProjectileType<GreatMoonlightManifest>(), 0, 0f, player.whoAmI);
            return true;
        }

        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Texture2D texture = ModContent.Request<Texture2D>("MultidimensionMod/Items/Souls/CultistSoul").Value;
            Rectangle frame;
            frame = Main.itemAnimations[Item.type].GetFrame(texture, Main.itemFrameCounter[whoAmI]);
            Vector2 origin = frame.Size() / 2f;
            spriteBatch.Draw(texture, Item.Center - Main.screenPosition, frame, Color.White, rotation, origin, scale, SpriteEffects.None, 0f);
        }

    }
}