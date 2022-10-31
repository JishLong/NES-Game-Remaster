using Sprint0.Blocks.Blocks;

namespace Sprint0.Commands.Blocks
{
    public class PushPushableBlockCommand : ICommand
    {
        private readonly PushableBlock Block;
        private readonly Types.Direction Direction;

        public PushPushableBlockCommand(PushableBlock block, Types.Direction direction) 
        {
            Block = block;
            Direction = direction;
        }

        public void Execute() 
        {
            Block.Push(Direction);
        }
    }
}
