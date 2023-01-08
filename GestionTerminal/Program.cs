using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class Herbivore : Formedevie
    {
        public string? male;
        public string? female;
    }
    class Carnivore : Formedevie
    {
        public string? male;
        public string? female;
    }
    class Plante : Formedevie
    { }
    class Viande : Formedevie
    { }
    class DechetOrganique : Formedevie
    { }
    class Formedevie
    {
        public int pv;
        public int pe;
        public string? name;
        public int nb;
        public int x;
        public int y;


        public virtual void Deplacement(Herbivore her, Carnivore car, Plante pl, Viande v, DechetOrganique d)
        {
            Random rd = new Random();
            int contact = rd.Next(1, 10);
            switch (contact)
            {
                case 1:
                    car.x += 50;
                    break;
                case 2:
                    car.x -= 50;
                    break;
                case 3:
                    car.y += 50;
                    break;
                case 4:
                    car.y += 50;
                    break;
                default:
                    break;
            }
        }
        public virtual void Deplacement2(Herbivore her, Carnivore car, Plante pl, Viande v, DechetOrganique d)
        {
            Random rd = new Random();
            int contact = rd.Next(1, 10);
            switch (contact)
            {
                case 1:
                    her.x += 50;
                    break;
                case 2:
                    her.x -= 50;
                    break;
                case 3:
                    her.y += 50;
                    break;
                case 4:
                    her.y += 50;
                    break;
                default:
                    break;
            }
        }
        public virtual void Attaquer(Herbivore her, Carnivore car, Plante pl, Viande v, DechetOrganique d)
        {
            Random rd = new Random();
            int contact = rd.Next(0, 5);
            if (contact == 1)
            {
                Console.WriteLine("Le " + car.name + " attaque le " + car.name);
                car.pv = car.pv - 20;
            }
            if (car.x == her.x && car.y == her.y)
            {
                Console.WriteLine("Le " + car.name + " attaque le " + her.name);
                her.pv = her.pv - 25;
            }
            if (her.x == pl.x && her.y == pl.y)
            {
                Console.WriteLine("Le " + her.name + " attaque l' " + pl.name);
                pl.pv = pl.pv - 100;
                Console.WriteLine("Le " + her.name + " se nourrit");
                her.pe = 10;
            }
        }
        public virtual void Mort(Herbivore her, Carnivore car, Plante pl, Viande v, DechetOrganique d)
        {
            if (her.pv < 1)
            {
                Console.WriteLine("Un parasaure est mort");
                her.nb = her.nb - 1;
                her.pv = 100;
                v.nb = v.nb + 1;
                v.x = her.x;
                v.y = her.y;
            }
            if (car.pv < 1)
            {
                Console.WriteLine("Un trex est mort");
                car.nb = car.nb - 1;
                car.pv = 100;
                v.nb = v.nb + 1;
                v.x = car.x;
                v.y = car.y;
            }
            if (pl.pv < 1)
            {
                Console.WriteLine("L'herbe est morte");
                pl.nb = pl.nb - 1;
                her.pv = 100;
                d.nb = d.nb + 1;
                d.x = pl.x;
                d.y = pl.y;
            }
        }
        public virtual void Accouplement(Herbivore her, Carnivore car, Plante pl, Viande v, DechetOrganique d)
        {
            Random rd = new Random();
            int hasard = rd.Next(0, 10);
            if (hasard == 1)
            {
                if (her.nb >= 2)
                {
                    Console.WriteLine("un " + her.name + " est né");
                    her.nb = her.nb + 1;
                }
            }
            if (hasard == 2)
            {
                if (car.nb >= 2)
                {
                    Console.WriteLine("un " + car.name + " est né");
                    car.nb = car.nb + 1;
                }
            }
            pl.nb = pl.nb * 2;
            if (pl.nb > 100)
            {
                pl.nb = 100;
            }
        }
        public virtual void ConversionPvPe(Herbivore her, Carnivore car, Plante pl, Viande v, DechetOrganique d)
        {
            if (her.pe < 1)
            {
                Console.WriteLine(her.name + " a faim");
                her.pv = her.pv - 10;
                her.pe = her.pe + 10;
            }
            if (pl.pe < 1)
            {
                Console.WriteLine(pl.name + " a besoin de nutriments");
                pl.pv = pl.pv - 10;
                pl.pe = pl.pe + 10;
            }
            if (car.pe < 1)
            {
                Console.WriteLine(car.name + " a faim");
                car.pv = car.pv - 10;
                car.pe = car.pe + 10;
            }
        }

        public virtual void Nourrir(Herbivore her, Carnivore car, Plante pl, Viande v, DechetOrganique d)
        {
            if (car.x == v.x && car.y == v.y)
            {
                Console.WriteLine("Le " + car.name + " se nourrit");
                car.pe += 10;
                v.nb -= 1;
            }
            if (pl.x == d.x && pl.y == d.y)
            {
                Console.WriteLine("L'" + pl.name + " se nourrit");
                pl.pe += 10;
                d.nb -= 1;
            }

        }

        static void Main(string[] args)
        {
            Formedevie mesformedevie = new Formedevie();

            Carnivore trex = new Carnivore();
            trex.pv = 100;
            trex.pe = 10;
            trex.name = "trex";
            trex.nb = 2;
            trex.male = "tmale";
            trex.female = "tfemale";
            trex.x = 100;
            trex.y = 150;

            Viande viande = new Viande();
            viande.nb = 1;
            viande.x = 50;
            viande.y = 150;
            viande.pe = 10;

            DechetOrganique dechet = new DechetOrganique();
            dechet.nb = 1;
            dechet.x = 50;
            dechet.y = 0;

            Herbivore parasaure = new Herbivore();
            parasaure.pv = 100;
            parasaure.pe = 10;
            parasaure.name = "parasaure";
            parasaure.nb = 2;
            parasaure.male = "pmale";
            parasaure.female = "pfemale";
            parasaure.x = 150;
            parasaure.y = 150;

            Plante herbe = new Plante();
            herbe.pv = 100;
            herbe.pe = 10;
            herbe.name = "herbe";
            herbe.nb = 2;
            herbe.x = 100;
            herbe.y = 100;

            Console.WriteLine("Initialisation");
            Console.WriteLine("--------------------------");

            Console.WriteLine("Le parasaure a " + parasaure.pv + " point de vie");
            Console.WriteLine("Le parasaure a " + parasaure.pe + " point d'energie");
            Console.WriteLine("Le trex a " + trex.pv + " point de vie");
            Console.WriteLine("Le trex a " + trex.pe + " point d'energie");
            Console.WriteLine("Le herbe a " + herbe.pv + " point de vie");
            Console.WriteLine("Le herbe a " + herbe.pe + " point d'energie");
            Console.WriteLine("--------------------------");

            for (int day = 0; day < 50; day++)
            {
                Console.WriteLine("Jour " + day);
                Console.WriteLine("");

                parasaure.pe = parasaure.pe - 1;
                trex.pe = trex.pe - 1;
                viande.pe = viande.pe - 1;
                herbe.pe = herbe.pe - 1;

                mesformedevie.Deplacement(parasaure, trex, herbe, viande, dechet);           
                mesformedevie.Deplacement2(parasaure, trex, herbe, viande, dechet);            
                mesformedevie.Attaquer(parasaure, trex, herbe, viande, dechet);              
                mesformedevie.Mort(parasaure, trex, herbe, viande, dechet);              
                mesformedevie.ConversionPvPe(parasaure, trex, herbe, viande, dechet);               
                mesformedevie.Nourrir(parasaure, trex, herbe, viande, dechet);              
                mesformedevie.Accouplement(parasaure, trex, herbe, viande, dechet);
                Console.WriteLine("");

                Console.WriteLine("Le parasaure a " + parasaure.pv + " point de vie");
                Console.WriteLine("Le trex a " + trex.pv + " point de vie");
                Console.WriteLine("Le herbe a " + herbe.pv + " point de vie");

                Console.WriteLine("");

                Console.WriteLine("Position du " + trex.name + " : (" + trex.x + "," + trex.y + ")");
                Console.WriteLine("Position du " + parasaure.name + " : (" + parasaure.x + "," + parasaure.y + ")");
                
                Console.WriteLine("Il reste " + herbe.nb + " " + herbe.name);
                Console.WriteLine("Il reste " + parasaure.nb + " " + parasaure.name);
                Console.WriteLine("Il reste " + trex.nb + " " + trex.name);
                Console.WriteLine("--------------------------");
            }
            Console.WriteLine("Extinction de la vie");
        }
    }
}

