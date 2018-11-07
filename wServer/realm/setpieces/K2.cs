using wServer.realm.worlds;

namespace wServer.realm.setpieces
{
    class K2 : ISetPiece
    {
        public int Size { get { return 32; } }

        public void RenderSetPiece(World world, IntPoint pos)
        {
            var proto = world.Manager.Resources.Worlds["K2"];
            SetPieces.RenderFromProto(world, pos, proto);
        }
    }
}
