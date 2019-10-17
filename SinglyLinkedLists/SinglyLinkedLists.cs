using System.IO;
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

    class SinglyLinkedList {
        public SinglyLinkedListNode head;
        public SinglyLinkedListNode tail;

        public SinglyLinkedList() {
            this.head = null;
            this.tail = null;
        }

        public void InsertNode(int nodeData) {
            SinglyLinkedListNode node = new SinglyLinkedListNode(nodeData);

            if (this.head == null) {
                this.head = node;
            } else {
                this.tail.next = node;
            }

            this.tail = node;
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

    static SinglyLinkedListNode reverseListIterative(SinglyLinkedListNode head)
    {

        SinglyLinkedListNode previousNode = null, current = head, nextNode = null;

        while (current != null)
        {
            nextNode = current.next;
            current.next = previousNode;
            previousNode = current;
            current = nextNode;
        }

        head = previousNode;

        return head;
    }

    static SinglyLinkedListNode reverseList(SinglyLinkedListNode head)
    {
        if (head == null)
            return null;

        if (head.next == null)
        {
           //This is hit when the end of the list is reached.
           //This returns the tail and is assigned as the "newHead." 
           return head;
        }
                                  
        SinglyLinkedListNode newHead = reverseList(head.next);                                           

        //Set the next node next to point back to the current node 
        head.next.next = head; 

        //Terminate list. This ensures the new last node is null terminated.
        head.next = null; 
        
        //newHead is only set when the end of the list is reaached.
        return newHead; 
    }

    static bool hasCycle(SinglyLinkedListNode head) 
    {

       //Floyd's cycle detection...
       //https://en.wikipedia.org/wiki/Cycle_detection
        
       var n1 = head; //The fast seek head 
       var n2 = head; //The slow seek head.

        while(n1.next != null && n1.next.next != null )
        {
            n1 = n1.next.next;
            n2 = n2.next;
            //If there is a cycle n1 will eventually
            //catch up to n2 and they will be equal.
            //IIRC this is a 1:2 resonance as seen 
            //between the orbits of Earth and Mars which
            //is why the optimal launch  windows to 
            //Mars is about every two years.

            if(n1 == n2)
                return true;
        }

    return false;
    }
    
    //Brute force
    static SinglyLinkedListNode mergeLists(SinglyLinkedListNode head1, SinglyLinkedListNode head2) 
    {

        if(head1 == null && head2 != null)
            return head2;
        if(head1 != null && head2 == null)
            return head1;
        if(head1 == null && head2 == null)
            return null;

        var newList = new SinglyLinkedList();
  
        while(true)
        {
            if((head1 == null) && (head2 == null))
               return newList.head;
            
            if(head1 == null && head2 != null)
            {
                newList.head = insertNodeAtTail(newList.head,head2.data);
                head2 = head2.next;
            }
            else if(head1 != null && head2 == null)
            {
                newList.head = insertNodeAtTail(newList.head,head1.data);
                head1 = head1.next;
            }
            else if(head1.data <= head2.data)
            {
                newList.head = insertNodeAtTail(newList.head,head1.data);
                head1 = head1.next;
            }
            else if (head1.data > head2.data)
            {
                newList.head = insertNodeAtTail(newList.head,head2.data);
                head2 = head2.next;
            }
        }
    }

    static SinglyLinkedListNode mergeListsRecursive(SinglyLinkedListNode head1, SinglyLinkedListNode head2) 
    {
        if (head1 == null && head2 == null) return null;

        else if (head1 == null) return head2; //burn through remaining items in head2
        else if (head2 == null) return head1; //burn through remaining items in head1
    
        if(head1.data <= head2.data)
        {
            head1.next = mergeListsRecursive(head1.next, head2);
        }
        else //head2 is smaller than head1
        {
            SinglyLinkedListNode temp = head2;
            head2 = head2.next;
            temp.next = head1;
            head1 = temp;
            head1.next = mergeListsRecursive(head1.next, head2);
        }
        return head1; 
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

    //Remove dupes from sorted list
    //This can be done recursivly but this is easier to read.
    static SinglyLinkedListNode removeDuplicates(SinglyLinkedListNode head) {

        if(head == null)
            return head;
        
        var index = head;

        while(index.next!= null)
        {
            if(index.data == index.next.data)
            {
                index.next = index.next.next;

            }
            else
            {
                index = index.next;
            }
        }
    
        return head;
    }

    static int getNode(SinglyLinkedListNode head, int positionFromTail) {
/*
        //Brute Force:
        List<int> data = new List<int>();
        var seekHead = head;
        while(seekHead != null)
        {
            data.Add(seekHead.data);
            seekHead = seekHead.next;
        }

        return data[data.Count - positionFromTail - 1 ];
         
 */
     // More elegant. I did not come up with this one, but it's cool.
     /* In a nutshell: "result" does not begin to advance until it is "positionFromTail" 
      * behind "current." Then they advance together. When current is null, result will
      * be where it needs to be.*/

        int index = 0;
        SinglyLinkedListNode current = head;
        SinglyLinkedListNode result = head;
        while(current!=null)
        {
            current=current.next;

            if (index++ > positionFromTail)
            {
                result=result.next;
            }
        }
        
        return result.data;

    }

    static void Main(string[] args)
    {
        //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        SinglyLinkedList llist = new SinglyLinkedList();
        SinglyLinkedList llist2 = new SinglyLinkedList();

        int llistCount = 4; // Convert.ToInt32(Console.ReadLine());
        int[] items = { 1, 3, 5, 7 };
        int[] items2 = { 0, 2, 4, 6 };
   
        for (int i = 0; i < llistCount; i++)
        {
            int llistItem = items[i];
            SinglyLinkedListNode llist_head = insertNodeAtTail(llist.head, llistItem);
            //SinglyLinkedListNode llist_head = insertNodeAtHead(llist.head, llistItem);
            llist.head = llist_head;
        }

        for (int i = 0; i < llistCount; i++)
        {
            int llistItem = items2[i];
            SinglyLinkedListNode llist_head = insertNodeAtTail(llist2.head, llistItem);
            
            llist2.head = llist_head;
        }

        /*
        int data = 66;
        int position = 3;
        var newHead = insertNodeAtPosition(llist.head, data, position);

        reversePrint(llist.head);
        var foo = reverseList(llist.head);
        reversePrint(foo);

        var result = CompareLists(foo,foo);
        result = CompareLists(foo,llist.head);
        */

        //var foo2 = reverseListIterative(llist.head);

        //var merged = mergeLists(llist.head,llist2.head);
        var merged = mergeListsRecursive(llist.head, llist2.head);
        reversePrint(merged);

        var foo = getNode(merged, 3);

        //PrintSinglyLinkedList(merged, "\n", textWriter);
        // textWriter.WriteLine();

        //textWriter.Flush();
        //textWriter.Close();
    }
}
