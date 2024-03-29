using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailState : ACantKill, IState
{
    public Sprite tileSprite;

    public void StateStart() { }

    public override void Click(Tile tile) { }
    public void SpriteUpdate(Tile tile)
    {
        tile.SetSprite(tileSprite);
    }
    public void DangerTilesNumberUpdate(Tile tile)
    {
        dangerTilesNumber = 0;
    }
    public void ChangeOnDanger(Tile tile, Tile enemy) { }
    public void ChangeOnSafe(Tile tile) { }
    public Sprite GetSprite()
    {
        return tileSprite;
    }
    public void ChangeAngle(IAngle angle) { }
    public void StateDestroy() { }
}
