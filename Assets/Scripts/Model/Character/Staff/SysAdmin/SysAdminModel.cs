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
        public SysAdminModel(StaffConfig sysAdminConfig, NavMeshAgent agent, List<ComputerModel> computers) : base(
            sysAdminConfig, agent)
        {
            Computers = computers;

            BrokenModels = new Queue<ComputerModel>();
        }

        public List<ComputerModel> Computers { get; }
        public Queue<ComputerModel> BrokenModels { get; }

        public event Action ModelRemoved;

        public void UpdateQueue(ComputerModel model)
        {
            if (BrokenModels.Contains(model))
            {
                if (model.Quality > ValueReaction)
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
            else if (model.Quality <= ValueReaction)
            {
                BrokenModels.Enqueue(model);
            }

            if (BrokenModels != null && !BrokenModels.IsEmpty())
                DestinationPoint = BrokenModels.Peek().Position;
        }

        public float GetTimeToRepair() => GetTimeForJob(100 - BrokenModels.Peek().Quality);
        
        public override void RemoveProcessedData()
        {
            // if (BrokenModels == null || BrokenModels.IsEmpty())
            //     return;
            //
            // BrokenModels.Dequeue();
        }
    }
}