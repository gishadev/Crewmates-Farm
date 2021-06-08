using UnityEngine;

namespace Gisha.CrewmatesFarm.Core
{
    public class ImpostorController : MonoBehaviour
    {
        [Header("Core")]
        [SerializeField] private Joystick joystick;
        [Header("Movement")]
        [SerializeField] private float moveSpeed = 10f;

        public Weapon CurrentWeapon = new Stick();
        public Vector3 MoveInput => new Vector3(joystick.Horizontal, 0f, joystick.Vertical).normalized;

        private Rigidbody _rb;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            if (MoveInput.magnitude > 0)
                transform.rotation = Quaternion.LookRotation(MoveInput);

            ///////////////// FOR PC /////////////////
            if (Input.GetKeyDown(KeyCode.Space))
                CurrentWeapon.Attack(transform.position, transform.forward);
            ///////////////////////////////////////////////////
            ///

            HandleAttackInput();
        }

        private void HandleAttackInput()
        {
            if (Input.touchCount == 0)
                return;

            Touch firstTouch = Input.GetTouch(0);
            if (firstTouch.phase == TouchPhase.Ended)
                CurrentWeapon.Attack(transform.position, transform.forward);
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
