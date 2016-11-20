namespace PofyTools.TomHax
{
	using UnityEngine;
	using System.Collections;
	using Pool;

	public class Obstacle : GameActor/*, ITransformable, ITriggerListener, IRenderable, IPoolable<Obstacle>,ICollidable*/
	{
		//public static int Mask;
		//public static int Layer;
		//public static string LayerName;

		//#region ITransformable implementation

		//protected Transform _selfTransform;

		//public Transform selfTransform {
		//	get {
		//		return this._selfTransform;
		//	}
		//}

		//#endregion

		//#region IRenderable implementation

		//private Transform _visual;

		//private MeshRenderer _selfRenderer;

		//public MeshRenderer selfRenderer {
		//	get {
		//		return this._selfRenderer;
		//	}
		//}

		//#endregion

		//#region ICollidable implementation

		//private Rigidbody _selfRigidbody;

		//public Rigidbody selfRigidbody {
		//	get {
		//		return this._selfRigidbody;
		//	}
		//}

		//private Collider _selfColider;

		//public Collider selfCollider {
		//	get {
		//		return this._selfColider;
		//	}
		//}

		//#endregion

		//#region ITriggerListener implementation

		//void OnTriggerEnter (Collider other)
		//{
		//	TriggerDetected (null, other);
		//}

		//void OnTriggerStay (Collider other)
		//{
		//	TriggerStay (null, other);
		//}

		//void OnTriggerExit (Collider other)
		//{
		//	TriggerEnded (null, other);
		//}

		//public void TriggerDetected (TriggerDetector detector, Collider other)
		//{
		//	if (other.gameObject.layer == LayerMask.NameToLayer ("Projectile")) {
		//		Projectile projectile = other.GetComponent<Projectile> ();
		//		TakeDamage (projectile.damage);
		//		projectile.Hit (this);
		//	} else if (other.gameObject.layer == LayerMask.NameToLayer ("Player")) {
		//		//FIXME: Should avoid coupling
		//		PlayerController.Player.TakeDamage (this._currentImpactDamage);
		//		Die ();
		//	}
		//}

		//public void TakeDamage (int damage)
		//{
		//	EnterHighlightState ();	
		//	this.currentHealth -= damage;
		//}

		//public void Kill ()
		//{
		//	EventManager.Events.addScore (this.scoreValue);
		//	GamePopup newPopup = ResourceManager.Resources.gamePopups.Obtain ();
		//	newPopup.selfTransform.position = this._selfTransform.position;
		//	newPopup.ResetFromPool ();
		//	newPopup.SetText (ResourceManager.FormatLong ((long)this.scoreValue));
		//	Die ();
		//	EventManager.Events.enemyKilled ();
		//}

		//protected virtual void Die ()
		//{
		//	ParticleSystem explosion = ResourceManager.SpawnEffect (this.explosionEffect);
		//	explosion.transform.position = this._selfTransform.position;
		//	explosion.Play ();
		//	if (!string.IsNullOrEmpty (this.deathSound))
		//		SoundManager.PlayVariation (clip: this.deathSound, lowPriority: true);
		//	Free ();
		//}

		//public string explosionEffect;



		//public void TriggerStay (TriggerDetector detector, Collider other)
		//{
		//	//
		//}

		//public void TriggerEnded (TriggerDetector detector, Collider other)
		//{
		//	//
		//}

		//#endregion

		//private Pool<Obstacle> _pool;

		//public void Free ()
		//{
		//	EventManager.Events.obstacleDestroyed (this);
		//	this.RemoveAllStates ();
		//	this._pool.Free (this);
		//}

		//public void ResetFromPool ()
		//{
		//	this._currentHealth = this.health;
		//	this._currentImpactDamage = this.impactDamage;
		//	this._currentSpeed = this.speed;

		//	this.gameObject.SetActive (true);
		//	this._selfRenderer.sharedMaterial = this._tempMaterial;

		//	this.direction = (PlayerController.Player.selfTransform.position - this._selfTransform.position).normalized;
		//}

		//public Pool<Obstacle> pool {
		//	get {
		//		return this._pool;
		//	}
		//	set {
		//		this._pool = value;
		//	}
		//}

		//public string id {
		//	get {
		//		return this.name;
		//	}
		//}

		//#region Highlight

		//public float highlightDuration = 0.1f;
		//private float _highlightTimer = 0;
		//private Material _tempMaterial;

		//void EnterHighlightState ()
		//{
		//	//ExitHighlightState ();

		//	this._highlightTimer = this.highlightDuration;

		//	this._selfRenderer.sharedMaterial = ResourceManager.Resources.highlightMaterial;

		//	AddState (this.Highlight);
		//}

		//void Highlight ()
		//{
		//	this._highlightTimer -= Time.deltaTime;
		//	if (this._highlightTimer < 0) {
		//		this._highlightTimer = 0;
		//		ExitHighlightState ();
		//	}
			
		//}

		//void ExitHighlightState ()
		//{
		//	this._selfRenderer.sharedMaterial = this._tempMaterial;
		//	RemoveState (this.Highlight);
		//}


		//#endregion

		//#region description / runtime

		//public int health = 100;
		//public float speed = 1;
		//public int impactDamage = 10;
		//public string deathSound;

		//public bool isHoming = false;


		//private int _currentHealth = 100;

		//public int currentHealth {
		//	get{ return this._currentHealth; }
		//	set {
		//		if (value != this._currentHealth) {
		//			this._currentHealth = value;
		//			if (this._currentHealth <= 0) {
		//				this._currentHealth = 0;
		//				this.Kill ();
		//			}
		//		}
		//	}
		//}

		//public float _currentSpeed = 1;
		//public int _currentImpactDamage = 10;
		//public Vector3 direction;

		//#endregion

		//public int scoreValue {
		//	get {
		//		int value = Mathf.CeilToInt ((this.health + this.impactDamage) * Mathf.RoundToInt (this.speed) / 100);
		//		//Debug.Log ("Value is: " + value);
		//		return value; 
		//	} 
		//}

		//public void Translate ()
		//{
		//	Vector3 finalDirection = this.direction;
		//	if (this.isHoming)
		//		finalDirection = (PlayerController.Player.selfTransform.position - this._selfTransform.position).normalized;

		//	this._selfTransform.Translate (finalDirection * this._currentSpeed * Time.smoothDeltaTime);
		//}

		//#region Mono

		//void Awake ()
		//{
		//	this._selfTransform = this.transform;
		//	this._visual = this._selfTransform.GetChild (0);
		//	this._selfRenderer = this._visual.GetComponent<MeshRenderer> ();
		//	this._selfColider = this._visual.GetComponent<Collider> ();
		//	this._selfRigidbody = GetComponent<Rigidbody> ();

		//	this._tempMaterial = this._selfRenderer.sharedMaterial;
		//}

		//#endregion
		
	}
}