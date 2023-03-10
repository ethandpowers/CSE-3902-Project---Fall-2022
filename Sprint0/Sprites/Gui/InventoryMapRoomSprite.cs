using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Assets;

namespace Sprint0.Sprites.Gui
{
    public class InventoryMapRoomSprite : AbstractSprite
    {
        private readonly Rectangle DefaultFrame;
        private readonly bool HasLeftRoom;
        private readonly bool HasRightRoom;
        private readonly bool HasUpRoom;
        private readonly bool HasDownRoom;

        public InventoryMapRoomSprite(bool hasLeftRoom, bool hasRightRoom, bool hasUpRoom, bool hasDownRoom) 
        {
            HasLeftRoom = hasLeftRoom;
            HasRightRoom = hasRightRoom;
            HasUpRoom = hasUpRoom;
            HasDownRoom = hasDownRoom;

            if (!hasLeftRoom && !hasRightRoom && !hasUpRoom && !hasDownRoom) DefaultFrame = AssetManager.DefaultImageAssets.MapIconNoDoors;
            else if (hasLeftRoom && hasRightRoom && hasUpRoom && hasDownRoom) DefaultFrame = AssetManager.DefaultImageAssets.MapIconAllDoors;
            else if (hasLeftRoom && hasRightRoom && !hasUpRoom && !hasDownRoom) DefaultFrame = AssetManager.DefaultImageAssets.MapIconHorizontalDoors;
            else if (!hasLeftRoom && !hasRightRoom && hasUpRoom && hasDownRoom) DefaultFrame = AssetManager.DefaultImageAssets.MapIconVerticalDoors;

            else if (hasLeftRoom && !hasRightRoom && !hasUpRoom && !hasDownRoom) DefaultFrame = AssetManager.DefaultImageAssets.MapIconLeftDoor;
            else if (!hasLeftRoom && hasRightRoom && !hasUpRoom && !hasDownRoom) DefaultFrame = AssetManager.DefaultImageAssets.MapIconRightDoor;
            else if (!hasLeftRoom && !hasRightRoom && hasUpRoom && !hasDownRoom) DefaultFrame = AssetManager.DefaultImageAssets.MapIconUpDoor;
            else if (!hasLeftRoom && !hasRightRoom && !hasUpRoom && hasDownRoom) DefaultFrame = AssetManager.DefaultImageAssets.MapIconDownDoor;

            else if (hasLeftRoom && !hasRightRoom && hasUpRoom && !hasDownRoom) DefaultFrame = AssetManager.DefaultImageAssets.MapIconUpLeftDoors;
            else if (!hasLeftRoom && hasRightRoom && hasUpRoom && !hasDownRoom) DefaultFrame = AssetManager.DefaultImageAssets.MapIconUpRightDoors;
            else if (hasLeftRoom && !hasRightRoom && !hasUpRoom && hasDownRoom) DefaultFrame = AssetManager.DefaultImageAssets.MapIconDownLeftDoors;
            else if (!hasLeftRoom && hasRightRoom && !hasUpRoom && hasDownRoom) DefaultFrame = AssetManager.DefaultImageAssets.MapIconDownRightDoors;

            else if (hasLeftRoom && hasRightRoom && hasUpRoom && !hasDownRoom) DefaultFrame = AssetManager.DefaultImageAssets.MapIconNoDownDoor;
            else if (hasLeftRoom && hasRightRoom && !hasUpRoom && hasDownRoom) DefaultFrame = AssetManager.DefaultImageAssets.MapIconNoUpDoor;
            else if (hasLeftRoom && !hasRightRoom && hasUpRoom && hasDownRoom) DefaultFrame = AssetManager.DefaultImageAssets.MapIconNoRightDoor;
            else /*if (!hasLeftRoom && hasRightRoom && hasUpRoom && hasDownRoom)*/ DefaultFrame = AssetManager.DefaultImageAssets.MapIconNoLeftDoor;
        }

        protected override Texture2D GetSpriteSheet() => ImageMappings.GetInstance().GuiElementsSpriteSheet;

        protected override Rectangle GetFirstFrame() 
        {
            if (!HasLeftRoom && !HasRightRoom && !HasUpRoom && !HasDownRoom) return ImageMappings.GetInstance().MapIconNoDoors;
            else if (HasLeftRoom && HasRightRoom && HasUpRoom && HasDownRoom) return ImageMappings.GetInstance().MapIconAllDoors;
            else if (HasLeftRoom && HasRightRoom && !HasUpRoom && !HasDownRoom) return ImageMappings.GetInstance().MapIconHorizontalDoors;
            else if (!HasLeftRoom && !HasRightRoom && HasUpRoom && HasDownRoom) return ImageMappings.GetInstance().MapIconVerticalDoors;

            else if (HasLeftRoom && !HasRightRoom && !HasUpRoom && !HasDownRoom) return ImageMappings.GetInstance().MapIconLeftDoor;
            else if (!HasLeftRoom && HasRightRoom && !HasUpRoom && !HasDownRoom) return ImageMappings.GetInstance().MapIconRightDoor;
            else if (!HasLeftRoom && !HasRightRoom && HasUpRoom && !HasDownRoom) return ImageMappings.GetInstance().MapIconUpDoor;
            else if (!HasLeftRoom && !HasRightRoom && !HasUpRoom && HasDownRoom) return ImageMappings.GetInstance().MapIconDownDoor;

            else if (HasLeftRoom && !HasRightRoom && HasUpRoom && !HasDownRoom) return ImageMappings.GetInstance().MapIconUpLeftDoors;
            else if (!HasLeftRoom && HasRightRoom && HasUpRoom && !HasDownRoom) return ImageMappings.GetInstance().MapIconUpRightDoors;
            else if (HasLeftRoom && !HasRightRoom && !HasUpRoom && HasDownRoom) return ImageMappings.GetInstance().MapIconDownLeftDoors;
            else if (!HasLeftRoom && HasRightRoom && !HasUpRoom && HasDownRoom) return ImageMappings.GetInstance().MapIconDownRightDoors;

            else if (HasLeftRoom && HasRightRoom && HasUpRoom && !HasDownRoom) return ImageMappings.GetInstance().MapIconNoDownDoor;
            else if (HasLeftRoom && HasRightRoom && !HasUpRoom && HasDownRoom) return ImageMappings.GetInstance().MapIconNoUpDoor;
            else if (HasLeftRoom && !HasRightRoom && HasUpRoom && HasDownRoom) return ImageMappings.GetInstance().MapIconNoRightDoor;
            else /*if (!HasLeftRoom && HasRightRoom && HasUpRoom && HasDownRoom)*/ return ImageMappings.GetInstance().MapIconNoLeftDoor;
        }

        protected override Rectangle GetDefaultFrame() => DefaultFrame;
    }
}
