using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sense : MonoBehaviour {
    public List<Vector3> positions { get; private set; }
    public List<Vector2> velocities { get; private set; }
    private LayerMask boidLayer;
    private Rigidbody2D rb;

    private void Awake() {
        boidLayer = LayerMask.GetMask("boid");
        rb = transform.GetComponentInParent<Rigidbody2D>();
        positions = new List<Vector3>(50);
        velocities = new List<Vector2>(50);
    }

    private void Update() {
        positions.Clear();
        velocities.Clear();
        Collider2D[] boidsSensed = Physics2D.OverlapCircleAll(transform.position, 3, boidLayer);
        for (int i = 0; i < boidsSensed.Length; i++) {
            GameObject boid = boidsSensed[i].gameObject;
            if (boid != transform.parent.gameObject) {
                addToSenseLists(boid);
            }
        }
    }

    private bool boidNotBehind(Vector3 boid) {
        Vector3 directionToBoid = boid - transform.position;
        Vector3 velocity = rb.velocity;
        float degrees = Vector3.Angle(velocity, directionToBoid);
        return degrees <= 135;
    }

    private void addToSenseLists(GameObject boid) {
        positions.Add(boid.transform.position);
        velocities.Add(boid.GetComponent<Rigidbody2D>().velocity);
    }
}
