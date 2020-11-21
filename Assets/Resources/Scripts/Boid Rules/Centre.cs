using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Centre : IBoidRule {
    private List<Vector3> positions;
    private Transform transform;

    public Centre(List<Vector3> positions, Transform transform) {
        this.positions = positions;
        this.transform = transform;
    }

    public Vector2 steerDirection() {
        if (positions.Count == 0) {
            return Vector2.zero;
        }

        Vector3 positionSum = Vector3.zero;
        foreach (Vector3 position in positions) {
            positionSum += position;
        }

        Vector3 averagePosition = positionSum / positions.Count;
        Vector3 towardsPosition = averagePosition - transform.position;
        return towardsPosition;
    }
}
