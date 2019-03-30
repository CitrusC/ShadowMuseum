using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRotate : MonoBehaviour {

    public static float torque = 65;

	void Start () {
        Cursor.visible = false;
    }

    void Update () {
		float turnHorizontal = Input.GetAxis ("Mouse Y");
		Vector3 turn = new Vector3 (0.0f, turnHorizontal, 0.0f);
        transform.Rotate(turn* torque * Time.deltaTime);
    }
}


