using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AStar : PathFinding
{
    public override List<Node> FindPath(Node startNode, Node targetNode, out HashSet<Node> closedSet, in Grid grid)
    {
	    List<Node> openSet = new List<Node>(); // - Create open set
		closedSet = new HashSet<Node>();
		openSet.Add(startNode); // - Add start node to open set

		//  - while open set isn't empty do
		while (openSet.Count > 0)       // - while open set isn't empty do
		{
			Node node = openSet[0]; //  - set current node with first node in open list

			for (int i = 1; i < openSet.Count; i++)//  - loop on open set other nodes and
			{
				if (openSet[i].fCost < node.fCost)// - loop on open set other nodes and compare their total cost if the new node cost is lower set current node with this node
				{
					node = openSet[i];
				}
			}

			openSet.Remove(node);   //  - Remove current node from open set
			closedSet.Add(node);    //  - add current node to closed set

            
			if (node == targetNode) //  - Check if the current node is target node, if it is return the path
			{
				return RetracePath(startNode, targetNode); //  - hint: use retrace path method
			}

            
			foreach (Node neighbour in grid.GetNeighbours(node)) 
			{                                                      
				if (!neighbour.walkable || closedSet.Contains(neighbour))   
				{
					continue;
				}

				var idx = openSet.IndexOf(neighbour);
				var new_G_Cost = GetDistance(node, neighbour);
				var new_H_Cost = GetDistance(neighbour, targetNode);
				int newFCost = new_G_Cost + new_H_Cost;
				
				if (idx != -1 && newFCost < openSet[idx].fCost)
                    
				{
					openSet[idx].parent = node;
					openSet[idx].gCost = new_G_Cost;
					openSet[idx].hCost = new_H_Cost;
				}
				else if(idx == -1)      
				{
					neighbour.parent = node;
					neighbour.gCost = new_G_Cost;
					neighbour.hCost = new_H_Cost;
					openSet.Add(neighbour);
				}
			}
            
            
		}


	

		// 		- If neighbor it is walkable and it wasn't current (in closed set)

		// 			- Calculate total cost of the neighbor node
		//			- hint: use GetDistance to get g cost to travel to neighbor node from current node,
		//				and h cost between neighbor node and goal

		//          - If new f cost is lower than its current f cost or the node isn't added to open list yet, set its g cost, and h cost with the new cost
		//          and its new parent node

		//      - if it isn't added to open set, add it

		return new List<Node>();
    }
}
