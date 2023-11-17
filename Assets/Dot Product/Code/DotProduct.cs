using UnityEditor;
using UnityEngine;

namespace Dot_Product.Code
{
    public class DotProduct : MonoBehaviour
    {
        [SerializeField] private Transform _transformPlayer;
        [SerializeField] private Transform _transformEnemy;
        [SerializeField] private Transform _transformCommunicate; 

        private void OnDrawGizmos() {
            float dotProduct = GetDotProduct();
            string message = $"Dot Product: {dotProduct:00.00} "; 
            message += dotProduct > 0 ? " The enemy is in front of you." : "The enemy is behind you.";
            Handles.Label(_transformCommunicate.position, message);
        }

        private float GetDotProduct() {
            Vector3 playerForward = _transformPlayer.forward.normalized;
            Vector3 directionToEnemy = (_transformEnemy.position - _transformPlayer.position).normalized;
            // yes, i know about Vector3.Dot
            return (playerForward.x * directionToEnemy.x) + (playerForward.y * directionToEnemy.y) +
                   (playerForward.z * directionToEnemy.z);
        }
    }
}
