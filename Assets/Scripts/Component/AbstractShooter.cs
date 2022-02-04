using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractShooter
{
    [SerializeField] protected List<Transform> _shotProjectileTransform;
    public List<Transform> ShotProjectileTransform => _shotProjectileTransform;
    protected GameObject _ownGameObject;
    public GameObject OwnGameObject => _ownGameObject;

    public void RecalcProjectileTransform()
    {
        TankShotProjectileRecordTransform(_ownGameObject);
    }

    // Запись Трансформов от куда вылетают Снаряды
    protected void TankShotProjectileRecordTransform(GameObject ownObject)
    {
        if (ownObject.activeInHierarchy)
        {
            int getParentCount = ownObject.transform.childCount;
            _shotProjectileTransform.Clear();
            for (int i = 0; i < getParentCount; i++)
            {
                var getTank = ownObject.transform.GetChild(i).gameObject;
                for (int t = 0; t < getTank.transform.childCount; t++)
                {
                    if (getTank.activeInHierarchy)
                    {
                        _shotProjectileTransform.Add(getTank.transform.GetChild(t));
                    }
                }
            }
        }
    }

    // OLD Version был в BasePersonView
    // public void TankShotProjectileRecordTransform()
    // {
    //     if (_tankMeshes == null) return;
    //     bool checkListIsEmpty = _tankMeshes.TrueForAll(x => x != null);

    //     if (!checkListIsEmpty)
    //     {
    //         Debug.Log("List Slot Empty");
    //         return;
    //     }

    //     foreach (GameObject Tank in _tankMeshes)
    //     {
    //         if (Tank.activeInHierarchy)
    //         {
    //             _shotProjectileTransform.Clear();
    //             int CountChild = Tank.transform.childCount;
    //             for (int i = 0; i < CountChild; i++)
    //             {
    //                 _shotProjectileTransform.Add(Tank.transform.GetChild(i));
    //             }
    //         }
    //     }
    // }
}