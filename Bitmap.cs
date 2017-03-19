using System;

namespace Rasterisation{
	public struct Color{
		public byte r,g,b;
	}
	public class Bitmap{
		Color[,] data;
		public Bitmap(int x,int y){
			data=new Color[x,y];
		}
		public Color this[int x,int y]{
			get{return data[x,y];}
			set{data[x,y]=value;}
		}
		public int x=>data.GetLength(0);
		public int y=>data.GetLength(1);
		public override String ToString()=>$"<Bitmap {x}x{y}>";
	}
}