using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateBoids : MonoBehaviour {
    [SerializeField] private GameObject boid;
    [SerializeField] private int boidNum;

    private void Awake() {
        for (int i = 0; i < boidNum; i++) {
            float x = Random.Range(0f, 50f);
            float y = Random.Range(0f, 50f);
            Vector3 position = new Vector3(x, y);
            GameObject newBoid = Instantiate(boid, position, Quaternion.identity);
        }
    }
}
