using MultidimensionMod.NPCs.Bosses.FeudalFungus;
using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria.ModLoader;
using Terraria.Localization;


namespace MultidimensionMod.Items.Summons
{
    public class ConfusingMushroom : ModItem
    {

        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Confusing Looking Mushroom");
            ItemID.Sets.SortingPriorityBossSpawns[Item.type] = 13;
            //Tooltip.SetDefault(@"Summons the Feudal Fungus Can only be used in a glowing mushroom biome");
        }

        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 44;
            Item.maxStack = 1;
            Item.value = 1000;
            Item.rare = ItemRarityID.Blue;
            Item.useAnimation = 30;
            Item.useTime = 30;
            Item.useStyle = ItemUseStyleID.HoldUp;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            if (Main.keyState.PressingShift())
            {
                TooltipLine line = new(Mod, "Lore", Language.GetTextValue("Mods.MultidimensionMod.Items.ConfusingMushroom.Lore"))
                {
                    OverrideColor = Color.LightGray
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
            if (player.ZoneGlowshroom && !NPC.AnyNPCs(ModContent.NPCType<FeudalFungus>()))
            {
                return true;
            }
            return false;
        }

        public override bool? UseItem(Player player)
        {
            NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<FeudalFungus>());
            SoundEngine.PlaySound(new("MultidimensionMod/Sounds/Custom/HallowedCry"), player.position);
            return true;
        }

        public void SpawnBoss(Player player, string name, string displayName)
        {

        }

        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Texture2D texture = ModContent.Request<Texture2D>("MultidimensionMod/Items/Summons/ConfusingMushroom_Glow").Value;
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