using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {
    
    private Rigidbody rb;
	private AudioSource audioSource;
    public float speed;
    public float tilt;

    public float fireRate;
	private float nextFire = 0.0F;

    public Boundary boundary;
    public GameObject shot;
    public Transform shotSpawn;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
		audioSource = GetComponent<AudioSource> ();
    }

    //Fixed Update is called automatically before each Physics step. Executed once per physics step
    void FixedUpdate()
    {
        float MoveHorizontal = Input.GetAxis("Horizontal");
        float MoveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(MoveHorizontal, 0.0f, MoveVertical);
        rb.velocity = movement * speed;
        rb.position = new Vector3
        (
            Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax), 
            0.0f, 
            Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
        );
        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * (-1) * tilt);
    }

    //Update is called at every frame change
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time > nextFire)
		{
            nextFire = Time.time + fireRate;
            GameObject clone = Instantiate(shot, shotSpawn.position, shotSpawn.rotation) as GameObject;	
			audioSource.Play();
        }
    }
}

