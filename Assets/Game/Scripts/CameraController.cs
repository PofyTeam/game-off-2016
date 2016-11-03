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

        #region Mono
        void Awake ()
		{
            this._selfTransform = this.transform;
		}

		protected override void Start ()
		{
			base.Start ();
			this.follow = true;
		}
        #endregion Mono

        #region Follow

        [Header("Follow State")]
        public float followSpeed = 1;
        public Vector3 followOffset;
        private bool _follow = false;

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
			AddState (this.Follow);
		}

		void Follow ()
		{
            Vector3 newPosition = Vector3.MoveTowards(this._selfTransform.position, this.target.position + this.followOffset, this.followSpeed * Time.smoothDeltaTime);
            newPosition[2] = this._selfTransform.position[2];
            this._selfTransform.position = newPosition;
		}

		void ExitFollowState ()
		{
			RemoveState (this.Follow);
		}

		#endregion
	}
	
	

}