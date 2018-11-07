//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text; //////////////////////////////NILLYS CAN RENDER SETPIECE FROM MAP SO THIS NEEDS TO BE REDONE
//using System.Threading.Tasks;
//using common.resources;
//using wServer.logic.loot;
//using wServer.realm.entities;
//using wServer.realm.worlds;

//namespace wServer.realm.setpieces
//{
//    internal class AbyssDeath : ISetPiece
//    {
//        public int Size
//        {
//            get { return 3; }
//        }

//        private byte[,] SetPiece
//        {
//            get
//            {
//                return new byte[,]
//                {
//                    {1, 1, 1},
//                    {1, 2, 1},
//                    {1, 1, 1},

//                };
//            }
//        }

//        public void RenderSetPiece(World world, IntPoint pos)
//        {
//            XmlData dat = world.Manager.GameData;

//            IntPoint p = new IntPoint
//            {
//                X = pos.X - (Size / 2),
//                Y = pos.Y - (Size / 2)
//            };

//            for (int x = 0; x < Size; x++)
//            {
//                for (int y = 0; y < Size; y++)
//                {
//                    if (SetPiece[y, x] == 1)
//                    {
//                        WmapTile tile = world.Map[x + p.X, y + p.Y].Clone();
//                        tile.TileId = dat.IdToTileType["Red Quad"];
//                        tile.ObjType = 0;
//                        world.Map[x + p.X, y + p.Y] = tile;
//                    }

//                    if (SetPiece[y, x] == 2)
//                    {
//                        WmapTile tile = world.Map[x + p.X, y + p.Y].Clone();
//                        tile.TileId = dat.IdToTileType["Red Quad"];
//                        tile.ObjType = 0;
//                        world.Map[x + p.X, y + p.Y] = tile;

//                        Entity en = Entity.Resolve(world.Manager, "Realm Portal");
//                        en.Move(x + p.X + 0.5f, y + p.Y + 0.5f);
//                        world.EnterWorld(en);
//                    }
//                }
//            }
//        }
//    }
//}
