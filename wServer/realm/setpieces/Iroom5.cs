﻿using wServer.realm.worlds;

namespace wServer.realm.setpieces
{
    class Iroom5 : ISetPiece
    {
        public int Size { get { return 32; } }

        public void RenderSetPiece(World world, IntPoint pos)
        {
            var proto = world.Manager.Resources.Worlds["Iroom5"];
            SetPieces.RenderFromProto(world, pos, proto);
        }
    }
}
