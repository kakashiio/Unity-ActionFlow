using System.Collections.Generic;

namespace IO.Unity3D.Source.ActionFlow
{
    //******************************************
    //  
    //
    // @Author: Kakashi
    // @Email: john.cha@qq.com
    // @Date: 2023-09-07 18:00
    //******************************************
    public class SequenceAction : IAction
    {
        private List<IAction> _Actions;
        private int _Index;
        private int _LastIndex = -1;

        public SequenceAction(List<IAction> actions)
        {
            _Actions = actions;
        }

        public bool Execute(IActionContext context)
        {
            while (_Index < _Actions.Count)
            {
                if (_LastIndex != _Index)
                {
                    _LastIndex = _Index;
                    _Actions[_Index].Start(context);
                }

                var finish = _Actions[_Index].Execute(context);
                if (!finish)
                {
                    return false;
                }
                _Actions[_Index].End(context);
                _Index++;
            }
            return _Index >= _Actions.Count;
        }

        public void Start(IActionContext context)
        {
            _Index = 0;
            _LastIndex = -1;
        }

        public void End(IActionContext context)
        {
        }
    }
}