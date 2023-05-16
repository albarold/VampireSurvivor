using UnityEngine;
using UnityEngine.Serialization;

/// <summary>
/// Represents a bullet moving in a given direction
/// A bullet can be fired by the player or by an enemy
/// call Initialize to set the direction
/// </summary>
public class Bullet : MonoBehaviour
{
    [SerializeField] int _team;
    [SerializeField] float _timeToLive = 10.0f;

    [SerializeField] bool Indestructible;
    float _speed = 10;
    float _damage = 5;
    Vector3 _direction;

    public void Initialize(Vector3 direction , float damage , float speed )
    {
        _direction = direction;
        _speed = speed;
        _damage = damage;
    }

    // Start is called before the first frame update
    void Start()
    {
        GameObject.Destroy(gameObject, _timeToLive);
    }

    void Update()
    {
        transform.position += _direction * _speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        var other = HitWithParent.GetComponent<Unit>(col);
        
        other.Knockback(transform.position);

        if (other == null && !Indestructible)
        {
            GameObject.Destroy(gameObject);
        }
        else if (other.Team != _team )
        {
            other.Hit(_damage);
            if (!Indestructible)
            {
                GameObject.Destroy(gameObject);
            }
            

            
        }
    }
}