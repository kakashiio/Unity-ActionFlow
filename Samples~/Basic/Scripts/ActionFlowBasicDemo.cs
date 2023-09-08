using System.Collections.Generic;
using IO.Unity3D.Source.ActionFlow;
using IO.Unity3D.Source.ActionFlow.Runtime;
using UnityEngine;

namespace IO.Unity3D.Source.ActionaFlow.Samples
{
    //******************************************
    //  
    //
    // @Author: Kakashi
    // @Email: john.cha@qq.com
    // @Date: 2023-09-07 17:58
    //******************************************
    public class ActionFlowBasicDemo : MonoBehaviour
    {
        public GameObject Cube;
        public AnimationCurve MoveCurve;
        public float MoveTime = 3;
        public Vector3 MoveOffset = Vector3.up * 5;
        public AnimationCurve RotationCurve;
        public float RotateTime = 3;
        public float RotateAngle = 180;
        
        private IAction _Action;
        private IActionContext _ActionContext;
        
        private void Start()
        {
            _ActionContext = new BaseActionContext();
            _Action = new ForAction(3, _BuildMotion02Action());
            _Action.Start(_ActionContext);
        }

        private IAction _BuildMotion01Action()
        {
            return new SequenceAction(new List<IAction>()
            {
                new MoveAction(Cube, Cube.transform.position, Cube.transform.position + MoveOffset, MoveTime, MoveCurve),
                new RotateAction(Cube, Cube.transform.rotation, Quaternion.Euler(Cube.transform.rotation.eulerAngles + Vector3.up * RotateAngle), RotateTime, RotationCurve)
            });
        }

        private IAction _BuildMotion02Action()
        {
            return new ParallelAction(new List<IAction>()
            {
                new MoveAction(Cube, Cube.transform.position, Cube.transform.position + MoveOffset, MoveTime, MoveCurve),
                new ForAction(Mathf.CeilToInt(MoveTime / RotateTime), new RotateAction(Cube, Cube.transform.rotation, Quaternion.Euler(Cube.transform.rotation.eulerAngles + Vector3.up * RotateAngle), RotateTime, RotationCurve))
            });
        }

        private void Update()
        {
            if (_Action != null && _Action.Execute(_ActionContext))
            {
                _Action.End(_ActionContext);
                _Action = null;
            }
        }
    }
}