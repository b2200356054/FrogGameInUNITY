using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogCollision : MonoBehaviour
{
    [SerializeField] private FrogMovement Movement;
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Wall")
        {
           
        }
        
    }
    
}
