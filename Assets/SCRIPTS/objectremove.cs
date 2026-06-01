using UnityEngine;

public class objectremove : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("obstacle"))
        {
             Destroy(other.gameObject);
        }
       
    }}
