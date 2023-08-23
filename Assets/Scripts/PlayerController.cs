using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject gameOverText;
    public GameObject restartButton;

    public float speed = 5.0f;

    public Rigidbody2D playerRb;
    public Camera cam;

    Vector2 movement;
    Vector2 mousePos;

    // Start is called before the first frame update
    void Start()
    {
        gameOverText.SetActive(false);
        restartButton.SetActive(false);

        playerRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Converting mouse position from pixel cordinates to world units
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

    }

    private void FixedUpdate()
    {
        MoverPlayer();
        FollowMouse();
    }

    //Player movement method
    void MoverPlayer()
    {
        playerRb.MovePosition(playerRb.position + movement * speed * Time.deltaTime);
    }

    // Method to make player follow the mouse
    void FollowMouse()
    {
        Vector2 lookDir = mousePos - playerRb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        playerRb.rotation = angle;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy")){
            gameOverText.SetActive(true);
            restartButton.SetActive(true);
            Destroy(gameObject);
        }
    }
}
