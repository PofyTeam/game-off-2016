namespace PofyTools.TomHax
{
    using System.Collections.Generic;
    using PofyTools;
    using UnityEngine;
    using UnityEngine.Analytics;
    using UnityEngine.SceneManagement;

    public class GameController : GameActor
    {
        //        #region Singleton

        //        public static GameController Game;

        //        #endregion

        //        #region State

        //        public enum State : int
        //        {
        //            Initialize = 0,
        //            Loading = 1,
        //            Menu = 2,
        //            Playing = 3,
        //            Pause = 4,
        //            Death = 5,
        //            CutScene = 6,
        //        }

        //        private State _state;

        //        public State state
        //        {
        //            get { return this._state; }
        //            set
        //            {
        //                if (value != this._state)
        //                {
        //                    switch (value)
        //                    {
        //                        case State.Initialize:
        //                            Debug.LogError("Game state can not be NONE.");
        //                            break;
        //                        case State.Menu:
        //                            break;
        //                        case State.Play:
        //                            if (this._state == State.Menu)
        //                            {
        //                                //TODO:ReportStart
        //                                AddState(this.CloseIn);
        //                                if (this.availableObstacles.Length != 0)
        //                                    AddState(this.TrySpawn);
        //                            }
        //                            Time.timeScale = 1;
        //                            break;
        //                        case State.Pause:
        //                            Time.timeScale = 0;
        //                            SaveData();
        //                            PlayerPrefs.Save();
        //                            break;
        //                        case State.Death:
        //                            //Debug.LogError ("You Died!");
        //                            SaveData();
        //                            RemoveState(this.TrySpawn);
        //                            RemoveState(this.CloseIn);
        //                            break;
        //                        default:
        //                            Debug.LogError("No such game state.");
        //                            return;
        //                    }
        //                    this._state = value;
        //                    EventManager.Events.gameStateChanged(this._state);
        //                }
        //            }
        //        }

        //        void OnRequestGameState(State requestedState)
        //        {
        //            if (requestedState == State.Menu)
        //            {
        //                PlayerPrefs.Save();
        //                //TODO:ReportBackToMenu (score: this.score, topScore: this.topScore, armor: this.armor, minesHit: this._mines, sessionCount: this._playSessions);
        //                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //                return;
        //            }
        //            this.state = requestedState;
        //        }
        //        #endregion

        //        #region Initialize
        //        bool _isInitialized;
        //        void EnterInitializeState()
        //        {
        //            if (!this._isInitialized)
        //            {
        //                AddState(Initialize);
        //                this._state = State.Initialize;
        //            }
        //        }
        //        private void Initialize()
        //        {
        //            //do stuff
        //            ExitInitializeState();
        //        }

        //        public UpdateDelegate onInitializeDone;
        //        void ExitInitializeState()
        //        {
        //            this._isInitialized = true;
        //            RemoveState(this.Initialize);
        //            if (onInitializeDone != null)
        //                onInitializeDone.Invoke();
        //        }

        //        #endregion

        //        #region Load

        //        bool _isLoading;
        //        void EnterLoadingState()
        //        {
        //            if (!_isLoading)
        //            {
        //                this._isLoading = true;
        //                AddState(StateLoading);
        //                this._state = State.Loading;
        //            }
        //        }

        //        private void StateLoading()
        //        {
        //            //do stuff
        //            ExitLoadingState();
        //        }

        //        public UpdateDelegate onLoadingDone;
        //        void ExitLoadingState()
        //        {
        //            this._isLoading = false;
        //            RemoveState(this.StateLoading);
        //            if (onLoadingDone != null)
        //            {
        //                onLoadingDone.Invoke();
        //            }

        //        }
        //        #endregion

        //        #region Menu

        //        void EnterMenuState()
        //        {
        //            AddState(this.StateMenu);
        //        }

        //        private void StateMenu()
        //        {
        //            //dostuff
        //            //ExitMenuState();
        //        }

        //        public UpdateDelegate onMenuDone;
        //        void ExitMenuState()
        //        {
        //            RemoveState(this.StateMenu);
        //            if (onMenuDone != null)
        //                onMenuDone.Invoke();
        //        }
        //        #endregion

        //        private void StatePlaying()
        //        {

        //        }

        //        private void StatePause()
        //        {

        //        }

        //        private void StateDeath()
        //        {

        //        }

        //        private void StateCutScene()
        //        {

        //        }

        //        #region Slow To Death State

        //        [Header("Slow To Death")]
        //        public float slowDuration = 1f;
        //        private float _slowTimer;
        //        public AnimationCurve slowCurve;

        //        void EnterSlowToDeath()
        //        {
        //            this._slowTimer = this.slowDuration;
        //            AddState(this.SlowToDeath);
        //        }

        //        void SlowToDeath()
        //        {
        //            this._slowTimer -= Time.unscaledDeltaTime;
        //            if (this._slowTimer < 0)
        //                this._slowTimer = 0;

        //            float normalizedTime = 1 - this._slowTimer / this.slowDuration;
        //            float mappedTime = this.slowCurve.Evaluate(normalizedTime);
        //            Time.timeScale = Mathf.Lerp(1, 0, mappedTime);

        //            if (this._slowTimer <= 0)
        //                ExitSlowToDeath();
        //        }

        //        void ExitSlowToDeath()
        //        {
        //            RemoveState(this.SlowToDeath);
        //            this.state = State.Death;
        //        }

        //        #endregion

        //        #region Obstacles

        //        [Header("Obstacles")]
        //        //TODO: read from level descriptor
        //        public string[] availableObstacles;
        //        public ElapsedTimeHandler spawnHandler;
        //        public float obstacleSpawnDistance = 16;

        //        Obstacle SpawnObstacle()
        //        {
        //            string random = this.availableObstacles[Random.Range(0, this.availableObstacles.Length)];
        //            Obstacle newObstacle = ResourceManager.Resources.obstacles.ObtainFromPool(random);
        //            newObstacle.selfTransform.position = (Vector3)Random.insideUnitCircle.normalized * this.obstacleSpawnDistance;
        //            newObstacle.ResetFromPool();

        //            return newObstacle;
        //        }

        //        void TrySpawn()
        //        {
        //            if (this.spawnHandler.TrySet())
        //            {
        //                SpawnObstacle();
        //            }
        //        }

        //        void CloseIn()
        //        {
        //            foreach (var obstaclePool in ResourceManager.Resources.obstacles)
        //            {
        //                for (int i = obstaclePool.Value.Count - 1; i >= 0; --i)
        //                {
        //                    var obstacle = obstaclePool.Value[i];
        //                    obstacle.Translate();
        //                }
        //            }
        //        }

        //        #endregion

        //        #region Mono

        //        void Awake()
        //        {
        //            Game = this;
        //            LoadData();
        //            this.state = State.Menu;
        //        }

        //        protected override void Start()
        //        {
        //            base.Start();
        //            AddState(this.UpdateBackButton);

        //            if (this.shouldForceCollect)
        //            {
        //                AddState(this.ForceCollect);
        //            }
        //        }

        //        public override void Subscribe()
        //        {
        //            base.Subscribe();
        //            EventManager.Events.addScore += this.OnAddScore;
        //            EventManager.Events.killAllRequest += this.KillAll;
        //            EventManager.Events.requestGameState += this.OnRequestGameState;
        //            //TODO:EventManager.Events.requestShare += this.OnShareRequested;
        //            EventManager.Events.shotFired += this.OnShotFired;
        //            EventManager.Events.enemyKilled += this.OnEnemyKilled;
        //        }

        //        public override void Unsubscribe()
        //        {
        //            base.Unsubscribe();
        //            EventManager.Events.addScore -= this.OnAddScore;
        //            EventManager.Events.killAllRequest -= this.KillAll;
        //            EventManager.Events.requestGameState -= this.OnRequestGameState;
        //            //TODO:EventManager.Events.requestShare -= this.OnShareRequested;
        //            EventManager.Events.shotFired -= this.OnShotFired;
        //            EventManager.Events.enemyKilled -= this.OnEnemyKilled;
        //        }

        //        void UpdateBackButton()
        //        {
        //            if (Input.GetKeyDown(KeyCode.Escape))
        //            {
        //                switch (this._state)
        //                {
        //                    case State.None:
        //                        Application.Quit();
        //                        break;
        //                    case State.Menu:
        //                        SaveData();
        //                        PlayerPrefs.Save();
        //                        Application.Quit();
        //                        break;
        //                    case State.Play:
        //                        this.state = State.Pause;
        //                        break;
        //                    case State.Pause:
        //                        OnRequestGameState(State.Menu);
        //                        break;
        //                    case State.Death:
        //                        OnRequestGameState(State.Menu);
        //                        break;
        //                    default:
        //                        Application.Quit();
        //                        break;
        //                }
        //            }
        //        }

        //        protected void OnApplicationFocus(bool focus)
        //        {
        //            if (!focus)
        //            {
        //                SoundManager.PauseAll();
        //                if (this._state == State.Play)
        //                {
        //                    this.state = State.Pause;
        //                }
        //            }
        //            else
        //                SoundManager.ResumeAll();
        //        }

        //        #endregion

        //        #region Game Data

        //        private int _playSessions;
        //        private int _totalShots;
        //        private int _totalKills;

        //        public void ResetGame(bool keepScore = false)
        //        {
        //            if (this.xp != 0)
        //                //TODO:ReportReset (keepScore, this.score, this.topScore);
        //                if (!keepScore)
        //                    this.xp = 0;
        //            //TODO:EventManager.Events.gameReset ();
        //            this.state = State.Play;
        //        }

        //        void LoadData()
        //        {
        //            this._level = (long)PlayerPrefs.GetFloat("level", 0);
        //            this._playSessions = PlayerPrefs.GetInt("sessionCount", 0);
        //            this._totalShots = PlayerPrefs.GetInt("shotCount", 0);
        //            this._totalKills = PlayerPrefs.GetInt("killCount", 0);
        //        }

        //        void SaveData()
        //        {
        //            //Debug.Log ("Saving top score as:" + this.topScore);
        //            PlayerPrefs.SetFloat("level", (float)this.level);
        //            PlayerPrefs.SetInt("sessionCount", this._playSessions);
        //            PlayerPrefs.SetInt("shotCount", this._totalShots);
        //            PlayerPrefs.SetInt("killCount", this._totalKills);
        //        }

        //        void OnShotFired()
        //        {
        //            this._totalShots++;
        //        }

        //        void OnEnemyKilled()
        //        {
        //            this._totalKills++;
        //        }

        //        [Header("Force CG Collect")]
        //        public bool shouldForceCollect = false;
        //        public int gcCollectInterval = 30;

        //        void ForceCollect()
        //        {
        //            if (Time.frameCount % 30 == 0)
        //            {
        //                System.GC.Collect();
        //            }
        //        }

        //        #endregion

        //        #region Score

        //        private long _xp;
        //        private long _nextLevelXpCost;

        //        public long xp
        //        {
        //            get
        //            {
        //                return this._xp;
        //            }
        //            set
        //            {
        //                if (this._xp != value)
        //                {
        //                    this._xp = value;

        //                    if (this._xp >= this._nextLevelXpCost)
        //                    {
        //                        this._xp = this._xp - this._nextLevelXpCost;
        //                        this.level++;
        //                    }

        //                    EventManager.Events.xpChanged(this._xp);
        //                }
        //            }
        //        }

        //        private long _level;

        //        public long level
        //        {
        //            get { return this._level; }
        //            set
        //            {
        //                if (value > this._level)
        //                {
        //                    this._level = value;
        //                    //TODO:Analytics.CustomEvent ("topScoreReached");
        //                    EventManager.Events.levelChanged(this._level);
        //                    this._nextLevelXpCost = Levelable.GetLevelCost(this._level);
        //                    Debug.LogWarning("LEVEL UP! NEW LEVEL IS: " + this._level);

        //                }
        //            }
        //        }

        //        void OnAddScore(int score)
        //        {
        //            this.xp += score;
        //        }

        //        #endregion

        //        #region GameCommands

        //        void KillAll()
        //        {
        //            foreach (var obstaclePool in ResourceManager.Resources.obstacles)
        //            {
        //                for (int i = obstaclePool.Value.Count - 1; i >= 0; --i)
        //                {
        //                    var obstacle = obstaclePool.Value[i];
        //                    obstacle.Kill();
        //                }
        //            }
        //        }



        //        #endregion

        //        #region Native Share

        //        //
        //        //		void OnShareRequested (string message)
        //        //		{
        //        //			this._shareTimer = 10;
        //        //			this._msg = message;
        //        //			AddState (this.WaitAndShare);
        //        //		}
        //        //
        //        //		string _msg;
        //        //		int _shareTimer = 0;
        //        //
        //        //		void WaitAndShare ()
        //        //		{
        //        //			this._shareTimer--;
        //        //			if (this._shareTimer == 5) {
        //        //				NativeShare share = GetComponent<NativeShare> ();
        //        //				share.ScreenshotName = "screenshot" + this.GetInstanceID () + ".png";
        //        //				share.ShareScreenshotWithText (this._msg + " " + GPGSIds.game_url + " #MineStrider");
        //        //			}
        //        //			if (this._shareTimer <= 0) {
        //        //				EventManager.Events.shareDone ();
        //        //				RemoveState (this.WaitAndShare);
        //        //			}
        //        //		}
        //        //

        //        #endregion

        //        #region Analytics

        //        private Dictionary<string, object> eventData = new Dictionary<string, object>();
        //        //TODO
        //        void ReportStart(int sessionCount, int armor, int topScore)
        //        {
        //            this.eventData.Clear();
        //            this.eventData["sessionCount"] = sessionCount;
        //            this.eventData["armor"] = armor;
        //            this.eventData["topScore"] = topScore;

        //            Debug.Log("Reporting Game Start Event...");
        //            Analytics.CustomEvent("gameStart", this.eventData);
        //        }

        //        void ReportReset(bool keepScore, int score, int topScore)
        //        {
        //            this.eventData.Clear();

        //            this.eventData["keepScore"] = keepScore;
        //            this.eventData["score"] = score;
        //            this.eventData["topScore"] = topScore;

        //            Debug.Log("Reporting Game Reset Event...");
        //            Analytics.CustomEvent("resetGame", this.eventData);
        //        }

        //        void ReportBackToMenu(int score, int topScore, int armor, int minesHit, int sessionCount)
        //        {
        //            this.eventData.Clear();

        //            this.eventData["score"] = score;
        //            this.eventData["topScore"] = topScore;
        //            this.eventData["armor"] = armor;
        //            this.eventData["minesHit"] = minesHit;
        //            this.eventData["sessionCount"] = sessionCount;

        //            Debug.Log("Reporting Back to Menu Event...");
        //            Analytics.CustomEvent("backToMenu", this.eventData);
        //        }

        //        #endregion

        //#if UNITY_EDITOR
        //        [ContextMenu("Delete Player Prefs")]
        //        public void DeletePlayerPrefs()
        //        {
        //            PlayerPrefs.DeleteAll();
        //            PlayerPrefs.Save();
        //        }
        //#endif

        //        //		public List<Obstacle> visibleTargets = new List<Obstacle> ();
    }
}