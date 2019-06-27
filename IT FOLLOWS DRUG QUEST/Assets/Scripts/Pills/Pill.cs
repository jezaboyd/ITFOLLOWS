using UnityEngine;

namespace Powerups.Pills
{
    public abstract class Pill : MonoBehaviour
    {
        void OnTriggerEnter2D(Collider2D otherP)
        {
            MoveWithInput controller = otherP.GetComponent<MoveWithInput>();

            if (controller != null)
            {
                if (ShouldConsumePill(controller))
                {
                    ConsumePill(controller);
                    PillPusher.PushPill(transform.position);
                    Destroy(gameObject);
                }
            }
        }

        protected abstract bool ShouldConsumePill(MoveWithInput controller);
        protected abstract void ConsumePill(MoveWithInput controller);
    }
}