using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smart_home.Models
{
    class Device
    {
        private int id;
        private string libelle;
        private string nom;
        private int status;
        private int zoneId;
        private int X;
        private int Y;

        public Device(int id, string libelle, string nom, int status, int zoneId, int x, int y)
        {
            this.id = id;
            this.libelle = libelle;
            this.nom = nom;
            this.status = status;
            this.zoneId = zoneId;
            this.X = x;
            this.Y = y;
        }

        public Device(string libelle, int zoneId, int x, int y)
        {
            this.libelle = libelle;
            this.zoneId = zoneId;
            this.X = x;
            this.Y = y;
        }

        public int Id { get => id; set => id = value; }
        public string Libelle { get => libelle; set => libelle = value; }
        public int ZoneId { get => zoneId; set => zoneId = value; }
        public int Status { get => status; set => status = value; }
        public int X1 { get => X; set => X = value; }
        public int Y1 { get => Y; set => Y = value; }
        public string Nom { get => nom; set => nom = value; }
    }
}
