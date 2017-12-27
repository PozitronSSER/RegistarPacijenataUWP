using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace RegistarPacijenataUWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            // lista za ComboBox "Spol"
            List<String> listSpol = new List<string>();
            listSpol.Add("M");
            listSpol.Add("Ž");
            cmbSpol.ItemsSource = listSpol;

            // lista za ComboBox "Paritet trudnoće"
            List<String> listParitet = new List<string>();
            listParitet.Add("1");
            listParitet.Add("2");
            listParitet.Add("3");
            listParitet.Add("4 i više");
            cmbParitetTrudnoće.ItemsSource = listParitet;

            // lista za ComboBox "Stav djeteta"
            List<String> listStav = new List<string>();
            listStav.Add("Glava");
            listStav.Add("Nožice");
            listStav.Add("Zadak");
            cmbStavDjeteta.ItemsSource = listStav;

            List<String> listPlodnost = new List<string>();
            listPlodnost.Add("Jednoplodna");
            listPlodnost.Add("Višeplodna");
            cmbPlodnost.ItemsSource = listPlodnost;

            List<String> listTrudnoca = new List<string>();
            listTrudnoca.Add("Prirodna");
            listTrudnoca.Add("Potpomognuta");
            cmbTrudnoca.ItemsSource = listTrudnoca;

            List<String> listPorod = new List<string>();
            listPorod.Add("Vaginalno");
            listPorod.Add("Carski rez");
            cmbPorod.ItemsSource = listPorod;

            List<String> listProfilaksa = new List<string>();
            listProfilaksa.Add("Da");
            listProfilaksa.Add("Ne");
            listProfilaksa.Add("Nepotpuna");
            cmbProfilaksa.ItemsSource = listProfilaksa;

            List<String> listProm = new List<string>();
            listProm.Add("Da");
            listProm.Add("Ne");
            cmbPROM.ItemsSource = listProm;

            List<String> listFebrilitet = new List<string>();
            listFebrilitet.Add("Da");
            listFebrilitet.Add("Ne");
            cmbFebrilitet.ItemsSource = listFebrilitet;

            List<String> listReanimacija = new List<string>();
            listReanimacija.Add("Da");
            listReanimacija.Add("Ne");
            cmbReanimacija.ItemsSource = listReanimacija;

        }


        private void btnNastavi_Click(object sender, RoutedEventArgs e)
        {

            //varijable za konstruktor
            string ime, prezime, imeMajke, imeOca, adresa, kontaktTelefon, datumRodjenja,
                spol, paritetTrudnoce, stavDjeteta, plodnost, nacinTrudnoce, 
                gestacijskaDobTjedni, gestacijskaDobDani, porod, trajanjePoroda, 
                profilaksa, prom, febrilitet, rm, rd, og, apgarIndeks, reanimacija,
                patologije, komplikacije;

            // liste za chkBox
            List<String> patologija = new List<string>();
            List<String> komplikacija = new List<string>();

            /*************** spremanje podataka sa obrasca u varijable***************/
            ime = txtIme.Text;
            prezime = txtPrezime.Text;
            imeMajke = txtImeMajke.Text;
            imeOca = txtImeOca.Text;
            adresa = txtAdresa.Text;
            kontaktTelefon = txtBrojTelefona.Text;
            trajanjePoroda = txtTrajanjePoroda.Text;
            rm = txtRodnaMasa.Text;
            rd = txtRodnaDuljina.Text;
            og = txtOpsegGlave.Text;
            apgarIndeks = txtApgar.Text;
            gestacijskaDobTjedni = txtGestacijskaDobTjedana.Text;
            gestacijskaDobDani = txtGestacijskaDobDana.Text;

            // dodavanje odabranih opcija za Patologiju trudnoće u List<string> (primjer Castinga)
            if ((bool)chkKrvarenje.IsChecked) { patologija.Add("Krvarenje"); }
            if ((bool)chkDijabetes.IsChecked) { patologija.Add("Dijabetes"); }
            if ((bool)chkPPI.IsChecked) { patologija.Add("PPI"); }
            if ((bool)chkInfekcije.IsChecked) { patologija.Add("Infekcije"); }
            if ((bool)chkHipertenzija.IsChecked) { patologija.Add("Hipertenzija"); }
            if (txtPatologijaOstalo.Text != null) { patologija.Add(txtPatologijaOstalo.Text); }
            
            // konverzija List<string> u string za upis u XML
            patologije = string.Join("\n", patologija.ToArray());

            // dodavanje odabranih opcija za Komplikacije u List<string> (primjer bez Castinga)
            if (chkHipoglikemija.IsChecked.Value) { komplikacija.Add("Hipoglikemija"); }
            if (chkRDS.IsChecked.Value) { komplikacija.Add("RDS"); }
            if (chkVentilacija.IsChecked.Value) { komplikacija.Add("Mehanička ventilacija"); }
            if (chkSepsa.IsChecked.Value) { komplikacija.Add("Sepsa"); }
            if (chkBilirubin.IsChecked.Value) { komplikacija.Add("Hiperbilirubinemija"); }
            if (chkKonvulzije.IsChecked.Value) { komplikacija.Add("Konvulzije"); }
            if (chkPVL.IsChecked.Value) { komplikacija.Add("PVL"); }
            if (chkPVIVH.IsChecked.Value) { komplikacija.Add("PV-IVH"); }
            if (chkNEC.IsChecked.Value) { komplikacija.Add("NEC"); }
            if (chkROP.IsChecked.Value) { komplikacija.Add("ROP"); }
            if (txtKomplikacijeOstalo.Text != null || txtKomplikacijeOstalo.Text == "") { komplikacija.Add(txtKomplikacijeOstalo.Text); }
            
            // konverzija List<string> u string za upis u XML
            komplikacije = string.Join("\n", komplikacija.ToArray());


            // provjera da li je sve odabrano i upozorenje korisniku ako nije
            try
            {
                datumRodjenja = dateDatumRodjenja.Date.ToString();
                spol = cmbSpol.SelectedItem.ToString();
                paritetTrudnoce = cmbParitetTrudnoće.SelectedItem.ToString();
                stavDjeteta = cmbStavDjeteta.SelectedItem.ToString();
                plodnost = cmbPlodnost.SelectedItem.ToString();
                nacinTrudnoce = cmbTrudnoca.SelectedItem.ToString();
                porod = cmbPorod.SelectedItem.ToString();
                profilaksa = cmbProfilaksa.SelectedItem.ToString();
                prom = cmbPROM.SelectedItem.ToString();
                febrilitet = cmbFebrilitet.SelectedItem.ToString();
                reanimacija = cmbReanimacija.SelectedItem.ToString();

                /********** kreiranje objekta **********/

                Pacijent unos = new Pacijent(ime, prezime, imeMajke, imeOca, adresa, kontaktTelefon,
                    datumRodjenja, spol, paritetTrudnoce, stavDjeteta, plodnost, nacinTrudnoce,
                    gestacijskaDobTjedni, gestacijskaDobDani, porod, trajanjePoroda, profilaksa,
                    prom, febrilitet, rm, rd, og, apgarIndeks, reanimacija, patologije, komplikacije);

                // provjera podataka
                MsgBox.Show(unos.ToString(), "test");

                // prebacivanje podataka u XML

                /*
                if (!File.Exists("Registar.xml"))
                {
                    XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
                    xmlWriterSettings.Indent = true;
                    xmlWriterSettings.NewLineOnAttributes = true;
                    using (XmlWriter xmlWriter = XmlWriter.Create("Registar.xml", xmlWriterSettings))
                    {
                        xmlWriter.WriteStartDocument();
                        xmlWriter.WriteStartElement("Registar");
                        xmlWriter.WriteStartElement("Pacijent");

                        xmlWriter.WriteElementString("Ime", ime);
                        xmlWriter.WriteElementString("Prezime", prezime);
                        xmlWriter.WriteElementString("Imemajke", imeMajke);
                        xmlWriter.WriteElementString("Imeoca", imeOca);
                        xmlWriter.WriteElementString("Adresa", adresa);
                        xmlWriter.WriteElementString("Kontakttelefon", kontaktTelefon);
                        xmlWriter.WriteElementString("Datumrođenja", Convert.ToString(datumRodenja));
                        xmlWriter.WriteElementString("Spol", spol);
                        xmlWriter.WriteElementString("Paritettrudnoće", paritetTrudnoce);
                        xmlWriter.WriteElementString("PlodnostTrudnoće", trudnocaPlodna);
                        xmlWriter.WriteElementString("PrirodaTrudnoće", trudnocaPrirodna);
                        xmlWriter.WriteElementString("NačinPoroda", nacinPoroda);
                        xmlWriter.WriteElementString("Trajanjeporoda", trajanjePoroda);
                        xmlWriter.WriteElementString("Stavdjeteta", stavDjeteta);
                        xmlWriter.WriteElementString("Profilaksa", profilaksa);
                        xmlWriter.WriteElementString("PROM", prom);
                        xmlWriter.WriteElementString("Ferbrilitet", febrilitetRodilje);
                        xmlWriter.WriteElementString("Patologijatrudnoće", ConvertStringArrayToStringJoin(patologijaTrudnoce));
                        xmlWriter.WriteElementString("Gestacijskadobtjedni", Convert.ToString(gestacijskaDobTjedana));
                        xmlWriter.WriteElementString("Gestacijskadobdani", Convert.ToString(gestacijskaDobDana));
                        xmlWriter.WriteElementString("Rodnamasa", Convert.ToString(rodnaMasa));
                        xmlWriter.WriteElementString("Rodnaduljina", Convert.ToString(rodnaDuljina));
                        xmlWriter.WriteElementString("Opsegglave", Convert.ToString(opsegGlave));
                        xmlWriter.WriteElementString("Apgarindeks", apgarIndeks);
                        xmlWriter.WriteElementString("Reanimacija", reanimacija);
                        xmlWriter.WriteElementString("Komplikacije", ConvertStringArrayToStringJoin(komplikacije));

                        xmlWriter.WriteEndElement();
                        xmlWriter.WriteEndElement();
                        xmlWriter.WriteEndDocument();
                        xmlWriter.Flush();
                        xmlWriter.Close();
                    }
                }
                else
                {
                    */

                

                    XDocument xDocument = XDocument.Load("Registar.xml");
                    XElement root = xDocument.Element("Registar");
                    IEnumerable<XElement> rows = root.Descendants("Pacijent"); 
                    XElement firstRow = rows.First();

                    firstRow.AddBeforeSelf(
                        new XElement("Pacijent",
                        new XElement("Ime", ime),
                        new XElement("Prezime", prezime),
                        new XElement("Imemajke", imeMajke),
                        new XElement("Imeoca", imeOca),
                        new XElement("Adresa", adresa),
                        new XElement("Kontakttelefon", kontaktTelefon),
                        new XElement("Datumrođenja", datumRodjenja),
                        new XElement("Spol", spol),
                        new XElement("Paritettrudnoće", paritetTrudnoce),
                        new XElement("PlodnostTrudnoće", plodnost),
                        new XElement("Prirodatrudnće", nacinTrudnoce),
                        new XElement("NačinPoroda", porod),
                        new XElement("Trajanjeporoda", trajanjePoroda),
                        new XElement("Stavdjeteta", stavDjeteta),
                        new XElement("Profilaksa", profilaksa),
                        new XElement("PROM", prom),
                        new XElement("Ferbrilitet", febrilitet),
                        new XElement("Patologijatrudnoće", patologije),
                        new XElement("Gestacijskadobtjedni", gestacijskaDobTjedni),
                        new XElement("Gestacijskadobdani", gestacijskaDobDani),
                        new XElement("Rodnamasa", rm),
                        new XElement("Rodnaduljina", rd),
                        new XElement("Opsegglave", og),
                        new XElement("Apgarindeks", apgarIndeks),
                        new XElement("Reanimacija", reanimacija),
                        new XElement("Komplikacije", komplikacije)));

                    xDocument.Save();
             //   }

            }
            catch
            {
                MsgBox.Show("Odaberite sva polja!", "Pogreška");
                return;
            }

            


            


            MsgBox.Show("Da li želite unesti još podataka?", "Unos uspješan");
            
            // čišćenje podataka za novi unos
            ocistiPodatke();

        }

        public void ocistiPodatke()
        {
            txtIme.Text = "";
            txtPrezime.Text = "";
            txtImeOca.Text = "";
            txtImeMajke.Text = "";
            txtAdresa.Text = "";
            txtBrojTelefona.Text = "";
            cmbSpol.SelectedItem = null;
            dateDatumRodjenja.SetDisplayDate(System.DateTime.Now);
            cmbParitetTrudnoće.SelectedItem = null;
            cmbStavDjeteta.SelectedItem = null;
            cmbPlodnost.SelectedItem = null;
            cmbTrudnoca.SelectedItem = null;
            txtGestacijskaDobDana.Text = "";
            txtGestacijskaDobTjedana.Text = "";
            chkKrvarenje.IsChecked = false;
            chkDijabetes.IsChecked = false;
            chkPPI.IsChecked = false;
            chkInfekcije.IsChecked = false;
            chkHipertenzija.IsChecked = false;
            chkEPH.IsChecked = false;
            txtPatologijaOstalo.Text = "";
            cmbPorod.SelectedItem = null;
            txtTrajanjePoroda.Text = "";
            cmbProfilaksa.SelectedItem = null;
            cmbPROM.SelectedItem = null;
            cmbFebrilitet.SelectedItem = null;
            txtRodnaMasa.Text = "";
            txtRodnaDuljina.Text = "";
            txtOpsegGlave.Text = "";
            txtApgar.Text = "";
            cmbReanimacija.SelectedItem = null;
            chkHipoglikemija.IsChecked = false;
            chkRDS.IsChecked = false;
            chkVentilacija.IsChecked = false;
            chkSepsa.IsChecked = false;
            chkBilirubin.IsChecked = false;
            chkKonvulzije.IsChecked = false;
            chkPVL.IsChecked = false;
            chkPVIVH.IsChecked = false;
            chkNEC.IsChecked = false;
            chkROP.IsChecked = false;
            txtKomplikacijeOstalo.Text = "";
        }

        private void btnIzlaz_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Exit();
        }
    }
}
