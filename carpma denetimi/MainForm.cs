/*
 * SharpDevelop tarafından düzenlendi.
 * Kullanıcı: musta
 * Tarih: 09.02.2017
 * Zaman: 12:54
 * 
 * Bu şablonu değiştirmek için Araçlar | Seçenekler | Kodlama | Standart Başlıkları Düzenle 'yi kullanın.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace carpma_denetimi
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		bool suruklenmedurumu=false;
		Point ilkkonum;
		private void Down(object sender, MouseEventArgs e)
		{
			suruklenmedurumu = true; //işlemi burada true diyerek başlatıyoruz.
			((Button)sender).Cursor = Cursors.SizeAll; //SizeAll yapmamımızın amacı taşırken hoş görüntü vermek için
			ilkkonum = e.Location; //İlk konuma gördüğünüz gibi değerimizi atıyoruz.
		}
		private void Move(object sender, MouseEventArgs e)
		{
			if (suruklenmedurumu) // suruklenmedurumu==true ile aynı.
			{
				((Button)sender).Left = e.X + ((Button)sender).Left - (ilkkonum.X);
				// button.left ile soldan uzaklığını ayarlıyoruz. Yani e.X dediğimizde buton üzerinde mouseun hareket ettiği pixeli alacağız + butonun soldan uzaklığını ekliyoruz son olarakta ilk mouseın tıklandığı alanı çıkarıyoruz yoksa butonun en solunda olur mouse imleci. Alttakide aynı şekilde Y koordinati için geçerli
				((Button)sender).Top = e.Y + ((Button)sender).Top - (ilkkonum.Y);
				((Button)sender).Text="üstü:"+((Button)sender).Top+",sağ:"+((Button)sender).Right+"alt:"+((Button)sender).Bottom+"sol:"+((Button)sender).Left;
			}
		}
		private void Up(object sender, MouseEventArgs e)
		{
			suruklenmedurumu = false; //Sol tuştan elimizi çektik artık yani sürükle işlemi bitti.
			((Button)sender).Cursor = Cursors.Default; //İmlecimiz(Cursor) default değerini alıyor.
		}
		
		public bool kontrol(Button b1,Button b2)//bu fonksiyon butonların kesişim alanı sıfırdan büyük olma durumunu kontrol eder
		{
			int a,b,c,d;
			a=(b1.Right-b2.Left)*(b2.Bottom-b1.Top);
			b=(b1.Bottom-b2.Top)*(b1.Right-b2.Left);
			c=(b1.Bottom-b2.Top)*(b2.Right-b1.Left);
			d=(b2.Bottom-b1.Top)*(b2.Right-b1.Left);
			if(a>0&&b>0&&c>0&&d>0)
				return true;
			else return false;
		}
		void Timer1Tick(object sender, EventArgs e)
		{
			if(kontrol(button1,button2))
			{
				label1.BackColor=Color.Green;//temas varsa label yeşil
			}else label1.BackColor=Color.Red;//yoksa kırmızı olacak
		}
		
		void MainFormLoad(object sender, EventArgs e)
		{
			timer1.Start();
		}
	}
}
