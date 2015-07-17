using System;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 运行状态显示类.
/// </summary>
public class Stats : MonoBehaviour
{
    private const string TEMPLATE = "FPS: <color=yellow>{0}</color> Target FPS: <color=yellow>{1}</color>\nMEM: <color=lime>{2}M</color> / <color=lime>{3}M</color>";

    private Text _text;

    private int _frame;
    private float _time;
    private string _targetFrameRate;

    void Start()
    {
        _frame = 0;
        _time = 0;
        _targetFrameRate = GetTargetFrameRate();

        _text = this.GetComponent<Text>();

        _text.text = String.Format(TEMPLATE, "--", _targetFrameRate, GetUseMemory(), GetTotalMemory());
    }

    private string GetTargetFrameRate()
    {
        if (Application.targetFrameRate == -1)
        {
            return "Fastest";
        }
        return Application.targetFrameRate.ToString();
    }
    
    void Update()
    {
        ++_frame;
        _time += Time.deltaTime;

        if(_time >= 1)
        {
            float fps = _frame / _time;
            _frame = 0;
            _time -= 1;

            _text.text = String.Format(TEMPLATE, fps.ToString("f1"), _targetFrameRate, GetUseMemory(), GetTotalMemory());
        }
    }

    private string GetUseMemory()
    {
        return (Profiler.GetMonoUsedSize() / 1048576).ToString("f1");
    }

    private string GetTotalMemory()
    {
        return (Profiler.GetMonoHeapSize() / 1048576).ToString("f1");
    }
}
