using UnityEngine;
using System.Collections;
public class MergeItem : MonoBehaviour
{
    private int _level = 1;
    private float _points = 1;
    private ObjectPool<CollectableItem> _pool;

    public ObjectPool<CollectableItem> Pool
    {
        set => _pool = value;
    }
    public int Level 
    {
        get => _level;
        set => _level = value;
    } 
    public float Points 
    {
        get => _points;
        set => _points = value;
    } 
    [SerializeField] private GameObject example;
    [SerializeField] private float radius;
    [SerializeField] float iterator = 0f;

    float tempRad;
    private Vector3 temp;
    IEnumerator Start()
    {
        Transform[] transforms = new Transform[(int)(_points * 0.1f)+1];
        Vector3[] basePos = new Vector3[transforms.Length];
        Vector3[] nextPos = new Vector3[transforms.Length];


        for (int i = 0; i < 10; i++)
        {
            transforms[i] = Instantiate(example, Vector3.up * 10f, Quaternion.identity).transform;
            basePos[i] = transforms[i].position;
            tempRad = Random.Range(0f,360f) * Mathf.Deg2Rad;
            nextPos[i] = new Vector3(Mathf.Cos(tempRad),0, Mathf.Sin(tempRad)) * radius;
        }

        bool count = true;
        while (count)
        {
            for (int j = 0; j < transforms.Length; j++)
            {
                temp = Vector3.Lerp(basePos[j],nextPos[j], iterator);
                temp.y = -10 * ((iterator-0.5f) * (iterator-0.5f)) + iterator; // Менять параболу тут
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