using Powerups.Pills;
using UnityEngine;

namespace Powerups
{
    public class ConfusionPill : Pill
    {
        public float confuseTime = 5.0f;
        
        protected override bool ShouldConsumePill(MoveWithInput controller)
        {
            return true;
        }

        protected override void ConsumePill(MoveWithInput controller)
        {
            controller.GetConfused(this);
        }
    }
}