using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class AIHitState : AIState
{
	public AIHitState(AIStateAgent agent) : base(agent)
	{
		AIStateTransition transition = new AIStateTransition(nameof(AIIdleState));
		transition.AddCondition(new FloatCondition(agent.timer, Condition.Predicate.LESS, 0));
		transitions.Add(transition);
	}

	public override void OnEnter()
	{
		agent.movement.Stop();
		agent.movement.Velocity = Vector3.zero;
		agent.animator?.SetTrigger("Hit");
		agent.timer.value = 2;
	}

	public override void OnExit()
	{
		
	}

	public override void OnUpdate()
	{
		
	}
}
