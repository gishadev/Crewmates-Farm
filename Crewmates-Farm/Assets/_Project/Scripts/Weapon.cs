using UnityEngine;

namespace Gisha.CrewmatesFarm.Core
{
    public class Weapon
    {
        public virtual void Attack()
        {
            Debug.Log("Weapon used!");
        }
    }

    public class Stick : Weapon
    {
        public override void Attack()
        {
            base.Attack();
            Debug.Log("Weapon is stick!");
        }
    }
}
