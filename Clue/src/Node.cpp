//
// Created by Kaiser Slocum on 6/8/2019
// Edited by Kaiser Slocum on 6/8/2019
// All Rights Reserved by God
//

#include "Node.h"

Node::Node(int v, Node * n, Node * p)
{
    value = v;
    next = n;
    prev = p;
}

Node * Node::getNext()
{
    return next;
}
Node * Node::getPrev()
{
    return prev;
}
int Node::getValue()
{
    return value;
}

void Node::setNext(Node * n)
{
    next = n;
}
void Node::setPrev(Node * p)
{
    prev = p;
}
void Node::setValue(int v)
{
    value = v;
}
