using UnityEngine;

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
            switch (_projectileNumber)
            {

                case 1:
                    {
                        var playerPosition = player.transform.position;
                        GameObject go = GameObject.Instantiate(_prefab, playerPosition, Quaternion.identity);
                        Vector3 direction = enemy.transform.position - playerPosition;
                        if (direction.sqrMagnitude > 0)
                        {
                            direction.Normalize();

                            go.GetComponent<Bullet>().Initialize(direction, GetDamage(), _speed);
                        }

                        break;
                    }
                case 2:
                    {
                        var playerPosition = player.transform.position;
                        GameObject go = GameObject.Instantiate(_prefab, playerPosition + new Vector3(0, -0.5f, 0), Quaternion.identity);
                        Vector3 direction = enemy.transform.position - playerPosition;
                        if (direction.sqrMagnitude > 0)
                        {
                            direction.Normalize();

                            go.GetComponent<Bullet>().Initialize(direction, GetDamage(), _speed);
                        }

                        go = GameObject.Instantiate(_prefab, playerPosition+new Vector3(0,0.5f,0), Quaternion.identity);
                        direction = enemy.transform.position - playerPosition;
                        if (direction.sqrMagnitude > 0)
                        {
                            direction.Normalize();

                            go.GetComponent<Bullet>().Initialize(direction, GetDamage(), _speed);
                        }
                        break;
                    }

                case 4:
                    {
                        var playerPosition = player.transform.position;
                        GameObject go = GameObject.Instantiate(_prefab, playerPosition + new Vector3(0, -0.5f, 0), Quaternion.identity);
                        Vector3 direction = enemy.transform.position - playerPosition;
                        if (direction.sqrMagnitude > 0)
                        {
                            direction.Normalize();

                            go.GetComponent<Bullet>().Initialize(direction, GetDamage(), _speed);
                        }

                        go = GameObject.Instantiate(_prefab, playerPosition + new Vector3(0, 0.5f, 0), Quaternion.identity);
                        direction = enemy.transform.position - playerPosition;
                        if (direction.sqrMagnitude > 0)
                        {
                            direction.Normalize();

                            go.GetComponent<Bullet>().Initialize(direction, GetDamage(), _speed);
                        }
                        


                        
                        go = GameObject.Instantiate(_prefab, playerPosition + new Vector3(-0.5f, -0.5f, 0), Quaternion.identity);
                        direction = -direction;
                        if (direction.sqrMagnitude > 0)
                        {
                            

                            go.GetComponent<Bullet>().Initialize(direction, GetDamage(), _speed);
                        }

                        go = GameObject.Instantiate(_prefab, playerPosition + new Vector3(0.5f, 0.5f, 0), Quaternion.identity);
                        
                        if (direction.sqrMagnitude > 0)
                        {
                            

                            go.GetComponent<Bullet>().Initialize(direction, GetDamage(), _speed);
                        }
                        break;
                    }

                case 8:
                    {
                        var playerPosition = player.transform.position;
                        GameObject go = GameObject.Instantiate(_prefab, playerPosition + new Vector3(0, -0.5f, 0), Quaternion.identity);
                        Vector3 direction = enemy.transform.position - playerPosition;
                        if (direction.sqrMagnitude > 0)
                        {
                            direction.Normalize();

                            go.GetComponent<Bullet>().Initialize(direction, GetDamage(), _speed);
                        }

                        go = GameObject.Instantiate(_prefab, playerPosition + new Vector3(0, 0.5f, 0), Quaternion.identity);
                        direction = enemy.transform.position - playerPosition;
                        if (direction.sqrMagnitude > 0)
                        {
                            direction.Normalize();

                            go.GetComponent<Bullet>().Initialize(direction, GetDamage(), _speed);
                        }

                        go = GameObject.Instantiate(_prefab, playerPosition + new Vector3(-0.5f, -0.5f, 0), Quaternion.identity);
                        direction = -direction;
                        if (direction.sqrMagnitude > 0)
                        {


                            go.GetComponent<Bullet>().Initialize(direction, GetDamage(), _speed);
                        }

                        go = GameObject.Instantiate(_prefab, playerPosition + new Vector3(0.5f, 0.5f, 0), Quaternion.identity);

                        if (direction.sqrMagnitude > 0)
                        {


                            go.GetComponent<Bullet>().Initialize(direction, GetDamage(), _speed);
                        }
                        

                        go = GameObject.Instantiate(_prefab, playerPosition + new Vector3(-0.5f, 0f, 0), Quaternion.identity);
                        direction = new Vector3(direction.y,direction.x,direction.z);
                        if (direction.sqrMagnitude > 0)
                        {


                            go.GetComponent<Bullet>().Initialize(direction, GetDamage(), _speed);
                        }

                        go = GameObject.Instantiate(_prefab, playerPosition + new Vector3(0.5f, 0f, 0), Quaternion.identity);

                        if (direction.sqrMagnitude > 0)
                        {


                            go.GetComponent<Bullet>().Initialize(direction, GetDamage(), _speed);
                        }
                        
                        go = GameObject.Instantiate(_prefab, playerPosition + new Vector3(-0.5f, 0f, 0), Quaternion.identity);
                        direction = -direction;
                        if (direction.sqrMagnitude > 0)
                        {


                            go.GetComponent<Bullet>().Initialize(direction, GetDamage(), _speed);
                        }

                        go = GameObject.Instantiate(_prefab, playerPosition + new Vector3(0.5f, 0f, 0), Quaternion.identity);

                        if (direction.sqrMagnitude > 0)
                        {


                            go.GetComponent<Bullet>().Initialize(direction, GetDamage(), _speed);
                        }

                        break;
                    }
            }
            
        }
    }
}