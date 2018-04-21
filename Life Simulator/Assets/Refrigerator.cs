using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Refrigerator : MonoBehaviour {
    void OnMouseUp()
    {
        PlayerController.Eat();
    }
}
