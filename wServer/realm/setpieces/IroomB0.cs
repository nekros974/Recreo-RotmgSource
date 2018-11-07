using wServer.realm.worlds;

namespace wServer.realm.setpieces
{
    class IroomB0 : ISetPiece
    {
        public int Size { get { return 32; } }

        public void RenderSetPiece(World world, IntPoint pos)
        {
            var proto = world.Manager.Resources.Worlds["IroomB0"];
            SetPieces.RenderFromProto(world, pos, proto);
        }
    }
}
