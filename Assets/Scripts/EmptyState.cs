using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyState : MonoBehaviour, IState
{
    Tile tile;
    public void SetTile(Tile linkedTile)
    {
        tile = linkedTile;
    }
    public void Click()
    {
        Vector2 tilePos = tile.transform.position;
        if (Manager.playerLink.MoveCheck(tilePos))
        {
            Manager.playerLink.PlayerChangePosition(tilePos);
            // ����� ���� ��� ����������� ������
            Manager.stepCount++;
            Messenger.Broadcast(GameEvent.NEXT_STEP);
            if (Player.energy < 4)
            {
                Player.energy++;
                Manager.link.EnergyUpdate();
            }
            Manager.link.StartCheckMovableTurret(tile);
            // ����������� ����������� ����� ��� ������� � ��������� ������
            Manager.playerLink.PlayerTileChange(tile);
        }
    }
    public void SpriteUpdate()
    {
        tile.SetSprite(0);
    }
    public void DangerTilesNumberUpdate()
    {
        tile.SetDangerTilesNumber(0);
    }
    public void SetListeners() { }
    public void DangerTilesSpawn() { }
    public void NextMove() { }
    public void DestroyListeners() { }
    public void CheckMovableTurretMove() { }
}
