namespace Sprint0.Commands.Character
{
    public class MoveCameraCommand : ICommand
    {
        private readonly Types.Direction Direction;
        private readonly int Amount;

        public MoveCameraCommand(Types.Direction direction, int amount)
        {
            Direction = direction;
            Amount = amount;
        }

        public void Execute()
        {
            Camera.Move(Direction, Amount);
        }
    }
}
