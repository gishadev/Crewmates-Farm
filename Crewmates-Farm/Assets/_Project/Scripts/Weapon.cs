using UnityEngine;

namespace Gisha.CrewmatesFarm.Core
{
    public class Weapon
    {
        protected LayerMask _whatIsAttackable = -1;

        public virtual void Attack(Vector3 origin, Vector3 attackDirection)
        {
            if (_whatIsAttackable == -1)
                _whatIsAttackable = 1 << LayerMask.NameToLayer("Attackable");

            Debug.Log("Weapon used!");
        }
    }

    public class Stick : Weapon
    {
        [SerializeField] private float attackRadius = 0.5f;
        [SerializeField] private float attackDst = 1f;

        public override void Attack(Vector3 origin, Vector3 attackDirection)
        {
            base.Attack(origin, attackDirection);

            Ray ray = new Ray(origin, attackDirection);
            if (Physics.SphereCast(ray, attackRadius, out RaycastHit hitInfo, attackDst, _whatIsAttackable))
            {
                Debug.DrawRay(ray.origin, ray.direction * attackDst);
                GameObject.Destroy(hitInfo.collider.gameObject);
            }
        }
    }
}
