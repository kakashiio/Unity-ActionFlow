using System.Collections.Generic;

namespace IO.Unity3D.Source.ActionFlow
{
    //******************************************
    //  
    //
    // @Author: Kakashi
    // @Email: john.cha@qq.com
    // @Date: 2023-09-07 22:48
    //******************************************
    public class AndCondition : ICondition
    {
        private List<ICondition> _Conditions;

        public AndCondition(List<ICondition> conditions)
        {
            _Conditions = conditions;
        }

        public bool Evaluate(IActionContext context)
        {
            foreach (var condition in _Conditions)
            {
                if (!condition.Evaluate(context))
                {
                    return false;
                }
            }
            return true;
        }
    }
}