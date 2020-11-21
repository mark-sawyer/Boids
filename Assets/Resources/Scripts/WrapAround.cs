using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrapAround : MonoBehaviour {
    [SerializeField] private float max;

    void Update() {
        float x = transform.position.x;
        float y = transform.position.y;
        x = wrapValue(x);
        y = wrapValue(y);
        transform.position = new Vector3(x, y);
    }

    private float wrapValue(float value) {
        if (value > max) {
            value = value - max;
        }
        else if (value < 0) {
            value = value + max;
        }
        return value;
    }
}
