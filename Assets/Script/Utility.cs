using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utility : MonoBehaviour {
    
    public static float AngleTowardsMouse(Vector3 pos) {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 5.23f;

        Vector3 objectPos = Camera.main.WorldToScreenPoint(pos);
        mousePosition.x = mousePosition.x - objectPos.x;
        mousePosition.y = mousePosition.y - objectPos.y;

        float angle = Mathf.Atan2(mousePosition.y, mousePosition.x) * Mathf.Rad2Deg;

        return angle;
    }
}
