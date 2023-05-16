
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represents an enemy who's moving toward the player
/// and damage him on collision
/// data bout the enemy are stored in the EnemyData class
/// CAUTION : don't forget to call Initialize when you create an enemy
/// </summary>
public class EnemyController : Unit
{
    public GameObject Head;
    public GameObject Body;
    public GameObject Blood;
    public GameObject Bloodsplash;
    GameObject _player;
    Rigidbody2D _rb;
    EnemyData _data;
    Vector3 direction;
    private List<PlayerController> _playersInTrigger = new List<PlayerController>();
    float LockMove;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }


    public void Initialize(GameObject player, EnemyData data)
    {
        _player = player;
        _data = data;
        _life = data.Life;
        _team = 1;
    }

    private void Update()
    {
        if (_life <= 0)
            return;


        foreach (var player in _playersInTrigger)
        {
            player.Hit(Time.deltaTime * _data.DamagePerSeconds);
        }
    }

    void FixedUpdate()
    {
        LockMove -= Time.deltaTime;
        if (LockMove<0)
        {
            MoveToPlayer();
        }

       
    }

    private void MoveToPlayer()
    {
        direction = _player.transform.position - transform.position;
        direction.z = 0;

        float moveStep = _data.MoveSpeed * Time.deltaTime;
        if (moveStep >= direction.magnitude)
        {
            _rb.velocity = Vector2.zero;
            transform.position = _player.transform.position;
        }
        else
        {
            direction.Normalize();
            _rb.velocity = direction * _data.MoveSpeed;
        }


        if (direction.x > 0)
        {
            this.gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }

        
    }

    public override void Hit(float damage)
    {
        _life -= damage;

        EffectsManager.Instance.audioManager.Play("EnemyHit");
        GameObject slash =GameObject.Instantiate(Bloodsplash, transform.position, Quaternion.identity);
        Destroy(slash, 1);

        if (Life <= 0)
        {
            
            Die();
        }
    }

    void Die()
    {
        MainGameplay.Instance.Enemies.Remove(this);
        GameObject.Destroy(gameObject);
        int n = Random.Range(1, 5);
        GameObject.Instantiate(Blood, transform.position, Quaternion.identity);
        GameObject _head= GameObject.Instantiate(Head, transform.position, Quaternion.identity);
        _head.GetComponent<Rigidbody2D>().AddForce(-direction * 5, ForceMode2D.Impulse);
        GameObject.Instantiate(Body, transform.position, Quaternion.identity);

        // Exécution d'une action en fonction du nombre aléatoire généré
        switch (n)
        {
            case 1:
                { 
                    var xp = GameObject.Instantiate(MainGameplay.Instance.PrefabXP, transform.position, Quaternion.identity);
                    xp.GetComponent<CollectableXp>().Initialize(1);
                    break;
                }
            case 2:
                {
                    var xp = GameObject.Instantiate(MainGameplay.Instance.PrefabXP, transform.position, Quaternion.identity);
                    xp.GetComponent<CollectableXp>().Initialize(1);

                    break;
                }
            case 3:
                {
                    var Life = GameObject.Instantiate(MainGameplay.Instance.PrefabLife, transform.position, Quaternion.identity);
                    Life.GetComponent<CollectableLife>().Initialize(5);
                    break;
                }
            case 4:
                break;
        }
        
        EffectsManager.Instance.audioManager.Play("EnemyDeath");
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        var other = HitWithParent.GetComponent<PlayerController>(col);

        if (other != null)
        {
            if (_playersInTrigger.Contains(other) == false)
                _playersInTrigger.Add(other);
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        var other = HitWithParent.GetComponent<PlayerController>(col);

        if (other != null)
        {
            if (_playersInTrigger.Contains(other))
                _playersInTrigger.Remove(other);
        }
    }

    public override void Knockback(Vector3 Origin)
    {
        LockMove = 0.2f;
        
        Debug.Log("test");
        Vector3 dir = (transform.position - Origin).normalized;
        _rb.AddForce(dir * 3f, ForceMode2D.Impulse);
        
    }
}