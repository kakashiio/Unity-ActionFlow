using System.Collections.Generic;

namespace IO.Unity3D.Source.ActionFlow
{
    //******************************************
    //  
    //
    // @Author: Kakashi
    // @Email: john.cha@qq.com
    // @Date: 2023-09-07 22:49
    //******************************************
    public class OrCondition : ICondition
    {
        private List<ICondition> _Conditions;

        public OrCondition(List<ICondition> conditions)
        {
            _Conditions = conditions;
        }

        public bool Evaluate(IActionContext context)
        {
            foreach (var condition in _Conditions)
            {
                if (condition.Evaluate(context))
                {
                    return true;
                }
            }
            return false;
        }
    }
}