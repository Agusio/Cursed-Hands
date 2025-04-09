using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

//Recibe inputs en Player, o vectores en caso de ser un Agent.
namespace AgentMVC
{
    public class AgentController
    {
        private AgentModel _m;
        private InputHandler _i;

        private Vector2 _direction;

        public AgentController(Agent agent)
        {
            _m = agent.Model;
            _i = agent.InputHandler;
            _direction = Vector3.zero;
        }

        public void UpdateController()
        {
            _direction = _i.InputVector;
            _m.Movement.MovementUpdate(_direction);
        }

        public void FixedUpdateController()
        {

        }
    }
}
