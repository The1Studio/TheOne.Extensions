﻿#nullable enable
namespace TheOne.Extensions
{
    using UnityEngine;

    public static class VectorExtensions
    {
        public static Vector2 WithX(this Vector2 vector, float x)
        {
            vector.x = x;
            return vector;
        }

        public static Vector2 WithY(this Vector2 vector, float y)
        {
            vector.y = y;
            return vector;
        }

        public static Vector3 WithX(this Vector3 vector, float x)
        {
            vector.x = x;
            return vector;
        }

        public static Vector3 WithY(this Vector3 vector, float y)
        {
            vector.y = y;
            return vector;
        }

        public static Vector3 WithZ(this Vector3 vector, float z)
        {
            vector.z = z;
            return vector;
        }

        public static Vector4 WithX(this Vector4 vector, float x)
        {
            vector.x = x;
            return vector;
        }

        public static Vector4 WithY(this Vector4 vector, float y)
        {
            vector.y = y;
            return vector;
        }

        public static Vector4 WithZ(this Vector4 vector, float z)
        {
            vector.z = z;
            return vector;
        }

        public static Vector4 WithW(this Vector4 vector, float w)
        {
            vector.w = w;
            return vector;
        }

        public static Vector2Int WithX(this Vector2Int vector, int x)
        {
            vector.x = x;
            return vector;
        }

        public static Vector2Int WithY(this Vector2Int vector, int y)
        {
            vector.y = y;
            return vector;
        }

        public static Vector3Int WithX(this Vector3Int vector, int x)
        {
            vector.x = x;
            return vector;
        }

        public static Vector3Int WithY(this Vector3Int vector, int y)
        {
            vector.y = y;
            return vector;
        }

        public static Vector3Int WithZ(this Vector3Int vector, int z)
        {
            vector.z = z;
            return vector;
        }
    }
}