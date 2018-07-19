using UnityEngine;
using System.Collections.Generic;
using DG.Tweening;
[RequireComponent(typeof(LineRenderer))]
[ExecuteInEditMode]
public class Bezier : MonoBehaviour {
    public List<Transform> controlPoints;
    public LineRenderer lineRenderer;

 //   private int layerOrder = 0;
    private int _segmentNum = 100;


    void Start() {
        if (!lineRenderer) {
            lineRenderer = GetComponent<LineRenderer>();
        }
    }

    public void GetChilTranform() {
        controlPoints.Clear();
        var count = transform.childCount;
        for (int i=0;i< count;i++) {
            controlPoints.Add(transform.GetChild(i));
        }
    }

    void Update() {
        GetChilTranform();
        calculate(controlPoints, 50);
        //  DrawCurve();
    }

    void DrawCurve() {
        for (int i = 1; i <= _segmentNum; i++) {
            float t = i / (float)_segmentNum;
            int nodeIndex = 0;
            Vector3 pixel = CalculateCubicBezierPoint(t, controlPoints[nodeIndex].position,
                controlPoints[nodeIndex + 1].position, controlPoints[nodeIndex + 2].position);
            lineRenderer.positionCount = i;
            lineRenderer.SetPosition(i - 1, pixel);
        }

    }

    Vector3 CalculateCubicBezierPoint(float t, Vector3 p0, Vector3 p1, Vector3 p2) {
        float u = 1 - t;
        float tt = t * t;
        float uu = u * u;

        Vector3 p = uu * p0;
        p += 2 * u * t * p1;
        p += tt * p2;

        return p;
    }

    Vector3 CalculateCubicBezierPointBase(float t, Vector3 p0, Vector3 p1) {
        float u = 1 - t;

        Vector3 p = u*p0;
        p += t*p1;
        return p;
    }


    public List<Vector3> calculate(List<Transform> poss, int precision) {

        //维度，坐标轴数（二维坐标，三维坐标...）
        int dimersion = 2;

        //贝塞尔曲线控制点数（阶数）
        int number = poss.Count;

        //控制点数不小于 2 ，至少为二维坐标系
        if (number < 2 || dimersion < 2)
            return null;

          List<Vector3> result = new List<Vector3>();

        //计算杨辉三角
        int[] mi = new int[number];
        mi[0] = mi[1] = 1;
        for (int i = 3; i <= number; i++) {

            int[] t = new int[i - 1];
            for (int j = 0; j < t.Length; j++) {
                t[j] = mi[j];
            }

            mi[0] = mi[i - 1] = 1;
            for (int j = 0; j < i - 2; j++) {
                mi[j + 1] = t[j] + t[j + 1];
            }
        }

        //计算坐标点
        for (int i = 0; i < precision; i++) {
            float t = (float)i / precision;
            Vector3 temp_ = new Vector3(0, 0, 0);
            for (int k = 0; k < number; k++) {
                temp_.x += Mathf.Pow(1 - t, number - k - 1) * poss[k].position.x * Mathf.Pow(t, k) * mi[k];
                temp_.y += Mathf.Pow(1 - t, number - k - 1) * poss[k].position.y * Mathf.Pow(t, k) * mi[k];
            }

            result.Add(temp_);
            lineRenderer.positionCount = i+1;
            lineRenderer.SetPosition(i, temp_);
        }
        return result;
    }
}