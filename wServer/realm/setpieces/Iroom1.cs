using wServer.realm.worlds;

namespace wServer.realm.setpieces
{
    class Iroom1 : ISetPiece
    {
        public int Size { get { return 32; } }

        public void RenderSetPiece(World world, IntPoint pos)
        {
            var proto = world.Manager.Resources.Worlds["Iroom1"];
            SetPieces.RenderFromProto(world, pos, proto);
        }
    }
}
