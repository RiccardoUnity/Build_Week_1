using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameUtility
{
    public enum PickUpType
    {
        None = 0,
        One = 1,
        Two = 2,
        Three = 3
    }

    public static class GameStaticUtility
    {
        //TAG
        private static string _playerTag = "Player";
        public static string PlayerTag => _playerTag;

        private static string _enemyTag = "Enemy";
        public static string EnemyTag => _enemyTag;

        private static string _pickUpTag = "PickUp";
        public static string PickUpTag => _pickUpTag;

        //PLAYER IN SCENA
        private static bool _playerAlreadySet = false;
        private static GameObject _player;
        public static GameObject Player
        {
            get => _player;
            set
            {
                if (!_playerAlreadySet)
                {
                    _player = value;
                    _playerAlreadySet = true;
                }
                else
                {
                    Debug.LogWarning("Non puoi settare di nuovo il Player");
                }
            }
        }

        //ENEMY IN SCENA
        private static List<Enemy> _enemies = new List<Enemy>();

        public static void AddEnemy(Enemy enemy) => _enemies.Add(enemy);

        public static void RemoveEnemy(Enemy enemy) => _enemies.Remove(enemy);

        public static List<Enemy> GetListEnemy() => _enemies;

        //GESTIONE SCENA
        public static void ReloadScene()
        {
            _playerAlreadySet = false;
            _enemies.Clear();

            SceneManager.LoadScene(0);
        }
    }
}
