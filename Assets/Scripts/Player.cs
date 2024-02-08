using System;
using Fusion;
using Fusion.Addons.Physics;
using UnityEngine;

public class Player : NetworkBehaviour
{
    private NetworkRigidbody3D _rb;

    private void Awake()
    {
        TryGetComponent(out _rb);
    }

    public override void Spawned()
    {
        name = $"{Object.InputAuthority} ({(HasInputAuthority ? "Input Authority" : (HasStateAuthority ? "State Authority" : "Proxy"))})";

        if (HasInputAuthority == false)
        {
            // Virtual cameras are enabled only for local player.
            var virtualCameras = GetComponentsInChildren<Camera>(true);
            for (int i = 0; i < virtualCameras.Length; i++)
            {
                virtualCameras[i].enabled = false;
            }
        }
    }
    
    public override void FixedUpdateNetwork()
    {
        if (GetInput(out NetworkInputData data))
        {
            data.direction.Normalize();
            Vector3 dir = 800 * data.direction * Runner.DeltaTime;
            _rb.Rigidbody.velocity = new Vector3(dir.x, _rb.Rigidbody.velocity.y, dir.z);
            if (data.jump)
            {
                _rb.Rigidbody.AddForce(new Vector3(0, 520000, 0));
            }
        }
    }
}