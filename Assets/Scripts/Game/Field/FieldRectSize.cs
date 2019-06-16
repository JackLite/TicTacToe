using UnityEngine;

namespace Game.Field
{
    public struct FieldRectSize
    {
        public readonly float Width;
        public readonly float Height;

        public FieldRectSize(float width, float height)
        {
            Width = width;
            Height = height;
        }

        public FieldRectSize(Rect rect)
        {
            Width = rect.width;
            Height = rect.height;
        }
    }
}