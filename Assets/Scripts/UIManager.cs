using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    Dictionary<int, GameObject> _dictionary = new Dictionary<int, GameObject>();
    public GameObject[] objects;
    public GameObject character;
    private bool charFlag = false;

    Vector3 spawnPoint;


    private void Awake()
    {
        for (int i = 0; i < objects.Length; i++) {
            _dictionary.Add(i, objects[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit cast;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out cast) && EventSystem.current.IsPointerOverGameObject(-1))
        {
            spawnPoint = cast.point;
        }
        //move spawn up to avoid clipping
        spawnPoint += new Vector3(0.0f, 1.0f, 0.0f);
    }

    public void Spawn(int index)
    {
        if (_dictionary[index] == character) { 
            if (!charFlag)
            {
                Instantiate(objects[index], spawnPoint, Quaternion.identity);
                charFlag = true;
            }
        } else { 
            Instantiate(objects[index], spawnPoint, Quaternion.identity);
        }

    }

}
