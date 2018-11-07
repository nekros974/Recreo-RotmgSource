using wServer.realm.worlds;

namespace wServer.realm.setpieces
{
    class Garfield : ISetPiece
    {
        public int Size { get { return 32; } }

        public void RenderSetPiece(World world, IntPoint pos)
        {
            var proto = world.Manager.Resources.Worlds["Garfield"];
            SetPieces.RenderFromProto(world, pos, proto);
        }
    }
}
