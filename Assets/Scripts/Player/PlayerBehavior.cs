using Unity.VisualScripting;
using UnityEngine;

namespace Player
{
    public class PlayerBehavior : MonoBehaviour
    {
        [SerializeField, Range(0.0f, 1.0f)]
        private float pillScaleFactor = 0.1f;
        
        protected PlayerStats _playerStats = new PlayerStats(1);
        
        public int Size => _playerStats.Size;
        
        private void OnTriggerEnter(Collider other)
        {
            Debug.Log($"Collided with {other.tag}");
            if (other.GameObject().CompareTag("Food"))
            {
                OnEatFood(other.GameObject());
            }
        
            if (other.GameObject().CompareTag("Pill"))
            {
                OnTakePill(other.GameObject());
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            var collisionCollider = collision.collider;
        
            if (collisionCollider.GameObject().CompareTag("Chompy"))
            {
                OnEnemyHit(collisionCollider.GameObject().GetComponent<PlayerBehavior>());
            }
        }
        
        protected void OnEatFood(GameObject foodObject)
        {
            Destroy(foodObject);
        }
        
        protected void OnTakePill(GameObject pillObject)
        {
            Destroy(pillObject);
            
            _playerStats.Size++;
            UpdatePlayerSize();
        }

        private void UpdatePlayerSize()
        {
            var radiusScale = new Vector3(1.0f, 0.0f, 1.0f);
            gameObject.transform.localScale += radiusScale * pillScaleFactor;
        }
        
        protected void OnEnemyHit(PlayerBehavior enemy)
        {
            var enemySize = enemy._playerStats.Size;
            
            Debug.Log($"Enemy hit with size: {enemySize}, and my size: {_playerStats.Size}");

            if (enemySize > _playerStats.Size)
            {
                Destroy(gameObject);
            }
            
        }
    }
}