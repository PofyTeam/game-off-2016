namespace PofyTools.TomHax
{
    using UnityEngine;
    using System.Collections;
    using PofyTools;

    public class EventManager : MonoBehaviour
    {
        public static EventManager Events;

        public IntDelegate addScore;
        public LongDelegate xpChanged, levelChanged;
        public UpdateDelegate killAllRequest, sniperBlastRequest, superTorqueRequest, superTorqueDone;
        public RangeDelegate healthChanged;
        //public GameStateDelegate gameStateChanged, requestGameState;

        public UpdateDelegate gameReset;
        public UpdateDelegate reward;

        public StringDelegate requestShare;
        public UpdateDelegate shareDone;

        public OffRangeDelegate angularSpeedChanged;

        public ObstacleDelegate obstacleDestroyed;

        public UpdateDelegate shotFired;
        public UpdateDelegate enemyKilled;

        public RangeDelegate chargeChanged;

        void Awake()
        {
            Events = this;

            this.addScore = this.IntIdle;
            this.xpChanged = this.LongIdle;
            this.levelChanged = this.LongIdle;

            this.killAllRequest = this.VoidIdle;
            this.sniperBlastRequest = this.VoidIdle;
            this.superTorqueRequest = this.VoidIdle;
            this.superTorqueDone = this.VoidIdle;

            this.healthChanged = this.RangeIdle;
            //this.gameStateChanged = this.GameStateIdle;
            //this.requestGameState = this.GameStateIdle;

            this.gameReset = this.VoidIdle;
            this.reward = this.VoidIdle;

            this.requestShare = this.StringIdle;
            this.shareDone = this.VoidIdle;

            this.angularSpeedChanged = this.OffRangeIdle;

            this.obstacleDestroyed = this.ObstacleIdle;

            this.shotFired = this.VoidIdle;
            this.enemyKilled = this.VoidIdle;

            this.chargeChanged = this.RangeIdle;
        }

        public void VoidIdle()
        {

        }

        public void ObstacleIdle(Obstacle obstacle)
        {
        }

        public void ProjectileIdle(Projectile projectile)
        {
        }

        public void IntIdle(int value)
        {
        }

        public void LongIdle(long value)
        {
        }

        void FloatIdle(float value)
        {
        }

        void ColliderIdle(Collider collider)
        {
        }

        public void BoolIdle(bool value)
        {
        }

        public void StringIdle(string value)
        {

        }

        public void IntRatioIdle(int value, int max)
        {
        }

        public void FloatRatioIdle(float value, float max)
        {
        }

        //public void GameStateIdle(GameController.State state)
        //{
        //}

        public void RangeIdle(Range range)
        {
        }

        public void OffRangeIdle(float value, Range rage)
        {
        }

    }

    public delegate void IntDelegate(int value);
    public delegate void LongDelegate(long value);
    public delegate void ObstacleDelegate(Obstacle obstacle);
    public delegate void ProjectileDelegete(Projectile Projectile);
    public delegate void IntRatioDelegate(int value, int max);
    public delegate void FloatRatioDelegate(float value, float max);
    //public delegate void GameStateDelegate(GameController.State state);

    public delegate void FloatDelegate(float value);
    public delegate void StringDelegate(string message);
    public delegate void ColliderDelegate(Collider collider);
    public delegate void RangeDelegate(Range range);
    public delegate void OffRangeDelegate(float value, Range range);
}
