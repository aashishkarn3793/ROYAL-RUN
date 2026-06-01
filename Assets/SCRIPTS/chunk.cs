
using System.Collections.Generic;
using System.Reflection.Emit;
using Unity.VisualScripting;
using UnityEngine;

public class chunk : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
  [SerializeField] float[] lanes = {-3, 0 ,3};
  [SerializeField] GameObject fence;
  [SerializeField] GameObject coins;
   List<int> availablelanes = new List<int> {0,1,2};
    void Start()
    {
        spawnfence();
        spawncoin();
    }

    private void spawnfence()
    {
       /* 
       rng 
       int randomnum =  Random.Range(0,3);
        for(int i = 0 ; i < randomnum; i++)
        {
            Vector3 pos = new Vector3(lanes[Random.Range(0, lanes.Length)], transform.position.y, transform.position.z);
        Instantiate(fence, pos, Quaternion.identity, this.transform);
        }*/
       
        int fencestospawn = Random.Range(0, lanes.Length);
        for(int i = 0 ; i< fencestospawn;i++)
        {
            if(availablelanes.Count <= 0) break;
            int randomlaneindex = Random.Range(0, availablelanes.Count);
            int selectedlane = availablelanes[randomlaneindex];
            availablelanes.RemoveAt(randomlaneindex);
            Vector3 pos = new Vector3(lanes[selectedlane], transform.position.y, transform.position.z);
            Instantiate(fence, pos, Quaternion.identity, this.transform);
        }
    }
    private void spawncoin()
    {
        int availablelane = availablelanes[0];
        Vector3 spawnposition = new Vector3(lanes[availablelane], transform.position.y + 0.7f, transform.position.z- 7f);
        Instantiate(coins, spawnposition, Quaternion.identity, transform);
   }
}
