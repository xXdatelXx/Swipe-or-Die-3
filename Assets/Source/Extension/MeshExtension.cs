using UnityEngine;

namespace SwipeOrDie.Extension
{
    public static class MeshExtension
    {
        public static byte[] Serialize(this Mesh mesh) => 
            MeshSerializer.SerializeMesh(mesh);

        public static Mesh DeSerialize(this MeshData meshData) => 
            meshData.Generate();
    }
}