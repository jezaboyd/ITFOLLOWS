using System.Collections;
using System.Collections.Generic;
using Powerups.Pills;
using UnityEngine;

public class CollectiblePill : Pill
{
    protected override bool ShouldConsumePill(MoveWithInput controller)
    {
        return controller.currentPill < controller.maxPill;
    }

    protected override void ConsumePill(MoveWithInput controller)
    {
        controller.ChangePill(1);

    }
}


