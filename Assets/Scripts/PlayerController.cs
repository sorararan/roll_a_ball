using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    public float speed;
    public Text scoreText;
    public Text winText;

    private Rigidbody rb;
    private int score;
    private int got_pick_ups;
    private bool is_game_finised;

    void Start() {
        is_game_finised = false;
        rb = GetComponent<Rigidbody>();

        score = 0;
        SetCountText();
        winText.text = "";
    }

    void Update() {
        if (!is_game_finised) {
            var moveHorizontal = Input.GetAxis("Horizontal");
            var moveVertical = Input.GetAxis("Vertical");

            var movement = new Vector3(moveHorizontal, 0, moveVertical);

            rb.AddForce(movement * speed);

            if (got_pick_ups >= 12) {
                is_game_finised = true;
                if (score >= 0) {
                    winText.text = "お前の勝ち！";
                } else {
                    winText.text = "お前の負け！ｗｗｗｗｗ";
                }
            }
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("PickUp")) {
            other.gameObject.SetActive(false);

            score++;
            got_pick_ups++;

            SetCountText ();
        }
    }

    private void SetCountText() {
        scoreText.text = "Count: " + score.ToString();
    }

    public void DecreaseScore() {
        this.score--;
        SetCountText ();
    }
}
