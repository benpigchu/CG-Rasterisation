using System;
using System.IO;

namespace Rasterisation{
	public static class Program{
		public static void Main(string[] args){
			float size=90.1f;
			Bitmap bitmap=new Bitmap(1920,1080);
			Color[] colors=new Color[]{
				new Color{r=225,g=0,b=0},
				new Color{r=225,g=0,b=127},
				new Color{r=225,g=0,b=255},
				new Color{r=127,g=0,b=255},
				new Color{r=0,g=0,b=255},
				new Color{r=0,g=127,b=255},
				new Color{r=0,g=255,b=255},
				new Color{r=0,g=255,b=127},
				new Color{r=0,g=255,b=0},
				new Color{r=127,g=255,b=0},
				new Color{r=225,g=255,b=0},
				new Color{r=225,g=127,b=0},
			};
			for(int i=0;i<12;i++){
				float centerX=960+30*(-2*i+11);
				float angle=(float)((i-1)/12f);
				bitmap.PaintPolygon(new Polygon(new Point[]{
					new Point{x=centerX+((float)(size*Math.Sin(angle*Math.PI))),y=540+((float)(size*Math.Cos(angle*Math.PI)))},
					new Point{x=centerX+((float)(size*Math.Sin((angle+0.5)*Math.PI))),y=540+((float)(size*Math.Cos((angle+0.5)*Math.PI)))},
					new Point{x=centerX+((float)(size*Math.Sin((angle+1)*Math.PI))),y=540+((float)(size*Math.Cos((angle+1)*Math.PI)))},
					new Point{x=centerX+((float)(size*Math.Sin((angle+1.5)*Math.PI))),y=540+((float)(size*Math.Cos((angle+1.5)*Math.PI)))},
				}),colors[i]);
			}
			bitmap.PaintPolygon(new Polygon(new Point[]{
				new Point{x=930,y=690},
				new Point{x=930,y=750.1f},
				new Point{x=990,y=690},
				new Point{x=990,y=750.1f},
			}),new Color{r=225,g=127,b=0});
			using(FileStream file=new FileStream("image.ppm",FileMode.Create)){
				bitmap.PpmOutput(file);
			}
		}
	}
}
