namespace PofyTools.TomHax
{
	using UnityEngine;
	using System.Collections.Generic;

	public class CameraController : GameActor,ITransformable
	{
        public const string TAG = "<color=blue><b>CameraController</b></color>: ";
        #region ITransformable implementation

        private Transform _selfTransform;

        public Transform selfTransform
        {
            get
            {
                return this._selfTransform;
            }
        }

        #endregion
        public Transform target;
        private Rigidbody2D _targetRB;

        public SpriteRenderer sky, far;

        #region Mono
        void Awake ()
		{
            this._selfTransform = this.transform;
		}

		protected override void Start ()
		{
			base.Start ();
			this.follow = true;
            AddState(this.UpdateBackground);
		}

        void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireCube(this.followBounds.center,this.followBounds.extents*2);
        }

        #endregion Mono

        #region Follow

        [Header("Follow State")]
        public float followSpeed = 1;
        public Vector3 followOffset;
        private bool _follow = false;
        public Bounds followBounds;
        public bool follow
        {
            get { return this._follow; }
            set
            {
                if (value != this._follow)
                {
                    if (value)
                        EnterFollowState();
                    else
                        ExitFollowState();

                    this._follow = value;
                }
            }
        }

		void EnterFollowState ()
		{
            Debug.Log(TAG + "Start Following");
            if (this._targetRB == null)
                this._targetRB = this.target.GetComponentInParent<Rigidbody2D>();
            if (this._targetRB != null)
            {
                AddState(FollowRB);
                return;
            }

            AddState (this.Follow);
		}

		void Follow ()
		{
            Vector3 newPosition = Vector3.MoveTowards(this._selfTransform.position, this.target.position + this.followOffset, this.followSpeed * Time.smoothDeltaTime);
            newPosition[2] = this._selfTransform.position[2];
            this._selfTransform.position = newPosition;
            if (!this.followBounds.Contains(this.transform.position)){
                ExitFollowState();
            }
		}

        void FollowRB()
        {
           // float _speed = Mathf.Max(this.followSpeed,Mathf.Min (this._targetRB.velocity.sqrMagnitude * 0.01f,1000f));

            float _speed = Mathf.Clamp(this._targetRB.velocity.sqrMagnitude * 0.01f, this.followSpeed, 1000f);
            Vector3 newPosition = this._selfTransform.position;
            newPosition[0] = Mathf.MoveTowards(newPosition[0],this.target.position[0],this.followSpeed*Time.smoothDeltaTime);
            newPosition[1] = Mathf.MoveTowards(newPosition[1], this.target.position[1], _speed * Time.smoothDeltaTime);

            //Vector3 newPosition = Vector3.MoveTowards(this._selfTransform.position, this.target.position + this.followOffset, _speed * Time.smoothDeltaTime);
            //newPosition[2] = this._selfTransform.position[2];
            this._selfTransform.position = newPosition;
            
            if (!this.followBounds.Contains(this.transform.position)){
                ExitFollowState();
            }
        }

        void UpdateBackground()
        {
            Vector3 newPosition = this.transform.position;
            this.far.transform.localPosition = newPosition * -0.2f;
        }

		void ExitFollowState ()
		{
			RemoveState (this.Follow);
		}

		#endregion

	}

    [System.Serializable]
    public class BackgroundSet
    {
        public Sprite sky, far, near;
    }
	
	

}