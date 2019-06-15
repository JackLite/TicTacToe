using UnityEngine;

namespace Game.Field
{
    public struct FieldRectSize
    {
        public float Width;
        public float Height;

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