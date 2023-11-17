using UnityEditor;
using UnityEngine;

namespace Сross_product
{
    public class CrossProduct : MonoBehaviour
    {
        [SerializeField] private Transform _transformPlayer;
        [SerializeField] private Transform _transformEnemy;
        [SerializeField] private Transform _transformCommunicate; 

        private void OnDrawGizmos() {
            var crossProduct = GetCrossProduct();
            string message = $"Cross Product: {crossProduct} "; 
            message += crossProduct.y > 0 ? " The enemy is in right of you." : "The enemy is in left of you.";
            Handles.Label(_transformCommunicate.position, message);
        }

        private Vector3 GetCrossProduct() {
            Vector3 playerForward = _transformPlayer.forward.normalized;
            Vector3 directionToEnemy = (_transformEnemy.position - _transformPlayer.position).normalized;
            
            // yes, i know about Vector3.Cross
            float crossX = playerForward.y * directionToEnemy.z - playerForward.z * directionToEnemy.y;
            float crossY = playerForward.z * directionToEnemy.x - playerForward.x * directionToEnemy.z;
            float crossZ = playerForward.x * directionToEnemy.y - playerForward.y * directionToEnemy.x;
            
            return new Vector3(crossX, crossY, crossZ);
            
        }
    }
}
