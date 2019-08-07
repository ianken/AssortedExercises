using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;


// NOTE: the insert at head exercise is bugged on hackerrank for c#. 
// C++ solution:
/*

    SinglyLinkedListNode* insertNodeAtHead(SinglyLinkedListNode* llist, int data) {

    SinglyLinkedListNode *tmp = new SinglyLinkedListNode(data);

    if(llist == nullptr)
    {
        return tmp;
    }
    else
    {
        tmp->next = llist;
        return tmp;
    }
}
*/

class Solution
{

    class SinglyLinkedListNode
    {
        public int data;
        public SinglyLinkedListNode next;

        public SinglyLinkedListNode(int nodeData)
        {
            this.data = nodeData;
            this.next = null;
        }
    }

    class SinglyLinkedList
    {
        public SinglyLinkedListNode head;

        public SinglyLinkedList()
        {
            this.head = null;
        }

    }

    static void PrintSinglyLinkedList(SinglyLinkedListNode node, string sep, TextWriter textWriter)
    {
        while (node != null)
        {
            textWriter.Write(node.data);

            node = node.next;

            if (node != null)
            {
                textWriter.Write(sep);
            }
        }
    }

    // Complete the insertNodeAtTail function below.
    // Complete the insertNodeAtHead function below.

    /*
     * For your reference:
     *
     * SinglyLinkedListNode {
     *     int data;
     *     SinglyLinkedListNode next;
     * }
     *
     */
static SinglyLinkedListNode insertNodeAtHead(SinglyLinkedListNode llist, int data)
    {

        var newHead = new SinglyLinkedListNode(data);
        if (llist == null)
            return newHead;
        else
        {
            newHead.next = llist;
            return newHead;
        }

    }


    static SinglyLinkedListNode insertNodeAtTail(SinglyLinkedListNode head, int data)
    {
        var newNode = new SinglyLinkedListNode(data);

        if (head == null)
        {
            head = newNode;
        }
        else
        {

            var seek = head;

            while (seek.next != null)
                seek = seek.next;
            seek.next = newNode;

        }

        return head;
    }

    static void Main(string[] args)
    {
        //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        SinglyLinkedList llist = new SinglyLinkedList();

        int llistCount = 4; // Convert.ToInt32(Console.ReadLine());
        int[] items = { 1, 2, 3, 4 }
; for (int i = 0; i < llistCount; i++)
        {
            int llistItem = items[i];
            //SinglyLinkedListNode llist_head = insertNodeAtTail(llist.head, llistItem);
            SinglyLinkedListNode llist_head = insertNodeAtHead(llist.head, llistItem);
            llist.head = llist_head;

        }



        //PrintSinglyLinkedList(llist.head, "\n", textWriter);
        // textWriter.WriteLine();

        //textWriter.Flush();
        //textWriter.Close();
    }
}
