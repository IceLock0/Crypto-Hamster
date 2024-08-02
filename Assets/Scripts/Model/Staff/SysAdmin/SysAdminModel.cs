using System;
using System.Collections.Generic;
using System.Linq;
using Model.Computer;
using ModestTree;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.AI;

namespace Model.Staff.SysAdmin
{
    public class SysAdminModel : StaffModel
    {
        public SysAdminModel(SysAdminConfig sysAdminConfig, NavMeshAgent agent, List<ComputerModel> computers) : base(
            sysAdminConfig, agent)
        {
            BrokenModels = new Queue<ComputerModel>();

            Computers = new List<ComputerModel>();
            Computers = computers;

            FatigueValueReaction = sysAdminConfig.FatigueValueReaction;
            RepairSpeed = sysAdminConfig.RepairSpeed;
        }

        public List<ComputerModel> Computers { get; }
        public Queue<ComputerModel> BrokenModels { get; }
        public float FatigueValueReaction { get; }
        public float RepairSpeed { get; }

        public event Action ModelRemoved;

        public void AddBrokenModel(ComputerModel model)
        {
            if (!BrokenModels.Contains(model) && model.Quality > FatigueValueReaction)
                return;
            
            if(!BrokenModels.Contains(model) && model.Quality <= FatigueValueReaction)
                BrokenModels.Enqueue(model);

            if (BrokenModels.Contains(model) && model.Quality > FatigueValueReaction)
            {
                for (var i = 0; i < BrokenModels.Count; i++)
                {
                    var firstElement = BrokenModels.Dequeue();

                    if (firstElement == model)
                        continue;

                    BrokenModels.Enqueue(firstElement);
                }

                ModelRemoved?.Invoke();
            }
        }

        public float GetTimeToRepair()
        {
            var qualityToRepair = 100 - BrokenModels.Peek().Quality;

            var timeToRepair = RepairSpeed / 100 * qualityToRepair;

            return timeToRepair;
        }

        public void RemoveRepairedModel()
        {
            if (BrokenModels.IsEmpty())
                return;
            
            BrokenModels.Dequeue();
        }
    }
}