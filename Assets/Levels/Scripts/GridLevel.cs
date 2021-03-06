using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridLevel : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector2 _gridSize;
    [SerializeField] private int m_GridSize = 6;
    [SerializeField] private Material[] m_Material;
    [SerializeField] private Material m_FloorMat;
    private GameObject _level;
    [SerializeField] private GameObject m_Player; 
    void Awake()
    {
        CreateFloor();
        CreateLevel(Vector3.zero);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateFloor()
    {
        var x = GameObject.CreatePrimitive(PrimitiveType.Cube);
        x.transform.position = new Vector3(0, -1, 0);
        x.transform.localScale = new Vector3(500, 1, 500);
        x.GetComponent<MeshRenderer>().material = m_FloorMat;
        x.name = "Floor";
    }
    
    void CreateLevel(Vector3 origin , int levelID = 0)
    {
        _gridSize = Vector2.one * m_GridSize;
        _level = new GameObject();
        _level.name = "Level";
        _level.transform.parent = transform;
        for (int i = 0; i < m_GridSize; i++)
        {
            for (int j = 0; j < m_GridSize; j++)
            {
                var x = GameObject.CreatePrimitive(PrimitiveType.Cube);
                x.transform.parent = _level.transform;
                x.transform.position = new Vector3(i, 0, j) + origin;
                var m = m_Material[Random.Range(0, m_Material.Length)];
                x.GetComponent<MeshRenderer>().material = m;
                x.tag = m.name;
                x.name = $"({i}, {j})";
            }
        }
    }
    
    
}
