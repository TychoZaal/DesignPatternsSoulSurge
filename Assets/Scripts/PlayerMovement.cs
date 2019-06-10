using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject player;

	public float speed = 2f;

	public Transform swordRotation;

	public Sprite spriteRight;
	public Sprite spriteLeft;
	public Sprite spriteUp;
	public Sprite spriteDown;

	public float knockBack = 1f;

	Vector2 movement;

    Rigidbody2D rb;
	SpriteRenderer sr;

    //state data to safe to memento
    private Vector2 playerPos;


    // Start is called before the first frame update
    void Start()
    {
		rb = GetComponent<Rigidbody2D>();
		sr = GetComponent<SpriteRenderer>();

        this.playerPos = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        this.playerPos = player.transform.position;

        movement.x = Input.GetAxisRaw("Horizontal");
		movement.y = Input.GetAxisRaw("Vertical");
    }

	private void FixedUpdate()
	{
		rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);

		if (movement.x > 0.01f)
		{
			swordRotation.eulerAngles = new Vector3(0f, 0f, 270f);
			sr.sprite = spriteRight;
		} else if (movement.x < -0.01f)
		{
			swordRotation.eulerAngles = new Vector3(0f, 0f, 90f);
			sr.sprite = spriteLeft;
		} else if (movement.y > 0.01f)
		{
			swordRotation.eulerAngles = new Vector3(0f, 0f, 0f);
			sr.sprite = spriteUp;
		} else if (movement.y < -0.01f)
		{
			swordRotation.eulerAngles = new Vector3(0f, 0f, 180f);
			sr.sprite = spriteDown;
		}
	}

    public void SetPosition(Vector2 newPosition)
    {
        player.transform.position = newPosition;
    }

    public PlayerMemento StoreInMemento()
    {
       // Debug.Log("StoreMemento: " + this.playerPos);
        return new PlayerMemento(this.playerPos);
    }

    public Vector2 RestoreFromMemento(PlayerMemento playerMemento)
    {
        this.playerPos = playerMemento.GetSavedPlayerPosition();

        return this.playerPos;
    }

}
