using UnityEngine;
using System.Collections.Generic;
using System.Collections;
[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class ScriptedGrid : MonoBehaviour
{
    private WaitForSeconds wfs = new WaitForSeconds(.05f);
    [SerializeField] private int ZSize;
    [SerializeField] private int XSize;
    [SerializeField] private int YSize;
    private Vector3[] Vertices;
    private Mesh ProceduralMeshGenerated;
    private void Start()
    {
       StartCoroutine(CreateMesh());
    }
    private IEnumerator CreateMesh()
    {
        GetComponent<MeshFilter>().mesh = ProceduralMeshGenerated = new Mesh();
        ProceduralMeshGenerated.name = "Procedural Grid";
        int m_cornerVertices = 8;
        int m_edgeVertices = (XSize + YSize + ZSize -3)*4;
        int faceVertices = (
            (XSize - 1) * (YSize - 1) +
            (XSize - 1) * (ZSize - 1) +
            (YSize - 1) * (ZSize - 1)) * 2;


        Vertices = new Vector3[m_cornerVertices + m_edgeVertices + faceVertices];
        Vector2[] m_Uv = new Vector2[Vertices.Length];
        Vector4[] m_tangents = new Vector4[Vertices.Length];
        Vector4 m_tangent = new Vector4(1f, 0f, 0f, -1f);
        int v = 0;
        for (int y = 0; y <= YSize; y++)
        {
            for (int x = 0; x <= XSize; x++)
            {
                Vertices[v++] = new Vector3(x, y, 0);
                yield return wfs;
            }
            for (int z = 1; z <= ZSize; z++)
            {
                Vertices[v++] = new Vector3(XSize, y, z);
                yield return wfs;
            }
            for (int x = XSize - 1; x >= 0; x--)
            {
                Vertices[v++] = new Vector3(x, y,ZSize);
                yield return wfs;
            }
            for (int z = ZSize - 1; z > 0; z--)
            {
                Vertices[v++] = new Vector3(0, y, z);
                yield return wfs;
            }
        }

        ProceduralMeshGenerated.vertices = Vertices;

        int[] m_triangles = new int[XSize * YSize * 6];
        for (int ti = 0, vi = 0, y = 0; y < YSize; y++, vi++)
        {
            for (int x = 0; x < XSize; x++, ti += 6, vi++)
            {
                m_triangles[ti] = vi;
                m_triangles[ti + 3] = m_triangles[ti + 2] = vi + 1;
                m_triangles[ti + 4] = m_triangles[ti + 1] = vi + XSize + 1;
                m_triangles[ti + 5] = vi + XSize + 2;
            }
        }
        ProceduralMeshGenerated.triangles = m_triangles;
        ProceduralMeshGenerated.uv = m_Uv;
        ProceduralMeshGenerated.tangents = m_tangents;
        ProceduralMeshGenerated.RecalculateNormals();
    }
  
}
