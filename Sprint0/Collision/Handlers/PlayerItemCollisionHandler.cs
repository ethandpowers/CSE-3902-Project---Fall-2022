﻿using Sprint0.Commands.GameStates;
using Sprint0.Items;
using Sprint0.Items.Items;
using Sprint0.Player;
using System.Collections.Generic;

namespace Sprint0.Collision.Handlers
{
    // Handles all collisions between players and items
    public class PlayerItemCollisionHandler
    {
        private readonly List<System.Type> InventoryItems;

        public PlayerItemCollisionHandler() 
        {
            InventoryItems = new List<System.Type> { typeof(Arrow), typeof(BlueCandle), typeof(BluePotion), typeof(Bomb), typeof(Bow),
            typeof(Compass), typeof(Key), typeof(Map), typeof(Rupee), typeof(WoodenBoomerang), typeof(ValuableRupee) };
        }

        public void HandleCollision(IPlayer player, IItem item, Game1 game)
        {
            if (InventoryItems.Contains(item.GetType()))
            {
                // Some item pickups give you more than one
                if (item is Bomb) player.Inventory.AddToInventory(item.GetItemType(), 4);
                else if (item is ValuableRupee) player.Inventory.AddToInventory(item.GetItemType(), 5);
                else player.Inventory.AddToInventory(item.GetItemType(), 1);

                if (item is Bow) 
                {
                    player.HoldItem(item);                    
                } 

                if (item is Key) AudioManager.GetInstance().PlayOnce(Resources.HeartKeyPickup);
                else if (item.GetItemType() == Types.Item.RUPEE) AudioManager.GetInstance().PlayOnce(Resources.RupeePickup);
                else AudioManager.GetInstance().PlayOnce(Resources.ItemPickup);               
            }
            else if (item is Clock) 
            {
                // freeze all enemies in the room indefinitely
                AudioManager.GetInstance().PlayOnce(Resources.ItemPickup);
            }
            else if (item is Fairy)
            {
                player.ChangeHealth(3, 0, game);
                AudioManager.GetInstance().PlayOnce(Resources.HeartKeyPickup);
            }
            else if (item is Heart)
            {
                player.ChangeHealth(1, 0, game);
                AudioManager.GetInstance().PlayOnce(Resources.HeartKeyPickup);
            }
            else if (item is HeartContainer)
            {
                player.ChangeHealth(0, 1, game);
                AudioManager.GetInstance().PlayOnce(Resources.ItemPickup);
            }
            else if (item is TriforcePiece)
            {
                player.HoldItem(item);
                new WinGameCommand(game).Execute();
            }
            game.LevelManager.CurrentLevel.CurrentRoom.RemoveItemFromRoom(item);
        }
    }
}
