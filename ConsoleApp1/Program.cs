using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            // MinCostCalculationDriverCode();
            // ShortestDistanceBetweenTwoNodesDriverCode();
        }
        
        // BST shortest distance between 2 nodes
        private static void ShortestDistanceBetweenTwoNodesDriverCode()
        {
            Node root = null;
            root = Insert(root, 20);
            Insert(root, 10);
            Insert(root, 5);
            Insert(root, 15);
            Insert(root, 30);
            Insert(root, 25);
            Insert(root, 35);
            Console.WriteLine(FindDistWrapper(root, 5, 10));
            Console.ReadLine();
        }

        // This function make sure that a is smaller  
        // than b before making a call to findDistWrapper()  
        private static int FindDistWrapper(Node root, int a, int b)
        {
            int temp = 0;
            if (a > b)
            {
                temp = a;
                a = b;
                b = temp;
            }

            return DistanceBetweenTwoNodes(root, a, b);
        }

        // Returns minimum distance beween a and b.  
        // This function assumes that a and b exist  
        // in BST.  
        private static int DistanceBetweenTwoNodes(Node root, int a, int b)
        {
            if (root == null)
            {
                return 0;
            }

            // both key lie on the left
            if (root.Key > a && root.Key > b)
            {
                return DistanceBetweenTwoNodes(root.Left, a, b);
            }

            // both key lie on the right
            if (root.Key < a && root.Key < b)
            {
                return DistanceBetweenTwoNodes(root.Right, a, b);
            }

            // one is on the left, other on the right
            // root is LCA
            if (root.Key >= a && root.Key <= b)
            {
                return DistanceFromRoot(root, a) + DistanceFromRoot(root, b);
            }

            return 0;
        }

        private static int DistanceFromRoot(Node root, int x)
        {
            if (root.Key == x)
            {
                return 0;
            }
            else if (root.Key > x)
            {
                return 1 + DistanceFromRoot(root.Left, x);
            }
            else
            {
                return 1 + DistanceFromRoot(root.Right, x);
            }
        }

        // Standard BST insert function  
        private static Node Insert(Node root, int key)
        {
            if (root == null)
            {
                root = CreateNewNode(key);
            }
            else if (key > root.Key)
            {
                root.Right = Insert(root.Right, key);
            }
            else if (key < root.Key)
            {
                root.Left = Insert(root.Left, key);
            }

            return root;
        }

        private static Node CreateNewNode(int key)
        {
            Node pointerNode = new Node();
            pointerNode.Key = key;
            pointerNode.Left = null;
            pointerNode.Right = null;
            return pointerNode;
        }


        // Min cost calculation
        private static void MinCostCalculationDriverCode()
        {
            // Min Cost Calculation driver code
            List<int> ropesList = new List<int>();
            ropesList.Add(8);
            ropesList.Add(4);
            ropesList.Add(6);
            ropesList.Add(12);
            Solution solutionClass = new Solution();
            solutionClass.MinCostCalculation(ropesList);
        }
    }


    public class Solution
    {
        public Boolean IsStringUnique(string str)
        {
            var characterArray = new bool[128];
            for (var i = 0; i < str.Length; i++)
            {
                var val = str[i];
                if (characterArray[val])
                {
                    return false;
                }

                characterArray[val] = true;
            }

            return true;
        }

        public int MinCostCalculation(List<int> ropes)
        {
            int totalCost = 0;

            while (ropes.Count > 1)
            {
                int sum = 0;
                ropes.Sort();
                sum = ropes[0] + ropes[1];
                totalCost += sum;
                ropes.RemoveAt(0);
                ropes.RemoveAt(0);
                // ropes.Add(sum);
            }

            return totalCost;
        }
    }

    public class Node
    {
        public Node Left, Right;
        public int Key;
    }
}