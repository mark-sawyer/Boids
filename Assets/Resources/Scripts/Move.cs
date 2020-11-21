using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {
    [SerializeField] private float speed;
    private Rigidbody2D rb;
    private Sense sense;
    private Avoid avoid;
    private Align align;
    private Centre centre;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        sense = transform.GetChild(0).GetComponent<Sense>();
        float angle = Random.Range(0, 2 * Mathf.PI);
        Vector2 v = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        rb.velocity = v * speed;
        avoid = new Avoid(sense.positions, transform);
        align = new Align(sense.velocities);
        centre = new Centre(sense.positions, transform);
    }

    void Update() {
        Vector2 v = rb.velocity;
        v += avoid.steerDirection();
        v += align.steerDirection();
        v += centre.steerDirection();
        v = v.normalized * speed;
        rb.velocity = v;
    }
}
