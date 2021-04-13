//
// Created by Kaiser Slocum on 6/7/2019
// Last edited by Kaiser Slocum on 12/22/2019
// All Rights Reserved by God
//

#include <iostream>
#include "Card.h"
#include "Game.h"
#include "Hand.h"
#include "LinkedList.h"
#include "Node.h"
#include "Player.h"

using namespace std;

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

int const has = 1;
int const noHas = 2;
int const mayHas = 3;
int const noGroup = 0;

void nodeTests()
{
    cout << "\n\nTesting Node Class" << endl;
    Node * n1;
    Node * n2;
    Node * n3;

    n1 = new Node(5);
    n2 = new Node(4);
    n3 = new Node(3);

    cout << "\nTesting getValue method" << endl;
    cout << "5:" << n1->getValue() << endl;
    cout << "\nTesting setNext method" << endl;
    n1->setNext(n2);
    cout << "4:" << n1->getNext()->getValue() << endl;
    cout << "\nTesting setPrev method" << endl;
    n1->setPrev(n3);
    cout << "3:" << n1->getPrev()->getValue() << endl;
    cout << "\nTesting getNext method" << endl;
    n3->setNext(n1);
    cout << "5:" << n3->getNext()->getValue() << endl;
    cout << "\nTesting getPrev method" << endl;
    n2->setPrev(n1);
    cout << "5:" << n2->getPrev()->getValue() << endl;
}
void linkedListTests()
{
    cout << "\n\nTesting LinkedList Class" << endl;
    LinkedList l1(nullptr, nullptr);
    LinkedList l2(5);

    cout << "\nTesting valueExists method" << endl;
    cout << "1:" << l2.valueExists(5) << endl;
    cout << "0:" << l2.valueExists(3) << endl;
    cout << "0:" << l1.valueExists(5) << endl;
    cout << "0:" << l1.valueExists(3) << endl;

    cout << "\nTesting deleteValue method" << endl;
    l2.deleteValue(5);
    cout << "0:" << l2.valueExists(5) << endl;
    l2.deleteValue(3);

    cout << "\nTesting addTailValue method" << endl;
    l2.addTailValue(5);
    l2.addTailValue(2);
    l2.addTailValue(4);
    cout << "5 2 4:" << l2.linkedListString() << endl;

    cout << "\nTesting addTailValue method" << endl;
    l2.addHeadValue(2);
    l2.addHeadValue(8);
    l2.addHeadValue(6);
    cout << "6 8 2 5 2 4:" << l2.linkedListString() << endl;

    cout << "\nTesting length method" << endl;
    cout << "6:" << l2.length() << endl;

    cout << "\nTesting getValue method" << endl;
    cout << "2:" << l2.getValue(4) << endl;
    cout << "Not there:";
    try
    {
        l2.getValue(7);
        cout << "there" << endl;
    }
    catch(range_error)
    {
        cout << "Not there" << endl;
    }

    cout << "\nTesting getHighestValue" << endl;
    cout << "8:" << l2.getHighestValue() << endl;
    l2.deleteValue(8);
    cout << "6:" << l2.getHighestValue() << endl;
    cout << "Not there:";
    try
    {
        l1.getValue(0);
        cout << "there" << endl;
    }
    catch(range_error)
    {
        cout << "Not there" << endl;
    }

    cout << "\nTesting displayList after complicated additions and subtractions" << endl;
    l1.deleteValue(4);
    l1.addHeadValue(3);
    l1.addHeadValue(2);
    l1.addHeadValue(1);
    l1.addTailValue(4);
    l1.addTailValue(5);
    l1.addTailValue(6);
    l1.deleteValue(3);
    l1.addTailValue(7);
    l1.addTailValue(8);
    l1.addTailValue(9);
    l1.deleteValue(7);
    l1.deleteValue(1);
    l1.deleteValue(2);
    l1.addHeadValue(3);
    l1.addHeadValue(2);
    l1.addHeadValue(1);
    l1.deleteValue(9);
    l1.deleteValue(8);
    l1.addTailValue(7);
    l1.addTailValue(8);
    l1.addTailValue(9);

    cout << "1 2 3 4 5 6 7 8 9:" << l1.linkedListString() << endl;
}
void cardTests()
{
    cout << "\n\nTesting Card Class" << endl;

    Card c1(ColMustard, "suspect", noHas);

    cout << "\nTesting getName method" << endl;
    cout << "ColMustard:"<< c1.getName() << endl;

    cout << "\nTesting getCardClass method" << endl;
    cout << "suspect:"<< c1.getCardClass() << endl;

    cout << "\nTesting getUsageStatus method" << endl;
    cout << noHas << ":"<< c1.getUsageStatus() << endl;

    cout << "\nTesting setUsageStatus method" << endl;
    c1.setUsageStatus(has);
    cout << has << ":"<< c1.getUsageStatus() << endl;

    cout << "\nTesting addGroupNumber method" << endl;
    c1.addGroupNumber(1);
    c1.addGroupNumber(2);
    c1.addGroupNumber(5);
    cout << "1 2 5:" << c1.allGroupNumbersString() << endl;

    cout << "\nTesting deleteGroupNumber method" << endl;
    cout << "1 2 5:" << c1.allGroupNumbersString() << endl;
    c1.deleteGroupNumber(2);
    cout << "1 5:" << c1.allGroupNumbersString() << endl;
    c1.deleteGroupNumber(5);
    cout << "1:" << c1.allGroupNumbersString() << endl;
    c1.deleteGroupNumber(5);
    cout << "1:" << c1.allGroupNumbersString() << endl;
    c1.deleteGroupNumber(1);
    cout << ":" << c1.allGroupNumbersString() << endl;

    cout << "\nTesting deleteAllGroupNumbers method" << endl;
    c1.deleteAllGroupNumbers();
    cout << ":"<< c1.allGroupNumbersString() << endl;

    cout << "\nTesting numGroupNumbers method" << endl;
    cout << "0:"<< c1.numGroupNumbers() << endl;
    c1.addGroupNumber(5);
    cout << "1:" << c1.numGroupNumbers() << endl;

    cout << "\nTesting getGroupNumber method" << endl;
    c1.addGroupNumber(3);
    cout << "53:"<< c1.getGroupNumber(0) << c1.getGroupNumber(1) << endl;
    cout << "Not There:";
    try
    {
        c1.getGroupNumber(5);
        cout << "There" << endl;
    }
    catch(range_error)
    {
        cout << "Not There" << endl;
    }

    cout << "\nTesting groupNumberExists method" << endl;
    cout << "0:"<< c1.groupNumberExists(6) << endl;
    cout << "1:" << c1.groupNumberExists(3) << endl;

    cout << "\nTesting highestGroupNumber method" << endl;
    cout << "5:" << c1.highestGroupNumber() << endl;
    c1.deleteGroupNumber(5);
    cout << "3:" << c1.highestGroupNumber() << endl;
    c1.addGroupNumber(10);
    c1.addGroupNumber(2);

    cout << "\nTesting cardString method" << endl;
    cout << "Name: ColMustard   CardClass: suspect UsageStatus: 1 GroupNumbers: 3 10 2" << endl;
    cout << c1.cardString() << endl;

    cout << "\nTesting allGroupNumbersString method" << endl;
    cout << "Also using a more complicated test on the deletion and addition of group numbers" << endl;
    c1.deleteAllGroupNumbers();

    c1.deleteGroupNumber(7);
    c1.addGroupNumber(4);
    c1.addGroupNumber(3);
    c1.addGroupNumber(2);
    cout << "4 3 2:" << c1.allGroupNumbersString() << endl;
    c1.deleteGroupNumber(5);
    c1.deleteGroupNumber(4);
    cout << "3 2:" << c1.allGroupNumbersString() << endl;
    c1.deleteGroupNumber(2);
    c1.deleteGroupNumber(10);
    cout << "3:" << c1.allGroupNumbersString() << endl;
    c1.deleteGroupNumber(3);
    cout << ":" << c1.allGroupNumbersString() << endl;
    c1.addGroupNumber(5);
    c1.addGroupNumber(6);
    c1.addGroupNumber(7);
    cout << "5 6 7:" << c1.allGroupNumbersString() << endl;
    c1.deleteGroupNumber(6);
    cout << "5 7:" << c1.allGroupNumbersString() << endl;
}
void handTests()
{
    cout << "\n\nTesting Hand Class" << endl;
    Hand h1;

    cout << "\nTesting getName method" << endl;
    cout << "ProfPlum:" << h1.getName(1) << endl;

    cout << "\nTesting getCard method" << endl;
    cout << "Knife:" << h1.getCard(6)->getName() << endl;

    cout << "\nTesting setCard method" << endl;
    h1.setCard(ProfPlum);
    cout << "1:" << h1.getCard(1)->getUsageStatus() << endl;

    cout << "\nTesting detractCard method" << endl;
    h1.detractCard(ProfPlum);
    cout << "2:" << h1.getCard(1)->getUsageStatus() << endl;

    cout << "\nTesting handString method" << endl;
    cout << "Should display complete list of all cards" << endl;
    cout << h1.handString() << endl;
}
void playerTests()
{
    cout << "\n\nTesting Player Class" << endl;
    Player p("Kaiser", 3);
    Player pm("Kailey", 2, true);

    cout << "\nTesting getName method" << endl;
    cout << "Kaiser:" << p.getName();

    cout << "\nTesting getNumCards method" << endl;
    cout << "3:" << p.getNumCards();

    cout << "\nTesting getMasterPlayer method" << endl;
    cout << "0:" << p.getMasterPlayer() << endl;
    cout << "1:" << pm.getMasterPlayer();

    cout << "\nTesting setCard method" << endl;
    p.setCard(MrGreen);
    cout << has << ":" << p.getCardWithName(MrGreen)->getUsageStatus();

    cout << "\nTesting setCardGroup method" << endl;
    p.setCardGroup(ProfPlum, 5);
    cout << "5:" << (p.getCardWithName(ProfPlum))->getGroupNumber(0);

    cout << "\nTesting detractCard method" << endl;
    p.detractCard(MissScarlett);
    cout << noHas << ":" << p.getCardWithName(MissScarlett)->getUsageStatus();

    cout << "\nTesting detractCards method" << endl;
    p.detractCards(ColMustard, Knife, BallRoom);
    cout << noHas << ":" << p.getCardWithName(ColMustard)->getUsageStatus() << endl;
    cout << noHas << ":" << p.getCardWithName(Knife)->getUsageStatus() << endl;
    cout << noHas << ":" << p.getCardWithName(BallRoom)->getUsageStatus() << endl;

    cout << "Fails:";
    try
    {
        p.detractCards(ColMustard, MrsWhite, BallRoom);
        cout << "Succeeds";
    }
    catch (invalid_argument)
    {
        cout << "Fails";
    }

    cout << "\nTesting doesHaveCard method" << endl;
    cout << "1:" << p.doesHaveCard(MrGreen) << endl;
    cout << "0:" << p.doesHaveCard(ColMustard) << endl;
    cout << "\nTesting doesHaveACard method (say no, then say yes)" << endl;
    cout << "0:" << p.doesHaveACard(ColMustard, Candlestick, Conservatory) << endl;
    cout << "1:" << p.doesHaveACard(MrGreen, Knife, BallRoom) << endl;
    cout << "\nTesting doesNotHaveCard method" << endl;
    cout << "0:" << p.doesNotHaveCard(MrGreen) << endl;
    cout << "1:" << p.doesNotHaveCard(ColMustard) << endl;

    cout << "\nTesting isValidCard method" << endl;
    cout << "1:" << p.isValidCard(ColMustard) << endl;
    cout << "0:" << p.isValidCard("CoMustard") << endl;
    cout << "\nTesting isValidSuspect method" << endl;
    cout << "1:" << p.isValidSuspect(ColMustard) << endl;
    cout << "0:" << p.isValidSuspect("CoMustard") << endl;
    cout << "\nTesting isValidWeapon method" << endl;
    cout << "1:" << p.isValidWeapon(Knife) << endl;
    cout << "0:" << p.isValidWeapon("Candlestic") << endl;
    cout << "\nTesting isValidRoom method" << endl;
    cout << "1:" << p.isValidRoom(Study) << endl;
    cout << "0:" << p.isValidRoom("BillardRoom") << endl;

    cout << "\nTesting onlyCardWithGroup method" << endl;
    cout << "1:" << p.onlyCardWithGroup(5) << endl;
    cout << "0:" << p.onlyCardWithGroup(10) << endl;
    cout << "0:" << p.onlyCardWithGroup(1) << endl;
    cout << "0:" << p.onlyCardWithGroup(0) << endl;
    cout << "\nTesting forcedCardExists method" << endl;
    cout << "1:" << p.forcedCardExists() << endl;
    p.resetCardsOfGroup(5);
    cout << "0:" << p.forcedCardExists() << endl;

    cout << "\nTesting getOnlyCardWithGroup method" << endl;
    p.setCardGroup(ProfPlum, 5);
    cout << "ProfPlum:" << (p.getOnlyCardWithGroup(5))->getName() << endl;
    cout << "Fails:";
    try
    {
        p.getOnlyCardWithGroup(4);
        cout << "Succeeds" << endl;
    }
    catch (invalid_argument)
    {
        cout << "Fails" << endl;
    }

    cout << "\nTesting getCardWithName method" << endl;
    cout << "MrsPeacock:" << (p.getCardWithName(MrsPeacock))->getName() << endl;
    cout << "Fails:";
    try
    {
        p.getCardWithName("MrsPecock");
        cout << "Succeeds" << endl;
    }
    catch (invalid_argument)
    {
        cout << "Fails" << endl;
    }

    cout << "\nTesting getCard method" << endl;
    cout << "ColMustard:" << (p.getCard(0))->getName() << endl;
    cout << "Fails:";
    try
    {
        p.getCard(21);
        cout << "Succeeds" << endl;
    }
    catch (invalid_argument)
    {
        cout << "Fails" << endl;
    }

    cout << "\nTesting highestGroupNumber method" << endl;
    cout << "5:" << p.highestGroupNumber() << endl;

    cout << "\nTesting numberOfUsageStatus method" << endl;
    Player q("Kaiser", 3);
    q.setCard(ColMustard);
    q.detractCard(MrsPeacock);
    cout << "1:" << q.numberOfUsageStatus(has) << endl;
    cout << "1:" << q.numberOfUsageStatus(noHas) << endl;
    cout << "19:" << q.numberOfUsageStatus(mayHas) << endl;

    cout << "\nTesting knownCardsHeld method" << endl;
    cout << "1:" << q.knownCardsHeld() << endl;
    cout << "1:" << p.knownCardsHeld() << endl;

    cout << "\nTesting resetCardsOfGroup method" << endl;
    q.setCardGroup(Knife, 3);
    q.setCardGroup(Hall, 3);
    cout << "0:" << q.onlyCardWithGroup(3) << endl;
    q.resetCardsOfGroup(3);
    q.setCardGroup(Study, 3);
    cout << "1:" << q.onlyCardWithGroup(3) << endl;

    cout << "\nTesting addGroupToCards method" << endl;
    q.addGroupToCards(ProfPlum, Knife, Hall);
    cout << "x:x:x;" << (q.getCardWithName(ProfPlum))->getGroupNumber(0) << ":" << (q.getCardWithName(Knife))->getGroupNumber(0) << ":" << (q.getCardWithName(Hall))->getGroupNumber(0) << endl;

    cout << "\nTesting askAccusation method" << endl;
    cout << "Make sure no invalid names can be entered or exceptions happen." << endl;
    string ka = "MissScarlett";
    string kb = "Revolver";
    string kc = "BilliardRoom";
    p.askAccusation(ka, kb, kc);

    cout << "\nTesting requestCard method" << endl;
    cout << mayHas << ":" << (p.getCard(19))->getUsageStatus() << endl;
    cout << "Enter 'Library'" << endl;
    p.requestCard(MissScarlett, Revolver, Library);
    cout << has << ":" << (p.getCard(19))->getUsageStatus() << endl;
    cout << "Now Enter 'Library' again. You should be instructed to re-enter something again.";
    cout << "Enter 'BilliardRoom' afterward" << endl;
    p.requestCard(MissScarlett, Revolver, BilliardRoom);

    cout << "\nTesting displayCard method" << endl;
    cout << "The following two lines should match:" << endl;
    cout << "Name: " << left << setw(12) << "DiningRoom" << " CardClass: " << setw(7) << "Room" << " UsageStatus: " << setw(1) << mayHas << " GroupNumbers: " << endl;
    cout << p.displayCard(14) << endl;

    cout << "\nTesting playerString method" << endl;
    cout << "Should display all the cards in the player's hand." << endl;
    cout << p.playerString() << endl;

    cout << "\nTesting askAndSetPlayerCard method" << endl;
    cout << "Type in 'Wrench'" << endl;
    p.askAndSetPlayerCard();
    cout << has << ":" << (p.getCard(11))->getUsageStatus() << endl;

    cout << "\nTesting updateMaxCards method" << endl;
    Player g("kaiser",6,true);
    cout << mayHas << ":" << (g.getCard(14))->getUsageStatus() << endl;
    g.setCard(ColMustard);
    g.setCard(MrsWhite);
    g.setCard(Study);
    g.setCard(Library);
    g.setCard(BallRoom);
    g.setCard(Wrench);
    g.updateMaxCards();
    cout << noHas << ":" << (g.getCard(1))->getUsageStatus() << endl;
    cout << noHas << ":" << (g.getCard(4))->getUsageStatus() << endl;
    cout << noHas << ":" << (g.getCard(8))->getUsageStatus() << endl;
    cout << noHas << ":" << (g.getCard(14))->getUsageStatus() << endl;
    (g.getCard(0))->setUsageStatus(mayHas);
    (g.getCard(11))->setUsageStatus(mayHas);
    g.updateMaxCards();
    cout << has << ":" << (g.getCard(0))->getUsageStatus() << endl;
    cout << has << ":" << (g.getCard(11))->getUsageStatus() << endl;

    cout << "\nTesting updateGroupCards method" << endl;
    Card * c = q.getOnlyCardWithGroup(3);
    cout << "3:" << c->getUsageStatus() << endl;
    q.updateGroupCards();
    cout << "1:" << c->getUsageStatus() << endl;

    Player t("Kaiser", 3);
    t.setCardGroup(ColMustard, 2);
    t.setCardGroup(ProfPlum, 2);
    Card * c1 = t.getCard(0);
    Card * c2 = t.getCard(1);
    cout << mayHas << ":" << c1->getUsageStatus() << endl;
    cout << mayHas << ":" << c2->getUsageStatus() << endl;
    t.updateGroupCards();
    cout << mayHas << ":" << c1->getUsageStatus() << endl;
    cout << mayHas << ":" << c2->getUsageStatus() << endl;

    cout << "\nTesting updatePlayer method" << endl;
    Player u("Kaiser", 3, true);
    u.addGroupToCards("ProfPlum", "Rope", "Study");
    u.addGroupToCards("ColMustard", "Knife", "DiningRoom");
    //u.detractCard(ColMustard); Need to remain mayHas
    u.detractCard(ProfPlum);
    u.detractCard(MrGreen);
    u.detractCard(MrsPeacock);
    u.detractCard(MissScarlett);
    u.detractCard(MrsWhite);
    u.detractCard(Knife);
    u.detractCard(Candlestick);
    u.detractCard(Revolver);
    //u.detractCard(Rope); Needs to remain mayHas
    u.detractCard(LeadPipe);
    u.detractCard(Wrench);
    u.detractCard(Hall);
    u.detractCard(Lounge);
    //u.detractCard(DiningRoom); Needs to remain mayHas
    u.detractCard(Kitchen);
    u.detractCard(BallRoom);
    u.detractCard(Conservatory);
    u.detractCard(BilliardRoom);
    u.detractCard(Library);
    u.detractCard(Study);
    cout << mayHas << ":" << (u.getCard(0))->getUsageStatus() << endl;
    cout << mayHas << ":" << (u.getCard(9))->getUsageStatus() << endl;
    cout << mayHas << ":" << (u.getCard(14))->getUsageStatus() << endl;
    u.updatePlayer();
    cout << has << ":" << (u.getCard(0))->getUsageStatus() << endl;
    cout << has << ":" << (u.getCard(9))->getUsageStatus() << endl;
    cout << has << ":" << (u.getCard(14))->getUsageStatus() << endl;
}
//This Method is just for the gameTests
void resetSetup(Player * kaiser, Player * kailey, Hand * mh)
{
    for (int i = 0; i < 21; i++)
    {
        (mh->getCard(i))->setUsageStatus(mayHas);
    }
    for (int i = 0; i < 21; i++)
    {
        (kaiser->getCard(i))->setUsageStatus(mayHas);
    }
    for (int i = 0; i < 21; i++)
    {
        (kailey->getCard(i))->setUsageStatus(mayHas);
    }
}
void gameTests()
{
    cout << "\n\nTesting Game Class" << endl;
    Game game("Kaiser", "Kailey");
    Hand * mh = game.getMasterHand();
    Player * kaiser = game.getPlayer(0);
    Player * kailey = game.getPlayer(1);

    cout << "\nTesting solutionFound and getSolutionFound methods" << endl;
    resetSetup(kaiser, kailey, mh);
    string s = " ";
    string w = " ";
    string r = " ";
    //mh->detractCard(ColMustard); Needs to stay mayHas
    mh->setCard(ProfPlum);
    mh->setCard(MrGreen);
    mh->setCard(MrsPeacock);
    mh->setCard(MissScarlett);
    mh->setCard(MrsWhite);
    mh->setCard(Knife);
    mh->setCard(Candlestick);
    mh->setCard(Revolver);
    //mh->detractCard(Rope); Needs to stay mayHas
    mh->setCard(LeadPipe);
    mh->setCard(Wrench);
    mh->setCard(Hall);
    mh->setCard(Lounge);
    mh->setCard(DiningRoom);
    //mh->setCard(Kitchen);
    mh->setCard(BallRoom);
    mh->setCard(Conservatory);
    //mh->detractCard(BilliardRoom); Needs to stay mayHas
    mh->setCard(Library);
    mh->setCard(Study);
    cout << "0:" << game.solutionFound() << endl;
    cout << "Success:";
    try
    {
        game.getSolutionFound(s,w,r);
        cout << "Failure" << endl;
    }
    catch (invalid_argument)
    {
        cout << "Success" << endl;
    }
    mh->setCard(Kitchen);
    cout << "1:" << game.solutionFound() << endl;
    game.getSolutionFound(s,w,r);
    cout << "ColMustard:" << s << endl;
    cout << "Rope:" << w << endl;
    cout << "BilliardRoom:" << r << endl;

    mh->detractCard(Kitchen);
    cout << "Success:";
    try
    {
        game.solutionFound();
        cout << "Failure" << endl;
    }
    catch (invalid_argument)
    {
        cout << "Success" << endl;
    }
    cout << "Success:";
    try
    {
        game.getSolutionFound(s,w,r);
        cout << "Failure" << endl;
    }
    catch (invalid_argument)
    {
        cout << "Success" << endl;
    }
    mh->setCard(BilliardRoom);
    kailey->setCard(BilliardRoom);
    cout << "1:" << game.solutionFound() << endl;
    game.getSolutionFound(s,w,r);
    cout << "ColMustard:" << s << endl;
    cout << "Rope:" << w << endl;
    cout << "Kitchen:" << r << endl;
    mh->detractCard(ColMustard);
    mh->detractCard(Rope);
    cout << "1:" << game.solutionFound() << endl;
    game.getSolutionFound(s,w,r);
    cout << "ColMustard:" << s << endl;
    cout << "Rope:" << w << endl;
    cout << "Kitchen:" << r << endl;

    cout << "\nTesting updateMaster method" << endl;
    resetSetup(kaiser, kailey, mh);
    mh->detractCard(ColMustard);
    mh->setCard(ProfPlum);
    mh->setCard(MrGreen);
    mh->setCard(MrsPeacock);
    mh->setCard(MissScarlett);
    mh->setCard(MrsWhite);
    mh->setCard(Knife);
    mh->setCard(Candlestick);
    mh->setCard(Revolver);
    //mh->detractCard(Rope); Needs to stay mayHas
    mh->setCard(LeadPipe);
    //mh->setCard(Wrench); Needs to stay mayHas
    //mh->setCard(Hall); Needs to stay mayHas
    mh->setCard(Lounge);
    mh->setCard(DiningRoom);
    mh->setCard(Kitchen);
    mh->setCard(BallRoom);
    mh->setCard(Conservatory);
    mh->setCard(BilliardRoom);
    mh->setCard(Library);
    mh->setCard(Study);
    game.updateMaster();
    cout << noHas << ":" << (mh->getCard(0))->getUsageStatus() << endl;
    cout << has << ":" << (mh->getCard(5))->getUsageStatus() << endl;
    cout << has << ":" << (mh->getCard(6))->getUsageStatus() << endl;
    cout << has << ":" << (mh->getCard(7))->getUsageStatus() << endl;
    cout << mayHas << ":" << (mh->getCard(9))->getUsageStatus() << endl;
    cout << mayHas << ":" << (mh->getCard(11))->getUsageStatus() << endl;
    cout << noHas << ":" << (mh->getCard(12))->getUsageStatus() << endl;
    cout << has << ":" << (mh->getCard(20))->getUsageStatus() << endl;
    mh->detractCard(Rope);
    game.updateMaster();
    cout << noHas << ":" << (mh->getCard(9))->getUsageStatus() << endl;
    cout << has << ":" << (mh->getCard(11))->getUsageStatus() << endl;

    cout << "\nTesting updateMasterSegment method" << endl;
    resetSetup(kaiser, kailey, mh);
    mh->detractCard(ColMustard);
    mh->setCard(ProfPlum);
    mh->setCard(MrGreen);
    mh->setCard(MrsPeacock);
    mh->setCard(MissScarlett);
    mh->setCard(MrsWhite);
    mh->detractCard(Knife);
    //mh->setCard(Candlestick); Needs to stay mayHas
    mh->setCard(Revolver);
    //mh->detractCard(Rope); Needs to stay mayHas
    mh->setCard(LeadPipe);
    //mh->setCard(Wrench); Needs to stay mayHas
    //mh->setCard(Hall); Needs to stay mayHas
    mh->setCard(Lounge);
    mh->setCard(DiningRoom);
    mh->setCard(Kitchen);
    mh->setCard(BallRoom);
    mh->setCard(Conservatory);
    mh->setCard(BilliardRoom);
    mh->setCard(Library);
    mh->setCard(Study);
    game.updateMasterSegment(0, 5);
    cout << noHas << ":" << (mh->getCard(0))->getUsageStatus() << endl;
    cout << has << ":" << (mh->getCard(5))->getUsageStatus() << endl;
    game.updateMasterSegment(6, 11);
    cout << noHas << ":" << (mh->getCard(6))->getUsageStatus() << endl;
    cout << has << ":" << (mh->getCard(7))->getUsageStatus() << endl;
    cout << has << ":" << (mh->getCard(9))->getUsageStatus() << endl;
    cout << has << ":" << (mh->getCard(11))->getUsageStatus() << endl;
    game.updateMasterSegment(12, 20);
    cout << noHas << ":" << (mh->getCard(12))->getUsageStatus() << endl;
    cout << has << ":" << (mh->getCard(20))->getUsageStatus() << endl;

    cout << "\nTesting updatePlayers method" << endl;
    //This is pretty hard to test - but it should work as long as the updatePlayer method works

    cout << "\nTesting validateEighteenCards method" << endl;
    resetSetup(kaiser, kailey, mh);
    Game game2("Kenzie", "Kirsten", 9, 9);
    cout << "0:" << game.validateEighteenCards() << endl;
    cout << "1:" << game2.validateEighteenCards() << endl;
    Game game3("Kenzie", "Kirsten", 9, 10);
    cout << "0:" << game3.validateEighteenCards() << endl;

    cout << "\nTesting aPlayerHasCard method" << endl;
    resetSetup(kaiser, kailey, mh);
    cout << "0:" << game.aPlayerHasCard("ColMustard") << endl;
    kaiser->setCard("ColMustard");
    cout << "1:" << game.aPlayerHasCard("ColMustard") << endl;
    kaiser->detractCard(ColMustard);
    kailey->detractCard(ColMustard);
    cout << "0:" << game.aPlayerHasCard("ColMustard") << endl;

    cout << "\nTesting noPlayerHasCard method" << endl;
    resetSetup(kaiser, kailey, mh);
    kaiser->detractCard(ColMustard);
    kailey->detractCard(ColMustard);
    cout << "1:" << game.noPlayerHasCard(ColMustard) << endl;
    kaiser->setCard(ColMustard);
    cout << "0:" << game.noPlayerHasCard(ColMustard) << endl;
    (kailey->getCard(0))->setUsageStatus(mayHas);
    kaiser->detractCard(ColMustard);
    cout << "0:" << game.noPlayerHasCard(ColMustard) << endl;

    cout << "\nTesting transitionPlayersToMaster method" << endl;
    resetSetup(kaiser, kailey, mh);

    kaiser->setCard(ProfPlum);
    kailey->detractCard(ProfPlum);

    kaiser->setCard(Revolver);
    //kailey->detractCard(Revolver);

    //kaiser->setCard(Study);
    kailey->detractCard(Study);

    kaiser->setCard(Hall);
    kailey->setCard(Hall);
    cout << "Success:";
    try
    {
        game.transitionPlayersToMaster();
        cout << "Failure" << endl;
    }
    catch (invalid_argument)
    {
        cout << "Success" << endl;
        kaiser->detractCard(Hall);
        kailey->detractCard(Hall);
    }

    cout << "1:" << game.transitionPlayersToMaster() << endl;
    cout << "0:" << game.transitionPlayersToMaster() << endl;

    cout << has << ":" << (mh->getCard(1))->getUsageStatus() << endl;
    cout << has << ":" << (mh->getCard(8))->getUsageStatus() << endl;
    cout << mayHas << ":" << (mh->getCard(20))->getUsageStatus() << endl;
    cout << noHas << ":" << (mh->getCard(12))->getUsageStatus() << endl;

    cout << "\nTesting ensureNoPlayerHasCard method" << endl;
    resetSetup(kaiser, kailey, mh);
    cout << mayHas << ":" << (kaiser->getCard(20))->getUsageStatus() << endl;
    cout << mayHas << ":" << (kailey->getCard(20))->getUsageStatus() << endl;
    cout << "1:" << game.ensureNoPlayerHasCard(Study) << endl;
    cout << noHas << ":" << (kaiser->getCard(20))->getUsageStatus() << endl;
    cout << noHas << ":" << (kailey->getCard(20))->getUsageStatus() << endl;
    cout << "0:" << game.ensureNoPlayerHasCard(Study) << endl;

    kailey->setCard(Study);
    cout << "Success:";
    try
    {
        game.ensureNoPlayerHasCard(Study);
        cout << "Failure" << endl;
    }
    catch (invalid_argument)
    {
        cout << "Success" << endl;
    }

    cout << "\nTesting ensureNoPlayerButOneHasCard method" << endl;
    resetSetup(kaiser, kailey, mh);
    cout << "0:" << game.ensureNoPlayerButOneHasCard(Knife) << endl;
    kailey->detractCard(Knife);
    cout << "1:" << game.ensureNoPlayerButOneHasCard(Knife) << endl;
    cout << "0:" << game.ensureNoPlayerButOneHasCard(Knife) << endl;
    cout << has << ":" << (kaiser->getCard(6))->getUsageStatus() << endl;
    cout << noHas << ":" << (kailey->getCard(6))->getUsageStatus() << endl;
    kailey->setCard(Knife);
    cout << "Success:";
    try
    {
        game.ensureNoPlayerButOneHasCard(Knife);
        cout << "Failure" << endl;
    }
    catch (invalid_argument)
    {
        cout << "Success" << endl;
    }

    cout << "\nTesting transitionMasterToPlayers method" << endl;
    resetSetup(kaiser, kailey, mh);
    mh->detractCard(ProfPlum);
    mh->setCard(Revolver);
    kaiser->setCard(Revolver);

    cout << "1:" << game.transitionMasterToPlayers() << endl;
    cout << "0:" << game.transitionMasterToPlayers() << endl;

    cout << noHas << ":" << (kaiser->getCard(1))->getUsageStatus() << endl;
    cout << noHas << ":" << (kailey->getCard(1))->getUsageStatus() << endl;
    cout << has << ":" << (kaiser->getCard(8))->getUsageStatus() << endl;
    cout << noHas << ":" << (kailey->getCard(8))->getUsageStatus() << endl;
    cout << mayHas << ":" << (kaiser->getCard(12))->getUsageStatus() << endl;
    cout << mayHas << ":" << (kailey->getCard(12))->getUsageStatus() << endl;

    cout << "\nTesting displayAllPlayers method" << endl;
    cout << "\nTesting displayMasterHand method" << endl;
    cout << "\nTesting initiateRoundOfTurns method" << endl;
    cout << "\nTesting update method" << endl;
    cout << "\nTesting initiateTurn method" << endl;
    resetSetup(kaiser, kailey, mh);
    game.initiateTurn(0);
    cout << game.displayAllPlayers() << endl;
    game.initiateTurn(1);
    cout << game.displayAllPlayers() << endl;
}

int main()
{
    //nodeTests();
    //linkedListTests();
    //cardTests();
    //handTests();
    //playerTests();
    //gameTests();

    cout << "Welcome to Clue!" << endl;
    int playersPlaying;
    bool failed = true;

    do
    {
        cout << "How many players will be playing?:";
        cin >> playersPlaying;
        cout << endl;

        if(cin.fail())
        {
            cin.clear();
            cin.ignore(numeric_limits<streamsize>::max(),'\n');
            failed = true;
            cout << "You did not enter a valid number of players who are playing." << endl;
            cout << "Please try again." << endl;
        }
        else
        {
            failed = false;
        }
    }while (failed == true);

    Game game(playersPlaying);

    while (game.solutionFound() == false)
    {
        game.initiateRoundOfTurns();
        cout << game.displayAllPlayers() << endl;
    }
    string s;
    string w;
    string r;
    game.getSolutionFound(s,w,r);

    cout << "I have found the solution!!!!" << endl;
    cout << "It was " << s << " with the " << w << " in the " << r << "." << endl;
    cout << "Thanks for playing." << endl;
    cout << "ANOTHER FANTASTIC GAME BY KAISER SLOCUM." << endl;
    cout << "INSPIRED AND GIFTED BY GOD!" << endl;
    cout << "ALL GOD'S AND KAISER'S RIGHTS ARE RESERVED BY THEM." << endl;
    cin >> playersPlaying;

    return 0;
}
