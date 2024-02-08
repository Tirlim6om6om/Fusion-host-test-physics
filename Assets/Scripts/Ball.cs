using System;
using Fusion.Addons.Physics;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private NetworkRigidbody3D _rb;
    
    private void Start()
    {
        TryGetComponent(out _rb);
    }
    
    // private void OnCollisionEnter(Collision collision)
    // {
    //     if (collision.gameObject.CompareTag("Player"))
    //     {
    //         _rb.Rigidbody.AddForce(0, 800, 0);
    //     }
    // }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _rb.Rigidbody.AddForce(0, 800, 0);
        }
    }
}
