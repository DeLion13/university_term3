using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;

namespace lab4
{

    public interface IGameStrategy
    {
        int DeployCardGame();
    }
    public class PokerTexas : IGameStrategy
    {
        public PokerTexas()
        {
            Console.WriteLine("You are playing Poker Texas Holdem!");
        }
        public int DeployCardGame()
        {
            return 2;
        }
    }
    public class Durak : IGameStrategy
    {
        public Durak()
        {
            Console.WriteLine("You are playing Durak!");
        }
        public int DeployCardGame()
        {
            return 6;
        }
    }
    public class BlackJack : IGameStrategy
    {
        public BlackJack()
        {
            Console.WriteLine("You are playing BlackJack!");
        }
        public int DeployCardGame()
        {
            return 1;
        }
    }
    public class GameItem
    {
        private IGameStrategy _ItemGame;
        private int _ItemCount;

        public GameItem()
        {
        }
        public void GiveCards(IGameStrategy game)
        {
            _ItemGame = game;
            _ItemCount = game.DeployCardGame();
        }
        public int ItemCount
        {
            get { return _ItemCount; }
            set {
                Console.WriteLine("You cannot change the rules!\n");
            }
        }
    }
}
