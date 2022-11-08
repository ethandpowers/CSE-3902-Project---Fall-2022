﻿using Sprint0.Player.State.Idle;
using Sprint0.Player.State;
using Sprint0.Sprites.Player.Attack.UseItem;
using Sprint0.Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Items.Items;

namespace Sprint0.Player.States.BlueArrow
{
    public class PlayerPickUpItemState : AbstractPlayerState
    {
        private readonly IItem Item;
        private bool JustPickedUp;

        public PlayerPickUpItemState(Player player, IItem item) : base(player)
        {
            Sprite = new PlayerPickUpItemSprite();
            Item = item;
        }

        public PlayerPickUpItemState(IPlayerState state, IItem item) : base(state)
        {
            Sprite = new PlayerPickUpItemSprite();
            Item = item;     
        }

        public override void Draw(SpriteBatch sb, Vector2 position) 
        {
            base.Draw(sb, position);
            Item.Position = Utils.LineUpEdges(GetHitbox(), Item.GetHitbox().Width, Item.GetHitbox().Height, Types.Direction.UP);
            Item.Draw(sb);
        }

        public override void Update()
        {
            base.Update();           
            Item.Update();

            if (FramesPassed == 2 && Item is Bow) AudioManager.GetInstance().PlaySelfishSound(Resources.NewItem);

            if (FramesPassed % ItemPickUpFrames == 0)
            {
                Player.State = new PlayerFacingDownState(this);
            }
        }
    }
}
