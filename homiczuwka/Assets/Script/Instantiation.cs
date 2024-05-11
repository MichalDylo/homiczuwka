using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Instantiation : MonoBehaviour
{

    public Enemy demon;
    public Enemy angel;
    public Transform instantiateAreaOne;
    public Transform instantiateAreaTwo;
    public Transform controlPointOne;
    public Transform controlPointTwo;
    public Transform endPointOne;
    public Transform endPointTwo;

    private float _time = 3f;
    private float _pointCount = 5f;

    public float insCD = 3f;

    public bool stopInstantiate = false;

    public HunterSliderUI hunterSliderUI;

    // Start is called before the first frame update
    void Start()
    {

    }

    float timeMarker = 0;
    float stopTimerMarker = 0;
    // Update is called once per frame
    void Update()
    {
        if (stopInstantiate == true)
        {
            stopTimerMarker += Time.deltaTime;

            if (stopTimerMarker >= 7.0f)
            {
                stopTimerMarker = 0;
                stopInstantiate = false;
                hunterSliderUI.angelHunterSlider.value = 0;
                hunterSliderUI.demonHunterSlider.value = 0;
            }
            return;
        }

        timeMarker += Time.deltaTime;
        if (timeMarker <= insCD)
        {
            timeMarker += Time.deltaTime;
        }
        else
        {
            timeMarker = 0;
            InstatiationEnemy();
        }
    }

    public void InstatiationEnemy()
    {
        Enemy enemy_1 = Instantiate(demon, instantiateAreaOne.position, Quaternion.identity);
        enemy_1.EnemyType = (int)ObjectType.EnemyType.demon;
        DoAnim(enemy_1.gameObject, instantiateAreaOne.position, endPointOne.position, controlPointOne.position);

        Enemy enemy_2 = Instantiate(angel, instantiateAreaTwo.position, Quaternion.identity);
        enemy_2.EnemyType = (int)ObjectType.EnemyType.angel;
        DoAnim(enemy_2.gameObject, instantiateAreaTwo.position, endPointTwo.position, controlPointTwo.position);

    }

    public static Vector3 Bezier2(Vector3 start, Vector3 center, Vector3 end, float t)
    {
        return (1 - t) * (1 - t) * start + 2 * t * (1 - t) * center + t * t * end;
    }

    private Vector3[] Bezier2Path(Vector3 startPos, Vector3 controlPos, Vector3 endPos)
    {
        Vector3[] path = new Vector3[(int)_pointCount];
        for (int i = 1; i <= _pointCount; i++)
        {
            float t = i / _pointCount;
            path[i - 1] = Bezier2(startPos, controlPos, endPos, t);
        }
        return path;
    }

    private void DoAnim(GameObject obj, Vector3 startPos, Vector3 endPos,Vector3 controlPos)
    {
        obj.transform.position = startPos;
        Vector3[] pathvec = Bezier2Path(startPos, controlPos, endPos);
        obj.transform.DOPath(pathvec, _time);
    }
}