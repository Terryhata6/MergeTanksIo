using System;
using UnityEngine;

public class Projectile : BaseProjectile, IMoveProjectile
{
  private float _speed;
  private float _damage;

  // private float _timeTest = 0.3f; //TEST
  // private float _tempTime = 0f; //TEST
  // UnityEngine.Camera cam; //TEST
  // Collider col; //TEST
  // Plane[] planes; //TEST
  // protected bool _isViewCamera; //TEST
  // Renderer render; //TEST

  void Awake()
  {
    // cam = UnityEngine.Camera.main; //TEST
    // planes = GeometryUtility.CalculateFrustumPlanes(cam); //TEST
    // col = GetComponent<Collider>(); //TEST
    // render = GetComponent<Renderer>(); //TEST

  }
  // private void OnBecameVisible()
  // {
  //   if (cam.cameraType != CameraType.SceneView)
  //   {
  //     _isViewCamera = true;
  //   }
  // }
  // private void OnBecameInvisible()
  // {
  //   if (cam.cameraType != CameraType.SceneView)
  //   {
  //     _isViewCamera = false;
  //   }
  // }
  public void Move()
  {
    // if (cam.isGameObjectVisible(render))
    // {
    //   _isViewCamera = true; //TEST
    // }
    // else
    // {
    //   _isViewCamera = false;
    // } //TEST

    // if (GeometryUtility.TestPlanesAABB(planes, col.bounds)) //TEST
    // {
    //   Debug.Log("YES"); //TEST
    //   _isViewCamera = true; //TEST
    // }
    // else { Debug.Log("NO"); _isViewCamera = false; } //TEST

    // if (_isViewCamera) //TEST
    // {
      transform.Translate(transform.forward * (_speed * Time.deltaTime), Space.World);
    // }
    // else
    // {
    //   _tempTime += Time.deltaTime;
    //   if (_tempTime >= _timeTest)
    //   {
    //     Debug.Log("_isViewCamera: UpDate");

    //     transform.Translate(transform.forward * (_speed * _tempTime), Space.World);
    //     _tempTime = 0f;
    //   }
    // }

  }

  public void ChangeSpeed(float speed)
  {
    _speed = speed;
  }

  public void ChangeDamage(float damage)
  {
    _damage = damage;
  }

  protected override void InternalTriggerEnter(Collider otherCollider)
  {
    if (otherCollider.TryGetComponent(out IApplyDamage applyDamage))
    {
     Debug.Log("Попал");
      if (_damage <= 0) return;
      applyDamage.TakeDamage(_damage);
    }
  }

// private void OnDisable()
  // {
  //   ObjectPool<Projectile>.Instance.AddObject(this);
  // }
}