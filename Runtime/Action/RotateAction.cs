using UnityEngine;

namespace IO.Unity3D.Source.ActionFlow
{
    //******************************************
    //  
    //
    // @Author: Kakashi
    // @Email: john.cha@qq.com
    // @Date: 2023-09-07 23:16
    //******************************************
    public class RotateAction : IAction
    {
        private GameObject _GameObject;
        private Quaternion _Src;
        private Quaternion _Dst;
        private float _Time;
        private AnimationCurve _Curve;

        private float _RotateTime;

        public RotateAction(GameObject gameObject, Quaternion src, Quaternion dst, float time, AnimationCurve curve)
        {
            _GameObject = gameObject;
            _Src = src;
            _Dst = dst;
            _Time = time;
            _Curve = curve;
        }

        public bool Execute(IActionContext context)
        {
            _RotateTime += context.GetDeltaTime();
            float r = _RotateTime / _Time;
            bool end = false;
            if (r >= 1)
            {
                r = 1;
                end = true;
            }

            _GameObject.transform.rotation = Quaternion.Lerp(_Src, _Dst, _Curve.Evaluate(r));
            return end;
        }

        public void Start(IActionContext context)
        {
            _RotateTime = 0;
        }

        public void End(IActionContext context)
        {
            _GameObject.transform.rotation = Quaternion.Lerp(_Src, _Dst, _Curve.Evaluate(1));
        }
    }
}