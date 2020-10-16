using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class SaveFunction : MonoBehaviour
{
    const string DLL_NAME = "SaveFeatureDLL";

    [StructLayout(LayoutKind.Sequential)]
    struct LevelObject
    {
        public int ID;
        public float x;
        public float y;
        public float z;

        public LevelObject (int _ID, float _x, float _y, float _z) 
        {
            ID = _ID;
            x = _x;
            y = _y;
            z = _z;
        }
    }

    [DllImport(DLL_NAME)]
    private static extern void AddObject(LevelObject newObject);

    [DllImport(DLL_NAME)]
    private static extern void RemoveObject(int index);

    [DllImport(DLL_NAME)]
    private static extern LevelObject GetObject(int index);

    [DllImport(DLL_NAME)]
    private static extern int GetObjectTotal();

    [DllImport(DLL_NAME)]
    private static extern void ClearList();


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LevelObject obj = new LevelObject(5, 6.0f, 2.0f, 1.0f);
            AddObject(obj);
            Debug.Log("object added");
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log(GetObject(0).ID);
            Debug.Log(GetObject(0).x);
            Debug.Log(GetObject(0).y);
            Debug.Log(GetObject(0).z);
        }
        
    }

    private void SaveLevel()
    {

    }

    private void LoadLevel()
    {

    }

    
    private void OnDestroy()
    {
        ClearList();
    }
}
