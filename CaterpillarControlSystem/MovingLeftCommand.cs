namespace CaterpillarControlSystem
{
    public class MovingLeftCommand:ICommand
    {
        public Caterpillar caterpillar;

        public MovingLeftCommand(Caterpillar caterpillar)
        {
            this.caterpillar = caterpillar;
        }

        public void Execute()
        {
           caterpillar.MovingLeft();
        }

        public void Undo()
        {
           caterpillar.MovingRight();
        }
    }
}
