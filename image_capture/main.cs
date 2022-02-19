using System;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Sample
{
	class Sample{
		
		static void Main()
		{
			// 画像のサイズを指定し、Bitmapオブジェクトのインスタンスを作成
			Bitmap bm = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
			// Bitmap bm = new Bitmap(500, 300);   // 幅500ピクセル × 高さ300ピクセルの場合
			
			// Graphicsオブジェクトのインスタンスを作成
			Graphics gr = Graphics.FromImage(bm);
			// 画面全体をコピー
			gr.CopyFromScreen(new Point(100, 100), new Point(Cursor.Position.X, Cursor.Position.Y), bm.Size);
			// PNGで保存
			//bm.Save("D:\\samplePNG.png", System.Drawing.Imaging.ImageFormat.Png);
			// BMPで保存
			bm.Save("D:\\sampleBMP.bmp", System.Drawing.Imaging.ImageFormat.Bmp);
			
			// JPGで保存
			//bm.Save("D:\\sampleJPG.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
			
			// TIFFで保存
			//bm.Save("D:\\sampleTIFF.tiff", System.Drawing.Imaging.ImageFormat.Tiff);
			gr.Dispose();
			MessageBox.Show("Dドライブ直下に出力しました");
		}
	}
}