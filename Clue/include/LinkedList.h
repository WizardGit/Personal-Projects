//
// Created by Kaiser Slocum on 6/8/2019
// Edited by Kaiser Slocum on 6/20/2019
// All Rights Reserved by God
//

#ifndef LINKEDLIST_H
#define LINKEDLIST_H
#include "Node.h"
#include <iostream>
#include <sstream>
#include <stdexcept>

using namespace std;

class LinkedList
{
    private:
        Node * head;
        Node * tail;

    public:
        LinkedList(Node * h = nullptr, Node * t = nullptr);
        LinkedList(int headValue);
        virtual ~LinkedList();

        bool valueExists(int value);
        void deleteValue(int value);
        void addTailValue(int value);
        void addHeadValue(int value);

        int length();
        int getValue(int index);
        int getHighestValue();

        string linkedListString();

    protected:
};

#endif // LINKEDLIST_H
