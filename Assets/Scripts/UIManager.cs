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
        //move spawn up to avoid clipping
        spawnPoint += new Vector3(0.0f, 1.0f, 0.0f);
    }
            
    public void CharacterSpawn()
    {
       if (!GameObject.Find("Player(Clone)"))
       {
            Instantiate(character, spawnPoint, Quaternion.identity);
            History.history.Push(new DeSpawnInteraction(character));
       }
       
   }
   public void WagonSpawn() {
       Instantiate(wagon, spawnPoint, Quaternion.identity);
        History.history.Push(new DeSpawnInteraction(wagon));
    }
    public void BrickSpawn()
    {
       Instantiate(brick, spawnPoint, Quaternion.identity);
        History.history.Push(new DeSpawnInteraction(brick));
    }
    public void RockSpawn() {
       Instantiate(rock, spawnPoint, Quaternion.identity);
        History.history.Push(new DeSpawnInteraction(rock));
    }
   public void RockClusterSpawn() {
       Instantiate(rockCluster, spawnPoint, Quaternion.identity);
        History.history.Push(new DeSpawnInteraction(rockCluster));
    }
   public void SpotLightSpawn() {
       Instantiate(spotLight, spawnPoint, Quaternion.identity);
        History.history.Push(new DeSpawnInteraction(spotLight));
    }
   public void PointLightSpawn() {
       Instantiate(pointLight, spawnPoint, Quaternion.identity);
        History.history.Push(new DeSpawnInteraction(pointLight));
    }

}
