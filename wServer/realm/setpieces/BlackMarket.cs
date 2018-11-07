using wServer.realm.worlds;

namespace wServer.realm.setpieces
{
    class BlackMarket : ISetPiece
    {
        public int Size { get { return 32; } }

        public void RenderSetPiece(World world, IntPoint pos)
        {
            var proto = world.Manager.Resources.Worlds["BlackMarket"];
            SetPieces.RenderFromProto(world, pos, proto);
        }
    }
}
