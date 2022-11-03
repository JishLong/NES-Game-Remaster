﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Blocks;
using Sprint0.Blocks.Blocks;
using Sprint0.Blocks.Utils;
using Sprint0.Characters;
using Sprint0.Characters.Utils;
using Sprint0.Collision;
using Sprint0.Items;
using Sprint0.Items.Utils;
using Sprint0.Projectiles;
using Sprint0.Projectiles.Tools;
using Sprint0.Sprites;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Threading;
using static Sprint0.Types;

namespace Sprint0.Levels
{
    public class Room
    {
        public List<IBlock> Blocks { get;}
        public List<ICharacter> Characters { get;}
        public List<IItem> Items { get;}

        public ProjectileHandler Projectiles { get;}

        private Dictionary<RoomTransition, Room> AdjacentRooms;

        private RoomBorder Border;

        private Level Context;

        public string RoomName;
        public Room(Level level, string roomName)
        {
            Context = level;
            Blocks = new List<IBlock>();
            Characters = new List<ICharacter>();
            Items = new List<IItem>();
            Projectiles = new ProjectileHandler();
            // TODO: This needs to take an argument so that it knows which border to construct.
            // This should probably be based off of room name or level name.
            Border = new RoomBorder();

            RoomName = roomName;
            AdjacentRooms = new Dictionary<RoomTransition, Room>()
            {
                {RoomTransition.UP, null },
                {RoomTransition.RIGHT, null },
                {RoomTransition.DOWN, null },
                {RoomTransition.LEFT, null },
                {RoomTransition.SECRET, null },
            };
        }
        public void AddTransition(Room room, RoomTransition direction)
        {
            AdjacentRooms[direction] = room;
        }
        public void MakeTransition(RoomTransition direction)
        {
            if (AdjacentRooms[direction] != null)   // If there is a valid adjacent room in this direction.
            {
                Context.CurrentRoom = AdjacentRooms[direction]; // Set the owning level's current room to this adjacent room.
            } 
        }
        public Room GetAdjacentRoom(RoomTransition direction) 
        {
            return AdjacentRooms[direction];
        }
        public void AddBlockToRoom(Types.Block block, Vector2 position)
        {
            Blocks.Add(BlockFactory.GetInstance().GetBlock(block, position));
        }
        public void RemoveItemFromRoom(IBlock block)
        {
            Blocks.Remove(block);
        }
        public void AddCharacterToRoom(Types.Character character, Vector2 position)
        {
            Characters.Add(CharacterFactory.GetInstance().GetCharacter(character, position));
        }
        public void RemoveCharacterFromRoom(ICharacter character)
        {
            Characters.Remove(character);
        }
        public void AddItemToRoom(Types.Item item, Vector2 position)
        {
            Items.Add(ItemFactory.GetInstance().GetItem(item, position));
        }
        public void RemoveItemFromRoom(IItem item) 
        {
            Items.Remove(item);
        }
        public void AddProjectileToRoom(Types.Projectile proj, ICollidable user, Types.Direction direction) 
        {
            Projectiles.AddProjectile(ProjectileFactory.GetInstance().GetProjectile(proj, user, direction));
        }
        public void RemoveProjectileFromRoom(IProjectile proj) 
        {
            Projectiles.RemoveProjectile(proj);
        }

        public void Update(GameTime gameTime)
        {         
            foreach(IBlock block in Blocks)
            {
                block.Update();
            }
            foreach (IItem item in Items)
            {
                item.Update();
            }
            foreach (ICharacter character in Characters)
            {
                character.Update(gameTime);
            }
            Projectiles.Update();
            Border.Update();
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
            Border.Draw(sb);
            foreach (IItem item in Items)
            {
                item.Draw(sb);
            }
            foreach (ICharacter character in Characters)
            {
                character.Draw(sb);
            }
            Projectiles.Draw(sb);       
        }
    }
}
