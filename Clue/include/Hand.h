//
// Created by Kaiser Slocum on 6/8/2019
// Edited by Kaiser Slocum on 7/21/2019
// All Rights Reserved by God
//

#ifndef HAND_H
#define HAND_H
#include <iostream>
#include <stdexcept>
#include <iomanip>
#include <sstream>
#include "Card.h"

using namespace std;

class Hand
{
    private:
        int const has = 1;
        int const noHas = 2;
        int const mayHas = 3;
        int const noGroup = 0;

        string const Suspect = "Suspect";
        string const ColMustard = "ColMustard";
        string const ProfPlum = "ProfPlum";
        string const MrGreen = "MrGreen";
        string const MrsPeacock = "MrsPeacock";
        string const MissScarlett = "MissScarlett";
        string const MrsWhite = "MrsWhite";

        string const Weapon = "Weapon";
        string const Knife = "Knife";
        string const Candlestick = "Candlestick";
        string const Revolver = "Revolver";
        string const Rope = "Rope";
        string const LeadPipe = "LeadPipe";
        string const Wrench = "Wrench";

        string const Room = "Room";
        string const Hall = "Hall";
        string const Lounge = "Lounge";
        string const DiningRoom = "DiningRoom";
        string const Kitchen = "Kitchen";
        string const BallRoom = "BallRoom";
        string const Conservatory = "Conservatory";
        string const BilliardRoom = "BilliardRoom";
        string const Library = "Library";
        string const Study = "Study";

        Card * (*hand);
    public:
        Hand();
        ~Hand();

        Card * getCard(int n);
        string getName(int n);
        string handString();

        void setCard(string name);
        void setCardsOfClass(string cardClass);
        void detractCard(string name);
    protected:
};

#endif // HAND_H
