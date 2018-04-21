using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed : MonoBehaviour {
    void OnMouseUp() {
        PlayerController.Sleep();
    }
}
