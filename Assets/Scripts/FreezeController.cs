using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FreezeController : MonoBehaviour {
    public Rigidbody rb;

    void Start() {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeAll;
        StartCoroutine(unfreeze(1));

    }

    IEnumerator unfreeze(int n) {
        yield return new WaitForSeconds(n);
        rb.constraints = RigidbodyConstraints.None;
    }
}
