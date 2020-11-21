using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Avoid : IBoidRule {
    private List<Vector3> positions;
    private Transform transform;

    public Avoid(List<Vector3> positions, Transform transform) {
        this.positions = positions;
        this.transform = transform;
    }

    public Vector2 steerDirection() {
        Vector3 direction = Vector3.zero;
        foreach (Vector3 position in positions) {
            float distance = (transform.position - position).magnitude;
            if (distance < 1) {
                direction = direction - (position - transform.position);
            }
        }

        return direction;
    }
}
