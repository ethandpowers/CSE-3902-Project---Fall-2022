using Microsoft.Xna.Framework;
using Sprint0.Blocks;
using Sprint0.Blocks.Utils;
using Sprint0.Doors.States.SecretUnlockedStates;
using Sprint0.Levels;
using Sprint0.Sprites.Doors.WallDoors;
using System.Collections.Generic;

namespace Sprint0.Doors.States.WallStates
{
    public class LeftSecretWallDoorState : AbstractImpassableDoorState
    {
        public LeftSecretWallDoorState(Door door)
        {
            // Set context
            Door = door;
            float Height = LevelResources.BlockHeight;
            float Width = LevelResources.BlockWidth;

            // Used mostly for drawing
            Position = LevelResources.LeftDoorPosition;

            // Create sprite
            DoorSprite = new WallDoorLeftSprite();

            // Blocks
            Blocks = new List<IBlock>();
            CreateBlocks(Height, Width);
            CreateTriggers(Height, Width);  
        }
        public override void Lock()
        {
            // Does nothing.
        }
        public override void Unlock()
        {
            // Get adjacent room
            Room adjacentRoom = Door.Room.GetAdjacentRoom(Types.RoomTransition.LEFT);
            // Get the door that is adjacent to this one and unlock it
            Door adjacentDoor = adjacentRoom.DoorHandler.GetDoors()["right"] as Door;
            adjacentDoor.State = new RightSecretUnlockedDoorState(adjacentDoor);
            Door.State = new LeftSecretUnlockedDoorState(Door);
        }
        private void CreateTriggers(float height, float width)
        {
            IBlock block = BlockFactory.GetBlock(Types.Block.EXPLOSION_TRIGGER, Position + new Vector2(width, height/2));
            block.Parent = Door;
            Blocks.Add(block);
        }
        private void CreateBlocks(float height, float width)
        {
            Blocks.Add(BlockFactory.GetBlock(Types.Block.BORDER_BLOCK, Position + new Vector2(width, 0))); // Top
            Blocks.Add(BlockFactory.GetBlock(Types.Block.BORDER_BLOCK, Position + new Vector2(width, height))); // Right
        }
        public override void Update(GameTime gameTime)
        {
            DoorSprite.Update();
        }
    }
}
