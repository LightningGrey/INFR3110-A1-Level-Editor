using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject character;
    public GameObject wagon;
    public GameObject rock;
    public GameObject rockCluster;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CharacterSpawn()
    {
        if (!GameObject.Find("Player(Clone)"))
        {
            Instantiate(character);
        }
        
    }
    public void WagonSpawn() {
        Instantiate(wagon);
    }
    public void RockSpawn() {
        Instantiate(rock);
    }
    public void RockClusterSpawn() {
        Instantiate(rockCluster);
    }

}
