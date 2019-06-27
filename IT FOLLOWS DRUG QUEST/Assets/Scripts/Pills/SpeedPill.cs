using Powerups.Pills;
using UnityEngine;
using UnityEngine.Serialization;

namespace Pills
{
    public class SpeedPill : Pill
    {
        [FormerlySerializedAs("time")] public float effectTime = 5.0f;
        public float speedBoost = 1.0f;
        
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
            speedBoost = Mathf.Max(0, speedBoost);
        }
    }
}