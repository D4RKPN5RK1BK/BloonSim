using CoreLibrary.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Character.Helpers
{
    // todo мусор ....
    internal class WalkHelper
    {
        //private readonly BaseCharacterController _character;
        //private readonly GravityDataStorage _gravityData;
        //private readonly WalkHandler _walkHandler;

        //public WalkHelper(BaseCharacterController character, GravityDataStorage gravityData, WalkHandler walkHandler)
        //{
        //    _character = character;
        //    _gravityData = gravityData;
        //    _walkHandler = walkHandler;
        //}

        //public Vector3 GetWalkOffset()
        //{
        //    var model = _walkHandler.CurrentModel;
        //    var resultDirection = _character.ObservablePoint.ToLocal(_walkHandler.WalkDirection);
        //    var walkVelocity = new Vector3(_gravityData.Velocity.x, 0, _gravityData.Velocity.z);
        //    var deltaMove = (model.speedup + model.drag) * Time.deltaTime;
        //    var deltaDrag = model.drag * Time.deltaTime;
        //    var move = (walkVelocity + resultDirection * deltaMove).magnitude < model.maxForce
        //        ? deltaMove * resultDirection
        //        : Vector3.zero;
        //    var drag = walkVelocity.magnitude > deltaDrag
        //        ? deltaDrag * walkVelocity.normalized
        //        : walkVelocity;

        //    return move - drag;
        //}
    }
}
