using Powerups.Pills;
using UnityEngine;
using UnityEngine.Serialization;

namespace Powerups
{
    public class ConfusionPill : Pill
    {
        [FormerlySerializedAs("confuseTime")] public float effectTime = 5.0f;
        
        protected override bool ShouldConsumePill(MoveWithInput controller)
        {
            return true;
        }

        protected override void ConsumePill(MoveWithInput controller)
        {
            controller.Consume(this);
        }
    }
}