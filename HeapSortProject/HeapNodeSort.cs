using System.Collections;
using Microsoft.VisualBasic;

namespace HeapSort;

internal static class HeapNodeSort<T> where T : IComparable
{
    private static int depthOfTree;

    private enum Direction
    {
        Right,
        Left
    }




    private class Node
    {
        public Node? Left { get; set; }
        public Node? Right { get; set; }
        public T? Data { get; set; }

        
    }

    public static T[] HeapSort(T[] arr)
    {
       var n = TurnIntoNodes(arr); //This node holds the entire tree
       BuildMaxHeap(n);
       return SortArray(arr, n);
    }

    private static T[] SortArray(T[] arr, Node? node)
    {
        

        
        for (int i = arr.Length-1; i >= 0; i--)
        {
            depthOfTree = GetDepthOfTree(node);
            arr[i] = node!.Data;
            SwapAndRemoveLastNode(node, node, depthOfTree);
            Heapify(node);
        }

        return arr;
    }

    private static bool SwapAndRemoveLastNode(Node? n, Node? rootNode, int depth, int l = 1, int r = 1, bool foundSuitableNode = false)
    {
        


   
        
        if(n.Right is { Right: not null })
            foundSuitableNode = SwapAndRemoveLastNode(n.Right, rootNode, depth, ++r, l, foundSuitableNode);
        if(n.Left != null && n.Left.Left != null)
            foundSuitableNode = SwapAndRemoveLastNode(n.Left, rootNode,depth, r, ++l, foundSuitableNode);
        int currDepth = Math.Max(l, r);
        if (n.Right != null && currDepth == depth-1 && foundSuitableNode == false)
        {
            SwapNodeValues(n.Right, rootNode);
            n.Right = null;
            foundSuitableNode = true; 
           
        }
        else if (n.Left != null && currDepth == depth-1 && foundSuitableNode == false)
        {
            
            SwapNodeValues(n.Left, rootNode);
            n.Left = null;
            foundSuitableNode = true;
        }
        return foundSuitableNode;

        






    }

    private static int GetDepthOfTree(Node? node)
    {
        // Base case: If the node is null, return 0
        if (node == null)
            return 0;

        // Calculate the depth of the left subtree
        int leftDepth = GetDepthOfTree(node.Left);

        // Calculate the depth of the right subtree
        int rightDepth = GetDepthOfTree(node.Right);

        // The depth of the current node is one more than the maximum depth of its subtrees
        int currentDepth = 1 + Math.Max(leftDepth, rightDepth);

        return currentDepth;
    }

    private static Node? TurnIntoNodes(T[] arr, int i = 0)
    {
        


        if (i > arr.Length-1)
        {
            return null;
        }

        var n = new Node
        {
            Data = arr[i],
            Left = TurnIntoNodes(arr, 2 * i + 1),
            Right = TurnIntoNodes(arr, 2 * i + 2)
        };
        return n;
    }
    private static void BuildMaxHeap(Node? node)
    {


        if (node.Left != null)
        {
            //Base case is when the node is null
            BuildMaxHeap(node.Left);
        }

        if (node.Right != null)
        {
            BuildMaxHeap(node.Right); //Base case is when the node is null
            
        }
        Heapify(node);


    }
   

    private static void Heapify(Node node)
    {

        Direction? d = null;
        
        var maxNode = node;
        
        if (node.Left != null && node.Left.Data.CompareTo(maxNode.Data) > 0 )
        {
            maxNode = node.Left;
            d = Direction.Left;

        }

        if (node.Right != null && node.Right.Data.CompareTo(maxNode.Data) > 0)
        {
            maxNode = node.Right;
            d = Direction.Right;

        }

        if (!maxNode.Data.Equals(node.Data))
        {
            if (d.Equals(Direction.Left))
            {
                SwapNodeValues(node, node.Left!);
                Heapify(node.Left!);
            }
            else if(d.Equals(Direction.Right)){
                SwapNodeValues(node, node.Right!);
                Heapify(node.Right!);
                
            }
            

        }


    }

    private static void SwapNodeValues(Node node, Node maxNode)
    {
        
        Node holder = new Node
        {
            Data = node.Data
        };
        node.Data = maxNode.Data;
        maxNode.Data = holder.Data;
    }

    private static Node FindLastNodeNotUsedByProgramButCoolMethod(Node? n, int depth, int l = 0, int r = 0, bool foundSuitableNode = false)
    {
        if (foundSuitableNode)
            return n;

        if (n.Right is { Right: not null })
            FindLastNodeNotUsedByProgramButCoolMethod(n.Right, depth, ++r, l, foundSuitableNode);
        if (n.Left != null)
            FindLastNodeNotUsedByProgramButCoolMethod(n.Left, depth, r, ++l, foundSuitableNode);
        int currDepth = Math.Max(l, r);
        if (n.Left == null && n.Right == null && currDepth == depth)
        {
            foundSuitableNode = true; // Set the flag to true if a suitable node is found
            return n;
        }

        return null!;
    }
}