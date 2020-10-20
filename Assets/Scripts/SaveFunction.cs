using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using JetBrains.Annotations;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.VFX;

public class SaveFunction : MonoBehaviour
{
    public GameObject[] objects;
    public InputField input;
    public Text panelText;
    public UIManager _manager;

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

    [DllImport(DLL_NAME)]
    private static extern bool SaveToFile([MarshalAs(UnmanagedType.LPStr)] string file);

    [DllImport(DLL_NAME)]
    private static extern bool LoadFromFile([MarshalAs(UnmanagedType.LPStr)] string file);


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

    public void SaveLevel()
    {

        objects = GameObject.FindGameObjectsWithTag("LevelObject");

        for (int i = 0; i < objects.Length; i++)
        {
            LevelObject _levelObject = new LevelObject(
                objects[i].GetComponent<ObjectData>().ID, objects[i].transform.position.x,
                objects[i].transform.position.y, objects[i].transform.position.z);
            AddObject(_levelObject);
        }

        if (input.text == "")
        {
            panelText.GetComponent<Text>().text = "Enter a file name.";
        }
        else
        { 
            string fileName = Application.dataPath + "/Resources/" + input.text 
                + ".txt"; 
            if (!System.IO.File.Exists(fileName))
            {
                System.IO.File.Delete(fileName);
            }
            SaveToFile(fileName);
            panelText.GetComponent<Text>().text = "File saved.";
        }
    }

    public void LoadLevel()
    {
        if (input.text == "")
        {
            panelText.GetComponent<Text>().text = "Enter a file name.";
        }
        else
        {
            string fileName = Application.dataPath + "/Resources/" + input.text 
                + ".txt";
            if (!System.IO.File.Exists(fileName))
            {
                panelText.GetComponent<Text>().text = "File not found.";
            }
            LoadFromFile(fileName);

            for (int i = 0; i < GetObjectTotal(); i++)
            {
                Instantiate(_manager._dictionary[GetObject(i).ID],
                    new Vector3(GetObject(i).x, GetObject(i).y, GetObject(i).z),
                    Quaternion.identity);

            }

            panelText.GetComponent<Text>().text = "Scene loaded.";
        }

    }

    
    private void OnDestroy()
    {
        ClearList();
    }
}
