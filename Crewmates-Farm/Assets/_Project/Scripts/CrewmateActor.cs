using UnityEngine;

namespace Gisha.CrewmatesFarm.Core
{
    public class CrewmateActor : MonoBehaviour
    {
        [SerializeField] private float moveSpeed;

        Transform _target;
        Rigidbody _rb;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
        }

        private void Start()
        {
            FindTarget();
        }

        private void Update()
        {
            FollowTarget();
        }

        /// <summary>
        /// Finds player (target).
        /// </summary>
        private void FindTarget()
        {
            if (GameObject.FindGameObjectsWithTag("Player").Length > 1)
                Debug.LogError("There are more than one player!");

            _target = GameObject.FindGameObjectWithTag("Player").transform;

            if (_target == null)
                Debug.LogError("Player is null!");
        }

        private void FollowTarget()
        {
            var dirToTarget = (_target.position - transform.position).normalized;
            _rb.velocity = dirToTarget * moveSpeed;
        }
    }
}
