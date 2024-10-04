using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace Json_Ornegi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private List<Kitap> list = new List<Kitap>();
        JavaScriptSerializer tercuman = new JavaScriptSerializer();

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Kaydet_Click(object sender, EventArgs e)
        {
            Kitap kitap = new Kitap();
            kitap.baslik = textBox1.Text;
            kitap.fiyat = numericUpDown1.Value;
            list.Add(kitap);
            JsonDosyasınaYaz(list);
        }

        private void JsonDosyasınaYaz(List<Kitap> list)
        {
           string jason = tercuman.Serialize(list);//listeyi json a çevirir
             File.WriteAllText("../../kitaplar.jason",jason);//önce yol sonra içerik verdik//siler ve yazar
            //File.AppendAllText("../../kitaplar.jason", jason);
        }

        private void jsonAdd_Click(object sender, EventArgs e)
        {
            string icerik = File.ReadAllText("../../kitaplar.jason");
            var liste = tercuman.Deserialize<List<Kitap>>(icerik);

            listBox1.DisplayMember = "baslik";
            foreach (Kitap kit in liste)
            {
                listBox1.Items.Add((kit));
            }
        }
    }
}
