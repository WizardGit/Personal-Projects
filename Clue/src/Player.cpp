//
// Created by Kaiser Slocum on 6/7/2019
// Last edited by Kaiser Slocum on 12/20/2019
// All Rights Reserved by God
//

#include "Player.h"

Player::Player(int playerNumber, bool mPlayer)
{
    if (mPlayer == true)
    {
        masterPlayer = true;
        SetupMasterPlayer(playerNumber);
    }
    else
    {
        cout << "What is the name of player number "<< playerNumber << ": ";
        cin >> name;
        cout << endl;

        bool failed = false;
        do
        {
            cout << "How many cards does "<< name << " have: ";
            cin >> numCards;
            cout << endl;

            if(cin.fail())
            {
                cin.clear();
                cin.ignore(numeric_limits<streamsize>::max(),'\n');
                failed = true;
                cout << "You did not enter a valid number of cards." << endl;
                cout << "Please try again." << endl;
            }
            else
            {
                failed = false;
            }
        }while (failed == true);
    }
}

void Player::SetupMasterPlayer(int playerNumber)
{
    cout << "You are the master player and player number " << playerNumber << "! What is your name: ";
    cin >> name;
    cout << endl;

    bool failed = false;
    do
    {
        cout << "How many cards do you have: ";
        cin >> numCards;
        cout << endl;

        if(cin.fail())
        {
            cin.clear();
            cin.ignore(numeric_limits<streamsize>::max(),'\n');
            failed = true;
            cout << "You did not enter a valid number of cards." << endl;
            cout << "Please try again." << endl;
        }
        else
        {
            failed = false;
        }
    }while (failed == true);

    for (int i = 0; i < numCards; i++)
    {
        askAndSetPlayerCard();
    }
    for (int i = 0; i < 21; i++)
    {
        Card * c = hand.getCard(i);

        if (c->getUsageStatus() == mayHas)
            detractCard(c->getName());
    }
}

Player::Player(string playerName, int playerNumCards, bool mPlayer)
{
    name = playerName;
    numCards = playerNumCards;
    masterPlayer = mPlayer;
}

Player::~Player()
{
    // Nothing To Delete
}

string Player::getName()
{
    return name;
}
int Player::getNumCards()
{
    return numCards;
}
bool Player::getMasterPlayer()
{
    return masterPlayer;
}

void Player::setCard(string cardName)
{
    Card * card = nullptr;
    for (int i = 0; i < 21; i++)
    {
        card = hand.getCard(i);

        if (card->getName() == cardName)
        {
            card->setUsageStatus(has);

            for (int i = 0; i < card->numGroupNumbers(); i++)
            {
                resetCardsOfGroup(card->getGroupNumber(i));
            }
        }
    }
}
void Player::detractCard(string cardName)
{
    Card * card;
    for (int i = 0; i < 21; i++)
    {
        card = hand.getCard(i);
        if (card->getName() == cardName)
        {
            card->setUsageStatus(noHas);
            card->deleteAllGroupNumbers();
        }
    }
}
void Player::setCardGroup(string cardName, int groupNumber)
{
    Card * card;
    for (int i = 0; i < 21; i++)
    {
        card = hand.getCard(i);
        if ((card->getName() == cardName) && (card->getUsageStatus() == mayHas))
        {
            card->addGroupNumber(groupNumber);
        }
    }
}

bool Player::doesHaveCard(string cardName)
{
    for (int i = 0; i < 21; i++)
    {
        if (((hand.getCard(i))->getName() == cardName) && ((hand.getCard(i))->getUsageStatus() == has))
            return true;
    }
    return false;
}
bool Player::doesNotHaveCard(string cardName)
{
    for (int i = 0; i < 21; i++)
    {
        if (((hand.getCard(i))->getName() == cardName) && ((hand.getCard(i))->getUsageStatus() == noHas))
            return true;
    }
    return false;
}

bool Player::onlyCardWithGroup(int groupNumber)
{
    int counter = 0;
    for (int i = 0; i < 21; i++)
    {
        if ((hand.getCard(i))->groupNumberExists(groupNumber) == true)
            counter++;
    }
    if (counter == 1)
        return true;
    else
        return false;
}
bool Player::forcedCardExists()
{
    int highNum = highestGroupNumber();

    for (int i = 0; i <= highNum; i++)
    {
        if(onlyCardWithGroup(i) == true)
            return true;
    }
    return false;
}
Card * Player::getOnlyCardWithGroup(int groupNumber)
{
    for (int i = 0; i < 21; i++)
    {
        if ((hand.getCard(i))->groupNumberExists(groupNumber) == true)
        {
            return hand.getCard(i);
        }
    }
    throw invalid_argument("There is not card with that group number!");
}
int Player::highestGroupNumber()
{
    int highestGroupNumber = 0;
    for (int i = 0; i < 21; i++)
    {
        if(((hand.getCard(i))->numGroupNumbers() > 0) && ((hand.getCard(i))->highestGroupNumber() > highestGroupNumber))
        {
            highestGroupNumber = (hand.getCard(i))->highestGroupNumber();
        }
    }
    return highestGroupNumber;
}
void Player::resetCardsOfGroup(int groupNumber)
{
    for (int i = 0; i < 21; i++)
    {
        Card * card = hand.getCard(i);
        card->deleteGroupNumber(groupNumber);
    }
}

int Player::knownCardsHeld()
{
    int counter = 0;

    for (int i = 0; i < 21; i++)
    {
        if ((hand.getCard(i))->getUsageStatus() == has)
        {
            counter++;
        }
    }
    return counter;
}

string Player::playerString()
{
    stringstream values;
    values << name << "'s Cards:\n";
    values << hand.handString() << "\n";

    return values.str();
}
string Player::displayCard(int index)
{
    stringstream values;
    values << (hand.getCard(index))->cardString() << "\n";

    return values.str();
}

int Player::numberOfUsageStatus(int u)
{
    int c = 0;
    for(int i = 0; i < 21; i++)
    {
        if ((hand.getCard(i))->getUsageStatus() == u)
        {
            c++;
        }
    }
    return c;
}
bool Player::updateMaxCards()
{
    int numHeld = numberOfUsageStatus(has);
    int numNotHeld = numberOfUsageStatus(noHas);

    if ((numHeld == numCards) && (numNotHeld == (21 - numCards)))
    {
        return false;
    }
    else if (numHeld == numCards)
    {
       for(int i = 0; i < 21; i++)
        {
            if ((hand.getCard(i))->getUsageStatus() != has)
                (hand.getCard(i))->setUsageStatus(noHas);
        }
        return true;
    }
    else if (numNotHeld == (21 - numCards))
    {
        for(int i = 0; i < 21; i++)
        {
            if ((hand.getCard(i))->getUsageStatus() != noHas)
                (hand.getCard(i))->setUsageStatus(has);
        }
        return true;
    }
    return false;
}
bool Player::updateGroupCards()
{
    for(int i = 1; i <= highestGroupNumber(); i++)
    {
        if(onlyCardWithGroup(i) == true)
        {
            Card * c = getOnlyCardWithGroup(i);
            setCard(c->getName());
            return true;
        }
    }
    return false;
}
void Player::updatePlayer()
{
    while ((updateGroupCards() == true) || (updateMaxCards() == true))
    {
        // Do nothing
    }
}
bool Player::isValidCard(string cardName)
{
    for(int i = 0; i < 21; i++)
    {
        if (cardName ==(hand.getCard(i))->getName())
        {
            return true;
        }
    }
    return false;
}
bool Player::isValidSuspect(string cardName)
{
    for(int i = 0; i < 6; i++)
    {
        if (cardName ==(hand.getCard(i))->getName())
        {
            return true;
        }
    }
    return false;
}
bool Player::isValidWeapon(string cardName)
{
    for(int i = 6; i < 12; i++)
    {
        if (cardName ==(hand.getCard(i))->getName())
        {
            return true;
        }
    }
    return false;
}
bool Player::isValidRoom(string cardName)
{
    for(int i = 12; i < 21; i++)
    {
        if (cardName ==(hand.getCard(i))->getName())
        {
            return true;
        }
    }
    return false;
}

void Player::askAccusation(string& suspect, string& weapon, string& room)
{
    do
    {
        cout << "What is the suspect that " << name << " asked for: ";
        cin >> suspect;
        cout << endl;
    } while(isValidSuspect(suspect) == false);

    do
    {
        cout << "What is the weapon that " << name << " asked for: ";
        cin >> weapon;
        cout << endl;
    } while(isValidWeapon(weapon) == false);

    do
    {
        cout << "What is the room that " << name << " asked for: ";
        cin >> room;
        cout << endl;
    } while(isValidRoom(room) == false);
}
bool Player::doesHaveACard(string suspect, string weapon, string room)
{
    string answer;

    while ((answer != "yes") && (answer != "no"))
    {
        cout << "Did " << name << " have either " << suspect << ", " << weapon << ", or " << room << ": ";
        cin >> answer;
        cout << endl;
    }

    if (answer == "yes")
    {
        if (masterPlayer == false)
            addGroupToCards(suspect, weapon, room);
        return true;
    }
    else if (answer == "no")
    {
        if (masterPlayer == false)
            detractCards(suspect, weapon, room);
        return false;
    }
    throw invalid_argument("Something went terribly wrong in Player method:doesHaveACard!");
}
void Player::detractCards(string suspect, string weapon, string room)
{
    if ((isValidSuspect(suspect) == false) || (isValidWeapon(weapon) == false) || (isValidRoom(room) == false))
        throw invalid_argument("One of the cards is not of the correct card class!");
    else
    {
        detractCard(suspect);
        detractCard(weapon);
        detractCard(room);
    }
}
Card * Player::getCardWithName(string cardName)
{
    for(int i = 0; i < 21; i++)
    {
        if (cardName ==(hand.getCard(i))->getName())
            return hand.getCard(i);
    }
    throw invalid_argument("The cardName is not a valid name");
}
Card * Player::getCard(int index)
{
    if ((index > 20) || (index < 0))
        throw invalid_argument("The index is not valid.");
    else
        return hand.getCard(index);
}
void Player::addGroupToCards(string suspect, string weapon, string room)
{
    Card * s = getCardWithName(suspect);
    Card * w = getCardWithName(weapon);
    Card * r = getCardWithName(room);

    if((s->getUsageStatus() != has) && (w->getUsageStatus() != has) && (r->getUsageStatus() != has))
    {
        if (s->getUsageStatus() == mayHas)
            s->addGroupNumber(currentGroupNumber);
        if (w->getUsageStatus() == mayHas)
            w->addGroupNumber(currentGroupNumber);
        if (r->getUsageStatus() == mayHas)
            r->addGroupNumber(currentGroupNumber);
    }
    currentGroupNumber++;
}
void Player::requestCard(string suspect, string weapon, string room)
{
    string name;

    do
    {
        cout << "Alright, which of the following cards does that player have:\n" << suspect << ", " << weapon << ", or " << room << endl;
        cin >> name;

        if ((name == suspect) || (name == weapon) || (name == room))
            setCard(name);
        else
            cout << "Sorry, that is not one of the cards that you asked for, please try again." << endl;

    }while ((name != suspect) && (name != weapon) && (name != room));
}
void Player::askAndSetPlayerCard()
{
    string name;

    do
    {
        cout << "Name a card that you have:";
        cin >> name;
        cout << endl;

        if ((isValidCard(name) == false) || (doesHaveCard(name) == true))
             cout << "Sorry, that is not a valid card, please try again." << endl;

    }while ((isValidCard(name) == false) || (doesHaveCard(name) == true));

    hand.setCard(name);
}
