//
// Created by Kaiser Slocum on 6/7/2019
// Last edited by Kaiser Slocum on 12/15/2019
// All Rights Reserved by God
//

#ifndef PLAYER_H
#define PLAYER_H
#include <iostream>
#include <stdexcept>
#include <iomanip>
#include <sstream>
#include <limits>
#include "Card.h"
#include "Hand.h"

using namespace std;

class Player
{
    private:
    protected:
        int const has = 1;
        int const noHas = 2;
        int const mayHas = 3;

        Hand hand;
        string name;
        int numCards;
        int currentGroupNumber = 1;
        bool masterPlayer = false;

    public:
        Player(int playerNumber, bool mPlayer = false);
        void SetupMasterPlayer(int playerNumber);
        Player(string playerName, int playerNumCards, bool mPlayer = false);
        virtual ~Player();

        string getName();
        int getNumCards();
        bool getMasterPlayer();

        void setCard(string cardName);
        void setCardGroup(string cardName, int groupNumber);
        void detractCard(string cardName);
        void detractCards(string suspect, string weapon, string room);

        bool doesHaveCard(string cardName);
        bool doesHaveACard(string suspect, string weapon, string room);
        bool doesNotHaveCard(string cardName);
        bool isValidCard(string cardName);
        bool isValidSuspect(string cardName);
        bool isValidWeapon(string cardName);
        bool isValidRoom(string cardName);
        bool onlyCardWithGroup(int groupNumber);
        bool forcedCardExists();

        Card * getOnlyCardWithGroup(int groupNumber);
        Card * getCardWithName(string cardName);
        Card * getCard(int index);

        int highestGroupNumber();
        int numberOfUsageStatus(int u);
        int knownCardsHeld();

        void resetCardsOfGroup(int groupNumber);
        bool updateMaxCards();
        bool updateGroupCards();
        void updatePlayer();
        void askAccusation(string& suspect, string& weapon, string& room);
        void addGroupToCards(string suspect, string weapon, string room);
        void requestCard(string suspect, string weapon, string room);
        void askAndSetPlayerCard();

        string playerString();
        string displayCard(int index);
};

#endif // PLAYER_H
