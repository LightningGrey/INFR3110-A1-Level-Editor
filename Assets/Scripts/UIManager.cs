using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Dictionary<int, GameObject> _dictionary = new Dictionary<int, GameObject>();
    public GameObject[] objects;
    public GameObject character;
    public GameObject spotLight;
    public GameObject pointLight;
    private bool charFlag = false;

    Vector3 spawnPoint;

    //observer
    public Subject _subject;
    private Object _createdObject;
    public Text panelText;
    private bool gravityBool = true;

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

        if (_dictionary[index] == character)
        {
            if (!charFlag)
            {
                _createdObject = new Object(this.GetComponent<Factory>().createObject(index, spawnPoint));
                charFlag = true;
            }
        } else
        {
            _createdObject = new Object(this.GetComponent<Factory>().createObject(index, spawnPoint));
            
        }


        if (_dictionary[index] != spotLight && _dictionary[index] != pointLight) {
            if (gravityBool == false) { 
                _createdObject.rb.useGravity = false;
            }
            _subject.AddObserver(_createdObject);
        }

    }

    public void GravityToggleButton()
    {
        _subject.Notify();
        gravityBool = !gravityBool;
        if (gravityBool == false)
        {
            panelText.GetComponent<Text>().text = "Gravity is off.";
        } else { 
            panelText.GetComponent<Text>().text = "Gravity is on.";
        }
    }

}

