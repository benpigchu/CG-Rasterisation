using System;

namespace Rasterisation{
	struct Point{
		public int x,y;
		public override string ToString(){
			return $"({x},{y})";
		}
	}
	class Polygon{
		Point[] data;
		public Polygon(Point[] points){
			data=points;
		}
		public override string ToString(){
			return $"<Polygon [{string.Join(",",data)}]>";
		}
	}
}