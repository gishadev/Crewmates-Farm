using UnityEngine;

namespace Gisha.CrewmatesFarm.Core
{
    public class ImpostorController : MonoBehaviour
    {
        [Header("Core")]
        [SerializeField] private Joystick joystick;
        [Header("Movement")]
        [SerializeField] private float moveSpeed = 10f;

        public Vector3 MoveInput => new Vector3(joystick.Horizontal,0f, joystick.Vertical).normalized;

        private Rigidbody _rb;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            Debug.Log(MoveInput);
        }

        private void FixedUpdate()
        {
            _rb.velocity = MoveInput * moveSpeed;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(transform.position, MoveInput);
        }
    }
}
