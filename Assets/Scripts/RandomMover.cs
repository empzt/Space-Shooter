using UnityEngine;
using System.Collections;

public class RandomMover : MonoBehaviour {
    private Rigidbody rb;
    private Vector3 toto = new Vector3(1, 0, 1);
    // Use this for initialization
    void Start() {
        rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.Scale(Random.insideUnitSphere,toto)*Random.Range(1,10);
        
        Debug.Log(rb.velocity);
    }
	
	// Update is called once per frame
	void Update () {

        
	}
}
