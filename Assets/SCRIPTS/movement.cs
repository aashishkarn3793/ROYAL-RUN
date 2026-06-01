using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.UI;

public class movement : MonoBehaviour
{
    [SerializeField] float movespeed = 3f;
    [SerializeField] Vector2 clamp;
     Vector2 move;
    Rigidbody rb;
   
    void Awake()
    {
        rb =  GetComponent<Rigidbody>();
    }
   
    void FixedUpdate()
    {
        handlemovement();
    }
    public void Move(InputAction.CallbackContext context)
    {
        move= context.ReadValue<Vector2>();
        Debug.Log(move);
    }
    public void handlemovement()
    {
        Vector3 currentpos =  rb.position;
        Vector3 movedir = new Vector3(move.x,0f,move.y);
        Vector3 newpos = currentpos + movedir *(movespeed * Time.fixedDeltaTime);
        newpos.x = Mathf.Clamp(newpos.x, -clamp.x , clamp.x);
        newpos.z = Mathf.Clamp(newpos.z, -clamp.y, clamp.y);
        rb.MovePosition(newpos);

    }
  
}
