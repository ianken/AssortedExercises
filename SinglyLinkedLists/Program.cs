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

    static SinglyLinkedListNode insertNodeAtPosition(SinglyLinkedListNode head, int data, int position) {

        var newNode = new SinglyLinkedListNode(data);

        if(head == null)
        {
            return newNode;
        }

        SinglyLinkedListNode seekHead = head;
        SinglyLinkedListNode previousNode = head;

        int i = 0;

        while( i != position)
        {
            previousNode = seekHead;            
            seekHead = seekHead.next;
            
            i++;
        }

        //Insert at begining
        if(seekHead == head)
        {
            newNode.next = head;
            head = newNode;
        }
        else 
        {
            previousNode.next = newNode;
            newNode.next = seekHead;
         }
               
        return head;
    }

    static void reversePrint(SinglyLinkedListNode head)
    {

        if (head == null)
            return;

        if (head.next == null)
        {
            Console.WriteLine(head.data);
            return;
        }
        else
        {
            reversePrint(head.next);
            Console.WriteLine(head.data);
        }
    }

    static bool CompareLists(SinglyLinkedListNode head1, SinglyLinkedListNode head2) 
    {
        var index1 = head1;
        var index2 = head2;

        if(head1 == null || head2 == null)
            return false;

        var result = true;

        while(index1 != null && index2 != null)
        {
            if(index1.data != index2.data)
                result = false;
            
            index1 = index1.next;
            index2 = index2.next;
        }

        //Both should be null
        if(index1 != index2)
            result = false;

        return result;

    }

    static SinglyLinkedListNode reverseList(SinglyLinkedListNode head)
    {
        if (head == null)
            return null;

        if (head.next == null)
        {
           //This is hit when the end of the list is reached.
           //This returns the tail and is assigned to "newHead." 
           return head;
        }
        
        SinglyLinkedListNode newHead = reverseList(head.next); 

        //Set the next node next to point back to the current node 
        head.next.next = head; 
        //Terminate list
        head.next = null; 
        
        //newHead is only set when the end of the list is reaached.
        return newHead; 
    }

    static bool hasCycle(SinglyLinkedListNode head) 
    {

       //Floyd's cycle detection...

       var n1 = head;
       var n2 = head;

        while(n1.next != null && n1.next.next != null )
        {
            n1 = n1.next.next;
            n2 = n2.next;
            
            if(n1 == n2)
                return true;
        }

    return false;
    }

    static SinglyLinkedListNode deleteNode(SinglyLinkedListNode head, int position)
    {

        SinglyLinkedListNode seekHead = head;
        SinglyLinkedListNode previousNode = head;

        int i = 0;

        while (i != position)
        {
            previousNode = seekHead;
            seekHead = seekHead.next;

            i++;
        }

        //Delete Head
        if (seekHead == previousNode)
        {
            if (seekHead.next != null)
                return seekHead.next;
            else //only one item in the list
                return null;
        }
                
        //end of list
        if (seekHead.next == null)
        {
            previousNode.next = null;
            return head;
        }

        previousNode.next = seekHead.next;
        return head;
    }

    static void Main(string[] args)
    {
        //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        SinglyLinkedList llist = new SinglyLinkedList();

        int llistCount = 4; // Convert.ToInt32(Console.ReadLine());
        int[] items = { 1, 2, 3, 4 };
   
        for (int i = 0; i < llistCount; i++)
        {
            int llistItem = items[i];
            //SinglyLinkedListNode llist_head = insertNodeAtTail(llist.head, llistItem);
            SinglyLinkedListNode llist_head = insertNodeAtHead(llist.head, llistItem);
            llist.head = llist_head;
        }

        int data = 66;
        int position = 3;
        var newHead = insertNodeAtPosition(llist.head, data, position);

        reversePrint(llist.head);
        var foo = reverseList(llist.head);
        reversePrint(foo);

        var result = CompareLists(foo,foo);
        result = CompareLists(foo,llist.head);

        //PrintSinglyLinkedList(llist.head, "\n", textWriter);
        // textWriter.WriteLine();

        //textWriter.Flush();
        //textWriter.Close();
    }
}
