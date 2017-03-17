using System;
using System.IO;

namespace Rasterisation{
	public class Program{
		public static void Main(string[] args){
			// Console.WriteLine(new Bitmap(50,50));
			Bitmap bitmap=new Bitmap(2,2);
			bitmap[0,0]=new Color{r=255,g=0,b=0};
			bitmap[1,0]=new Color{r=0,g=255,b=0};
			bitmap[0,1]=new Color{r=0,g=0,b=255};
			bitmap[1,1]=new Color{r=255,g=255,b=255};
			using(FileStream file=new FileStream("image.ppm",FileMode.Create)){
				bitmap.PpmOutput(file);
			}
		}
	}
}
