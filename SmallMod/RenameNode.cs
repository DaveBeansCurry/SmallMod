using System;
using Hacknet;
using Pathfinder.Action;
using Pathfinder.Meta.Load;
using Pathfinder.Util;

namespace RenameNode
{
    // Starts Custom Tracer, called Eulogy
    [Action("RenameNode")]
    public class RenameNode : DelayablePathfinderAction
    {
        [XMLStorage]
        public string compId;

        [XMLStorage]
        public string name;

        // Action Trigger
        public override void Trigger(OS os)
        {
            if (string.IsNullOrEmpty(compId) || string.IsNullOrEmpty(name))
            {
                os.write("Error: compId or name is null or empty.");
                return;
            }

            Computer comp = ComputerLookup.FindById(compId);
            if (comp == null)
            {
                os.write($"Error: No computer found with id {compId}.");
                return;
            }

            comp.name = name;
            os.write($"Computer with id {compId} renamed to {name}.");
        }
    }
}
