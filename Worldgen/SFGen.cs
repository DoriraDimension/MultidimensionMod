using MultidimensionMod.Tiles.Biomes.ShroomForest;
using MultidimensionMod.Walls;
using System;
using System.Threading;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using ReLogic.Content;
using Terraria;
using Terraria.IO;
using Terraria.ID;
using Terraria.WorldBuilding;
using Terraria.ModLoader;
using MultidimensionMod.Base;
using Terraria.GameContent.Generation;
using static Terraria.WorldGen;

namespace MultidimensionMod.Worldgen
{
    class SFGen : ModSystem
    {
        //Gen code is made possible by Ancients Awakened
        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref double totalWeight)
        {
            int BiomesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Micro Biomes"));
            if (BiomesIndex != -1)
            {
                tasks.Insert(BiomesIndex + 1, new PassLegacy("Scarlet Mycelium Forest", ShroomForestGen));
                int GenIndex2 = tasks.FindIndex(genpass => genpass.Name.Equals("Final Cleanup"));
                if (GenIndex2 != -1)
                {
                    tasks.Insert(GenIndex2 + 1, new PassLegacy("Scarlet Mycelium Forest Trees", GrowTrees));
                }
            }
        }
        
        float PlaceBiomeX = (int)(Main.maxTilesX / 7f * (WorldGen.genRand.NextBool(2) ? 2.25f : 2.75f));

        private void ShroomForestGen(GenerationProgress progress, GameConfiguration configuration)
        {
            progress.Message = "Spreading scarlet mycelium";
            int e = (int)GenVars.worldSurfaceLow + 30;
            while (Main.tile[(int)PlaceBiomeX, e] != null && !Main.tile[(int)PlaceBiomeX, e].HasTile)
            {
                e++;
            }
            for (int l = (int)PlaceBiomeX - 25; l < (int)PlaceBiomeX + 25; l++)
            {
                for (int m = e - 6; m < e + 90; m++)
                {
                    if (Main.tile[l, m] != null && Main.tile[l, m].HasTile)
                    {
                        int type = Main.tile[l, m].TileType;
                        if (type == TileID.Cloud || type == TileID.RainCloud || type == TileID.Sunplate)
                        {
                            e++;
                            if (!Main.tile[l, m].HasTile)
                            {
                                e++;
                            }
                        }
                    }
                }
            }
            float PlaceBiomeY = e;
            int checkforsnow = Main.tile[(int)PlaceBiomeX, (int)PlaceBiomeY].TileType;
            if(checkforsnow==TileID.SnowBlock||checkforsnow==TileID.IceBlock)
            {
                PlaceBiomeX = (int)(Main.maxTilesX / 7f * (PlaceBiomeX==(int)(Main.maxTilesX / 7f*2.25f) ?2.75f : 2.25f));
                e = (int)GenVars.worldSurfaceLow + 30;
            while (Main.tile[(int)PlaceBiomeX, e] != null && !Main.tile[(int)PlaceBiomeX, e].HasTile)
            {
                e++;
            }
            for (int l = (int)PlaceBiomeX - 25; l < (int)PlaceBiomeX + 25; l++)
            {
                for (int m = e - 6; m < e + 90; m++)
                {
                    if (Main.tile[l, m] != null && Main.tile[l, m].HasTile)
                    {
                        int type = Main.tile[l, m].TileType;
                        if (type == TileID.Cloud || type == TileID.RainCloud || type == TileID.Sunplate)
                        {
                            e++;
                            if (!Main.tile[l, m].HasTile)
                            {
                                e++;
                            }
                        }
                    }
                }
            }
            PlaceBiomeY = e;
            }

            ushort mycelium = (ushort)ModContent.TileType<Mycelium>(), sand = (ushort)ModContent.TileType<MyceliumSandPlaced>(),
                sandstone = (ushort)ModContent.TileType<MyceliumSandstonePlaced>(), hardenedSand = (ushort)ModContent.TileType<MyceliumHardsandPlaced>(), 
                sporeStone = (ushort)ModContent.TileType<SporeStonePlaced>(), sandstoneWall = (ushort)ModContent.WallType<MyceliumSandstoneWallPlaced>(), hardenedSandWall = (ushort)ModContent.WallType<MyceliumHardsandWallPlaced>();
            int worldSize = GetWorldSize();
            int biomeRadius = worldSize == 3 ? 300 : worldSize == 2 ? 260 : 180;
           


            Point originCenter = new((int)PlaceBiomeX, (int)PlaceBiomeY);
            // TILE CONVERSIONS
            WorldUtils.Gen(originCenter, new Shapes.Circle(biomeRadius), Actions.Chain(new GenAction[]
            {
                new InWorld(),
                new Modifiers.OnlyTiles(new ushort[]{ TileID.Grass, TileID.CrimsonGrass, TileID.CorruptGrass, TileID.JungleGrass}),
                new Modifiers.RadialDither(biomeRadius - 5, biomeRadius),
                new SetModTile(mycelium, true, true)
            }));
            WorldUtils.Gen(originCenter, new Shapes.Circle(biomeRadius), Actions.Chain(new GenAction[]
            {
                new InWorld(),
                new Modifiers.OnlyTiles(new ushort[]{ TileID.Mud, TileID.SnowBlock}),
                new Modifiers.RadialDither(biomeRadius - 5, biomeRadius),
                new SetModTile(0, true, true)
            }));
            WorldUtils.Gen(originCenter, new Shapes.Circle(biomeRadius), Actions.Chain(new GenAction[]
            {
                new InWorld(),
                new Modifiers.OnlyTiles(new ushort[]{ TileID.Sand, TileID.Crimsand, TileID.Ebonsand }),
                new Modifiers.RadialDither(biomeRadius - 5, biomeRadius),
                new SetModTile(sand, true, true)
            }));
            WorldUtils.Gen(originCenter, new Shapes.Circle(biomeRadius), Actions.Chain(new GenAction[]
            {
                new InWorld(),
                new Modifiers.OnlyTiles(new ushort[]{ TileID.HardenedSand, TileID.CorruptHardenedSand, TileID.CrimsonHardenedSand }),
                new Modifiers.RadialDither(biomeRadius - 5, biomeRadius),
                new SetModTile(hardenedSand, true, true)
            }));
            WorldUtils.Gen(originCenter, new Shapes.Circle(biomeRadius), Actions.Chain(new GenAction[]
            {
                new InWorld(),
                new Modifiers.OnlyTiles(new ushort[]{ TileID.Sandstone, TileID.CorruptSandstone,TileID. CrimsonSandstone}),
                new Modifiers.RadialDither(biomeRadius - 5, biomeRadius),
                new SetModTile(sandstone, true, true)
            }));
            WorldUtils.Gen(originCenter, new Shapes.Circle(biomeRadius), Actions.Chain(new GenAction[]
            {
                new InWorld(),
                new Modifiers.OnlyTiles(new ushort[]{ TileID.Stone, TileID.Crimstone, TileID.Ebonstone, TileID.IceBlock}),
                new Modifiers.RadialDither(biomeRadius - 5, biomeRadius),
                new SetModTile(sporeStone, true, true)
            }));
            //Walls
            WorldUtils.Gen(originCenter, new Shapes.Circle(biomeRadius), Actions.Chain(new GenAction[]
            {
                new InWorld(),
                new Modifiers.OnlyWalls(new ushort[]{ WallID.HardenedSand}),
                new Modifiers.RadialDither(biomeRadius - 5, biomeRadius),
                new PlaceModWall(hardenedSandWall, true)
            }));
            WorldUtils.Gen(originCenter, new Shapes.Circle(biomeRadius), Actions.Chain(new GenAction[]
            {
                new InWorld(),
                new Modifiers.OnlyWalls(new ushort[]{ WallID.Sandstone}),
                new Modifiers.RadialDither(biomeRadius - 5, biomeRadius),
                new PlaceModWall(sandstoneWall, true)
            }));


            WorldUtils.Gen(new((int)PlaceBiomeX-(int)(biomeRadius*0.2), (int)PlaceBiomeY+ (int)(biomeRadius *1.5f)), new Shapes.Circle((int)(biomeRadius*0.6)), Actions.Chain(new GenAction[]
            {
                new InWorld(),
                new Actions.SetTile(59, true, true),
                new Actions.PlaceTile(59)
            }));
            WorldUtils.Gen(new((int)PlaceBiomeX, (int)PlaceBiomeY+ (int)(biomeRadius *1.5f)), new Shapes.Circle((int)(biomeRadius*0.6)), Actions.Chain(new GenAction[]
            {
                new InWorld(),
                new Actions.SetTile(59, true, true),
                new Actions.PlaceTile(59)
            }));
            WorldUtils.Gen(new((int)PlaceBiomeX+(int)(biomeRadius*0.2), (int)PlaceBiomeY+ (int)(biomeRadius *1.5f)), new Shapes.Circle((int)(biomeRadius*0.6)), Actions.Chain(new GenAction[]
            {
                new InWorld(),
                new Actions.SetTile(59, true, true),
                new Actions.PlaceTile(59)
            }));
         
            //tunnels
            List<Point> MoreTunnels = new();
            for(int count=0; count<WorldGen.genRand.Next(3,6);count++){
            int CurrentX= (int)(PlaceBiomeX+(((biomeRadius*WorldGen.genRand.NextFloat(0f,0.7f))*(WorldGen.genRand.NextBool(2)==true ? -1:1))));
            int CurrentY=(int)PlaceBiomeY;
            int rand = WorldGen.genRand.Next(1, 100);
            while(CurrentY<(int)PlaceBiomeY+(int)(biomeRadius *1.5f)+(int)(biomeRadius*0.05f)+WorldGen.genRand.Next(45,51))
            {
                
                WorldUtils.Gen(new((int)CurrentX, (int)CurrentY), new Shapes.Circle((int)(WorldGen.genRand.Next(2, 5))), Actions.Chain(new GenAction[]
                {
                    new InWorld(),
                    new Actions.ClearTile(true)
                }));   
                WorldUtils.Gen(new((int)CurrentX, (int)CurrentY), new Shapes.Circle(9), Actions.Chain(new GenAction[]
                {
                    new InWorld(),
                    new Modifiers.OnlyTiles(new ushort[]{TileID.Sand, TileID.Crimsand, TileID.Ebonsand,sand}),
                    new SetModTile(hardenedSand, true, true)
                }));     
                CurrentX += (int)(4*Math.Sin(rand+((CurrentY)/16)));
                CurrentY+=WorldGen.genRand.Next(1,3);
                if(CurrentY%20==18&&WorldGen.genRand.NextBool(2))
                    MoreTunnels.Add(new Point(CurrentX, CurrentY));
            }
            }
            for(int TunnelIndex=0; TunnelIndex < MoreTunnels.Count;TunnelIndex++)
            {
               int XIncrease = WorldGen.genRand.Next(-2,2);
               int YIncrease = WorldGen.genRand.Next(-2,2);
               int CurrentX = MoreTunnels[TunnelIndex].X;
               int CurrentY= MoreTunnels[TunnelIndex].Y;
               for(int Step=0; Step<20; Step++)
               {
                    if (CurrentY<Main.worldSurface)
                        continue;
                    WorldUtils.Gen(new((int)CurrentX, (int)CurrentY), new Shapes.Circle((int)(WorldGen.genRand.Next(1, 3))), Actions.Chain(new GenAction[]
                    {
                        new InWorld(),
                        new Actions.ClearTile(true)
                    }));     
                    WorldUtils.Gen(new((int)CurrentX, (int)CurrentY), new Shapes.Circle(6), Actions.Chain(new GenAction[]
                    {
                        new InWorld(),
                        new Modifiers.OnlyTiles(new ushort[]{TileID.Sand, TileID.Crimsand, TileID.Ebonsand,sand}),
                        new SetModTile(hardenedSand, true, true)
                    })); 
                    CurrentY+= (int)Math.Abs((4*Math.Sin(MathHelper.ToRadians((Step*20)+CurrentX))))+YIncrease;
                    CurrentX+= (int)(3*Math.Sin(MathHelper.ToRadians((Step*30)+CurrentY)))+XIncrease;
               }
            }
            //So with that sorted out generate a cave for feud
            int Radi=(int)(biomeRadius*0.05f);
            for(int X = (int)PlaceBiomeX-(int)(biomeRadius*0.5); X <= (int)PlaceBiomeX; X += 6)
            {
                
                WorldUtils.Gen(new((int)X, (int)PlaceBiomeY+(int)(biomeRadius *1.5f)), new Shapes.Circle(Radi+(WorldGen.genRand.Next(4,15))), Actions.Chain(new GenAction[]
                    {
                        new InWorld(),
                        new Actions.ClearTile(true)
                    }));     
                Radi+=1;
            }
            //Make tunnel underneath
            for(int X = (int)PlaceBiomeX-(int)(biomeRadius*0.5); X <= (int)PlaceBiomeX+(int)(biomeRadius*0.5); X += 1)
            {
                
                WorldUtils.Gen(new((int)X, (int)PlaceBiomeY+(int)(biomeRadius *1.5f)+Radi+WorldGen.genRand.Next(25,33)), new Shapes.Circle((WorldGen.genRand.Next(4,10))), Actions.Chain(new GenAction[]
                    {
                        new InWorld(),
                        new Actions.ClearTile(true)
                    }));     
            }
            for(int X = (int)PlaceBiomeX; X <= (int)PlaceBiomeX+(int)(biomeRadius*0.5); X += 6)
            {
                
                WorldUtils.Gen(new((int)X, (int)PlaceBiomeY+(int)(biomeRadius *1.5f)), new Shapes.Circle(Radi+(WorldGen.genRand.Next(4,15))), Actions.Chain(new GenAction[]
                    {
                        new InWorld(),
                        new Actions.ClearTile(true)
                    }));     
                Radi-=1;
            }
            //Add bumps on the bottom
       
            for (int X = (int)PlaceBiomeX-(int)(biomeRadius*0.5); X <= (int)PlaceBiomeX+(int)(biomeRadius*0.5); X += 1){
                int Ycheck= (int)PlaceBiomeY+(int)(biomeRadius *1.5f);
                if(X%30==28 &&WorldGen.genRand.NextBool(2)){
                while(Ycheck<Main.maxTilesY/2)
                {
                    Ycheck++;
                    if(Main.tile[X,Ycheck].TileType==59&&Main.tile[X,Ycheck].HasTile)
                    {
                        
                        WorldUtils.Gen(new(X, Ycheck), new Shapes.Circle((int)(WorldGen.genRand.Next(4,13))), Actions.Chain(new GenAction[]
                            {
                                new InWorld(),
                                new Actions.SetTile(59, true, true),
                                new Actions.PlaceTile(59)
                            }));
                        break; 
                    }
                }
                }
            }
                
            


            for (int X = (int)PlaceBiomeX-(int)(biomeRadius); X <= (int)PlaceBiomeX+(int)(biomeRadius); X++)
            {
                for (int Y = (int)PlaceBiomeY -(int)(biomeRadius); Y <= (int)PlaceBiomeY+(int)(2f*biomeRadius); Y++)
                {
                    Tile tile = Main.tile[X, Y];
                    Tile tileAbove = Main.tile[X, Y - 1];
                    Tile tileBelow = Main.tile[X, Y + 1];
                    Tile tileLeft = Main.tile[X - 1, Y];
                    Tile tileRight = Main.tile[X + 1, Y];
                    //myeclium
                    if (tile.TileType == 0 && (!tileAbove.HasTile || !tileBelow.HasTile || !tileLeft.HasTile || !tileRight.HasTile))
                    {
                        tile.TileType = (ushort)ModContent.TileType<Mycelium>();
                    }

                    if (tile.TileType == 0 && (tileAbove.TileType == ModContent.TileType<Mycelium>() || tileBelow.TileType == ModContent.TileType<Mycelium>() ||
                    tileLeft.TileType == ModContent.TileType<Mycelium>() || tileRight.TileType == ModContent.TileType<Mycelium>()))
                    {
                        WorldGen.SpreadGrass(X, Y, 0, ModContent.TileType<Mycelium>(), false);
                    }
                    //blue mush idk
                    if (tile.TileType == 59 && (!tileAbove.HasTile || !tileBelow.HasTile || !tileLeft.HasTile || !tileRight.HasTile))
                    {
                        tile.TileType = (ushort)70;
                    }

                    if (tile.TileType == 59 && (tileAbove.TileType == 70 || tileBelow.TileType == 70 ||
                    tileLeft.TileType ==70 || tileRight.TileType == 70))
                    {
                        WorldGen.SpreadGrass(X, Y, 59,70, false);
                    }
                }
            }
            //trees or... mushrooms?
            for (int X = (int)PlaceBiomeX-(int)(biomeRadius); X <= (int)PlaceBiomeX+(int)(biomeRadius); X++)
            {
                for (int Y = (int)PlaceBiomeY -(int)(biomeRadius); Y <= (int)PlaceBiomeY+(int)(2f*biomeRadius); Y++)
                {
                    
                    if (Main.tile[X, Y].TileType == (ushort)ModContent.TileType<Mycelium>())
                    {
                        if (WorldGen.genRand.NextBool(5))
                            WorldGen.TryGrowingTreeByType(5, X, Y-1);
                    }
                    if (Main.tile[X, Y].TileType == 70)
                    {
                        if (WorldGen.genRand.NextBool(3))
                            WorldGen.GrowTree(X, Y);
                    }
                    
                }
            }
          

        }
        
        private void GrowTrees(GenerationProgress progress, GameConfiguration configuration)
        {
            int e = (int)GenVars.worldSurfaceLow + 30;
            while (Main.tile[(int)PlaceBiomeX, e] != null && !Main.tile[(int)PlaceBiomeX, e].HasTile)
            {
                e++;
            }
            for (int l = (int)PlaceBiomeX - 25; l < (int)PlaceBiomeX + 25; l++)
            {
                for (int m = e - 6; m < e + 90; m++)
                {
                    if (Main.tile[l, m] != null && Main.tile[l, m].HasTile)
                    {
                        int type = Main.tile[l, m].TileType;
                        if (type == TileID.Cloud || type == TileID.RainCloud || type == TileID.Sunplate)
                        {
                            e++;
                            if (!Main.tile[l, m].HasTile)
                            {
                                e++;
                            }
                        }
                    }
                }
            }
            int worldSize = GetWorldSize();

            float PlaceBiomeY = e;
            int biomeRadius = worldSize == 3 ? 300 : worldSize == 2 ? 260 : 180;

            for (int X = (int)PlaceBiomeX-(int)(biomeRadius); X <= (int)PlaceBiomeX+(int)(biomeRadius); X++)
                {
                    for (int Y = (int)PlaceBiomeY -(int)(biomeRadius); Y <= (int)PlaceBiomeY+(int)(2f*biomeRadius); Y++)
                    {
                        
                        if (Main.tile[X, Y].TileType == (ushort)ModContent.TileType<Mycelium>())
                        {
                            if (WorldGen.genRand.NextBool(5))
                                WorldGen.TryGrowingTreeByType(5, X, Y-1);
                        }
                        if (Main.tile[X, Y].TileType == 70)
                        {
                            if (WorldGen.genRand.NextBool(3))
                                WorldGen.GrowTree(X, Y);
                        }
                        
                    }
                }
            for (int X = (int)PlaceBiomeX-(int)(biomeRadius); X <= (int)PlaceBiomeX+(int)(biomeRadius); X++)
                {
                    for (int Y = (int)PlaceBiomeY -(int)(biomeRadius); Y <= (int)PlaceBiomeY+(int)(2f*biomeRadius); Y++)
                    {
                        
                        if (Main.tile[X, Y].TileType == 583 || Main.tile[X, Y].TileType == 584 || Main.tile[X, Y].TileType == 585 || Main.tile[X, Y].TileType == 586 || Main.tile[X, Y].TileType == 587 || Main.tile[X, Y].TileType == 588 || Main.tile[X, Y].TileType == 589)
                        {   
                            Tile tile = Main.tile[X, Y];
                            tile.HasTile=false;  
                        }
                        
                    }
                }
        }

        
        


        public static int GetWorldSize()
        {
            if (Main.maxTilesX == 4200) { return 1; }
            else if (Main.maxTilesX == 6400) { return 2; }
            else if (Main.maxTilesX == 8400) { return 3; }
            return 1; //unknown size, assume small
        }
    }

}