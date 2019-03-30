using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartController_chess : MonoBehaviour {
    public int waitTime = 1;
    private int count;
    void Start() {
        count = 0;
    }

    void Update () {
        if (count >= 7) {
            StartCoroutine(restart(waitTime));
        }
    }

    IEnumerator restart(int n) {
        yield return new WaitForSeconds(n);
        SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("chess")) {
            other.gameObject.SetActive(false);
            count += 1;
            Debug.Log(count);
        }   
    }
}
