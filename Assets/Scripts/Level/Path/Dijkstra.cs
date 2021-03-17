using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dijkstra : PathFinding
{
    public override List<Node> FindPath(Node startNode, Node targetNode, out HashSet<Node> closedSet, in Grid grid)
    {
        
        List<Node> openSet = new List<Node>();    // - Create open set
        
        closedSet = new HashSet<Node>();
        openSet.Add(startNode);     // - Add start node to open set

        
        while (openSet.Count > 0)       // - while open set isn't empty do
        {
            Node node = openSet[0]; //  - set current node with first node in open list

            for (int i = 1; i < openSet.Count; i++)//  - loop on open set other nodes and
            {
                if (openSet[i].gCost < node.gCost)// compare their g cost if the new node cost is lower set current node with this node
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
                var gcost = GetDistance(node, neighbour);     
                                                                              
                
                if (idx != -1 && openSet[idx].gCost > gcost)
                    
                {
                    openSet[idx].parent = node;
                    openSet[idx].gCost = neighbour.gCost;
                }
                else if(idx == -1)      
                {
                    neighbour.parent = node;
                    neighbour.gCost = gcost;
                    openSet.Add(neighbour);
                }
            }
            
            /*foreach (Node neighbour in grid.GetNeighbours(node))//  - For each neighbor node to current node
            { //  - hint use grid.GetNeighbors
                if (!neighbour.walkable || closedSet.Contains(neighbour))//      - If neighbor it is walkable and it wasn't current (in closed set)
                {
                    continue;
                }

                int newCostToNeighbour = GetDistance(neighbour, targetNode); // - Calculate g cost of the neighbor node   // - hint: use GetDistance to get g cost to travel to neighbor node from current node
                if (newCostToNeighbour < neighbour.hCost || !openSet.Contains(neighbour))//- If new g cost is lower than its current g cost or the node isn't added to open list yet, set its g cost with the new cost
                {
                    neighbour.hCost = newCostToNeighbour;
                    neighbour.parent = node;    //and its new parent node

                    if (!openSet.Contains(neighbour))
                        openSet.Add(neighbour);     //- if it isn't added to open set, add it
                }
            }*/
            
        }

        return new List<Node>();
    }
}
