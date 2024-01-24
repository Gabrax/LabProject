using UnityEngine;
using UnityEditor;
using System.IO;

namespace LowPolyWater
{
    public class GeneratePlane : ScriptableWizard
    {
        public string objectName;            

        public int widthSegments = 1;        
        public int heightSegments = 1;       
        public float planeWidth = 1.0f;     
        public float planeHeight = 1.0f;    

        public bool addCollider = false;     
        public Material material;            

        static Camera cam;
        static Camera lastUsedCam;

         
        public static string assetSaveLocation = "Assets/Low Poly Water/Plane Meshes/";

        [MenuItem("GameObject/LowPoly Water/Generate Water Plane...")]
        static void CreateWizard()
        {
            cam = Camera.current;
             
            if (!cam)
            {
                cam = lastUsedCam;
            }
            else
            {
                lastUsedCam = cam;
            }

             
             
            if (!Directory.Exists(assetSaveLocation))
            {
                Directory.CreateDirectory(assetSaveLocation);
            }

             
            DisplayWizard("Generate Water Plane", typeof(GeneratePlane));
        }

        void OnWizardUpdate()
        {
             
             
            widthSegments = Mathf.Clamp(widthSegments, 1, 254);
            heightSegments = Mathf.Clamp(heightSegments, 1, 254);
        }

        private void OnWizardCreate()
        {
             
            GameObject plane = new GameObject();

             
            if (string.IsNullOrEmpty(objectName))
            {
                plane.name = "Plane";
            }
            else
            {
                plane.name = objectName;
            }

             
            MeshFilter meshFilter = plane.AddComponent(typeof(MeshFilter)) as MeshFilter;
            MeshRenderer meshRenderer = plane.AddComponent((typeof(MeshRenderer))) as MeshRenderer;
            meshRenderer.sharedMaterial = material;

             
            string planeMeshAssetName = plane.name + widthSegments + "x" + heightSegments
                                        + "W" + planeWidth + "H" + planeHeight + ".asset";

             
            Mesh m = (Mesh)AssetDatabase.LoadAssetAtPath(assetSaveLocation + planeMeshAssetName, typeof(Mesh));

             
            if (m == null)
            {
                m = new Mesh();
                m.name = plane.name;

                int hCount2 = widthSegments + 1;
                int vCount2 = heightSegments + 1;
                int numTriangles = widthSegments * heightSegments * 6;
                int numVertices = hCount2 * vCount2;

                Vector3[] vertices = new Vector3[numVertices];
                Vector2[] uvs = new Vector2[numVertices];
                int[] triangles = new int[numTriangles];
                Vector4[] tangents = new Vector4[numVertices];
                Vector4 tangent = new Vector4(1f, 0f, 0f, -1f);
                Vector2 anchorOffset = Vector2.zero;

                int index = 0;
                float uvFactorX = 1.0f / widthSegments;
                float uvFactorY = 1.0f / heightSegments;
                float scaleX = planeWidth / widthSegments;
                float scaleY = planeHeight / heightSegments;

                 
                for (float y = 0.0f; y < vCount2; y++)
                {
                    for (float x = 0.0f; x < hCount2; x++)
                    {
                        vertices[index] = new Vector3(x * scaleX - planeWidth / 2f - anchorOffset.x, 0.0f, y * scaleY - planeHeight / 2f - anchorOffset.y);

                        tangents[index] = tangent;
                        uvs[index++] = new Vector2(x * uvFactorX, y * uvFactorY);
                    }
                }

                 
                index = 0;
                for (int y = 0; y < heightSegments; y++)
                {
                    for (int x = 0; x < widthSegments; x++)
                    {
                        triangles[index] = (y * hCount2) + x;
                        triangles[index + 1] = ((y + 1) * hCount2) + x;
                        triangles[index + 2] = (y * hCount2) + x + 1;

                        triangles[index + 3] = ((y + 1) * hCount2) + x;
                        triangles[index + 4] = ((y + 1) * hCount2) + x + 1;
                        triangles[index + 5] = (y * hCount2) + x + 1;
                        index += 6;
                    }
                }

                 
                m.vertices = vertices;
                m.uv = uvs;
                m.triangles = triangles;
                m.tangents = tangents;
                m.RecalculateNormals();

                 
                AssetDatabase.CreateAsset(m, assetSaveLocation + planeMeshAssetName);
                AssetDatabase.SaveAssets();
            }

             
            meshFilter.sharedMesh = m;
            m.RecalculateBounds();

             
            if (addCollider)
                plane.AddComponent(typeof(BoxCollider));

             
            plane.AddComponent<LowPolyWater>();
            
            Selection.activeObject = plane;
        }
    }
}
