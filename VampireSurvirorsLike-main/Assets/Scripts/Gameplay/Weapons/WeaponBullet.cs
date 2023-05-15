using UnityEngine;
using System.Collections.Generic;
namespace Gameplay.Weapons
{
    
    /// <summary>
    /// Represents a weapon that shot one bullet at a time to the closest enemy
    /// </summary>
    public class WeaponBullet : WeaponBase
    {

        [SerializeField] GameObject _prefab;
        [SerializeField] float _speed;

        public WeaponBullet()
        {
        }
        
        public override void Update( PlayerController player )
        {
            _timerCoolDown += Time.deltaTime;

            if (_timerCoolDown < _coolDown)
                return;

            _timerCoolDown -= _coolDown;

            EnemyController enemy = MainGameplay.Instance.GetClosestEnemy(player.transform.position);
            if (enemy == null)
                return;

            var playerPosition = player.transform.position;
            Vector3 direction = (enemy.transform.position - playerPosition).normalized;
            Vector3 VerticalDir = new Vector3(direction.y, -direction.x, direction.z).normalized;
            if (_projectileNumber==1)
            {
                GameObject go = GameObject.Instantiate(_prefab, playerPosition, Quaternion.identity);

                if (direction.sqrMagnitude > 0)
                {
                    direction.Normalize();
                    
                    go.GetComponent<Bullet>().Initialize(direction, GetDamage(), _speed);
                    EffectsManager.Instance.audioManager.Play("KnifeShot");
                }
            }
            else 
            {
                GameObject[] Gos = new GameObject[2];
                Gos[0] = GameObject.Instantiate(_prefab, playerPosition + VerticalDir*0.3f, Quaternion.identity);
                Gos[1] = GameObject.Instantiate(_prefab, playerPosition - VerticalDir*0.3f, Quaternion.identity);

                if (direction.sqrMagnitude > 0)
                {
                    
                    direction.Normalize();
                    foreach (var item in Gos)
                    {

                        item.GetComponent<Bullet>().Initialize(direction, GetDamage(), _speed);
                    }
                    EffectsManager.Instance.audioManager.Play("KnifeShot");
                }

            }
            if (_projectileNumber >= 3)
            {
                GameObject go = GameObject.Instantiate(_prefab, playerPosition, Quaternion.identity);

                if (direction.sqrMagnitude > 0)
                {
                    direction.Normalize();

                    go.GetComponent<Bullet>().Initialize(-direction, GetDamage(), _speed);
                }
            }
            if (_projectileNumber > 4)
            {
                GameObject[] Gos = new GameObject[2];
                Gos[0] = GameObject.Instantiate(_prefab, playerPosition, Quaternion.identity);
                Gos[1] = GameObject.Instantiate(_prefab, playerPosition, Quaternion.identity);

                if (direction.sqrMagnitude > 0)
                {
                    direction.Normalize();

                    Gos[0].GetComponent<Bullet>().Initialize(VerticalDir, GetDamage(), _speed);
                    Gos[1].GetComponent<Bullet>().Initialize(-VerticalDir, GetDamage(), _speed);


                }
            }



        }
    }
}