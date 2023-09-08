using System;
using System.Collections.Generic;

namespace IO.Unity3D.Source.ActionFlow
{
    //******************************************
    //  
    //
    // @Author: Kakashi
    // @Email: john.cha@qq.com
    // @Date: 2023-09-07 23:27
    //******************************************
    public class ParallelAction : IAction
    {
        private List<IAction> _Actions;
        private bool[] _Finished;

        public ParallelAction(List<IAction> actions)
        {
            _Actions = actions;
            _Finished = new bool[actions.Count];
        }

        public bool Execute(IActionContext context)
        {
            bool allFinish = true;
            for (int i = 0; i < _Actions.Count; i++)
            {
                if (_Finished[i])
                {
                    continue;
                }

                bool finish = _Actions[i].Execute(context);
                _Finished[i] = finish;
                if (!finish)
                {
                    allFinish = false;
                }
                else
                {
                    _Actions[i].End(context);
                }
            }
            return allFinish;
        }

        public void Start(IActionContext context)
        {
            for (int i = 0; i < _Actions.Count; i++)
            {
                _Actions[i].Start(context);
                _Finished[i] = false;
            }
        }

        public void End(IActionContext context)
        {
        }
    }
}