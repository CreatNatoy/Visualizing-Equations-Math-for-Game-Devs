using UnityEditor;
using UnityEngine;

namespace Quaternion
{
    public class RotateToTargetQuaternion : MonoBehaviour
    {
        [SerializeField] private float rotationSpeed = 1;
        [SerializeField] private Transform _transformTarget;
        [SerializeField] private Transform _transformCommunicate;

        private void OnDrawGizmos() {
            RotateToTarget();
            Handles.Label(_transformCommunicate.position, gameObject.name);
            Debug.DrawLine(transform.position, transform.position + transform.forward * 3f, Color.blue);
        }


        private void RotateToTarget() {
            if (_transformTarget != null)
            {
                if (_transformTarget != null)
                {
                    Vector3 directionToTarget = _transformTarget.position - transform.position;
                    UnityEngine.Quaternion targetRotation = UnityEngine.Quaternion.LookRotation(directionToTarget, Vector3.up);
                    transform.rotation = UnityEngine.Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed);
                }
            }
        }
    }
}