﻿using Microsoft.Xna.Framework;
using Sprint0.Blocks;
using Sprint0.Blocks.Blocks;
using Sprint0.Doors;
using Sprint0.Items;
using Sprint0.Levels;
using Sprint0.Levels.Events;

namespace Sprint0.Events
{
    public class EventEnemiesKilledUnlocksDoor : AbstractEvent
    {

        Room Room;
        Door Door;
        public EventEnemiesKilledUnlocksDoor(Room room, Door door)
        {
            Room = room;
            Door = door;
        }

        public override void Update(GameTime gameTime)
        {

            if(Room.Characters.Count == 0 && Fired == false)
            {
                Door.Unlock();
                Fired = true;
            }
        }
    }
}
