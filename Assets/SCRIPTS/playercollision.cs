using Unity.VisualScripting;
using UnityEngine;

public class playercollision : MonoBehaviour
{
    logicmanager lm;
    [SerializeField] Animator animator;
    void Start()
    {
        lm =  FindAnyObjectByType<logicmanager>();
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("coin"))
        {
            lm.changecoin(1);
            Destroy(collision.gameObject);
        }
       else if (collision.gameObject.CompareTag("fence"))
        {
            animator.SetTrigger("hit");
        }
        else if (collision.gameObject.CompareTag("obstacle"))
        {
            lm.changelife(-1);
            Destroy(collision.gameObject);
        }
    }
}
