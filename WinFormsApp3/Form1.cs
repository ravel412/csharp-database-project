using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using static System.Net.Mime.MediaTypeNames;
using System.Text;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.Xml;
using System.Windows.Forms;
using System.Diagnostics.Eventing.Reader;
using System.Collections.Generic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Linq;

namespace WinFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            tabControl1.TabPages.Remove(tabPage2);
            tabControl1.TabPages.Remove(tabPage3);
            tabControl1.TabPages.Remove(tabPage4);
            tabControl1.TabPages.Remove(tabPage5);
            dosyaolustur();
            button3.Enabled = false;
            button4.Enabled = false;
            dataGridView1.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
        }

        public static string exeYolu = System.Reflection.Assembly.GetExecutingAssembly().Location;
        public static string klasorYolu = Path.GetDirectoryName(exeYolu);
        public static string dosyaYolu = klasorYolu + @"\temp.txt";


        public void dosyaolustur()
        {
            if (File.Exists(dosyaYolu) == false)
            {
                TextWriter yazivi = new StreamWriter(dosyaYolu);
            }


        }

        public static string connectionaddress;
        private void tabPage2_Click(object sender, EventArgs e)
        {




        }

        private void button2_Click(object sender, EventArgs e)
        {
            TabControl tabControl = (TabControl)sender;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click_1(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click_2(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        public static bool c1, c2, c3, c4, c5;




        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click_2(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            connectionaddress = @"Data Source=" + textBox1.Text + ";Initial Catalog=" + database.Text + ";User = " + kullaniciadi.Text + ";Password = " + sifre.Text + " ";
            funksiyon.connectionadress1 = connectionaddress;
            SqlConnection con = new SqlConnection(funksiyon.connectionadress1);


            try
            {

                funksiyon.baglanti(con);
                SqlCommand sorgu = new SqlCommand("Select * From tblOkulTasarim", con);
                SqlDataAdapter sda = new SqlDataAdapter(sorgu);
                DataTable dtable = new DataTable();
                DataTable dtable2 = new DataTable();
                sda.Fill(dtable);

                dataGridView1.DataSource = dtable;
                dataGridView2.DataSource = dtable;
                tabControl1.TabPages.Remove(tabPage1);
                tabControl1.TabPages.Add(tabPage2);

            }
            catch
            {
                MessageBox.Show("Baglanti Girislerinizde Problem Var. Lutfen Tekrar Deneyiniz.");
            }


            sorts();

        }



        public static string Base64Decode(string sifrelimetin)
        {

            var sifreliMetinBaytlari = Convert.FromBase64String(sifrelimetin);
            return
            Encoding.UTF8.GetString(sifreliMetinBaytlari);
        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }



        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_3(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {
        }

        private void label7_Click(object sender, EventArgs e)
        {
        }

        private void label2_Click_1(object sender, EventArgs e)
        {
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click_4(object sender, EventArgs e)
        {
            tabControl1.TabPages.Add(tabPage3);
            tabControl1.SelectTab(tabPage3);

        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public static string secilen;
        public static string secilenint;
        public static int secilendgs;
        public static string columnName;
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {

            secilen = (dataGridView1.CurrentRow.Cells["Tasarim"].Value).ToString();

            try
            {
                secilen = Base64Decode(secilen);
                File.WriteAllText(dosyaYolu, secilen);
                secilenint = (dataGridView1.CurrentRow.Cells["Id"].Value).ToString();
            }

            catch
            {

                MessageBox.Show("Tikladiginiz hucrenin ait oldugu satirin Tasarim verisi base64 formatinda degil.Olasi bir hatada yonetici ile gorusunuz.");
            }

            secilendgs = Convert.ToInt32(dataGridView1.CurrentCell.ColumnIndex.ToString());
            columnName = this.dataGridView1.Columns[secilendgs].Name;



            label13.Text = secilenint;




        }

        //datagridin s?ralanabilir olmas?n? engellemek ad?na foreach döngüsü
        public void sorts()
        {
            foreach (DataGridViewColumn dgvc in dataGridView1.Columns)
            {
                dgvc.SortMode = DataGridViewColumnSortMode.NotSortable;
            }


        }


        public void refresh()
        {
            SqlConnection connn = new SqlConnection(funksiyon.connectionadress1);
            SqlCommand sorgu = new SqlCommand("Select * From tblOkulTasarim", connn);
            SqlDataAdapter sdaa1 = new SqlDataAdapter(sorgu);
            DataTable dtable = new DataTable();
            sdaa1.Fill(dtable);

            dataGridView1.DataSource = dtable;
            dataGridView2.DataSource = dtable;
        }


        private void button3_Click(object sender, EventArgs e)
        {
            string ornek = File.ReadAllText(dosyaYolu);

            string aliza = ornek.Replace(textBox2.Text, textBox3.Text);

            File.WriteAllText(dosyaYolu, aliza);

            string ornekdecode = Base64Encode(aliza);

            SqlConnection conk = new SqlConnection(funksiyon.connectionadress1);
            conk.Open();
            SqlCommand command = new SqlCommand("UPDATE tblOkulTasarim SET Tasarim=@ta1 WHERE Id= @ta2;", conk);

            command.Parameters.AddWithValue("@ta1", ornekdecode);
            command.Parameters.AddWithValue("@ta2", Convert.ToInt32(secilenint));
            command.ExecuteNonQuery();
            refresh();



        }


        bool condition;
        private void button2_Click_2(object sender, EventArgs e)
        {
            if (secilen == null)
            {

                MessageBox.Show("Oncelikle bir satir seciniz");
            }
            else
            {

                string arama = textBox2.Text;

                string[] okuma = File.ReadAllLines(dosyaYolu);

                for (int i = 0; i < okuma.Length; i++)
                {


                    if (okuma[i].Contains(textBox2.Text))
                    {


                        condition = true;

                        break;


                    }

                    else
                    {

                        condition = false;
                    }

                }
                //araman?n basarili sekilde sonuclanmasi
                if (condition == true)
                {

                    MessageBox.Show("Aramanizda eslesen sonuc veya sonuclar bulundu.Arama yaptiginiz iceren kisimlari degistirmek icin degistirme metnine giris yapip metin butona tiklayabilirsiniz");
                    button3.Enabled = true;
                    button2.Enabled = false;
                    button4.Enabled = true;

                }
                
                //aranan metnin bulunamamas?
                else
                {

                    MessageBox.Show("Aramanizla eslesen sonuclar bulunamadi");
                    button3.Enabled = false;
                    button4.Enabled = false;

                }


            }


        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
           //arama islemleri otokontrolu 
            textBox2.Text = null;
            textBox2.Enabled = true;
            button4.Enabled = false;
            button2.Enabled = true;
            button3.Enabled = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Remove(tabPage3);
        }




        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            c4 = true;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            c1 = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //satir kaydetme icin gerekli fonksiyon ve donguler, diziye kaydedilmek üzere
            refresh();
            int ix = dataGridView1.Rows.Count;
            string[] txts = new string[ix];
            string[] a1 = new string[ix];
            string[] a2 = new string[ix];
            string[] a3 = new string[ix];
            string[] a4 = new string[ix];


            for (int i = 0; i < ix; i++)
            {

                if (c1 == true)
                {
                    if (dataGridView1.Rows[i].Cells[0].Value != null)
                        txts[i] = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    if (dataGridView1.Rows[i].Cells[0].Value == null)
                        txts[i] = " ";




                }


                if (c2 == true)
                {
                    if (dataGridView1.Rows[i].Cells[1].Value != null)
                        a1[i] = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    if (dataGridView1.Rows[i].Cells[1].Value == null)
                        a1[i] = " ";

                }


                if (c3 == true)
                {
                    if (dataGridView1.Rows[i].Cells[2].Value != null)
                        a2[i] = dataGridView1.Rows[i].Cells[2].Value.ToString();
                    if (dataGridView1.Rows[i].Cells[2].Value == null)
                        a2[i] = " ";

                }


                if (c4 == true)
                {

                    if (dataGridView1.Rows[i].Cells[3].Value != null)
                        a3[i] = dataGridView1.Rows[i].Cells[3].Value.ToString();
                    if (dataGridView1.Rows[i].Cells[3].Value == null)
                        a3[i] = " ";

                }

                if (c5 == true)
                {

                    if (dataGridView1.Rows[i].Cells[4].Value != null)
                        a4[i] = dataGridView1.Rows[i].Cells[4].Value.ToString();
                    if (dataGridView1.Rows[i].Cells[4].Value == null)
                        a4[i] = " ";
                }




            }

            string[] alltext = new string[ix];
            //secilen kolonlara gore satir verilerinin eklenmesi
            for (int i = 0; i < ix - 1; i++)
            {
                alltext[i] = "Satir " + i.ToString() + " = " + txts[i] + "  " + a1[i] + "   " + a2[i] + "   " + a3[i] + "   " + a4[i];



            }


            //dosyalar? kaydedici buton ad?na gerekli komutlar
            SaveFileDialog save = new SaveFileDialog();
            save.OverwritePrompt = false;
            save.CreatePrompt = true;
            save.CheckFileExists = false;
            save.CheckPathExists = false;
            save.RestoreDirectory = true;
            save.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            save.InitialDirectory = @"C:\Users\Ahmet\Desktop";
            save.Title = "Txt Dosyasi";
            save.FileName = "kaydet1.txt";
            //txt format?nda kaydetmeyi sa?lama
            save.DefaultExt = "txt";
            save.Filter = "txt Dosyasi (*.txt)|*.txt|Tüm Dosyalar(*.*)|*.*";
            save.ShowDialog();
            if (save.FileName != null)
            {


                StreamWriter texti = new StreamWriter(save.FileName);
                texti.Close();
                File.WriteAllLines(save.FileName, alltext);
                MessageBox.Show("Secilen Verileriniz Basariyla Eklendi.");






            }
            save.FileName = null;


        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            c3 = true;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            c2 = true;
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            c5 = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            
            //yeni verilerin eklenmesi ve parametre i?lemleri
            SqlConnection kl1 = new SqlConnection(funksiyon.connectionadress1);


            SqlCommand comkl1 = new SqlCommand(@"INSERT INTO tblOkulTasarim(Id,TasarimAdi,TasarimKayitTarihi,TasarimGuncellemeTarihi,Tasarim) VALUES (@sk1,@sk2,@sk3,@sk4,@sk5)", kl1);
            comkl1.Parameters.AddWithValue("@sk1", textBox4.Text);
            comkl1.Parameters.AddWithValue("@sk2", textBox5.Text);
            comkl1.Parameters.AddWithValue("@sk3", textBox6.Text);
            comkl1.Parameters.AddWithValue("@sk4", textBox7.Text);
            comkl1.Parameters.AddWithValue("@sk5", textBox8.Text);
            funksiyon.baglanti(kl1);
            //olas? bir base64  decode hatas?n? messagebox'ta göstermesi için bo? bir string
            string mesaj = "";



            //girilen tasar?m verisini base64 format?nda olup olmad???n?n kontrol edilmesi
            try
            {
                string denemequery = Base64Decode(textBox8.Text);
            }
            catch (Exception ex)
            {
                mesaj += "Ek bilgi, Girdiginiz Veri base64 Formatinda degil.";

            }

            //verileri ekleme komutlar?n?n çal??t?r?lmas? aksi halde hata verilmesi
            try
            {
                comkl1.ExecuteNonQuery();
                MessageBox.Show("Verileriniz Eklendi!");
            }

            catch
            {
                MessageBox.Show("Girdiginiz verilerin uygun parametreler icinde olduguna tekrar ediniz!" + mesaj);

            }
            refresh();
            // textBox.Text = string.empty;
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";


        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            //Mevut TabPage'i kapatir ve yönlendirir
            tabControl1.TabPages.Add(tabPage4);
            tabControl1.SelectTab(tabPage4);
        }

        private void textBox4_Click(object sender, EventArgs e)
        {

            textBox4.Font = new Font("Regular", 9);

        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            textBox4.Font = new Font("Italic", 8);

        }

        private void textBox4_ControlRemoved(object sender, ControlEventArgs e)
        {

        }

        private void textBox4_ImeModeChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_Move(object sender, EventArgs e)
        {

        }

        private void textBox4_ParentChanged(object sender, EventArgs e)
        {

        }

        private void tabPage4_ControlRemoved(object sender, ControlEventArgs e)
        {
            textBox4.Font = new Font("Italic", 8);
        }

        private void tabPage4_Move(object sender, EventArgs e)
        {

        }

        private void textBox4_DragDrop(object sender, DragEventArgs e)
        {


        }

        private void textBox4_Validated(object sender, EventArgs e)
        {
            textBox4.Font = new Font("Italic", 8);
        }

        private void textBox6_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            //mevcut TabPage ekranindan ayrilip sunucu TabPage'ine yonlendirme
            tabControl1.TabPages.Remove(tabPage4);
            tabControl1.SelectTab(tabPage2);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //silme için gerekli baglanti, komut ve parametreler
            
            SqlConnection silme = new SqlConnection(funksiyon.connectionadress1);
            SqlCommand silmecmd = new SqlCommand(@"DELETE FROM tblOkultasarim WHERE ID=@xy", silme);
            silmecmd.Parameters.AddWithValue("@xy", secilenint);
            funksiyon.baglanti(silme);
            silmecmd.ExecuteNonQuery();
            
            //silme isleminin ardindan veriyi yeniden select edip yenileme
            refresh();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            //mevcut TabPage'i kapattiktan sonra sunucu TabPage'ine yonlendirme
            tabControl1.TabPages.Add(tabPage5);
            tabControl1.SelectTab(tabPage5);

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            //mevcut tabpage'i kapattiktan sonra sunucu ekranina yonlendirme
            tabControl1.TabPages.Remove(tabPage5);
            tabControl1.SelectTab(tabPage2);
        }


        private void button12_Click(object sender, EventArgs e)
        {


            //yeni sql baglantisi ve komutu olusturma
            SqlConnection dtbl2 = new SqlConnection(funksiyon.connectionadress1);
            SqlCommand cmd2 = new SqlCommand("UPDATE tblOkulTasarim SET Id=@p1, TasarimAdi=@p2, TasarimKayitTarihi=@p3,TasarimGuncellemeTarihi=@p4,Tasarim= @p5 WHERE Id =" + Convert.ToInt32(id) + "", dtbl2);
            //güncelleme i?lemleri için gerekli textBox parametrelerini ekleme
            cmd2.Parameters.AddWithValue("@p1", textBox13.Text);
            cmd2.Parameters.AddWithValue("@p2", textBox9.Text);
            cmd2.Parameters.AddWithValue("@p3", textBox10.Text);
            cmd2.Parameters.AddWithValue("@p4", textBox11.Text);
            cmd2.Parameters.AddWithValue("@p5", textBox12.Text);
            funksiyon.baglanti(dtbl2);
            cmd2.ExecuteNonQuery();
            refresh();
            //textBox'lar? islemin ardindan bosaltir.
            textBox13.Text = string.Empty;
            textBox9.Text = string.Empty;
            textBox10.Text = string.Empty;
            textBox11.Text = string.Empty;
            textBox12.Text = string.Empty;

        }

        public static string id;
        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {

            //id nin varligini kontrol etme ve ardindan label'da goruntuleme
            try
            {

                id = dataGridView2.CurrentRow.Cells["Id"].Value.ToString();
            }

            catch
            {
                MessageBox.Show("Id'si Olmayan Bir Satir Sectiniz");
            }

            label21.Text = id;
        }

        private void button14_Click(object sender, EventArgs e)
        {


        }

        private void button15_Click(object sender, EventArgs e)
        {


        }

        private void button14_Click_1(object sender, EventArgs e)
        {
            
            
            //yeniden giris islemleri icin giri? textBox'lar?n? bos stringe cevirme
            textBox1.Text = string.Empty;
            kullaniciadi.Text = string.Empty;
            sifre.Text = string.Empty;
            database.Text = string.Empty;
            //mevcut TabPage'leri kapatip yenilerini acma
            tabControl1.TabPages.Remove(tabPage1);
            tabControl1.TabPages.Remove(tabPage2);
            tabControl1.TabPages.Remove(tabPage3);
            tabControl1.TabPages.Remove(tabPage4);
            tabControl1.TabPages.Remove(tabPage5);

            tabControl1.TabPages.Add(tabPage1);

        }

        private void button15_Click_1(object sender, EventArgs e)
        {
            //yeni acilacak form için textboxlar? sifirlama
            textBox1.Text = string.Empty;
            kullaniciadi.Text = string.Empty;
            sifre.Text = string.Empty;
            database.Text = string.Empty;


            //yeni baglanma formu acma
            Form1 ahmet = new Form1();
            ahmet.ShowDialog();

        }

        private void button16_Click(object sender, EventArgs e)
        {
            //formu kapama
            this.Close();
        }
    }
}

