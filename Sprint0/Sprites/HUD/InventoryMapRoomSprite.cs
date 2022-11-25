using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Sprites.Doors.UnlockdDoorSprites
{
    public class InventoryMapRoomSprite : AbstractStillSprite
    {
        private readonly Rectangle Frame;

        public InventoryMapRoomSprite(bool hasLeftRoom, bool hasRightRoom, bool hasUpRoom, bool hasDownRoom) 
        {
            if (!hasLeftRoom && !hasRightRoom && !hasUpRoom && !hasDownRoom) Frame = Resources.MapIconNoDoors;
            else if (hasLeftRoom && hasRightRoom && hasUpRoom && hasDownRoom) Frame = Resources.MapIconAllDoors;
            else if (hasLeftRoom && hasRightRoom && !hasUpRoom && !hasDownRoom) Frame = Resources.MapIconHorzDoors;
            else if (!hasLeftRoom && !hasRightRoom && hasUpRoom && hasDownRoom) Frame = Resources.MapIconVertDoors;

            else if (hasLeftRoom && !hasRightRoom && !hasUpRoom && !hasDownRoom) Frame = Resources.MapIconLeftDoor;
            else if (!hasLeftRoom && hasRightRoom && !hasUpRoom && !hasDownRoom) Frame = Resources.MapIconRightDoor;
            else if (!hasLeftRoom && !hasRightRoom && hasUpRoom && !hasDownRoom) Frame = Resources.MapIconUpDoor;
            else if (!hasLeftRoom && !hasRightRoom && !hasUpRoom && hasDownRoom) Frame = Resources.MapIconDownDoor;

            else if (hasLeftRoom && !hasRightRoom && hasUpRoom && !hasDownRoom) Frame = Resources.MapIconUpLeftDoors;
            else if (!hasLeftRoom && hasRightRoom && hasUpRoom && !hasDownRoom) Frame = Resources.MapIconUpRightDoors;
            else if (hasLeftRoom && !hasRightRoom && !hasUpRoom && hasDownRoom) Frame = Resources.MapIconDownLeftDoors;
            else if (!hasLeftRoom && hasRightRoom && !hasUpRoom && hasDownRoom) Frame = Resources.MapIconDownRightDoors;

            else if (hasLeftRoom && hasRightRoom && hasUpRoom && !hasDownRoom) Frame = Resources.MapIconNoDownDoor;
            else if (hasLeftRoom && hasRightRoom && !hasUpRoom && hasDownRoom) Frame = Resources.MapIconNoUpDoor;
            else if (hasLeftRoom && !hasRightRoom && hasUpRoom && hasDownRoom) Frame = Resources.MapIconNoRightDoor;
            else if (!hasLeftRoom && hasRightRoom && hasUpRoom && hasDownRoom) Frame = Resources.MapIconNoLeftDoor;
        }

        protected override Texture2D GetSpriteSheet() => Resources.GuiElementsSpriteSheet;

        protected override Rectangle GetFrame() => Frame;
    }
}
