using System.Collections.Generic;
using UnityEngine;

public class CollectableController : BaseController, IExecute
{
    private CollectablesParam _collParams;
    private CollectableItem _tempColl;
    private ObjectPool<CollectableItem> _pool;
    private List<CollectableItem> _activeColl;
    private float _tempMaxY;
    private float _tempMaxZ;
    private float _tempMaxX;
    private float _tempMinY;
    private float _tempMinZ;
    private float _tempMinX;
    private int _tempNumber;
    private int _index;
    private CollectableSpray _spray;
    private List<Transform> _tempTransforms;
    private GameObject _tempObj;
    private GameObject _mergeObj;
    private List<Vector3> _vertices;
    private Vector3 _tempPos;
    private RaycastHit _hit;
    private float _respawnDelay;
    private List<float> _respawnDelays;


    public override void Initialize()
    {
        GameEvents.Current.OnItemCollected += SetMovingCoin;
        GameEvents.Current.OnCollectablesParamSet += SetParams;
        GameEvents.Current.OnCollectableDisable += DeleteActiveCol;
        GameEvents.Current.OnCollectableDisable += ReturnCollToPool;
        GameEvents.Current.OnPersonDead += SprayCollectables;
        GameEvents.Current.OnSprayAvaible += SetSpray;
        GameEvents.Current.OnMergeObj += SetMergeObj;


        _pool = new ObjectPool<CollectableItem>();
        _activeColl = new List<CollectableItem>();
        _respawnDelays = new List<float>();
        _tempTransforms = new List<Transform>();
        _respawnDelay = 4f;
        Debug.Log("CollectableController start");
    }

    public override void Execute()
    {
        Respawn();
        for (_index = 0; _index < _activeColl.Count; _index++)
        {
            MoveCollectable(_activeColl[_index]); // движение coin
        }
    }

    private void PoolInit()
    {
        _pool.CleanPool();
        if (_collParams)
        {
            Debug.Log("Collectable pOOL INIT");
            _pool.Initialize(_collParams.Examples ,_collParams.Size + 50);
        }
    }

    private void SpawnCollectables(int size)
    {
        for (_index = 0; _index < size; _index++)
        {
            SpawnCollectable();
        }
    }

    private void SpawnCollectable()
    {
        GetRandomPos();
        if (GetRandomPos())
        {
            _tempColl = _pool.GetObject(_tempPos + Vector3.up);
            _tempColl.gameObject.layer = (int)Layers.Collectables;
            CollectableInit(_tempColl);
        }
        else
        {
            _respawnDelays.Add(0.5f);
        }
        GameEvents.Current.EnvironmentUpdated();
    }

    private void CollectableInit(CollectableItem col)
    {
        col.Points = Random.Range(1, 10);
        col.NeedRespawn = true;
    }

    private bool GetRandomPos()
    {
        _tempPos.x = Random.Range(_tempMinX, _tempMaxX);
        _tempPos.y = Random.Range(_tempMaxY, _tempMaxY);
        _tempPos.z = Random.Range(_tempMinZ, _tempMaxZ);
        Physics.Raycast(_tempPos + Vector3.up, Vector3.down * 10f, out _hit, 4f);
        if (_hit.collider == null || _hit.collider.gameObject.layer!.Equals((int)Layers.Ground))
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    
    private void MoveCollectable(CollectableItem col)
    {

        if (col.enabled & col.Target!=null)
        {
            col.transform.position = Vector3.MoveTowards(col.transform.position, col.Target.position + Vector3.up, Time.deltaTime * 2f);
        }
        if (col.Target == null || (col.Target.position -  col.transform.position).magnitude > 15f)
        {
            col.Target = null;
            _activeColl.Remove(col);
        }
    }

    private void SetCollectableToRespawn(float time)
    {
        _respawnDelays.Add(time);
    }

    private void Respawn()
    {
        for (_index = 0; _index < _respawnDelays.Count; _index++)
        {
            _respawnDelays[_index] -= Time.deltaTime;
            if (_respawnDelays[_index] <= 0)
            {
                SpawnCollectable();
                _respawnDelays.RemoveAt(_index);
            }
        }
    }
    private void SetMovingCoin(CollectableItem coin) // Установка движущегося coin(когда игрок подбирает коин он движется к игроку)
    {
        if (!_activeColl.Contains(coin))
        {
            _activeColl.Add(coin);
        }
        
    }

    private void DeleteActiveCol(CollectableItem col)
    {
        if (_activeColl.Contains(col))
        {
            _activeColl.Remove(col);
        }

        if (col.NeedRespawn)
        {
            SetCollectableToRespawn(_respawnDelay);
        }
    }

    private void ReturnCollToPool(CollectableItem col)
    {
        _pool.AddObject(col);
    }

    private void SetParams(CollectablesParam cp)
    {
        if (cp)
        {
            Debug.Log("Collectables Params set"); 
            _collParams = cp;
            _respawnDelay = _collParams.RespawnDelay;
            if (_collParams.Ground.Equals(null))
            {
                Debug.LogError("noGround");
                return;
            }
            CalculateBounds(_collParams.Vertices,_collParams.Ground);
            PoolInit();
            SpawnCollectables(_collParams.Size);
        }
    }

    private void SetSpray(CollectableSpray spray)
    {
        if (spray)
        {
            Debug.Log("CollectableSpray Set");
            _spray = spray; 
        }
    }

    private void SprayCollectables(BasePersonView view)
    {
        _tempNumber = (int)(view.Points * 0.05f) + 1;
        for (int _index = 0; _index < _tempNumber; _index++)
        {
            _tempColl = _pool.GetObject(view.Position);
            _tempColl.gameObject.layer = (int)Layers.Collectables;
            _tempColl.Points = 10;
            _tempColl.NeedRespawn = false;
            _tempTransforms.Add(_tempColl.transform);
            GameEvents.Current.EnvironmentUpdated();
        }
        if (_spray)
        {
            _spray.SprayCollectables(_tempTransforms, 3f, 3f);
            _tempObj = GameObject.Instantiate(_mergeObj, view.Position, Quaternion.identity);
            //_tempObj.GetComponent<MeshFilter>().mesh = view.GetComponent<MeshFilter>().mesh;
            //_spray.SprayCollectable(_tempObj.transform, 0f, 2f);
        }
        _tempTransforms.Clear();
    }

    private void SetMergeObj(GameObject obj)
    {
        if (obj.Equals(null))
        {
            return;
        }
        _mergeObj = obj;
        _mergeObj.layer = (int) Layers.Merge;
        if (_mergeObj.TryGetComponent(out MeshFilter LOL).Equals(false))
        {
            _mergeObj.AddComponent<MeshFilter>();
            LOL = null;
        }
    }

    private void CalculateBounds(Vector3[] vertices, Transform ground)
    {
        _tempMaxX = vertices[0].x;
        _tempMaxY = vertices[0].y;
        _tempMaxZ = vertices[0].z;
        _tempMinX = vertices[0].x;
        _tempMinY = vertices[0].y;
        _tempMinZ = vertices[0].z;
        for (_index = 0; _index < vertices.Length; _index++)
        {
            
            if (vertices[_index].x > _tempMaxX)
            {
                _tempMaxX = vertices[_index].x;
            }
            if (vertices[_index].x < _tempMinX)
            {
                _tempMinX = vertices[_index].x;
            }
            if (vertices[_index].z > _tempMaxZ)
            {
                _tempMaxZ = vertices[_index].z;
            }
            if (vertices[_index].z < _tempMinZ)
            {
                _tempMinZ = vertices[_index].z;
            }
            if (vertices[_index].y > _tempMaxY)
            {
                _tempMaxY = vertices[_index].y;
            }
            if (vertices[_index].y < _tempMinY)
            {
                _tempMinY = vertices[_index].y;
            }
        }
        _tempMaxX = _tempMaxX * ground.localScale.x + ground.position.x;
        _tempMaxY = _tempMaxY * ground.localScale.y + ground.position.y;
        _tempMaxZ = _tempMaxZ * ground.localScale.z + ground.position.z;
        _tempMinX = _tempMinX * ground.localScale.x + ground.position.x;
        _tempMinY = _tempMinY * ground.localScale.y + ground.position.y;
        _tempMinZ = _tempMinZ * ground.localScale.z + ground.position.z;
        Debug.Log($"y{_tempMinY}  z{_tempMinZ}  x{_tempMinX}  y{_tempMaxY}  z{_tempMaxZ}  x{_tempMaxX}");
    }
}
