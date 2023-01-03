using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smart_home
{
    class Zone
    {
        private int id;
        private string libelle;
        private string nom;
        private int status;
        private int x;
        private int y;
        private int w;
        private int h;

        public Zone(string libelle)
        {
            this.libelle = libelle;
        }

        public Zone(int id, string libelle, string nom, int x, int y, int w, int h, int status)
        {
            this.id = id;
            this.libelle = libelle;
            this.nom = nom;
            this.x = x;
            this.y = y;
            this.w = w;
            this.h = h;
            this.status = status;
        }

        public Zone(string libelle, string nom, int x, int y, int w, int h)
        {
            this.libelle = libelle;
            this.nom = nom;
            this.x = x;
            this.y = y;
            this.w = w;
            this.h = h;
        }

        public int Id { get => id; set => id = value; }
        public string Libelle { get => libelle; set => libelle = value; }
        public string Nom { get => nom; set => nom = value; }
        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public int W { get => w; set => w = value; }
        public int H { get => h; set => h = value; }
        public int Status { get => status; set => status = value; }
    }
}
