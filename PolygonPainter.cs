using System;
using System.Collections.Generic;

namespace Rasterisation{
	public static class PolygonPaintExtension{
		private struct EdgeRecord{
			public float x,dx;
			public int ymax;
			public override string ToString()=>$"<EdgeRecord x:{x} dx:{dx} ymax:{ymax}>";
		}
		public static void PaintPolygon(this Bitmap bitmap,Polygon polygon,Color color){
			List<EdgeRecord>[] record=new List<EdgeRecord>[bitmap.y+1];
			for(int i=0;i<polygon.length;i++){
				Point p1=polygon[i],p2=polygon[(i+1>=polygon.length)?0:(i+1)];
				Console.WriteLine($"{p1} {p2}");
				int y1=(int)(Math.Ceiling(p1.y));
				int y2=(int)(Math.Ceiling(p2.y));
				Console.WriteLine($"{y1} {y2}");
				if(y1<0){y1=0;}
				if(y2<0){y2=0;}
				if(y1>bitmap.y){y2=bitmap.y;}
				if(y2>bitmap.y){y2=bitmap.y;}
				if(y1==y2){break;}
				Point pBegin,pEnd;
				int yBegin,yEnd;
				if(y1>y2){
					pBegin=p2;
					pEnd=p1;
					yBegin=y2;
					yEnd=y1;
				}else{
					pBegin=p1;
					pEnd=p2;
					yBegin=y1;
					yEnd=y2;
				}
				float dx=(pEnd.x-pBegin.x)/(pEnd.y-pBegin.y);
				float x=(yBegin-pBegin.y)*dx+pBegin.x;
				if(record[yBegin]==null){
					record[yBegin]=new List<EdgeRecord>();
				}
				record[yBegin].Add(new EdgeRecord{x=x,dx=dx,ymax=yEnd});
				Console.WriteLine($"--add {yBegin} {yEnd} {x} {dx}");
			}
			List<EdgeRecord> intersect=new List<EdgeRecord>();
			for(int line=0;line<bitmap.y;line++){
				if(record[line]!=null){
					intersect.AddRange(record[line]);
				}
				intersect.RemoveAll((edge)=>edge.ymax<=line);
				intersect.Sort((edge1,edge2)=>Comparer<float>.Default.Compare(edge1.x,edge2.x));
				Console.WriteLine(string.Join(",",intersect));
				if(intersect.Count%2!=0){
					throw new Exception("Odd edges!");
				}
				for(int i=0;i<intersect.Count/2;i++){
					float left=intersect[2*i].x;
					float right=intersect[2*i+1].x;
					int lPoint=(int)(Math.Ceiling(left));
					int rPoint=(int)(Math.Floor(right));
					if(lPoint<0){lPoint=0;}
					if(rPoint<0){lPoint=0;}
					if(lPoint>bitmap.x){lPoint=bitmap.x;}
					if(rPoint>bitmap.x){lPoint=bitmap.x;}
					Console.WriteLine($"{lPoint} -> {rPoint}");
					for(int point=lPoint;point<=rPoint;point++){
						bitmap[point,line]=color;
					}
				}
				for(int i=0;i<intersect.Count;i++){
					intersect[i]=new EdgeRecord{x=intersect[i].x+intersect[i].dx,dx=intersect[i].dx,ymax=intersect[i].ymax};
				}
			}
		}
	}
}