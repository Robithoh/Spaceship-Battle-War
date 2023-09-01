using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    float moveSpeed = 3;
    bool moveUp;
    bool moveDown;
    bool moveLeft;
    bool moveRight;
    bool boostUp;

    public AudioSource BoosterSound;
    public AudioClip Booster;
    public GameObject BoosterAnim;
    public GameObject WindAnim;
    public static SoundManager Instance;
    // Start is called before the first frame update
    void Start()
    {
        BoosterAnim.active = false;
        WindAnim.active = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Timer.gameEnding) return;
        if (Pause.paused) return;
        moveUp = Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W);
        moveDown = Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S);
        moveLeft = Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A);
        moveRight = Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D);
        boostUp = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);

        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
                BoosterSound.PlayOneShot(Booster);
            BoosterAnim.active = true;
            WindAnim.active = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift))
        {
            BoosterAnim.active = false;
            WindAnim.active = false;
        }
    }
    private void FixedUpdate()
    {
        Vector2 pos = transform.position;

        float moveAmount = moveSpeed * Time.fixedDeltaTime;
        if (boostUp)
        {
            moveAmount *= 4;
        }
        Vector2 move = Vector2.zero;

        if (moveUp)
        {
            move.y += moveAmount;
        }
        if (moveDown)
        {
            move.y -= moveAmount;
        }
        if (moveLeft)
        {
            move.x -= moveAmount;
        }
        if (moveRight)
        {
            move.x += moveAmount;
        }

        float moveMagnitude = Mathf.Sqrt(move.x * move.x + move.y * move.y);
        if (moveMagnitude > moveAmount)
        {
            float ratio = moveAmount / moveMagnitude;
            move *= ratio;
        }

        pos += move;

        if (pos.x <= -8.5f)
        {
            pos.x = -8.5f;
        }
        if (pos.x >= 8.5f)
        {
            pos.x = 8.5f;
        }
        if (pos.y <= -4.7f)
        {
            pos.y = -4.7f;
        }
        if (pos.y >= 4.7f)
        {
            pos.y = 4.7f;
        }

        transform.position = pos;
    }
    public void IncreaseSpeed()
    {
        moveSpeed *= 2;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PowerUp powerUp = collision.GetComponent<PowerUp>();
        if (powerUp)
        {

            if (powerUp.increaseSpeed)
            {
                IncreaseSpeed();
            }
            Destroy(powerUp.gameObject);
        }
    }
}
