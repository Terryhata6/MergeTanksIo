// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// //Снаряды По Кругу
// [CreateAssetMenu(fileName = "CircularProjectile", menuName = "ScriptableObjects/CircularProjectile", order = 1)]
// public class CircularProjectilePerk : AbstractPerk
// {
//     [SerializeField] private float _angle;
//     [SerializeField] private float _radius;
//     private float _delay;
//     private float _tempDelay;
//     private Vector3 _ceshPos;

//     public override void Activate(Shooter ownShoot)
//     {
//         _ownShooter = ownShoot;
//         //projectile.transform.forward = 
//         // Vector3 result = Vector3.forward * 1f;
//         // result = Quaternion.Euler(0,_timeCounter,0) * result;
//         // projectile.transform.forward = result;

//         // for (int i = 0; i < 20; i++)
//         // {

//         //     float angle = i * (2 * 3.14159f / 10);

//         //     float x = Mathf.Cos(angle) * 22f;
//         //     float y = 0f;
//         //     float z = Mathf.Sin(angle) * 22f;
//         //     _result = new Vector3(_result.x + x, y, _result.z + z);
//         //     Vector3 startPos = Vector3.zero;
//         //     Vector3 endPos = _result;
//         //     Debug.DrawLine(startPos, endPos);
//         //     for (int t = 0; t < 20; t++)
//         //     {
//         //     x = Mathf.Cos(angle) * 22f;
//         //     y = 0f;
//         //     z = Mathf.Sin(angle) * 22f;
//         //     _result = new Vector3(_result.x + x, y, _result.z + z);
//         //     Vector3 startPoss = Vector3.zero;
//         //     Vector3 wwendPos = endPos;
//         //         Debug.DrawLine(endPos, wwendPos);
//         //     }
//         // }
//         // Debug.DrawLine(Vector3.zero, new Vector3(10f,0,0) * Time.deltaTime, Color.red);
//         // Debug.DrawLine(new Vector3(10f,0,0), new Vector3(10f,0,10f), Color.blue);
//         // Debug.DrawLine(new Vector3(10f,0,10f), new Vector3(-20f,0,10f), Color.green);



//         //foreach (var item in shooter.ProjectileList)
//         //{

//         //}

//         //shooter.transform.position = 
//     }

//     public override void UpdateFixedExecute(Projectile ownProjectile)
//     {
//         base.UpdateFixedExecute(ownProjectile);
//         _ceshPos = _ownShooter.transform.position;
//         _ceshPos.y = 0;

//         //_angle = 0;
//         //_radius = 10f;
//         //_angle += Time.deltaTime;
//         //_tempDelay += Time.deltaTime;

//         _angle += Time.deltaTime;
//         Debug.Log(_angle);

//         var x = Mathf.Cos(_angle * 0.3f) * _radius;
//         var z = Mathf.Sin(_angle * 0.3f) * _radius;
//         var vec = new Vector3(x, 0, z) + _ceshPos;
//         // Debug.DrawLine(_ceshPos, vec, Color.red);
//         ownProjectile.transform.forward = vec;
//     }

//     protected override void InternalAddLevel()
//     {
//         // TODO
//     }

//     protected override void InternalRemoveLevel()
//     {
//         // TODO
//     }
// }