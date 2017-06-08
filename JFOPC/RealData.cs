using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CYQ.Data.Tool;

namespace JFMonitor {
    public class RealData {
        public float T1 { get; set; }
        public float T2 { get; set; }
        public float H1 { get; set; }
        public float H2 { get; set; }
        public DateTime Time { get; set; }
    }
    public class RealDataOperter {
        public int DataCount;
        public string Fname;
        List<RealData> mDataList;
      
        public List<RealData> DataList {
            get { 
               return mDataList;
            }
        }

        public bool Read() {
            BinaryReader br=null;
            mDataList = new List<RealData>();
            if (!File.Exists(Fname)) return false;
            var flag=false;
            try {
                br = new BinaryReader(new FileStream(Fname,FileMode.Open));
                var pos = 0;
                var length = br.BaseStream.Length;
                while (pos < length) { 
                    var nr=new RealData();
                    nr.T1 = br.ReadSingle();
                    nr.T2 = br.ReadSingle();
                    nr.H1 = br.ReadSingle();
                    nr.H2 = br.ReadSingle();
                    var a= br.ReadInt64();
                    var t=new DateTime(a);
                    nr.Time = t;
                    if (!mDataList.Contains(nr)) mDataList.Add(nr);
                    pos += 24;
                }
                flag = true;
            } catch {
                   
            } finally {
                if(br!=null) br.Close();
            }
            return flag;
        }
        
       public void Add( RealData value) {
            if(mDataList==null)
                mDataList = new List<RealData>();
            if (mDataList.Contains(value)) return;
            mDataList.Add(value);
            var sl=mDataList.Count-DataCount;
            if(sl>0)
                for (var i = 0; i < sl; i++) {
                    mDataList.RemoveAt(0);
                }
        }
        public void SaveData() {
            //创建文件
            var  fs = new FileStream(Fname,FileMode.Create);
       
            //数据保存到磁盘中
            var bw = new BinaryWriter(fs);
            foreach (var r in mDataList)
            {
                bw.Write(r.T1);
                bw.Write(r.T2);
                bw.Write(r.H1);
                bw.Write(r.H2);
                bw.Write(r.Time.Ticks);
                bw.Flush();
            }
            bw.Close();
        }
    }

}
