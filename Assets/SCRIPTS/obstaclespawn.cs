using System.Collections;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class obstaclespawn : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
  [SerializeField] GameObject[] obstacles;
  [SerializeField] int numtospawn = 10;
  [SerializeField] int waitfortime = 2;
  [SerializeField] GameObject obstacleparent;
  [SerializeField] float spawnwidth =3f;
  
  private void Start()
    {
        StartCoroutine(spawnobject());
    }

  IEnumerator spawnobject()
    {
        while (true)
        {
            yield return new WaitForSeconds(waitfortime);
            Vector3 spawnposition = new Vector3(Random.Range(-spawnwidth,spawnwidth),transform.position.y,transform.position.z);
            GameObject obstacle = obstacles[Random.Range(0, obstacles.Length)];
            Instantiate(obstacle, spawnposition, Random.rotation, obstacleparent.transform);
            numtospawn--;
           }
    }
}
   
