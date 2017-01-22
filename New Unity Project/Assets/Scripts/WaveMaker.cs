using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vectrosity;

public class WaveMaker : MonoBehaviour {

    public float freqBaseLS;
    public float freqBaseRS;

    public float freqRngLS;
    public float freqRngRS;

    public float ampBaseLS;
    public float ampRangeLS;

    public float ampBaseRS;
    public float ampRangeRS;

    public List<float> pointsLS = new List<float>();
    public List<float> pointsRS = new List<float>();

    private float periodLS;
    private float periodRS;

    public float LSUD;
    public float LSLR;
    public float RSUD;
    public float RSLR;

    public float[] points;

    private VectorLine graphicMain;
    private VectorLine graphicLeft;
    private VectorLine graphicRight;
    public Vector3[] valuesMain;
    public Vector3[] valuesLeft;
    public Vector3[] valuesRight;
    public int segmentNum;
    public float lineWidth;

    public Color mainLineCol;
    public Color leftLineCol;
    public Color rightLineCol;

    public int pointNum;

    // Use this for initialization
    void Start () {
        points = new float[pointNum];
        valuesMain = new Vector3[pointNum];
        valuesLeft = new Vector3[pointNum];
        valuesRight = new Vector3[pointNum];

        for (int i = 0; i < pointNum; i++)
        {
            pointsLS.Add(0);
            pointsRS.Add(0);
            points[i] = 0.0f;
            valuesMain[i] = Vector3.zero;
            valuesLeft[i] = Vector3.zero;
            valuesRight[i] = Vector3.zero;
        }
        InitLine();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        MakeNewPoint();
        CombinePoints();
        DrawLine();
	}

    void MakeNewPoint ()
    {
        float freqModLS = freqBaseLS + (freqRngLS * LSLR);
        float freqModRS = freqBaseRS + (freqRngRS * RSLR);
        float ampModLS = ampBaseLS + (ampRangeLS * LSUD);
        float ampModRS = ampBaseRS + (ampRangeRS * RSUD);

        periodLS += freqModLS * Time.fixedDeltaTime;
        periodRS += freqModRS * Time.fixedDeltaTime;

        float nextPointLS = ampModLS * Mathf.Sin(periodLS);
        float nextPointRS = ampModRS * Mathf.Sin(periodRS);

        pointsLS.Add(nextPointLS);
        pointsRS.Add(nextPointRS);

        pointsLS.RemoveAt(0);
        pointsRS.RemoveAt(0);
    }

    void CombinePoints()
    {
        for (int i = 0; i < pointNum; i++)
        {
            points[i] = (pointsLS[pointNum - 1 - i] + pointsRS[i]);
        }
    }

    void DrawLine()
    {
        for (int i = 0; i < pointNum; i++)
        {
            valuesMain[i] = new Vector3(-pointNum + (i * 2), points[i], 0);
            valuesLeft[i] = new Vector3(-20 - (i * .8f), pointsLS[i] / 7 - 48, 0);
            valuesRight[i] = new Vector3(20 + (i * .8f), pointsRS[i] / 7 - 48, 0);
        }
        graphicMain.MakeSpline(valuesMain);
        graphicLeft.MakeSpline(valuesLeft);
        graphicRight.MakeSpline(valuesRight);
        graphicMain.color = mainLineCol;
        graphicLeft.color = leftLineCol;
        graphicRight.color = rightLineCol;

        //graphicMain.Draw();
        //graphicLeft.Draw();
        //graphicRight.Draw();
    }

    public void InitLine()
    {
        graphicMain = new VectorLine("SquiggleMain", new List<Vector3>(segmentNum), null, lineWidth, LineType.Discrete, Joins.Weld);
        graphicLeft = new VectorLine("SquiggleLeft", new List<Vector3>(segmentNum), null, lineWidth, LineType.Discrete, Joins.Weld);
        graphicRight = new VectorLine("SquiggleRight", new List<Vector3>(segmentNum), null, lineWidth, LineType.Discrete, Joins.Weld);
    }

    public void ShutDownLine()
    {
        VectorLine.Destroy(ref graphicMain);
        VectorLine.Destroy(ref graphicLeft);
        VectorLine.Destroy(ref graphicRight);
    }
}
