using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpFloor : MonoBehaviour
{
    [SerializeField] float jumpForce;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.layer);
        int playerLayerMask = LayerMask.NameToLayer("Player");
        Debug.Log(playerLayerMask);
        
        if (collision.gameObject.layer == playerLayerMask)
        {
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            if(rb != null)
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }
            
    }
}
