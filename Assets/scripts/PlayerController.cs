using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    private Rigidbody rb;
    public GameObject bullet;
    public Transform bulletSpawnPos;
    public float speed;
    private float nextFire;
    public float fireRate;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        nextFire = fireRate;
	}
	
	// Update is called once per frame
	void Update ()
    {
        float moveHor = Input.GetAxis("Horizontal");
        float moveVer = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHor, 0.0f, moveVer);
        Quaternion rotation = new Quaternion(moveHor, 0.0f, moveVer, 0.0f);
        if(Input.GetButton("Jump") && Time.time > nextFire)
        {
            Instantiate(bullet, bulletSpawnPos.position, bulletSpawnPos.rotation);
            nextFire = Time.time + fireRate;
        }
        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        rb.AddForce(movement * speed, ForceMode.Force);
        
        float xRot = rb.rotation.x;
        float zRot = rb.rotation.z;
        float yRot = rb.rotation.y;
        Debug.Log("xRot = " + xRot + " yRot = " + yRot + " zRot = " + zRot);
        if (xRot < 0.0f)
        {
            rb.AddTorque(10.0f, 0.0f, 0.0f, ForceMode.Force);
        }
        else if (xRot > 0.0f)
        {
            rb.AddTorque(-10.0f, 0.0f, 0.0f, ForceMode.Force);
        }
        if (zRot < 0.0f)
        {
            rb.AddTorque(0.0f, 0.0f, 10.0f, ForceMode.Force);
        }
        else if (zRot > 0.0f)
        {
            rb.AddTorque(0.0f, 0.0f, -10.0f, ForceMode.Force);
        }
        if (yRot < 0)
        {
            rb.AddTorque(0.0f, 10.0f, 0.0f, ForceMode.Force);
        }
        else if (yRot > 0)
        {
            rb.AddTorque(0.0f, -10.0f, 0.0f, ForceMode.Force);
        }
    }
}
