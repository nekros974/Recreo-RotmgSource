using wServer.realm.worlds;

namespace wServer.realm.setpieces
{
    class Aroom21 : ISetPiece
    {
        public int Size { get { return 32; } }

        public void RenderSetPiece(World world, IntPoint pos)
        {
            var proto = world.Manager.Resources.Worlds["Aroom21"];
            SetPieces.RenderFromProto(world, pos, proto);
        }
    }
}
