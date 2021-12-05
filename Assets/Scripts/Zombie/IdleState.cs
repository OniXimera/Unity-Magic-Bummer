
public class IdleState : State
{
    //fix 05.12.2021
    public override void Action()
    {
        _animator.SetInteger("MoveTip", 0);
    }
}
