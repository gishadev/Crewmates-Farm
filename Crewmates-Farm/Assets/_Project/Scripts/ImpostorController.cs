using UnityEngine;

namespace Gisha.CrewmatesFarm.Core
{
    public class ImpostorController : MonoBehaviour
    {
        [Header("Core")]
        [SerializeField] private Joystick joystick;
        [Header("Movement")]
        [SerializeField] private float moveSpeed = 10f;

        public Vector3 MoveInput => new Vector3(joystick.Horizontal,0f, joystick.Vertical);

        private void Update()
        {
            Debug.Log(MoveInput);
        }
    }
}
