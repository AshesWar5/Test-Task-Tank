using System.Collections.Generic;
using TestTask.Enemy;
using TestTask.Level;
using TestTask.Player;
using TestTask.UI;
using TestTask.Weapon;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TestTask
{
    [RequireComponent(typeof(CollectionUpdate), typeof(AsyncTaskService))]
    public sealed class Startup : MonoBehaviour, ICleaner, IGameRestart
    {
        [SerializeField]
        private UIMain _ui;

        private List<ICleaner> _cleaners;
        private CollectionUpdate _update;
        private AsyncTaskService _asyncTask;

        private const int INDEX_GAME_SCANE = 0;

        private void Start()
        {
            _cleaners = new List<ICleaner>();

            _asyncTask = GetComponent<AsyncTaskService>();
            _update = InitializeGameUpdate();

            var gameConfig = InitializeGameConfig();
            InitializeUIMain();
            var input = InitializeInput();
            var level = InitializeLevel(gameConfig.IndexLevel);
            var player = InitializePlayer(input, level.StatPointPlayer);
            var shoot = InitializeShoot();
            var weapon = InitializeWeapons(input, player.Weapons, player.Player.PointWeapon, shoot);
            var enemy = InitializeEnemy(gameConfig.MaxCountEnemy, level.PointsForEnemys, player.Player.transform);

            _cleaners.Add(_update);
            _cleaners.Add(_ui);
            _cleaners.Add(player.Player);
            _cleaners.Add(weapon);

            _update.AddToUpdateList(enemy);
        }

        public void Cleaner()
        {
            foreach (var cleaner in _cleaners)
            {
                cleaner.Cleaner();
            }
        }

        public void RestartGame()
        {
            Cleaner();
            SceneManager.LoadScene(INDEX_GAME_SCANE);
        }

        private CollectionUpdate InitializeGameUpdate()
        {
            var update = GetComponent<CollectionUpdate>();
            update.Initialize();
            return update;
        }

        private GameConfig InitializeGameConfig()
        {
            return Resources.Load<GameConfig>("Configs/Game");
        }

        private void InitializeUIMain()
        {
            _ui.Initialize(this);
        }

        private IInput InitializeInput()
        {
            IInput input = null;

            if (Application.isMobilePlatform == false)
            {
                var inputPlatform = new PCInput();
                inputPlatform.Initialize();
                _update.AddToUpdateList(inputPlatform);
                input = inputPlatform;
            }

            return input;
        }

        private LevelView InitializeLevel(int indexLevel)
        {
            var factory = Resources.Load<LevelFactory>("Factories/Level");
            return factory.Get(indexLevel);
        }

        private PlayerModel InitializePlayer(IInput input, Transform pointPlayerSpawn)
        {
            var factory = Resources.Load<PlayerFactory>("Factories/Player");
            var model = factory.Get(pointPlayerSpawn.position, Vector3.zero);
            var movement = new PlayerMovement(model.Player.Agent, model.SpeedMovement);
            var health = new Health(model.Health, model.Protection);
            new PlayerDamager(model.Player.CollisionListener, model.Player);

            model.Player.Initialize(input, movement, health, _ui);

            return model;
        }

        private WeaponSystem InitializeWeapons(IInput input, WeaponType[] weapons, Transform parrentWeapon,
            ShootFactory shoot)
        {
            var factory = Resources.Load<WeaponFactory>("Factories/Weapon");
            return new WeaponSystem(input, weapons, factory, factory, shoot, parrentWeapon);
        }

        private ShootFactory InitializeShoot()
        {
            return new ShootFactory();
        }

        private EnemySystem InitializeEnemy(int maxCountEnemy, Transform[] pointsEnemy,
            Transform targetEnemy)
        {
            var factory = Resources.Load<EnemyFactory>("Factories/Enemy");
            return new EnemySystem(factory, maxCountEnemy, pointsEnemy, _asyncTask, targetEnemy);
        }
    }
}