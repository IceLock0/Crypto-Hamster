using System;
using System.Collections.Generic;
using System.Linq;
using Model.Computer;
using ModestTree;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

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

          //  FatigueValueReaction = sysAdminConfig.FatigueValueReaction;
          //  RepairSpeed = sysAdminConfig.RepairSpeed;
        }

        public List<ComputerModel> Computers { get; }
        public Queue<ComputerModel> BrokenModels { get; }
        public float FatigueValueReaction { get; }
        public float RepairSpeed { get; }

        public event Action ModelRemoved;

        public void AddBrokenModel(ComputerModel model)
        {
            if (BrokenModels.Contains(model))
            {
                if (model.Quality > FatigueValueReaction)
                {
                    var brokenModelsCount = BrokenModels.Count;

                    for (int i = 0; i < brokenModelsCount; i++)
                    {
                        var element = BrokenModels.Dequeue();

                        if (model == element)
                            continue;
                        
                        BrokenModels.Enqueue(element);
                    }
                    ModelRemoved?.Invoke();
                }
            }
            else if (model.Quality <= FatigueValueReaction)
            {
                BrokenModels.Enqueue(model);
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