using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    public float speed;
    [SerializeField] private int id;
    private Rigidbody rb;

    void OnCollisionEnter(Collision col) {
        if (col.gameObject.name == "Player") {
            col.gameObject.GetComponent<PlayerController>().DecreaseScore();
        }
    }
}
