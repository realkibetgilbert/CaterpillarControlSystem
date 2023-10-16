namespace CaterpillarControlSystem
{
    public class MoveUpCommand : ICommand
    {
        public Caterpillar caterpillar;
        public MoveUpCommand(Caterpillar caterpillar)
        {
            this.caterpillar = caterpillar;
        }
        public void Execute()
        {
            caterpillar.MovingUp();
        }

        public void Undo()
        {
            caterpillar.MovingDown();
        }
    }
}
