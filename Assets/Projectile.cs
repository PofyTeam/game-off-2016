namespace PofyTools.TomHax
{
	using UnityEngine;
	using System.Collections;
	using Pool;

	public class Projectile : MonoBehaviour,ICollidable, IPoolable<Projectile>
	{
		#region IPoolable implementation

		protected Pool<Projectile> _pool;
		protected TrailRenderer _trail;
		protected Component _halo;

		public virtual void Free ()
		{
//			Debug.Log ("Freed");
			this._wasVisible = false;
			this.pool.Free (this);
			if (this._halo != null)
				this._halo.GetType ().GetProperty ("enabled").SetValue (this._halo, false, null);
		}

		public virtual void ResetFromPool ()
		{
			if (this._trail != null)
				this._trail.Clear ();
			if (this._halo != null) {
				this._halo.GetType ().GetProperty ("enabled").SetValue (this._halo, true, null);
			}
			this.gameObject.SetActive (true);
		}

		public Pool<Projectile> pool {
			get {
				return this._pool;
			}set {
				this._pool = value;
			}
		}

		#endregion

		#region ITransformable implementation

		protected Transform _selfTransform;

		public Transform selfTransform {
			get {
				return this._selfTransform;
			}
		}

		#endregion

		#region IIdentifiable implementation

		public string id {
			get {
				return this.name;
			}
		}

		#endregion

		#region ICollidable implementation

		protected Rigidbody _selfRigidbody;

		public Rigidbody selfRigidbody {
			get {
				return this._selfRigidbody;
			}
		}

		protected Collider _selfCollider;

		public Collider selfCollider {
			get {
				return this._selfCollider;
			}
		}

		#endregion

		public int damage;
		public Vector3 direction;
		public float speed = 100;

		void Awake ()
		{
			this._selfTransform = this.transform;
			this._selfRigidbody = GetComponent<Rigidbody> ();
			this._selfCollider = GetComponent<Collider> ();
			this._trail = GetComponent<TrailRenderer> ();
			this._halo = GetComponent ("Halo");
		}

		protected bool _wasVisible;

		protected void OnBecameInvisible ()
		{
//			Debug.Log ("Try on invisible...");
			if (this._wasVisible) {
				Free ();
			}
		}

		protected void OnBecameVisible ()
		{
//			Debug.Log ("Became visible.");
			this._wasVisible = true;
		}

		public virtual void Translate ()
		{
			this._selfTransform.Translate (this.direction * this.speed * Time.smoothDeltaTime);
		}

		public virtual void Hit (Obstacle obstacle)
		{
			Free ();
		}

		public virtual void OnFire ()
		{
			//
		}

	}
}