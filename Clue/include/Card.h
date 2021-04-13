//
// Created by Kaiser Slocum on 6/7/2019
// Edited by Kaiser Slocum on 6/29/2019
// All Rights Reserved by God
//

#ifndef CARD_H
#define CARD_H
#include <iostream>
#include <iomanip>
#include <stdexcept>
#include <sstream>
#include "LinkedList.h"

using namespace std;

class Card
{
    private:
        string name;
        string cardClass;
        int usageStatus;
        LinkedList * group;

    public:
        Card(string n, string c, int u);

        string getName();
        string getCardClass();
        int getUsageStatus();
        void setUsageStatus(int u);

        void addGroupNumber(int v);
        void deleteGroupNumber(int v);
        void deleteAllGroupNumbers();
        int numGroupNumbers();
        int getGroupNumber(int index);
        bool groupNumberExists(int v);
        int highestGroupNumber();

        string cardString();
        string allGroupNumbersString();

    protected:
};

#endif // CARD_H
