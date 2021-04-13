//
// Created by Kaiser Slocum on 6/8/2019
// Edited by Kaiser Slocum on 12/22/2019
// All Rights Reserved by God
//

#include "Hand.h"

Hand::Hand()
{
    hand = new Card * [21];
    *(hand + 0)  = new Card(ColMustard,     Suspect,    mayHas);
    *(hand + 1)  = new Card(ProfPlum,       Suspect,    mayHas);
    *(hand + 2)  = new Card(MrGreen,        Suspect,    mayHas);
    *(hand + 3)  = new Card(MrsPeacock,     Suspect,    mayHas);
    *(hand + 4)  = new Card(MissScarlett,   Suspect,    mayHas);
    *(hand + 5)  = new Card(MrsWhite,       Suspect,    mayHas);
    *(hand + 6)  = new Card(Knife,          Weapon,     mayHas);
    *(hand + 7)  = new Card(Candlestick,    Weapon,     mayHas);
    *(hand + 8)  = new Card(Revolver,       Weapon,     mayHas);
    *(hand + 9)  = new Card(Rope,           Weapon,     mayHas);
    *(hand + 10) = new Card(LeadPipe,       Weapon,     mayHas);
    *(hand + 11) = new Card(Wrench,         Weapon,     mayHas);
    *(hand + 12) = new Card(Hall,           Room,       mayHas);
    *(hand + 13) = new Card(Lounge,         Room,       mayHas);
    *(hand + 14) = new Card(DiningRoom,     Room,       mayHas);
    *(hand + 15) = new Card(Kitchen,        Room,       mayHas);
    *(hand + 16) = new Card(BallRoom,       Room,       mayHas);
    *(hand + 17) = new Card(Conservatory,   Room,       mayHas);
    *(hand + 18) = new Card(BilliardRoom,   Room,       mayHas);
    *(hand + 19) = new Card(Library,        Room,       mayHas);
    *(hand + 20) = new Card(Study,          Room,       mayHas);
}
Hand::~Hand()
{
    for (int i = 0; i < 21; i++)
    {
        delete *(hand + i);
    }
}

Card * Hand::getCard(int n)
{
    return *(hand + n);
}

string Hand::getName(int n)
{
    return (*(hand + n))->getName();
}

string Hand::handString()
{
    stringstream values;

    for (int i = 0; i < 21; i++)
    {
        Card * c = getCard(i);

        if (c->getUsageStatus() == has)
            values << "Has           ";
        else if (c->getUsageStatus() == noHas)
            values << "Does not have ";
        else if (c->getUsageStatus() == mayHas)
            values << "May have      ";
        else
            throw invalid_argument("The usageStatus is not recognized in playerString method!");
        values << c->getName() << "\n";
    }
    return values.str();
}

void Hand::setCard(string name)
{
    for (int i = 0; i < 21; i++)
    {
        if((*(hand + i))->getName() == name)
        {
            (*(hand + i))->setUsageStatus(has);
        }
    }
}
void Hand::detractCard(string name)
{
    for (int i = 0; i < 21; i++)
    {
        if((*(hand + i))->getName() == name)
        {
            (*(hand + i))->setUsageStatus(noHas);
        }
    }
}
void Hand::setCardsOfClass(string cardClass)
{
    if ((cardClass != Suspect) && (cardClass != Weapon) && (cardClass != Room))
        throw invalid_argument("The cardClass is not valid!");

    for (int i = 0; i < 21; i++)
    {
        Card * c = *(hand + i);

        if ((c->getCardClass() == cardClass) && (c->getUsageStatus() != noHas))
        {
            setCard(c->getName());
        }
    }
}
