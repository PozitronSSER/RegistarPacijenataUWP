using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistarPacijenataUWP
{
    class Pacijent
    {
        private string ime;
        private string prezime;
        private string imeMajke;
        private string imeOca;
        private string adresa;
        private string kontaktTelefon;
        private string datumRodjenja;
        private string spol;
        private string paritetTrudnoce;
        private string stavDjeteta;
        private string plodnost;
        private string nacinTrudnoce;
        private string gestacijskaDobTjedni;
        private string gestacijskaDobDani;
        private string porod;
        private string trajanjePoroda;
        private string profilaksa;
        private string prom;
        private string febrilitet;
        private string rm;
        private string rd;
        private string og;
        private string apgarIndeks;
        private string reanimacija;
        private string patologije;
        private string komplikacije;

        public Pacijent(string ime, string prezime, string imeMajke, string imeOca, string adresa, string kontaktTelefon, string datumRodjenja, string spol, string paritetTrudnoce, string stavDjeteta, string plodnost, string nacinTrudnoce, string gestacijskaDobTjedni, string gestacijskaDobDani, string porod, string trajanjePoroda, string profilaksa, string prom, string febrilitet, string rm, string rd, string og, string apgarIndeks, string reanimacija, string patologije, string komplikacije)
        {
            this.ime = ime;
            this.prezime = prezime;
            this.imeMajke = imeMajke;
            this.imeOca = imeOca;
            this.adresa = adresa;
            this.kontaktTelefon = kontaktTelefon;
            this.datumRodjenja = datumRodjenja;
            this.spol = spol;
            this.paritetTrudnoce = paritetTrudnoce;
            this.stavDjeteta = stavDjeteta;
            this.plodnost = plodnost;
            this.nacinTrudnoce = nacinTrudnoce;
            this.gestacijskaDobTjedni = gestacijskaDobTjedni;
            this.gestacijskaDobDani = gestacijskaDobDani;
            this.porod = porod;
            this.trajanjePoroda = trajanjePoroda;
            this.profilaksa = profilaksa;
            this.prom = prom;
            this.febrilitet = febrilitet;
            this.rm = rm;
            this.rd = rd;
            this.og = og;
            this.apgarIndeks = apgarIndeks;
            this.reanimacija = reanimacija;
            this.patologije = patologije;
            this.komplikacije = komplikacije;
        }

        public override string ToString()
        {
            string opisObjekta;
            opisObjekta = ime +" "+  prezime +" "+  imeMajke +" "+  imeOca +" "+  adresa +" "+  kontaktTelefon +" "+ 
                    datumRodjenja +" "+  spol +" "+  paritetTrudnoce +" "+  stavDjeteta +" "+  plodnost +" "+  nacinTrudnoce +" "+ 
                    gestacijskaDobTjedni +" "+  gestacijskaDobDani +" "+  porod +" "+  trajanjePoroda +" "+  profilaksa +" "+ 
                    prom +" "+  febrilitet +" "+  rm +" "+  rd +" "+  og +" "+  apgarIndeks +" "+  reanimacija +" "+  patologije +" "+  komplikacije;

            return opisObjekta;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
