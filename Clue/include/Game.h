//
// Created by Kaiser Slocum on 6/7/2019
// Last edited by Kaiser Slocum on 12/22/2019
// All Rights Reserved by God
//

#ifndef GAME_H
#define GAME_H
#include "Player.h"
#include "Card.h"
#include "Hand.h"
#include <iostream>
#include <stdexcept>
#include <sstream>

using namespace std;

class Game
{
    int const has = 1;
    int const noHas = 2;
    int const mayHas = 3;

    Hand * masterHand;
    Player * (*playerArray);
    int numPlayers;

    public:
        Game(int np);
        virtual ~Game();

        Game(string nameA, string nameB, int cardsA = 3, int cardsB = 3);
        Hand * getMasterHand();
        Player * getPlayer(int index);

        bool validateEighteenCards();
        string displayAllPlayers();
        string displayMasterHand();
        void initiateTurn(int playerIndex);
        void initiateRoundOfTurns();

        bool solutionFound();
        void getSolutionFound(string& suspect, string& weapon, string& room);

        void update();
        void updateMaster();
        void updateMasterSegment(int startIndex, int endIndex);
        void updatePlayers();

        bool aPlayerHasCard(string cardName);
        bool noPlayerHasCard(string cardName);
        bool transitionPlayersToMaster();
        bool ensureNoPlayerHasCard(string cardName);
        bool ensureNoPlayerButOneHasCard(string cardName);
        bool transitionMasterToPlayers();

    protected:
};

#endif // GAME_H
