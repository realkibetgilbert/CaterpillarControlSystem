namespace CaterpillarControlSystem
{
    public class MovingDownCommand:ICommand
    {
        public Caterpillar caterpillar;
        public MovingDownCommand(Caterpillar caterpillar)
        {
            this.caterpillar = caterpillar;
        }
        public void Execute()
        {
            caterpillar.MovingDown();
        }

        public void Undo()
        {
            caterpillar.MovingUp();
        }
    }
}
