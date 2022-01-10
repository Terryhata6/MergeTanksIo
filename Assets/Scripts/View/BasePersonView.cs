using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public abstract class BasePersonView : BaseObjectView, IApplyDamage, IDead
{
    [SerializeField] protected int _points;  //EnterAlt
    public int Points => _points; //EnterAlt
    #region {Author:Doonn}
    [SerializeField] protected PerkManager _perkManager; 
    public PerkManager PerkManager => _perkManager;

    #region Fields
    private Shooter _shooter;

    // Player Level Up
    [SerializeField, Range(1, 5)] private int _level = 1;
    public int Level => _level;

    // Shot Project Transform
    [SerializeField] private List<Transform> _shotProjectileTransform;
    public List<Transform> ShotProjectileTransform => _shotProjectileTransform;

    #endregion

    [SerializeField] private List<GameObject> _tankMeshes;

    #endregion

    #region Player Params
    [SerializeField] private ViewParamsComponent _viewParams = new ViewParamsComponent();
    public ViewParamsComponent ViewParams => _viewParams;
    #endregion

    #region {Author:Doonn}
    public void Awake()
    {
        TankShotProjectileRecordTransform();
    }

    public void InitializeShooter(Shooter shooter)
    {
        _shooter = shooter;
        _perkManager = new PerkManager(_viewParams, _shooter);
    }

    public void ChangeTankMesh(int index)
    {
        for (int i = 0; i < _tankMeshes.Count; i++)
        {
            _tankMeshes[i].SetActive(false);
        }

        _tankMeshes[index - 1].SetActive(true);
    }
//Enter Alt
    public virtual void OnTriggerEnter(Collider other)
    {
        CheckCollectable(other.gameObject);
        //CheckMerge(other.gameObject);
    }
//Enter Alt
    private void CheckCollectable(GameObject other)
    {
        if (other.layer.Equals((int) Layers.Collectables))
        {
            if ((other.transform.position - transform.position).magnitude < 2f)
            {
                other.SetActive(false);
                GetPoints(other.GetComponent<CollectableItem>().Points);
            }
        }
    }
//Enter Alt
    private void CheckMerge(GameObject other)
    {
        if (other.layer.Equals((int) Layers.Merge))
        {
            
            if (CheckTankMeshesList(_tankMeshes) == false) return;
            if (_tankMeshes.Count < 5) return;
            if (Level >= 5) return; // << Хард Код (Level >= 5)

            _level++;
            ChangeTankMesh(Level);

            TankShotProjectileRecordTransform();
            Destroy(other);
        }
    }
//Enter Alt
    private void GetMerge(MergeItem item)
    {
        UpParams(item.Level);
    }

    private void UpParams(int multiplier)
    {
        
    }
    
    //Enter Alt 07.12
    private void GetPoints(int points)
    {
        _points += points;
    }

    // Запись Трансформов от куда вылетают Снаряды
    public void TankShotProjectileRecordTransform()
    {
        if (_tankMeshes == null) return;
        bool checkListIsEmpty = _tankMeshes.TrueForAll(x => x != null);

        if (!checkListIsEmpty)
        {
            Debug.Log("List Slot Empty");
            return;
        }


        foreach (GameObject Tank in _tankMeshes)
        {
            if (Tank.activeInHierarchy)
            {
                _shotProjectileTransform.Clear();
                int CountChild = Tank.transform.childCount;
                for (int i = 0; i < CountChild; i++)
                {
                    _shotProjectileTransform.Add(Tank.transform.GetChild(i));
                }
            }
        }
    }

    private bool CheckTankMeshesList(List<GameObject> tankMeshes)
    {
        if (tankMeshes.Count == 0) return false;

        for (int i = 0; i < _tankMeshes.Count; i++)
        {
            if (_tankMeshes[i].Equals(null)) return false;
        }
        return true;
    }

    public void Attack()
    {
        if (_shooter == null) return;
        _shooter.Shooting(_perkManager.OwnShooterPerkList);
    }

    public void TakeDamage(float damage)
    {
        Debug.Log("Нанес Повреждение");
        ViewParams.ChangeHealth(ViewParams.Health - damage);
        IsDead();
    }

    public virtual void IsDead()
    {
        
        if (ViewParams.IsDead())
        {
            Debug.Log(GetType().ToString() + " DEAD");
        }
        
        Destroy(gameObject);
    }
    #endregion
    
    //eNTER-ALT
    
    [SerializeField] private GameObject example;
    [SerializeField] private float radius;
    [SerializeField] float iterator = 0f;

    float tempRad;
    private Vector3 temp;

    IEnumerator SprayCollectables()
    {
        Transform[] transforms = new Transform[10];
        Vector3[] basePos = new Vector3[transforms.Length];
        Vector3[] nextPos = new Vector3[transforms.Length];


        for (int i = 0; i < 10; i++)
        {
            transforms[i] = Instantiate(example, Vector3.up * 10f, Quaternion.identity).transform;
            basePos[i] = transforms[i].position;
            tempRad = Random.Range(0f, 360f) * Mathf.Deg2Rad;
            nextPos[i] = new Vector3(Mathf.Cos(tempRad), 0, Mathf.Sin(tempRad)) * radius;
        }

        bool count = true;
        while (count)
        {
            for (int j = 0; j < transforms.Length; j++)
            {
                temp = Vector3.Lerp(basePos[j], nextPos[j], iterator);
                temp.y = -10 * ((iterator - 0.5f) * (iterator - 0.5f)) + iterator; // Менять параболу тут
                transforms[j].position = temp;
            }

            iterator += Time.deltaTime / 3f;
            if (iterator >= 1)
            {
                count = false;
            }

            yield return null;
        }
    }
}