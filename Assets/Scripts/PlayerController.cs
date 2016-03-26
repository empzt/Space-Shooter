using UnityEngine;
using System.Collections;

[System.Serializable]
public class Tilts
{
    public float xtilt;
    public float ztilt;
}

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;

}

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public float speed;
    public Boundary boundary;
    public Tilts tilts;
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    private float nextFire;
    private AudioSource audioSource;

    // Update is called once per frame
    void Update()
    {
        audioSource = GetComponent<AudioSource>();
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            // GameObject clone = 
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation); // as GameObject;
            audioSource.Play();
        }
        
    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.velocity = movement * speed;

        rb.position = new Vector3
            (
                Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
                0.0f,
                Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
            );
        rb.rotation = Quaternion.Euler(rb.velocity.z * tilts.ztilt, 0.0f, rb.velocity.x * -tilts.xtilt);
    }


}
