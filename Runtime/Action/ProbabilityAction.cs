using UnityEngine;

namespace IO.Unity3D.Source.ActionFlow
{
    //******************************************
    //  
    //
    // @Author: Kakashi
    // @Email: john.cha@qq.com
    // @Date: 2023-09-07 18:56
    //******************************************
    public class ProbabilityAction : IAction
    {
        private float _Probability;
        private IAction _WithinProbabilityAction;
        private IAction _OutofProbabilityAction;
        
        private IAction _Action;

        public ProbabilityAction(float probability, IAction withinProbabilityAction, IAction outofProbabilityAction)
        {
            _Probability = probability;
            _WithinProbabilityAction = withinProbabilityAction;
            _OutofProbabilityAction = outofProbabilityAction;
        }

        public bool Execute(IActionContext context)
        {
            return _Action.Execute(context);
        }

        public void Start(IActionContext context)
        {
            _Action = Random.Range(0f, 1f) <= _Probability ? _WithinProbabilityAction : _OutofProbabilityAction;
            _Action.Start(context);
        }

        public void End(IActionContext context)
        {
            _Action.End(context);
        }
    }
}