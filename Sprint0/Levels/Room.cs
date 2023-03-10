using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Blocks;
using Sprint0.Blocks.Blocks;
using Sprint0.Blocks.Utils;
using Sprint0.Characters;
using Sprint0.Characters.Enemies;
using Sprint0.Characters.Utils;
using Sprint0.Collision;
using Sprint0.Doors;
using Sprint0.Entities;
using Sprint0.Items;
using Sprint0.Items.Utils;
using Sprint0.Levels.Borders;
using Sprint0.Levels.Events;
using Sprint0.Levels.Utils;
using Sprint0.Npcs;
using Sprint0.Projectiles;
using Sprint0.Projectiles.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using static Sprint0.Types;

namespace Sprint0.Levels
{
    public class Room : IEntity
    {
        public List<IBlock> Blocks { get; }
        public List<ICharacter> Characters { get; }
        public List<IItem> Items { get; }
        public DoorHandler DoorHandler { get; }
        public ProjectileHandler Projectiles { get; }
        public EventMaster EventMaster { get; }

        public IEntity Parent { get; set; }
        private Dictionary<RoomTransition, Room> AdjacentRooms;

        private IBorder Border;

        private Level Context;

        public string Name { get; set; }
        public int RoomID;
        public Room(Level level, string roomName)
        {
            Context = level;
            Blocks = new List<IBlock>();
            Characters = new List<ICharacter>();
            Items = new List<IItem>();
            EventMaster = new EventMaster();
            DoorHandler = new DoorHandler();
            Projectiles = new ProjectileHandler();

            Name = roomName;
            int length = roomName.Length - 4;
            string substring = roomName.Substring(4, length);
            RoomID = int.Parse(substring);
            //RoomID = int.Parse(roomName.Substring(4, length));
            AdjacentRooms = new Dictionary<RoomTransition, Room>()
            {
                {RoomTransition.UP, null },
                {RoomTransition.RIGHT, null },
                {RoomTransition.DOWN, null },
                {RoomTransition.LEFT, null },
                {RoomTransition.SECRET, null },
            };
        }

        public void SetBorder(Border border)
        {
            Border = BorderFactory.GetInstance().GetBorder(border);
        }
        public void AddTransition(Room room, RoomTransition direction)
        {
            AdjacentRooms[direction] = room;
        }
        public void MakeTransition(RoomTransition direction, bool goToBeginning = false)
        {
            if (AdjacentRooms[direction] != null)   // If there is a valid adjacent room in this direction.
            {
                Context.CurrentRoom = AdjacentRooms[direction]; // Set the owning level's current room to this adjacent room.
                ResetRoom();
                Context.VisitedRooms.Add(Context.CurrentRoom.RoomID);
            }
        }
        public void ResetRoom() 
        {
            foreach (ICharacter character in Characters)
            {
                character.Unfreeze();
                if (character is SecretText) (character as SecretText).Reset();
            }
            foreach (IBlock block in Blocks) if (block is PushableBlock) (block as PushableBlock).Reset();
        }
        public Room GetAdjacentRoom(RoomTransition direction)
        {
            return AdjacentRooms[direction];
        }
        public void AddBlockToRoom(Types.Block block, Vector2 position)
        {
            Blocks.Add(BlockFactory.GetInstance().GetBlock(block, position));
        }
        // Overloaded method to add a block directly to the collection.
        public void AddBlockToRoom(IBlock block)
        {
            Blocks.Add(block);
        }
        public void RemoveBlockFromRoom(IBlock block)
        {
            Blocks.Remove(block);
        }
        public void AddCharacterToRoom(Types.Character character, Vector2 position, Types.Direction direction = Direction.NO_DIRECTION,
            bool clockwise = false)
        {
            Characters.Add(CharacterFactory.GetInstance().GetCharacter(character, position, direction, clockwise));
        }
        public void AddCharacterToRoom(ICharacter character)
        {
            Characters.Add(character);
        }

        public void RemoveCharacterFromRoom(ICharacter character)
        {
            Characters.Remove(character);
        }
        public void AddItemToRoom(Types.Item item, Vector2 position)
        {
            Items.Add(ItemFactory.GetInstance().GetItem(item, position));
        }
        // Overloaded method to add an item directly to the collection.
        public void AddItemToRoom(IItem item)
        {
            Items.Add(item);
        }
        public void RemoveItemFromRoom(IItem item)
        {
            Items.Remove(item);
        }
        public void AddEventToRoom(IEvent roomevent)
        {
            EventMaster.AddEvent(roomevent);
        }
        public void AddDoorToRoom(string key, IDoor door)
        {
            DoorHandler.AddDoor(key, door);
        }
        public void AddProjectileToRoom(Types.Projectile proj, ICollidable user, Types.Direction direction)
        {
            Projectiles.AddProjectile(ProjectileFactory.GetInstance().GetProjectile(proj, user, direction));
        }
        public void RemoveProjectileFromRoom(IProjectile proj)
        {
            Projectiles.RemoveProjectile(proj);
        }
        public void SetBorder(BlueRoomBorder border)
        {
            Border = border;
        }
        public void Update(GameTime gameTime)
        {
            foreach (IBlock block in Blocks)
            {
                block.Update();
            }
            foreach (IItem item in Items)
            {
                item.Update();
            }
            for (int i = Characters.Count - 1; i >= 0; i--)
            {
                Characters[i].Update(gameTime);
                if (Characters[i] is Hand && (Characters[i] as Hand).ShouldBeKilled) Characters.RemoveAt(i);
            }
            DoorHandler.Update(gameTime);
            Border.Update();
            Projectiles.Update();
        }
        public void Draw(SpriteBatch sb)
        {
            List<IBlock> PushableBlocks = new();
            foreach (IBlock block in Blocks)
            {
                block.Draw(sb);
                if (block is PushableBlock) PushableBlocks.Add(block);
            }
            foreach (PushableBlock pb in PushableBlocks)
            {
                pb.Draw(sb);
            }
            PushableBlocks.Clear();
            foreach (IItem item in Items)
            {
                item.Draw(sb);
            }
            
            foreach (ICharacter character in Characters)
            {
                character.Draw(sb);
            }
            DoorHandler.Draw(sb);
            Border.Draw(sb);
            Projectiles.Draw(sb);
        }
    }
}
