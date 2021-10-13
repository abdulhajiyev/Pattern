using System;
using System.Collections.Generic;

namespace Flyweight
{
    public class Program
    {
        // All player types and weapon (used by getRandPlayerType()
        // and getRandWeapon()
        private static string[] _playerType = { "Terrorist", "CounterTerrorist" };
        private static string[] _weapons = { "AK-47", "M4A4", "Gut Knife", "Desert Eagle" };

        public static void Main(string[] args)
        {
            PlayerFactory factory = new PlayerFactory();

            List<IPlayer> units = new List<IPlayer>();

            for (int i = 0; i < 1000000; i++)
            {
                /*Terrorist unit = new Terrorist();
                CounterTerrorist unit2 = new CounterTerrorist();
                unit2.AssignWeapon(GetRandWeapon());
                unit2.Mission();
                units.Add(unit2);*/

                IPlayer unit = factory.GetPlayer(GetRandPlayerType());

                unit.AssignWeapon(GetRandWeapon());
                unit.Mission();

                units.Add(unit);
            }

            Console.ReadKey();
        }

        public static string GetRandPlayerType()
        {
            Random r = new Random();
            //  Will return an integer between [0,2)
            int randInt = r.Next(_playerType.Length);
            //  return the player stored at index 'randInt'
            return _playerType[randInt];
        }

        public static string GetRandWeapon()
        {
            Random r = new Random();
            //  Will return an integer between [0,5)
            int randInt = r.Next(_weapons.Length);
            //  Return the weapon stored at index 'randInt'
            return _weapons[randInt];
        }
    }



    public interface IPlayer
    {
        public void AssignWeapon(string weapon);
        public void Mission();
    }

    public class PlayerFactory
    {
        private Dictionary<string, IPlayer> dic = new();

        public IPlayer GetPlayer(String type)
        {
            IPlayer p = null;
            if (dic.ContainsKey(type))
            {
                p = dic[type];
            }
            else
            {
                switch (type)
                {
                    case "Terrorist":
                        Console.WriteLine("Terrorist Created");
                        p = new Terrorist();
                        break;
                    case "CounterTerrorist":
                        Console.WriteLine("Counter Terrorist Created");
                        p = new CounterTerrorist();
                        break;
                }

                // Once created insert it into the HashMap
                dic[type] = p;
            }

            return p;
        }
    }

    public class CounterTerrorist : IPlayer
    {
        //  Intrinsic Attribute
        private string Task;

        //  Extrinsic Attribute
        private string _weapon;

        public void AssignWeapon(string weapon)
        {
            //  Assign a weapon
            _weapon = weapon;
        }

        public void Mission()
        {
            // Work on the Mission
            Console.WriteLine("Counter Terrorist with weapon " + _weapon + "|" + " Task is " + Task);
        }

        public CounterTerrorist()
        {
            Task = "DEFUSE BOMB";
        }
    }

    public class Terrorist : IPlayer
    {
        //  Intrinsic Attribute
        private string Task;

        //  Extrinsic Attribute
        private string _weapon;

        public void AssignWeapon(string weapon)
        {
            //  Assign a weapon
            _weapon = weapon;
        }

        public void Mission()
        {
            // Work on the Mission
            Console.WriteLine("Terrorist with weapon " + _weapon + "|" + " Task is " + Task);
        }

        public Terrorist()
        {
            Task = "PLANT A BOMB";
        }
    }
}