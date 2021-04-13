//
// Created by Kaiser Slocum on 6/8/2019
// Edited by Kaiser Slocum on 6/8/2019
// All Rights Reserved by God
//

#ifndef NODE_H
#define NODE_H

class Node
{
    private:
        Node * next;
        Node * prev;
        int value;
    public:
        Node(int v, Node * n = nullptr, Node * p = nullptr);

        Node * getNext();
        Node * getPrev();
        int getValue();

        void setNext(Node * n);
        void setPrev(Node * p);
        void setValue(int v);

    protected:
};

#endif // NODE_H
