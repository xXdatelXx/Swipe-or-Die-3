using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using B83.MeshTools;
using UnityEngine;

/// <summary>
/// From: https://pastebin.com/yW91qEQh
/// (i don't want to refactor this ¯\_(ツ)_/¯)
/// </summary>
[Serializable]
public class MeshData
{
    [SerializeField, HideInInspector] private byte[] m_Data;
    private Mesh m_Mesh;
    public byte[] Data => m_Data;

    public MeshData(Mesh aMesh)
    {
        m_Mesh = aMesh;
        if (aMesh == null)
            m_Data = null;
        else
            m_Data = MeshSerializer.SerializeMesh(m_Mesh);
    }

    public Mesh Generate()
    {
        if (m_Mesh == null && m_Data != null)
            m_Mesh = MeshSerializer.DeserializeMesh(m_Data);
        return m_Mesh;
    }
}

public static class MeshSerializer
{
    /*
     * Structure:
     * - Magic string "Mesh" (4 bytes)
     * - vertex count [int] (4 bytes)
     * - submesh count [int] (4 bytes)
     * - vertices [array of Vector3]
     * 
     * - additional chunks:
     *   [vertex attributes]
     *   - Name (name of the Mesh object)
     *   - Normals [array of Vector3]
     *   - Tangents [array of Vector4]
     *   - Colors [array of Color32]
     *   - UV0-4 [
     *       - component count[byte](2/3/4)
     *       - array of Vector2/3/4
     *     ]
     *   - BoneWeights [array of 4x int+float pair]
     *   
     *   [other data]
     *   - Submesh [
     *       - topology[byte]
     *       - count[int]
     *       - component size[byte](1/2/4)
     *       - array of byte/ushort/int
     *     ]
     *   - Bindposes [
     *       - count[int]
     *       - array of Matrix4x4
     *     ]
     *   - BlendShape [
     *       - Name [string]
     *       - frameCount [int]
     *       - frames [ array of:
     *           - frameWeight [float]
     *           - array of [
     *               - position delta [Vector3]
     *               - normal delta [Vector3]
     *               - tangent delta [Vector3]
     *             ]
     *         ]
     *     ]
     */
    private enum EChunkID : byte
    {
        End,
        Name,
        Normals,
        Tangents,
        Colors,
        BoneWeights,
        UV0,
        UV1,
        UV2,
        UV3,
        Submesh,
        Bindposes,
        BlendShape,
    }

    const uint m_Magic = 0x6873654D; // "Mesh"

    public static byte[] SerializeMesh(Mesh aMesh)
    {
        using (var stream = new MemoryStream())
        {
            SerializeMesh(stream, aMesh);
            return stream.ToArray();
        }
    }

    public static void SerializeMesh(MemoryStream aStream, Mesh aMesh)
    {
        using (var writer = new BinaryWriter(aStream))
            SerializeMesh(writer, aMesh);
    }

    public static void SerializeMesh(BinaryWriter aWriter, Mesh aMesh)
    {
        aWriter.Write(m_Magic);
        var vertices = aMesh.vertices;
        int count = vertices.Length;
        int subMeshCount = aMesh.subMeshCount;
        aWriter.Write(count);
        aWriter.Write(subMeshCount);
        foreach (var v in vertices)
            aWriter.WriteVector3(v);

        // start of tagged chunks
        if (!string.IsNullOrEmpty(aMesh.name))
        {
            aWriter.Write((byte)EChunkID.Name);
            aWriter.Write(aMesh.name);
        }

        var normals = aMesh.normals;
        if (normals != null && normals.Length == count)
        {
            aWriter.Write((byte)EChunkID.Normals);
            foreach (var v in normals)
                aWriter.WriteVector3(v);
            normals = null;
        }

        var tangents = aMesh.tangents;
        if (tangents != null && tangents.Length == count)
        {
            aWriter.Write((byte)EChunkID.Tangents);
            foreach (var v in tangents)
                aWriter.WriteVector4(v);
            tangents = null;
        }

        var colors = aMesh.colors32;
        if (colors != null && colors.Length == count)
        {
            aWriter.Write((byte)EChunkID.Colors);
            foreach (var c in colors)
                aWriter.WriteColor32(c);
            colors = null;
        }

        var boneWeights = aMesh.boneWeights;
        if (boneWeights != null && boneWeights.Length == count)
        {
            aWriter.Write((byte)EChunkID.BoneWeights);
            foreach (var w in boneWeights)
                aWriter.WriteBoneWeight(w);
            boneWeights = null;
        }

        List<Vector4> uvs = new List<Vector4>();
        for (int i = 0; i < 4; i++)
        {
            uvs.Clear();
            aMesh.GetUVs(i, uvs);
            if (uvs.Count == count)
            {
                aWriter.Write((byte)((byte)EChunkID.UV0 + i));
                byte channelCount = 2;
                foreach (var uv in uvs)
                {
                    if (uv.z != 0f)
                        channelCount = 3;
                    if (uv.w != 0f)
                    {
                        channelCount = 4;
                        break;
                    }
                }

                aWriter.Write(channelCount);
                if (channelCount == 2)
                    foreach (var uv in uvs)
                        aWriter.WriteVector2(uv);
                else if (channelCount == 3)
                    foreach (var uv in uvs)
                        aWriter.WriteVector3(uv);
                else
                    foreach (var uv in uvs)
                        aWriter.WriteVector4(uv);
            }
        }

        List<int> indices = new List<int>(count * 3);
        for (int i = 0; i < subMeshCount; i++)
        {
            indices.Clear();
            aMesh.GetIndices(indices, i);
            if (indices.Count > 0)
            {
                aWriter.Write((byte)EChunkID.Submesh);
                aWriter.Write((byte)aMesh.GetTopology(i));
                aWriter.Write(indices.Count);
                var max = indices.Max();
                if (max < 256)
                {
                    aWriter.Write((byte)1);
                    foreach (var index in indices)
                        aWriter.Write((byte)index);
                }
                else if (max < 65536)
                {
                    aWriter.Write((byte)2);
                    foreach (var index in indices)
                        aWriter.Write((ushort)index);
                }
                else
                {
                    aWriter.Write((byte)4);
                    foreach (var index in indices)
                        aWriter.Write(index);
                }
            }
        }

        var bindposes = aMesh.bindposes;
        if (bindposes != null && bindposes.Length > 0)
        {
            aWriter.Write((byte)EChunkID.Bindposes);
            aWriter.Write(bindposes.Length);
            foreach (var b in bindposes)
                aWriter.WriteMatrix4x4(b);
            bindposes = null;
        }

        int blendShapeCount = aMesh.blendShapeCount;
        if (blendShapeCount > 0)
        {
            var blendVerts = new Vector3[count];
            var blendNormals = new Vector3[count];
            var blendTangents = new Vector3[count];
            for (int i = 0; i < blendShapeCount; i++)
            {
                aWriter.Write((byte)EChunkID.BlendShape);
                aWriter.Write(aMesh.GetBlendShapeName(i));
                var frameCount = aMesh.GetBlendShapeFrameCount(i);
                aWriter.Write(frameCount);
                for (int n = 0; n < frameCount; n++)
                {
                    aMesh.GetBlendShapeFrameVertices(i, n, blendVerts, blendNormals, blendTangents);
                    aWriter.Write(aMesh.GetBlendShapeFrameWeight(i, n));
                    for (int k = 0; k < count; k++)
                    {
                        aWriter.WriteVector3(blendVerts[k]);
                        aWriter.WriteVector3(blendNormals[k]);
                        aWriter.WriteVector3(blendTangents[k]);
                    }
                }
            }
        }

        aWriter.Write((byte)EChunkID.End);
    }


    public static Mesh DeserializeMesh(byte[] aData, Mesh aTarget = null)
    {
        using (var stream = new MemoryStream(aData))
            return DeserializeMesh(stream, aTarget);
    }

    public static Mesh DeserializeMesh(MemoryStream aStream, Mesh aTarget = null)
    {
        using (var reader = new BinaryReader(aStream))
            return DeserializeMesh(reader, aTarget);
    }

    public static Mesh DeserializeMesh(BinaryReader aReader, Mesh aTarget = null)
    {
        if (aReader.ReadUInt32() != m_Magic)
            return null;
        if (aTarget == null)
            aTarget = new Mesh();
        aTarget.Clear();
        aTarget.ClearBlendShapes();
        int count = aReader.ReadInt32();
        if (count > 65534)
            aTarget.indexFormat = UnityEngine.Rendering.IndexFormat.UInt32;
        int subMeshCount = aReader.ReadInt32();
        Vector3[] vector3Array = new Vector3[count];
        Vector3[] vector3Array2 = null;
        Vector3[] vector3Array3 = null;
        List<Vector4> vector4List = null;
        for (int i = 0; i < count; i++)
            vector3Array[i] = aReader.ReadVector3();
        aTarget.vertices = vector3Array;
        aTarget.subMeshCount = subMeshCount;
        int subMeshIndex = 0;
        byte componentCount = 0;

        // reading chunks
        var stream = aReader.BaseStream;
        while ((stream.CanSeek && stream.Position < stream.Length) || stream.CanRead)
        {
            var chunkID = (EChunkID)aReader.ReadByte();
            if (chunkID == EChunkID.End)
                break;
            switch (chunkID)
            {
                case EChunkID.Name:
                    aTarget.name = aReader.ReadString();
                    break;
                case EChunkID.Normals:
                    for (int i = 0; i < count; i++)
                        vector3Array[i] = aReader.ReadVector3();
                    aTarget.normals = vector3Array;
                    break;
                case EChunkID.Tangents:
                    if (vector4List == null)
                        vector4List = new List<Vector4>(count);
                    vector4List.Clear();
                    for (int i = 0; i < count; i++)
                        vector4List.Add(aReader.ReadVector4());
                    aTarget.SetTangents(vector4List);
                    break;
                case EChunkID.Colors:
                    var colors = new Color32[count];
                    for (int i = 0; i < count; i++)
                        colors[i] = aReader.ReadColor32();
                    aTarget.colors32 = colors;
                    break;
                case EChunkID.BoneWeights:
                    var boneWeights = new BoneWeight[count];
                    for (int i = 0; i < count; i++)
                        boneWeights[i] = aReader.ReadBoneWeight();
                    aTarget.boneWeights = boneWeights;
                    break;
                case EChunkID.UV0:
                case EChunkID.UV1:
                case EChunkID.UV2:
                case EChunkID.UV3:
                    int uvChannel = chunkID - EChunkID.UV0;
                    componentCount = aReader.ReadByte();
                    if (vector4List == null)
                        vector4List = new List<Vector4>(count);
                    vector4List.Clear();

                    if (componentCount == 2)
                    {
                        for (int i = 0; i < count; i++)
                            vector4List.Add(aReader.ReadVector2());
                    }
                    else if (componentCount == 3)
                    {
                        for (int i = 0; i < count; i++)
                            vector4List.Add(aReader.ReadVector3());
                    }
                    else if (componentCount == 4)
                    {
                        for (int i = 0; i < count; i++)
                            vector4List.Add(aReader.ReadVector4());
                    }

                    aTarget.SetUVs(uvChannel, vector4List);
                    break;
                case EChunkID.Submesh:
                    var topology = (MeshTopology)aReader.ReadByte();
                    int indexCount = aReader.ReadInt32();
                    var indices = new int[indexCount];
                    componentCount = aReader.ReadByte();
                    if (componentCount == 1)
                    {
                        for (int i = 0; i < indexCount; i++)
                            indices[i] = aReader.ReadByte();
                    }
                    else if (componentCount == 2)
                    {
                        for (int i = 0; i < indexCount; i++)
                            indices[i] = aReader.ReadUInt16();
                    }
                    else if (componentCount == 4)
                    {
                        for (int i = 0; i < indexCount; i++)
                            indices[i] = aReader.ReadInt32();
                    }

                    aTarget.SetIndices(indices, topology, subMeshIndex++, false);
                    break;
                case EChunkID.Bindposes:
                    int bindposesCount = aReader.ReadInt32();
                    var bindposes = new Matrix4x4[bindposesCount];
                    for (int i = 0; i < bindposesCount; i++)
                        bindposes[i] = aReader.ReadMatrix4x4();
                    aTarget.bindposes = bindposes;
                    break;
                case EChunkID.BlendShape:
                    var blendShapeName = aReader.ReadString();
                    int frameCount = aReader.ReadInt32();
                    if (vector3Array2 == null)
                        vector3Array2 = new Vector3[count];
                    if (vector3Array3 == null)
                        vector3Array3 = new Vector3[count];
                    for (int i = 0; i < frameCount; i++)
                    {
                        float weight = aReader.ReadSingle();
                        for (int n = 0; n < count; n++)
                        {
                            vector3Array[n] = aReader.ReadVector3();
                            vector3Array2[n] = aReader.ReadVector3();
                            vector3Array3[n] = aReader.ReadVector3();
                        }

                        aTarget.AddBlendShapeFrame(blendShapeName, weight, vector3Array, vector3Array2, vector3Array3);
                    }

                    break;
            }
        }

        return aTarget;
    }
}