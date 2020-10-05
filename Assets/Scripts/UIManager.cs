using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject character;
    public GameObject brick;
    public GameObject wagon;
    public GameObject rock;
    public GameObject rockCluster;
    public GameObject spotLight;
    public GameObject pointLight;
    Vector3 spawnPoint;

    // Update is called once per frame
    void Update()
    {
        RaycastHit cast;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out cast) && EventSystem.current.IsPointerOverGameObject(-1))
        {
            spawnPoint = cast.point;
        }
    }

    public void CharacterSpawn()
    {
       if (!GameObject.Find("Player(Clone)"))
       {
           Instantiate(character, spawnPoint, Quaternion.identity); 
       }
       
   }
   public void WagonSpawn() {
       Instantiate(wagon, spawnPoint, Quaternion.identity);
    }
    public void BrickSpawn()
    {
        Instantiate(brick, spawnPoint, Quaternion.identity);
    }
    public void RockSpawn() {
       Instantiate(rock, spawnPoint, Quaternion.identity);
    }
   public void RockClusterSpawn() {
       Instantiate(rockCluster, spawnPoint, Quaternion.identity);
    }
   public void SpotLightSpawn() {
       Instantiate(spotLight, spawnPoint, Quaternion.identity);
    }
   public void PointLightSpawn() {
       Instantiate(pointLight, spawnPoint, Quaternion.identity);
    }

}
