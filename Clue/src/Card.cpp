//
// Created by Kaiser Slocum on 6/7/2019
// Last edited by Kaiser Slocum on 12/15/2019
// All Rights Reserved by God
//

#include "Card.h"

Card::Card(string n, string c, int u)
{
    name = n;
    cardClass = c;
    usageStatus = u;

    group = new LinkedList();
}

string Card::getName()
{
    return name;
}
string Card::getCardClass()
{
    return cardClass;
}
int Card::getUsageStatus()
{
    return usageStatus;
}
void Card::setUsageStatus(int u)
{
    usageStatus = u;
}

void Card::addGroupNumber(int v)
{
    group->addTailValue(v);
}
void Card::deleteGroupNumber(int v)
{
    group->deleteValue(v);
}
void Card::deleteAllGroupNumbers()
{
    delete group;
    group = new LinkedList();
}
int Card::numGroupNumbers()
{
    return group->length();
}
int Card::getGroupNumber(int index)
{
    return group->getValue(index);
}
bool Card::groupNumberExists(int v)
{
    return group->valueExists(v);
}
int Card::highestGroupNumber()
{
    return group->getHighestValue();
}

string Card::cardString()
{
    stringstream values;

    values << "Name: " << left << setw(12) << name << " CardClass: " << setw(7) << cardClass <<" UsageStatus: " << setw(1) << usageStatus << " GroupNumbers: " << allGroupNumbersString();

    return values.str();
}
string Card::allGroupNumbersString()
{
    return group->linkedListString();
}
