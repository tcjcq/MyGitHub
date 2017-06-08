using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFMonitor {
    public class CItemID {
        /// <summary>
        /// IP地址
        /// </summary>
        public string IPAddress { get; set; }
        /// <summary>
        /// 标签名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// TSAP1
        /// </summary>
        public string TSAP1 { get; set; }
        /// <summary>
        /// TSAP2
        /// </summary>
        public string TSAP2 { get; set; }
        /// <summary>
        /// IPConnection
        /// </summary>
        public string IPConnection {
            get {
                return string.Format("{0}:{1}:{2}",IPAddress,TSAP1,TSAP2);
            }
        }
        /// <summary>
        /// NetAddressFull
        /// </summary>
        public string NetAddressFull {
            get {
                return string.Format("2:{0}:{1}:{2}",IPAddress,TSAP1,TSAP2);
            }
        }
        /// <summary>
        /// 数据地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 类型定义 BOOL,BYTE,CHAR,INT,WORD,DINT,DWORD,REAL,STRING 
        /// </summary>
        public IDdataType Type { get; set; }
        /// <summary>
        /// 访问定义: "RW"或者"R"
        /// </summary>
        public AccessMode Access { get; set; }
        /// <summary>
        /// 返回完整的ItemID
        /// </summary>
        /// <returns></returns>
        override public string ToString()
        {
            return string.Format("2:{0},{1},{2},{3}",IPConnection,Address,Type,Access);
        }
   
        private Object mValue;

        public Object Value
        {
            get { return mValue; }
            set {
                switch (Type) {
                    case IDdataType.BOOL:
                        try {
                             mValue=Convert.ToBoolean(value);
                            
                        }
                        catch  
                        {
                        	
                        }
                      
                        break;
                    case IDdataType.BYTE:
                        try {
                            mValue = Convert.ToByte(value);
                        } catch {

                        }
                        break;
                    
                    case IDdataType.INT:
                        try {
                            mValue = Convert.ToInt16(value);
                        } catch {

                        }
                        break;
                    case IDdataType.WORD:
                        try {
                            mValue = Convert.ToUInt16(value);
                        } catch {

                        }
                        break;
                    case IDdataType.DINT:
                        try {
                            mValue = Convert.ToInt32(value);
                        } catch {

                        }
                        break;
                    case IDdataType.DWORD:
                        try {
                            mValue = Convert.ToUInt32(value);
                        } catch {

                        }
                        break;
                    case IDdataType.REAL:
                        try {
                             
                            mValue = Convert.ToSingle(value);
                        } catch {

                        }
                        break;
                    case IDdataType.STRING:
                        try {
                            var s=Convert.ToString(value);
                            if (s.Length > 254) s = s.Substring(0,254);
                            mValue = s;
                             
                        } catch {

                        }
                        break;
                    default:
                        break;
                }
               
            }
        }

        public int HandleSrv { get; set; }
        public int Quality { get; set; }
        public DateTime TimeStamp { get; set; }
        public int errorCode { get; set; }

        public CItemID( string name,string ip,string tsap1,string tsap2,string dataAddr,IDdataType dataType,AccessMode accessMode )
        {
            IPAddress = ip;
            TSAP1 = tsap1;
            TSAP2 = tsap2;
            Address = dataAddr;
            Type = dataType;
            Access = accessMode;
            Name = name;
        }
    }

}
