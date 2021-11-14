// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// //Снаряды По Кругу
// [CreateAssetMenu(fileName = "CircularProjectile", menuName = "ScriptableObjects/CircularProjectile", order = 1)]
// public class CircularProjectilePerk : AbstractPerk
// {
//     private float _angle;
//     private float _radius;
//     private float _delay;
//     private float _tempDelay;
//     private Vector3 _ceshPos;
//     private CircularProjectilePerk()
//     {
//         _typePerk = PerkType.Offence;
//         _maxLevel = 2;
//         _fixedExecute = true;

//         _angle = 0;
//         _radius = 5f;
//         _delay = 1f;
//     }

//     public override void Activate(Shooter shooter)
//     {
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
//         _ceshPos = shooter.transform.position;
//         _ceshPos.y = 0;
//         _angle += Time.deltaTime;
//         _tempDelay += Time.deltaTime;
//         var x = Mathf.Cos(_angle) * _radius;
//             var z = Mathf.Sin(_angle) * _radius;
//         //_angle = 360f;

        
//         for (int i = 0; i < shooter.ProjectileList.Count; i++)
//         {
//             _angle += i;
            
//             shooter.ProjectileList[i].transform.position = new Vector3(x, 0, z) + _ceshPos;
//         }



//         //foreach (var item in shooter.ProjectileList)
//         //{

//         //}

//         //shooter.transform.position = 
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