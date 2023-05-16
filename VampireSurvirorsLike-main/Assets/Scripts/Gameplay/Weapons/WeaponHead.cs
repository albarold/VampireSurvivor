using UnityEngine;
using System.Collections.Generic;
namespace Gameplay.Weapons
{
    
    /// <summary>
    /// Represents a weapon that shot one bullet at a time to the closest enemy
    /// </summary>
    public class WeaponHead : WeaponBase
    {

        [SerializeField] GameObject _prefab;
        [SerializeField] float _speed;
        [SerializeField] Sprite NoheadPlayer;
        [SerializeField] RuntimeAnimatorController NoheadAnim;
        bool NoHead=false;

        GameObject go;
        public WeaponHead()
        {
        }
        
        void Start()
        {
            Debug.Log("aze");
            
        }
        public override void Update( PlayerController player )
        {
            if (!NoHead)
            {
                player.gameObject.GetComponent<SpriteRenderer>().sprite = NoheadPlayer;
                player.gameObject.GetComponent<Animator>().runtimeAnimatorController = NoheadAnim;
            }
            var playerPosition = player.transform.position;
            if (go == null)
            {
                EffectsManager.Instance.audioManager.Play("HeadSpin");
                go = GameObject.Instantiate(_prefab, playerPosition+new Vector3(0,3f,0), Quaternion.identity);
            }

            go.transform.RotateAround(playerPosition, Vector3.forward, _speed);
            go.transform.right = Vector3.right;

            Vector3 relativePos = go.transform.position - playerPosition;
            float dist = Vector3.Distance(go.transform.position, playerPosition);

            if (dist>4)
            {
                go.transform.position += -relativePos * _speed * Time.deltaTime;
            }else if (dist<2)
            {
                go.transform.position += relativePos * _speed * Time.deltaTime;
            }
           // go.GetComponent<Rigidbody2D>().AddForce((relativePos)*15000, ForceMode2D.Force);

            /*if (go.GetComponent<Rigidbody2D>().velocity.magnitude>= 2)
            {
                Debug.Log("ez");
                go.GetComponent<Rigidbody2D>().AddForce(-(go.GetComponent<Rigidbody>().velocity), ForceMode2D.Force);
            }*/

        }

        
    }
}