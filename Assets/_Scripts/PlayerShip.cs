using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerShip : MonoBehaviour {

	public int health;					//Health of the player


	public AudioSource hitSound;		//sound when the player gets hit
	public Rigidbody2D rocket;			//Prefab of the rocket fired from the ship
	public float shotSpeed;				//Speed at which the rocket travels when it is fired from the ship
	public float speed;					//Speed at which the ship will travel through space
	public Animator anim;				//The animator for the ship

	private SpriteRenderer healthBar;	//The health bar above the player model
	private Vector3 healthScale;		//The scale of the health bar to make it small



	// Use this for initialization
	void Start () {
		health = 100;
		shotSpeed = 150f;
		speed = 20;
		anim = GetComponent<Animator>();
		healthBar = GameObject.Find("HealthBar").GetComponent<SpriteRenderer>();

		healthScale = healthBar.transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {

		SetBoundaries();

		//shoot a rockt if the player left clicks
		if(Input.GetButtonDown("Fire1"))
		{
			Rigidbody2D instance = Instantiate(rocket, transform.position, transform.rotation) as Rigidbody2D;
			instance.velocity = new Vector2(shotSpeed, 0);
		}

		//Get the direction of x and y travel
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");

		//move the player in the direction they traveled according to the speed they can travel
		transform.Translate(Vector3.right*h*speed*Time.deltaTime);
		transform.Translate(Vector3.up*v*speed*Time.deltaTime);
		
	}

	public IEnumerator HitPlayer()
	{
		//give 5 hits until death
		health -= 20;
		hitSound.Play();

		if(health == 0)
		{
			EndGame();
		}

		// Set the health bar's colour to proportion of the way between green and red based on the player's health.
		healthBar.material.color = Color.Lerp(Color.green, Color.red, 1 - health * 0.01f);

		// Set the scale of the health bar to be proportional to the player's health.
		healthBar.transform.localScale = new Vector3(healthScale.x * health * 0.01f, 1, 1);

		//Play the hit animation
		anim.Play("HitAnimation");

		yield return new WaitForEndOfFrame();
		yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);
	}

	private void EndGame()
	{
		//load the first level
		SceneManager.LoadScene(4);
	}

	private void SetBoundaries()
	{
		//Clamp in the x direction
		if(transform.position.x <= -78)
		{
			transform.position = new Vector2(-78, transform.position.y);
		}
		else if(transform.position.x >= 78)
		{
			transform.position = new Vector2(78, transform.position.y);
		}

		//Clamp in the y direction
		if(transform.position.y <= -48)
		{
			transform.position = new Vector2(transform.position.x, -48);
		}
		else if(transform.position.y >= 48)
		{
			transform.position = new Vector2(transform.position.x, 48);
		}
	}

}


