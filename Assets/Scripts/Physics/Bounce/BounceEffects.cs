using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceEffects 
{
    private readonly Rigidbody _rigidbody;
    private readonly BounceData _data;
    private readonly Vector3Curves _scaleCurves;

    public BounceEffects(Rigidbody rigidbody, BounceData bounceData, Vector3Curves scaleCurves)
    {
        _rigidbody = rigidbody;
        _data = bounceData;
        _scaleCurves = scaleCurves;
    }

    public void ApplyUpwardsScaleTo(Transform transform, Vector3 itialScale)
    {
        if (_rigidbody.velocity.y <= 0.0f)
        {
            
            return;

        }
           
        float percent = _rigidbody.velocity.y / _data.MaxHeight;

        Vector3 scale = new Vector3
        {
            x = _scaleCurves.XCurve.Evaluate(percent),
            y = _scaleCurves.YCurve.Evaluate(percent),
            z = _scaleCurves.ZCurve.Evaluate(percent)
        };
        transform.localScale = Vector3.Scale(itialScale, scale);
    }
}
