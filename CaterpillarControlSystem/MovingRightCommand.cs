namespace CaterpillarControlSystem
{
    public class MovingRightCommand:ICommand
    {
        Caterpillar caterpillar;
        public MovingRightCommand(Caterpillar caterpillar)
        {
            this.caterpillar = caterpillar;
        }
        public void Execute()
        {
            caterpillar.MovingRight();
        }

        public void Undo()
        {
            caterpillar.MovingLeft();
        }
    }
}
