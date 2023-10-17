namespace CaterpillarControlSystem
{
    public interface ICommand
    {
        void Execute();
        void Undo();
    }
}
