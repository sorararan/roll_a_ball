using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    public float speed;
    private Rigidbody rb;
    public float span;
    private float currentTime;
    private float currentMoveHorizontal;
    private float currentMoveVertical;

    void Start() {
        currentTime = span;
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate () {
        currentTime += Time.deltaTime;
        if(currentTime > span){
            currentMoveHorizontal = Random.Range(-1.0f, 1.0f);
            currentMoveVertical = Random.Range(-1.0f, 1.0f);
            currentTime = 0f;
        }

        var movement = new Vector3(currentMoveHorizontal, 0, currentMoveVertical);
        rb.AddForce(movement * speed);
    }

    void OnCollisionEnter(Collision col) {
        if (col.gameObject.name == "Player") {
            col.gameObject.GetComponent<PlayerController>().DecreaseScore();
        }
    }
}
