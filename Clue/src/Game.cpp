//
// Created by Kaiser Slocum on 6/7/2019
// Last edited by Kaiser Slocum on 12/22/2019
// All Rights Reserved by God
//

#include "Game.h"

Game::Game(int np)
{
    if ((np < 2) || (np > 6))
        throw invalid_argument("There cannot be less than 2 players or more than 6 players!");

    numPlayers = np;
    masterHand = new Hand();
    playerArray = new Player * [numPlayers];

    Player * p = new Player(1, true);
    *(playerArray + 0) = p;

    for (int i = 1; i < numPlayers; i++)
    {
        Player * p = new Player(i + 1, false);
        *(playerArray + i) = p;
    }

    if (validateEighteenCards() == false)
        throw invalid_argument("A total of eighteen cards was NOT entered!");
    update();
}

//Don't actually use in the problem - ONLY for testing
Game::Game(string nameA, string nameB, int cardsA, int cardsB)
{
    numPlayers = 2;
    masterHand = new Hand();
    playerArray = new Player * [numPlayers];

    Player * pA = new Player(nameA, cardsA, true);
    *(playerArray + 0) = pA;

    Player * pB = new Player(nameB, cardsB, false);
    *(playerArray + 1) = pB;

    update();
}
Hand * Game::getMasterHand()
{
    return masterHand;
}
Player * Game::getPlayer(int index)
{
    if ((index >= numPlayers) || (index < 0))
        throw invalid_argument("The index is outside of the bounds of the array!");
    else
        return *(playerArray + index);
}

Game::~Game()
{
    for (int i = 0; i < numPlayers; i++)
    {
        delete *(playerArray + i);
    }
}
bool Game::validateEighteenCards()
{
    int totalCards = 0;
    for (int i = 0; i < numPlayers; i++)
    {
        totalCards += (*(playerArray + i))->getNumCards();
    }

    if (totalCards == 18)
        return true;
    else
        return false;
}

void Game::initiateTurn(int playerIndex)
{
    string answer = " ";

    do
    {
       cout << "Is " << (*(playerArray + playerIndex))->getName() << " making an accusation?:";
        cin >> answer;
    } while ((answer != "Yes") && (answer != "yes") && (answer != "No") && (answer != "no"));

    if ((answer == "yes") || (answer == "Yes"))
    {
        if ((playerIndex < 0) || (playerIndex >= numPlayers))
            throw invalid_argument("The playerIndex is outside the bounds of the array.");

        string suspect = " ";
        string weapon = " ";
        string room = " ";

        Player * p = (*(playerArray + playerIndex));

        if (p->getMasterPlayer() == true)
        {
            cout << "It is your turn.  This is what you have:" << endl;
            cout << displayMasterHand() << endl;
        }
        p->askAccusation(suspect, weapon, room);

        for (int i = playerIndex + 1; i != playerIndex; i++)
        {
            if (i == numPlayers)
                i = 0;

            if((*(playerArray + i))->doesHaveACard(suspect, weapon, room) == true)
            {
                if (p->getMasterPlayer() == true)
                    (*(playerArray + i))->requestCard(suspect, weapon, room);
                i = playerIndex - 1;
            }

            if ((i+1) == numPlayers)
                i = -1;
        }
    update();
    }
}
void Game::initiateRoundOfTurns()
{
    for (int i = 0; i < numPlayers; i++)
    {
        if (solutionFound() == false)
            initiateTurn(i);
    }
}

string Game::displayAllPlayers()
{
    stringstream values;

    for (int i = 0; i < numPlayers; i++)
    {
        values << (*(playerArray + i))->playerString() << "\n\n";
    }
    return values.str();
}
string Game::displayMasterHand()
{
    return masterHand->handString();
}

bool Game::solutionFound()
{
    update();

    int noC = 0;
    int mayC = 0;
    for (int i = 0; i < 21; i++)
    {
        if (masterHand->getCard(i)->getUsageStatus() == noHas)
            noC++;
        if (masterHand->getCard(i)->getUsageStatus() == mayHas)
            mayC++;
    }
    if ((mayC + noC) == 3)
        return true;
    else if (noC > 3)
        throw invalid_argument("There are too many detracted cards!");
    else
        return false;
}
void Game::getSolutionFound(string& suspect, string& weapon, string& room)
{
    if(solutionFound() == false)
        throw invalid_argument("There is no solution yet!");

    update();

    string * tempArray = new string[3];

    int counter = 0;
    for (int i = 0; i < 21; i++)
    {
        if (masterHand->getCard(i)->getUsageStatus() == noHas)
        {
            *(tempArray + counter) = masterHand->getCard(i)->getName();
            counter++;
        }
    }
    suspect = *(tempArray + 0);
    weapon = *(tempArray + 1);
    room = *(tempArray + 2);
}

void Game::update()
{
    bool repeatAgain = true;

    while (repeatAgain == true)
    {
        repeatAgain = false;

        updatePlayers();
        if (transitionPlayersToMaster() == true)
            repeatAgain = true;

        updateMaster();
        if (transitionMasterToPlayers() == true)
            repeatAgain = true;
    }
}
void Game::updatePlayers()
{
    for (int i = 0; i < numPlayers; i++)
    {
        (*(playerArray + i))->updatePlayer();
    }
}
void Game::updateMaster()
{
    updateMasterSegment(0,5);
    updateMasterSegment(6,11);
    updateMasterSegment(12,20);
}
void Game::updateMasterSegment(int startIndex, int endIndex)
{
    //Quick validation...
    if ((startIndex < 0) || (endIndex > 20))
        throw invalid_argument("One or both of the indices are outside the bounds of the array for the updateMasterSegment method!");
    if (((startIndex != 0) && (startIndex != 6) && (startIndex != 12)) || ((endIndex != 5) && (endIndex != 11) && (endIndex != 20)))
        throw invalid_argument("There is NO exception, except that you put in the wrong indices for the updateMasterSegment method.");

    int noHasCounter = 0;
    int hasCounter = 0;
    int mayHasCounter = 0;

    for (int c = startIndex; c <= endIndex; c++)
    {
        string name = masterHand->getCard(c)->getName();

        if (masterHand->getCard(c)->getUsageStatus() == has)
            hasCounter++;
        else if (masterHand->getCard(c)->getUsageStatus() == noHas)
            noHasCounter++;
        else if (masterHand->getCard(c)->getUsageStatus() == mayHas)
            mayHasCounter++;
    }

    if ((hasCounter == (endIndex - startIndex)) && (mayHasCounter == 1))
    {
        for (int c = startIndex; c <= endIndex; c++)
        {
            string name = masterHand->getCard(c)->getName();

            if (masterHand->getCard(c)->getUsageStatus() == mayHas)
                masterHand->detractCard(name);
        }
    }
    else if ((noHasCounter == 1) && (mayHasCounter > 0))
    {
        for (int c = startIndex; c <= endIndex; c++)
        {
            string name = masterHand->getCard(c)->getName();

            if (masterHand->getCard(c)->getUsageStatus() == mayHas)
                masterHand->setCard(name);
        }
    }
}

// If a player has the specified card, then "true" is returned
// A "false" is returned if either no player has the specified card, or if at least one player may have the card
bool Game::aPlayerHasCard(string cardName)
{
    int temp = 0;
    for(int i = 0; i < numPlayers; i++)
    {
        Player * p = *(playerArray + i);

        if (p->doesHaveCard(cardName) == true)
            temp += 1;
    }
    if (temp == 1)
        return true;
    else if (temp > 1)
        throw invalid_argument("More than one player has a card in aPlayerHasCard method.");
    else
        return false;
}
// If no player has the specified card, then "true" is returned
// A "false" is returned if either a player has the specified card, or if at least one player may have the card
bool Game::noPlayerHasCard(string cardName)
{
    for(int i = 0; i < numPlayers; i++)
    {
        Player * p = *(playerArray + i);

        if (p->doesNotHaveCard(cardName) == false)
            return false;
    }
    return true;
}
// "True" is returned if no players have a card or if a player does have a card
// "False" is returned if there was no update made to the Master Hand
bool Game::transitionPlayersToMaster()
{
    bool finalResult = false;
    Card * currentCard = nullptr;

    for (int c = 0; c < 21; c++)
    {
        currentCard = masterHand->getCard(c);

        if (currentCard->getUsageStatus() == mayHas)
        {
            if (aPlayerHasCard(currentCard->getName()) == true)
            {
                currentCard->setUsageStatus(has);
                finalResult = true;
            }
            if (noPlayerHasCard(currentCard->getName()) == true)
            {
                currentCard->setUsageStatus(noHas);
                finalResult = true;
            }
        }
    }
    return finalResult;
}

// Returns "true" if no player has the specified card, but a change was made
// Returns "false" if no player has the specified card, and a change was made
// Throws an exception if a player has the specified card
// WARNING!!: This method actually CHANGES players' cards
bool Game::ensureNoPlayerHasCard(string cardName)
{
    bool finalResult = false;

    for(int i = 0; i < numPlayers; i++)
    {
        Player * p = *(playerArray + i);

        if (p->doesHaveCard(cardName) == true)
        {
            throw invalid_argument("Somehow a detracted card from the master hand is not guaranteed by all the players in ensureNoPlayerHasCard method!");
        }
        else if ((p->doesHaveCard(cardName) == false) && (p->doesNotHaveCard(cardName) == false))
        {
            p->detractCard(cardName);
            finalResult = true;
        }
    }
    return finalResult;
}
// Assumes that only one player has the specified card
// It then sets all the other players to noHas the card
bool Game::ensureNoPlayerButOneHasCard(string cardName)
{
    bool finalResult = false;
    int numHas = 0;
    int numNotHas = 0;

    for(int i = 0; i < numPlayers; i++)
    {
        Player * p = *(playerArray + i);

        if (p->doesHaveCard(cardName) == true)
            numHas += 1;
        else if (p->doesNotHaveCard(cardName) == true)
            numNotHas += 1;
    }
    if ((noPlayerHasCard(cardName) == true) || (numHas > 1))
    {
        throw invalid_argument("Error with a set card from the master hand in ensureNoPlayerButOneHasCard method!");
    }

    //Now we can assume that:
    //There is at least one player that could have the card
    //There is no more than one player that has the card
    for(int i = 0; i < numPlayers; i++)
    {
        Player * p = *(playerArray + i);

        if ((p->doesHaveCard(cardName) == false) && (p->doesNotHaveCard(cardName) == false))
        {
            if (numHas == 1)
            {
                p->detractCard(cardName);
                finalResult = true;
            }
            else if (numNotHas == (numPlayers - 1))
            {
                p->setCard(cardName);
                finalResult = true;
            }
        }
    }

    //If finalResult == false, we can assume that there are at least two players that could have the card
    //In this case, we cannot do anything

    return finalResult;
}
// If the masterHand noHas or has a card, it updates the players' hands accordingly
bool Game::transitionMasterToPlayers()
{
    bool finalResult = false;
    Card * currentCard = nullptr;

    for (int c = 0; c < 21; c++)
    {
        currentCard = masterHand->getCard(c);

        if (currentCard->getUsageStatus() == noHas)
        {
            if (ensureNoPlayerHasCard(currentCard->getName()) == true)
                finalResult = true;
        }
        else if (currentCard->getUsageStatus() == has)
        {
            if (ensureNoPlayerButOneHasCard(currentCard->getName()))
                finalResult = true;
        }
    }
    return finalResult;
}
