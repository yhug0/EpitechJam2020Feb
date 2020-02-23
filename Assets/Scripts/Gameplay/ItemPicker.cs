using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemPicker : MonoBehaviour
{
    int yellow = 0;
    int white = 0;

    public TextMeshProUGUI  yellowIndicator;
    public TextMeshProUGUI  whiteIndicator;
    void Update()
    {
        yellowIndicator.text = ": " + yellow;
        whiteIndicator.text = ": " + white;
    }
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "yellow") {
            yellow += 1;
            Destroy(other.gameObject);
        } else if (other.tag == "white")
        {
            white += 1;
            Destroy(other.gameObject);
        }
    }
}
