using UnityEngine;

namespace IO.Unity3D.Source.ActionFlow
{
    //******************************************
    //  
    //
    // @Author: Kakashi
    // @Email: john.cha@qq.com
    // @Date: 2023-09-07 23:11
    //******************************************
    public class MoveAction : IAction
    {
        private GameObject _GameObject;
        private Vector3 _Src;
        private Vector3 _Dst;
        private float _Time;
        private AnimationCurve _Curve;

        private float _MoveTime;

        public MoveAction(GameObject gameObject, Vector3 src, Vector3 dst, float time, AnimationCurve curve)
        {
            _GameObject = gameObject;
            _Src = src;
            _Dst = dst;
            _Time = time;
            _Curve = curve;
        }

        public bool Execute(IActionContext context)
        {
            _MoveTime += context.GetDeltaTime();
            float r = _MoveTime / _Time;
            bool end = false;
            if (r >= 1)
            {
                r = 1;
                end = true;
            }

            _GameObject.transform.position = Vector3.Lerp(_Src, _Dst, _Curve.Evaluate(r));
            return end;
        }

        public void Start(IActionContext context)
        {
            _MoveTime = 0;
        }

        public void End(IActionContext context)
        {
            _GameObject.transform.position = Vector3.Lerp(_Src, _Dst, _Curve.Evaluate(1));
            Debug.Log("Move End");
        }
    }
}