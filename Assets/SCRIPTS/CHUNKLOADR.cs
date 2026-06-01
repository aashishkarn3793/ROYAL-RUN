using System.Collections.Generic;

using UnityEngine;

public class CHUNKLOADR : MonoBehaviour
{
  [SerializeField] GameObject[] chunkprefabs;
  [SerializeField] GameObject chunkparent;
  [SerializeField] int chunkamount = 10;
  [SerializeField] int chunklength = 10;
 // GameObject[] chunks = new GameObject[10]; 
 List<GameObject> chunks = new List<GameObject>();
 [SerializeField] float movespeed = 5f;

    public void Start()
    {
        chunkload();
    }
    public void Update()
    {
        movechunk();
    }

    private void chunkload()
    {
        for (int i = 0; i < chunkamount; i++)
        {
            float chunkz;
            if (i == 0)
            {
                chunkz = transform.position.z;
            }
            else
            {
                chunkz = (i * chunklength) + transform.position.z;
            }
             GameObject chunkprefab = chunkprefabs[Random.Range(0,chunkprefabs.Length)];
            Vector3 chunkpos = new Vector3(transform.position.x, transform.position.y, chunkz);
            GameObject newChunk =Instantiate(chunkprefab, chunkpos, Quaternion.identity, chunkparent.transform);
            chunks.Add(newChunk);
        }
    }
    private void movechunk()
    {
        for(int i=0;i < chunks.Count; i++)
        {
            GameObject chunk = chunks[i];
            chunk.transform.Translate(-transform.forward* movespeed * Time.deltaTime);
            if(chunk.transform.position.z <= Camera.main.transform.position.z - chunklength)
            {
                chunks.Remove(chunk);
                Destroy(chunk);
                spawnnewchunk();
            }
        }
    }
    private void spawnnewchunk()
    {
            float chunkz ;
            chunkz =  (chunks[chunks.Count-1].transform.position.z + chunklength);
             GameObject chunkprefab = chunkprefabs[Random.Range(0,chunkprefabs.Length)];
            Vector3 chunkpos = new Vector3(transform.position.x, transform.position.y, chunkz);
            GameObject newChunk =Instantiate(chunkprefab, chunkpos, Quaternion.identity, chunkparent.transform);
            chunks.Add(newChunk);

    }
}
