//
// Created by Kaiser Slocum on 6/8/2019
// Edited by Kaiser Slocum on 6/20/2019
// All Rights Reserved by God
//

#include "LinkedList.h"

// Sets the head and tail of the LinkedList to "h" and "t"
LinkedList::LinkedList(Node * h, Node * t)
{
    head = h;
    tail = t;
}
LinkedList::LinkedList(int headValue)
{
    Node * h = new Node(headValue, nullptr, nullptr);
    head = h;
    tail = nullptr;
}

// Deletes the LinkedList by deleting all Nodes inside of it
LinkedList::~LinkedList()
{
    while (head != nullptr)
    {
        Node * temp = head;
        head = head->getNext();
        delete temp;
    }
}

// Returns true if the value exists somewhere in the Linked List
bool LinkedList::valueExists(int value)
{
    Node * temp = head;
    while (temp != nullptr)
    {
        if (temp->getValue() == value)
            return true;
        temp = temp->getNext();
    }
    return false;
}

// Finds the first specified value in the list and deletes it if it is there
void LinkedList::deleteValue(int value)
{
    Node * temp = head;
    Node * prevNode;
    Node * nextNode;

    while (temp != nullptr)
    {
        prevNode = temp->getPrev();
        nextNode = temp->getNext();

        if (temp->getValue() == value)
        {
            if (temp == head)
            {
                head = temp->getNext();

                if (head != nullptr)
                    head->setPrev(nullptr);
                if (head == tail)
                    tail = nullptr;
            }
            else if (temp == tail)
            {
                tail = temp->getPrev();

                if (tail != nullptr)
                    tail->setNext(nullptr);
                if (head == tail)
                    tail = nullptr;
            }
            else
            {
                prevNode->setNext(nextNode);
                nextNode->setPrev(prevNode);
            }
            delete temp;
            temp = nullptr;
        }
        else
        {
            temp = temp->getNext();
        }
    }
}

// Adds the value to the back of the list
void LinkedList::addTailValue(int value)
{
    if (head == nullptr)
    {
        head = new Node(value);
    }
    else if (tail == nullptr)
    {
        tail = new Node(value, nullptr, head);
        head->setNext(tail);
    }
    else
    {
        Node * temp = new Node(value, nullptr, tail);
        tail->setNext(temp);
        tail = temp;
    }
}
// Adds the value to the front of the list
void LinkedList::addHeadValue(int value)
{
    if (head == nullptr)
    {
        head = new Node(value);
    }
    else if (tail == nullptr)
    {
        Node * temp = new Node(value, head, nullptr);
        tail = head;
        head = temp;
        tail->setPrev(head);
    }
    else
    {
        Node * temp = new Node(value, head, nullptr);
        head->setPrev(temp);
        head = temp;
    }
}
// Returns the length of the linked list
int LinkedList::length()
{
    int c = 0;
    Node * temp = head;

    while (temp != nullptr)
    {
        c++;
        temp = temp->getNext();
    }
    return c;
}
// Returns the integer at the specified index, does not delete the integer in the linked list
int LinkedList::getValue(int index)
{
    if(length() == 0)
        throw range_error("The linked list is empty!");
    else if(index >= length())
        throw range_error("The index is larger than the array!");

    Node * temp = head;
    int c = 0;

    while (temp != nullptr)
    {
        if (c == index)
        {
            return temp->getValue();
        }
        c++;
        temp = temp->getNext();
    }
    return c;
}
// Returns the highest integer, does not delete the integer in the linked list
int LinkedList::getHighestValue()
{
    if(length() == 0)
        throw range_error("The linked list is empty!");

    Node * temp = head;
    int c = temp->getValue();

    while (temp != nullptr)
    {
        if (temp->getValue() > c)
        {
            c = temp->getValue();
        }
        temp = temp->getNext();
    }
    return c;
}

// Returns a string of all of the Nodes' values
string LinkedList::linkedListString()
{
    stringstream values;
    Node * temp = head;
    while (temp != nullptr)
    {
        values << temp->getValue() << " ";
        temp = temp->getNext();
    }
    return values.str();
}
