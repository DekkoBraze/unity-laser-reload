using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretState : AMayKill, IState
{
    public Sprite tileSprite;

    public bool isInfinite;

    public void SpriteUpdate(Tile tile)
    {
        tile.SetSprite(tileSprite);
    }
    public void DangerTilesNumberUpdate(Tile tile)
    {
        dangerTilesNumber = 2;
    }
    public void NextMove(Tile tile) { }
    public void CheckMovableTurretMove(Tile tile) { }
    public Sprite GetSprite()
    {
        return tileSprite;
    }
}