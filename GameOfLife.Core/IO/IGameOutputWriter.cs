namespace GameOfLife.Core.IO
{
    public interface IGameOutputWriter
    {
        public void Write(IUniverse universe);
    }
}
