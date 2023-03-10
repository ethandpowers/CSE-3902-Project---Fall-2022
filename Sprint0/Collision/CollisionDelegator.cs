using Sprint0.Blocks;
using Sprint0.Characters;
using Sprint0.Collision.Handlers;
using Sprint0.Items;
using Sprint0.Player;
using Sprint0.Projectiles;

namespace Sprint0.Collision
{
    /* DEV NOTES:
     * 
     * The collision delegator's job is to figure out what specific kind of collision has occurred - for example, is it one in which
     * the player is the affected object and a block is the acting object (player-block collision)?
     * 
     * Once the collision delegator has done this, it delegates the affected/acting objects and side (obtained from the collision
     * detector) to an appropriate collision handler that is capable of handling that specific type of collision
     */
    public class CollisionDelegator
    {
        private readonly PlayerCharacterCollisionHandler PlayerCharacterHandler;
        private readonly PlayerProjectileCollisionHandler PlayerProjectileHandler;
        private readonly PlayerBlockCollisionHandler PlayerBlockHandler;
        private readonly PlayerItemCollisionHandler PlayerItemHandler;
        private readonly CharacterCharacterCollisionHandler CharacterCharacterHandler;
        private readonly CharacterProjectileCollisionHandler CharacterProjectileHandler;
        private readonly CharacterBlockCollisionHandler CharacterBlockHandler;   
        private readonly ProjectileBlockCollisionHandler ProjectileBlockHandler;
        private readonly ProjectileItemCollisionHandler ProjectileItemHandler;

        public CollisionDelegator() 
        {
            PlayerCharacterHandler = new PlayerCharacterCollisionHandler();
            PlayerProjectileHandler = new PlayerProjectileCollisionHandler();
            PlayerBlockHandler = new PlayerBlockCollisionHandler();
            PlayerItemHandler = new PlayerItemCollisionHandler();
            CharacterCharacterHandler = new();
            CharacterProjectileHandler = new CharacterProjectileCollisionHandler();
            CharacterBlockHandler = new CharacterBlockCollisionHandler(); 
            ProjectileBlockHandler = new ProjectileBlockCollisionHandler();
            ProjectileItemHandler = new ProjectileItemCollisionHandler();
        }

        public void DelegateCollision(ICollidable CollidableA, ICollidable CollidableB, Types.Direction SideA, Game1 game) 
        {
            if (CollidableA is IPlayer && CollidableB is ICharacter)
            {
                PlayerCharacterHandler.HandleCollision(CollidableA as IPlayer, CollidableB as ICharacter, SideA, game);
            }
            else if (CollidableA is IPlayer && CollidableB is IProjectile)
            {
                PlayerProjectileHandler.HandleCollision(CollidableA as IPlayer, CollidableB as IProjectile, SideA, game);
            }
            else if (CollidableA is IPlayer && CollidableB is IBlock)
            {
                PlayerBlockHandler.HandleCollision(CollidableA as IPlayer, CollidableB as IBlock, SideA, game,
                    game.LevelManager.CurrentLevel.CurrentRoom);
            }
            else if (CollidableA is IPlayer && CollidableB is IItem)
            {
                PlayerItemHandler.HandleCollision(CollidableA as IPlayer, CollidableB as IItem, game,
                    game.LevelManager.CurrentLevel.CurrentRoom);
            }
            else if (CollidableA is ICharacter && CollidableB is ICharacter) 
            {
                CharacterCharacterHandler.HandleCollision(CollidableA as ICharacter, CollidableB as ICharacter);
            }
            else if (CollidableA is ICharacter && CollidableB is IBlock)
            {
                CharacterBlockHandler.HandleCollision(CollidableA as ICharacter, CollidableB as IBlock, SideA);
            }
            else if (CollidableA is ICharacter && CollidableB is IProjectile)
            {
                CharacterProjectileHandler.HandleCollision(CollidableA as ICharacter, CollidableB as IProjectile, SideA,
                    game.LevelManager.CurrentLevel.CurrentRoom);
            }
            else if (CollidableA is IProjectile && CollidableB is IBlock)
            {
                ProjectileBlockHandler.HandleCollision(CollidableA as IProjectile, CollidableB as IBlock, SideA);
            }
            else if (CollidableA is IProjectile && CollidableB is IItem)
            {
                ProjectileItemHandler.HandleCollision(CollidableA as IProjectile, CollidableB as IItem, SideA);
            }
        } 
    }
}
