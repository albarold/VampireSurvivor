using UnityEngine;

/// <summary>
/// Represents the xp points the player has to collect to level up
/// </summary>
public class CollectableLife : MonoBehaviour
{
    public int Value { get; private set; }

    public void Initialize(int value)
    {
        Value = value;
    }
    
    void OnTriggerEnter2D(Collider2D col)
    {
        var other = HitWithParent.GetComponent<PlayerController>(col);
        
        if (other != null)
        {
            other.CollectLife(Value);
            GameObject.Destroy(gameObject);
        }
    }
    
    
    
}
