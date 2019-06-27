using Powerups.Pills;
using UnityEngine;

namespace Pills
{
    public class ReducedSpeedPill : Pill
    {
        public float effectTime = 5.0f;
        public float speedSlowdown = 1.0f;
        
        protected override bool ShouldConsumePill(MoveWithInput controller)
        {
            return true;
        }

        protected override void ConsumePill(MoveWithInput controller)
        {
            controller.Consume(this);
        }

        private void OnValidate()
        {
            speedSlowdown = Mathf.Max(0, speedSlowdown);
        }
    }
}