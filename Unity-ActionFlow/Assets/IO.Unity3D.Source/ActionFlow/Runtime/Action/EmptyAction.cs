namespace IO.Unity3D.Source.ActionFlow
{
    //******************************************
    //  
    //
    // @Author: Kakashi
    // @Email: john.cha@qq.com
    // @Date: 2023-09-07 18:20
    //******************************************
    public class EmptyAction : IAction
    {
        public static readonly IAction DEFAULT = new EmptyAction();

        public bool Execute(IActionContext context)
        {
            return true;
        }

        public void Start(IActionContext context)
        {
        }

        public void End(IActionContext context)
        {
        }
    }
}