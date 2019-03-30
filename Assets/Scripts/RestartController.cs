using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartController : MonoBehaviour {
    public float floor = -8;
    public int waitTime = 1;

    void Update () {
        if (transform.position.y < floor) {
            StartCoroutine(restart(waitTime));
        }
    }

    IEnumerator restart(int n) {
        yield return new WaitForSeconds(n);
        SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }
}
