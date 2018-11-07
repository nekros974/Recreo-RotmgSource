using wServer.realm.worlds;

namespace wServer.realm.setpieces
{
    class froomL : ISetPiece
    {
        public int Size { get { return 32; } }

        public void RenderSetPiece(World world, IntPoint pos)
        {
            var proto = world.Manager.Resources.Worlds["froomL"];
            SetPieces.RenderFromProto(world, pos, proto);
        }
    }
}
