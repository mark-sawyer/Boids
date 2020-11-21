using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceDirection : MonoBehaviour {
    private Rigidbody2D rb;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        Vector2 v = rb.velocity;
        float radAngle = Mathf.Atan2(v.y, v.x);
        float degAngle = radAngle * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, degAngle));
    }
}
