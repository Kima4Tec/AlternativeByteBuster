using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AlternativeByteBuster
{
    internal class Grafik
    {
        public void Skriv(int x, int y, string tekst) //en metode, hvor jeg kan positionere en tekst
        {
            Console.SetCursorPosition(x, y);
            Console.Write(tekst);
        }
        public void ByteBusterLogo(int x, int y) //jeg har lavet et logo tegnet med x'er, som jeg kan positionere med Skriv-metoden
        {
            Skriv(x, y + 0, "                                                                                              ");
            Skriv(x, y + 1, "                               ╔══╗────╔╗───╔══╗──────╔╗                                      ");
            Skriv(x, y + 2, "                               ║╔╗║───╔╝╚╗──║╔╗║─────╔╝╚╗                                     ");
            Skriv(x, y + 3, "                               ║╚╝╚╦╗─╠╗╔╬══╣╚╝╚╦╗╔╦═╩╗╔╬══╦═╗                                ");
            Skriv(x, y + 4, "                               ║╔═╗║║─║║║║║═╣╔═╗║║║║══╣║║║═╣╔╝                                ");
            Skriv(x, y + 5, "                               ║╚═╝║╚═╝║╚╣║═╣╚═╝║╚╝╠══║╚╣║═╣║                                 ");
            Skriv(x, y + 6, "                               ╚═══╩═╗╔╩═╩══╩═══╩══╩══╩═╩══╩╝                                 ");
            Skriv(x, y + 7, "                               ────╔═╝║                                                       ");
            Skriv(x, y + 8, "                               ────╚══╝                                                       ");
            Skriv(x, y + 9, "                                                                                              ");
        }
        public void EmptyBox(int x, int y) //denne kan jeg bruge som en clear af det tekst-område som jeg bruger
        {
            Skriv(x, y + 0, "                                                                                             ");
            Skriv(x, y + 1, "                                                                                             ");
            Skriv(x, y + 2, "                                                                                             ");
            Skriv(x, y + 3, "                                                                                             ");
            Skriv(x, y + 4, "                                                                                             ");
            Skriv(x, y + 5, "                                                                                             ");
            Skriv(x, y + 6, "                                                                                             ");
            Skriv(x, y + 7, "                                                                                             ");
            Skriv(x, y + 8, "                                                                                             ");
            Skriv(x, y + 9, "                                                                                             ");
            Skriv(x, y + 10, "                                                                                             ");
            Skriv(x, y + 11, "                                                                                             ");
            Skriv(x, y + 12, "                                                                                             ");
        }
   
        public void Rammer() //rammerne omkring logo og tekstfeltet
        {
            //Her tegner jeg et rektangel

            //første vandrette streg
            for (int i = 0; i < 93; i++)
            {
                Skriv(13 + i, 1, "─");
            }
            //anden vandrette stribe
            for (int i = 0; i < 93; i++)
            {
                Skriv(13 + i, 10, "─");
            }
            //tredje vandrette stribe
            for (int i = 0; i < 93; i++)
            {
                Skriv(13 + i, 24, "─");
            }
            //venstre lodret streg
            for (int i = 0; i < 22; i++)
            {
                Skriv(12, 2 + i, "│");
            }
            //højre lodret streg
            for (int i = 0; i < 22; i++)
            {
                Skriv(106, 2 + i, "│");
            }
            //venstre top hjørne
            Skriv(12, 1, "┌");

            //Højre top hjørne
            Skriv(106, 1, "┐");

            //Venstre ml hjørne
            Skriv(12, 10, "├");

            //Højre ml hjørne
            Skriv(106, 10, "┤");

            //Venstre ml hjørne
            Skriv(12, 24, "└");

            //Højre nedre hjørne
            Skriv(106, 24, "┘");

        }
    }
}