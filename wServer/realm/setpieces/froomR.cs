using wServer.realm.worlds;

namespace wServer.realm.setpieces
{
    class froomR : ISetPiece
    {
        public int Size { get { return 32; } }

        public void RenderSetPiece(World world, IntPoint pos)
        {
            var proto = world.Manager.Resources.Worlds["froomR"];
            SetPieces.RenderFromProto(world, pos, proto);
        }
    }
}
