using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class Boss : MonoBehaviour {

	public int maxHealth;			//The maximum amount of health for the boss
	private int health;				//Amount of health the boss has
	public Animator anim;			//The animator connected to the boss object

	public float shotSpeed;			//The speed at which the bullet travels
	public AudioSource shotSound;	//The sound when they boss fires a shot
	public Image healthBar;			//The health bar for the boss enemy

	public Rigidbody2D bullet;		//The projetile that the boss uses to attack the ship
	public float shotTimer;			//The timers to see how many times the boss can attack in a second

	private bool crossShot;			//If the next shot from the boss is a cross shot then the bool is true
	private bool up;				//If the boss is traveling up then true
	public float moveSpeed;			//How fast the boss is moving


	// Use this for initialization
	void Start () {

		//Initialize all components for the boss object
		up = false;
		moveSpeed = 20f;
		shotTimer = 0.0f;
		shotSpeed = 80;
		maxHealth = 75;
		health = maxHealth;
		anim = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {
		healthBar.fillAmount = (float)health/maxHealth;

		//Start the timer for when the boss can shoot
		shotTimer += Time.deltaTime;

		//if the timer is ready to fire
		if(shotTimer >= 1.5)
		{
			//FIRE!!!
			StartCoroutine("fireWeapon");
			shotTimer = 0.0f;
		}

		if(transform.position.y <= -26)
		{
			up = true;
		}

		if(transform.position.y >= 26)
		{
			up = false;
		}

		if(up)
		{
			transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
		}
		else
		{
			transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
		}

	
	}

	private void ShootShots()
	{
		shotSound.Play();

		if(!crossShot)
		{
			//Create the bullet for the UFO to shoot
			Rigidbody2D instance1 = Instantiate(bullet, transform.position, transform.rotation) as Rigidbody2D;
			Rigidbody2D instance2 = Instantiate(bullet, new Vector3(transform.position.x, transform.position.y+10, transform.position.z), transform.rotation) as Rigidbody2D;
			Rigidbody2D instance3 = Instantiate(bullet, new Vector3(transform.position.x, transform.position.y-10, transform.position.z), transform.rotation) as Rigidbody2D;

			//Give it some velocity
			instance1.velocity = new Vector2(-shotSpeed, 0);
			instance2.velocity = new Vector2(-shotSpeed, 0);
			instance3.velocity = new Vector2(-shotSpeed, 0);
			crossShot = !crossShot;

		}
		else
		{
			//Create the bullet for the UFO to shoot
			Rigidbody2D instance1 = Instantiate(bullet, transform.position, transform.rotation) as Rigidbody2D;
			Rigidbody2D instance2 = Instantiate(bullet, new Vector3(transform.position.x, transform.position.y+10, transform.position.z), transform.rotation) as Rigidbody2D;
			Rigidbody2D instance3 = Instantiate(bullet, new Vector3(transform.position.x, transform.position.y-10, transform.position.z), transform.rotation) as Rigidbody2D;

			//Give it some velocity
			instance1.velocity = new Vector2(-shotSpeed, 0);
			instance2.velocity = new Vector2(-shotSpeed, shotSpeed/4);
			instance3.velocity = new Vector2(-shotSpeed, -shotSpeed/4);
			crossShot = !crossShot;
		}

	}

	public IEnumerator fireWeapon()
	{
		//Start the shooting animation
		anim.Play("BossFireShot");

		//wait until the animation has started then wait for the animation to finish
		yield return new WaitForEndOfFrame();
		print(anim.GetCurrentAnimatorStateInfo(0).length);
		yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);

		//Actually shoot the shot
		ShootShots();

	}

	public IEnumerator takeDamage()
	{
		if(health > 0)
		{
			health--;
			anim.Play("BossHit");
			yield return new WaitForEndOfFrame();
			yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);
		}

		else
		{
			Destroy(gameObject);
			SceneManager.LoadScene("Level");
		}
	}
}
