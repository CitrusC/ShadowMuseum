using UnityEngine;

public class SceneController : MonoBehaviour {
    public float triggerSpeed = 6.5f;
    public float triggerLongth = 150;

    public static int currentObject = -1;

    private int i;
    private float longth = 0;

    public GameObject boat;
    public GameObject statueOfLiberty;
    public GameObject poetschePhotoskulturGoethe;
    public GameObject cube;
    public GameObject chess;
    public GameObject poker;

    public GameObject menu;
    public GameObject UI;

    int mod(int a, int b) {
        int r = a % b;
        return r < 0 ? r + b : r;
    }

    void Start () {
        if (currentObject == -1) {
            currentObject = 0;
            enableObject(0);
        }
        else {
            enableObject(currentObject);
        }
    }

    void Update() {
		if (Input.GetAxis("Mouse Y") > triggerSpeed) {
            longth += Input.GetAxis("Mouse Y");
            if (longth > triggerLongth) {
                longth = 0;
                changeObject(-1);
                Debug.Log(">");
            }
        }
        if (Input.GetAxis("Mouse Y") < -triggerSpeed) {
            longth += Input.GetAxis("Mouse Y");
            if (longth < -triggerLongth) {
                longth = 0;
                changeObject(1);
                Debug.Log("<");
            }
        }
        if (Input.GetKeyDown(KeyCode.A)) {
            changeObject(-1);
        }
        if (Input.GetKeyDown(KeyCode.D)) {
            changeObject(1);
        }

        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (menu.active) {
                menu.active = false;
                Cursor.visible = false;
            }
            else {
                menu.active = true;
                Cursor.visible = true;
            }
        }
    }

    public void disableObject(int i) {
        switch (i) {
            case 0:
                boat.active = false;
                break;
            case 1:
                statueOfLiberty.active = false;
                break;
            case 2:
                poetschePhotoskulturGoethe.active = false;
                UI.active = false;
                break;
            case 3:
                cube.active = false;
                UI.active = false;
                break;
            case 4:
                chess.active = false;
                UI.active = false;
                break;
            case 5:
                poker.active = false;
                UI.active = false;
                break;
        }
    }

    public void enableObject(int i) {
        switch (i) {
            case 0:
                boat.active = true;
                break;
            case 1:
                statueOfLiberty.active = true;
                break;
            case 2:
                poetschePhotoskulturGoethe.active = true;
                UI.active = true;
                break;
            case 3:
                cube.active = true;
                UI.active = true;
                break;
            case 4:
                chess.active = true;
                UI.active = true;
                break;
            case 5:
                poker.active = true;
                UI.active = true;
                break;
        }
    }

    public void changeObject(int i) {
        disableObject(currentObject);
        currentObject = mod(currentObject + i, 6);
        enableObject(currentObject);
    }
}
  