using System;
using System.IO;
using System.Text;

namespace Rasterisation{
	public static class PpmOutputExtension{
		public static void PpmOutput(this Bitmap bitmap,Stream stream){
			UTF8Encoding encoding=new UTF8Encoding();
			using(BinaryWriter writer=new BinaryWriter(stream)){
				writer.Write(encoding.GetBytes($"P6\n{bitmap.x} {bitmap.y}\n255\n"));
				for(int j=0;j<bitmap.y;j++){
					for(int i=0;i<bitmap.x;i++){
						Color color=bitmap[i,j];
						writer.Write(color.r);
						writer.Write(color.g);
						writer.Write(color.b);
					}
				}
			}
		}
	}
}