using UnityEngine;
using System.Collections;

public class BulletMover : MonoBehaviour
{
    private Rigidbody rb;
    public float launchPower;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * launchPower,ForceMode.Impulse);
    }
}
