using System;

namespace Rasterisation{
	public struct Point{
		public float x,y;
		public override string ToString(){
			return $"({x},{y})";
		}
	}
	public class Polygon{
		Point[] data;
		public Polygon(Point[] points){
			data=points;
		}
		public Point this[int i]=>data[i];
		public int length=>data.Length;
		public override string ToString()=>$"<Polygon [{string.Join(",",data)}]>";
	}
}