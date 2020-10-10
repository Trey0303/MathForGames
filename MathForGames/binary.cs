using System;
using System.Collections.Generic;
using System.Text;

namespace MathForGames
{
    class binary
    {
        const byte CHAINSAW = 0x01;
        const byte PISTOL = 0x01 << 1;
        const byte SHOTGUN = 0x01 << 2;
        const byte SUPER_SHOTGUN = 0x01 << 3;
        const byte CHAINGUN = 0x01 << 4;
        const byte ROCKET_LAUNCHER = 0x01 << 5;
        const byte PLASMA_GUN = 0x01 << 6;
        const byte BFG9000 = 0x01 << 7;
        //static void Main(string[] args)
        //{
        //    byte inventory = 0;
        //    inventory |= PLASMA_GUN;
        //    inventory |= PISTOL;
        //    inventory |= CHAINSAW;
        //    PrintInventory(inventory);
        //    Console.ReadLine();
        //}
        public static void AddToInventory(ref byte inventory, byte weapon)
        {
            inventory |= weapon;
        }
        public static void PrintInventory(byte inventory)
        {
            Console.Write("Fists | ");
            if ((inventory & CHAINSAW) == CHAINSAW)
                Console.Write("Chainsaw | ");
            if ((inventory & PISTOL) == PISTOL)
                Console.Write("Pistol | ");
            if ((inventory & SHOTGUN) == SHOTGUN)
                Console.Write("Shotgun | ");
            if ((inventory & SUPER_SHOTGUN) == SUPER_SHOTGUN)
                Console.Write("Super Shotgun | ");
            if ((inventory & CHAINGUN) == CHAINGUN)
                Console.Write("Chaingun | ");
            if ((inventory & ROCKET_LAUNCHER) == ROCKET_LAUNCHER)
                Console.Write("Rocket Launcher | ");
            if ((inventory & PLASMA_GUN) == PLASMA_GUN)
                Console.Write("Plasma Gun | ");
            if ((inventory & BFG9000) == BFG9000)
                Console.Write("BFG 9000 | ");
            Console.Write("\n");
        }

    }
}
