namespace IO.Unity3D.Source.ActionFlow
{
    //******************************************
    //  
    //
    // @Author: Kakashi
    // @Email: john.cha@qq.com
    // @Date: 2023-09-07 22:51
    //******************************************
    public class InverseCondition : ICondition
    {
        private ICondition _Condition;
        
        public bool Evaluate(IActionContext context)
        {
            return !_Condition.Evaluate(context);
        }
    }
}