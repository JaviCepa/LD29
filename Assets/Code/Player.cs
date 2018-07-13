using UnityEngine;
using System.Collections;

public class Player : SuperMono {
	public int health=5;
	public Sprite walk1, walk2;
	public Sprite hand1, hand2;
	public Sprite scis1, scis2;
	SpriteRenderer handSprite;
	SpriteRenderer scisSprite;
	public GameObject hand, scis;
	public GameObject leafParticles;
	bool alive=true;

	bool walking=false;
	bool vulnerable=true;
	float vulnerableTimer=0;

	Vector3 position;

	void Awake() {
		player = this;
		leafParticle = leafParticles;
		position = transform.position;
	}

	new public void Start () {
		base.Start ();
		handSprite = hand.GetComponent<SpriteRenderer> ();
		scisSprite = scis.GetComponent<SpriteRenderer> ();
		GetComponent<Collider2D>().enabled = true;
		alive = true;
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit();
		}
		if (alive) {
		hand.GetComponent<Renderer>().enabled=spriteRenderer.enabled;
		vulnerableTimer -= Time.deltaTime;
		if (vulnerableTimer <= 0) {
			vulnerable=true;
		}
		if (!vulnerable) {
			spriteRenderer.enabled=Mathf.Floor(Time.time*16)%2==0;
		} else {
			spriteRenderer.enabled=true;
		}
		walking = false;
		if (Input.GetKey(KeyCode.RightArrow)) {
			if (transform.position.x<9) {
				position+=1/8f*Vector3.right;
				walking=true;
				transform.localScale=new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
			}
		}
		if (Input.GetKey(KeyCode.LeftArrow)) {
			if (transform.position.x>-9) {
				position-=1/8f*Vector3.right;
				walking=true;
                    transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
                }
		}
			
		transform.position=position;

		if (Input.GetKeyDown(KeyCode.X)) {
			if (state!=GameStates.win) {
				soundManager.Play("Cut");
			} else {
				if (Random.value>0.5f) {
					soundManager.Play("Clap");
				} else if (Random.value>0.5f) {
					soundManager.Play("Clap1");
				} else {
					soundManager.Play("Clap2");
				}
			}
			Collider2D hit=Physics2D.OverlapCircle(transform.position+Vector3.right*Mathf.Sign(transform.localScale.x), 0.3f);
			if (hit!=null) {
				hit.gameObject.SendMessage("Damage", SendMessageOptions.DontRequireReceiver);
				int particleCount=Random.Range(1,3);
				
				for (int i = 0; i < particleCount; i++) {
					Instantiate(leafParticles, transform.position+Vector3.right* Mathf.Sign(transform.localScale.x) * (1.25f+Random.Range(-0.25f,0.25f))-Vector3.up*0.2f+Vector3.forward*15, Quaternion.identity);
				}
				soundManager.Play("CutHit");
			}
			if (state==GameStates.ready) {
				state=GameStates.playing;
				soundManager.Play("StartGame");
				soundManager.Invoke("PlayMainTheme", 3);
			}
		}
		if (Input.GetKey (KeyCode.X)) {
			handSprite.sprite=hand2;
			scisSprite.sprite=scis2;
		} else {
			handSprite.sprite=hand1;
			scisSprite.sprite=scis1;
		}
		if (walking) {
			if (Mathf.Floor(Time.time*10)%2==0) {
				spriteRenderer.sprite=walk1;
			} else {
				spriteRenderer.sprite=walk2;
			}
		} else {
			spriteRenderer.sprite=walk1;
		}

		if (health<=0) {
			Die();
		}
		} else {
			if (Input.anyKeyDown) {
				Application.LoadLevel(0);
				state=GameStates.ready;
			}
		}
	}

	void Damage(int amount) {
		if (vulnerable) {
			soundManager.Play ("Hurt");
			health-=amount;
			vulnerable=false;
			vulnerableTimer=2;
		}
	}

	void Die() {
		if (alive) {
			soundManager.Play("GameOver");
		}

		foreach (var item in transform.GetComponentsInChildren<SpriteRenderer>()) {
			item.enabled=false;
		}
		foreach (var item in transform.GetComponentsInChildren<Collider2D>()) {
			item.enabled=false;
		}
		alive = false;
		
		if (state == GameStates.playing) {
			state=GameStates.gameover;
		}
	}
}
