using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smart_home
{
    class myHome
    {
        private int id;
        private string idUser;
        private string nbrZone;
        private int l;
        private int m;

        public myHome(string idUser, string nbrZone, int l, int m)
        {
            this.idUser = idUser;
            this.nbrZone = nbrZone;
            this.l = l;
            this.m = m;
        }

        public myHome(int id, string idUser, string nbrZone, int l, int m)
        {
            this.id = id;
            this.idUser = idUser;
            this.nbrZone = nbrZone;
            this.l = l;
            this.m = m;
        }

        public int Id { get => id; set => id = value; }
        public string IdUser { get => idUser; set => idUser = value; }
        public string NbrZone { get => nbrZone; set => nbrZone = value; }
        public int L { get => l; set => l = value; }
        public int M { get => m; set => m = value; }
    }

}
