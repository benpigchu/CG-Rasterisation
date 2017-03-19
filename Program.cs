using System;
using System.IO;

namespace Rasterisation{
	public class Program{
		public static void Main(string[] args){
			Console.WriteLine(new Polygon(new Point[]{
				new Point{x=1.2f,y=1},
				new Point{x=2,y=9.4f},
				new Point{x=4,y=5},
				new Point{x=7,y=1},
			}));
			Bitmap bitmap=new Bitmap(100,100);
			bitmap.PaintPolygon(new Polygon(new Point[]{
				new Point{x=10.2f,y=10},
				new Point{x=20,y=90.4f},
				new Point{x=40,y=5},
				new Point{x=7,y=30},
			}),new Color{r=255,g=127,b=0});
			using(FileStream file=new FileStream("image.ppm",FileMode.Create)){
				bitmap.PpmOutput(file);
			}
		}
	}
}
