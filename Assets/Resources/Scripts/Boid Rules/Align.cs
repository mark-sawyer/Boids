using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Align : IBoidRule {
    List<Vector2> velocities;

    public Align(List<Vector2> velocities) {
        this.velocities = velocities;
    }

    public Vector2 steerDirection() {
        if (velocities.Count == 0) {
            return Vector2.zero;
        }

        Vector2 sumVelocity = Vector2.zero;
        foreach (Vector2 velocity in velocities) {
            sumVelocity += velocity;
        }
        Vector2 averageVelocity = sumVelocity / velocities.Count;
        return averageVelocity;
    }
}
