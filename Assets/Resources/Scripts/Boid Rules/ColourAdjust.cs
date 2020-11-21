using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourAdjust : MonoBehaviour {
    private SpriteRenderer sr;
    private List<Vector3> positions;
    private float colourFunctionInput;
    private float delta;
    [SerializeField] private Color lowColour;
    [SerializeField] private Color highColour;

    private void Start() {
        sr = GetComponent<SpriteRenderer>();
        positions = transform.GetChild(0).GetComponent<Sense>().positions;
        delta = 0.01f;
        colourFunctionInput = 0.5f;
    }

    private void Update() {
        int nearby = positions.Count;
        float goalcolourFunctionInput = (float)nearby / 70;
        if (colourFunctionInput < goalcolourFunctionInput) {
            colourFunctionInput += delta;
        }
        else if (colourFunctionInput > goalcolourFunctionInput) {
            colourFunctionInput -= delta;
        }
        colourFunctionInput = Mathf.Clamp(colourFunctionInput, 0, 1);
        Color goalColour = Color.Lerp(lowColour, highColour, colourFunctionInput);
        sr.color = goalColour;
    }
}
