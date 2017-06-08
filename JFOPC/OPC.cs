using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using OPC.Data;
using OPC.Data.Interface;
using OPCSiemensDAAutomation;

namespace JFMonitor {

    //    OPC品质类型
    //---------------------------------------------------------------------------------------------
    //The OPC_QUALITY_xxx 定义了一个过程值或者事件的品质。并且分为3类，good, uncertain和bad。
    //下面的类型为合法的:
    //类型                                                              值          说明
    //OPC_QUALITY_GOOD                   0xC0       值是好的。
    //OPC_QUALITY_LOCAL_OVERRIDE         0xD8       值被覆盖。典型意思为输入失去连接和手动被强制。
    //下面的类型为不确定:
    //类型                                                              值          说明
    //OPC_QUALITY_UNCERTAIN              0x40       没有指定原因说明值为什么不确定。
    //OPC_QUALITY_LAST_USABLE            0x44       最后的可用值。
    //OPC_QUALITY_SENSOR_CAL             0x50       传感器达到了它的一个限值或者超过了它的量程。
    //OPC_QUALITY_EGU_EXCEEDED           0x54       返回值越限。
    //OPC_QUALITY_SUB_NORMAL             0x58       值有几个源，并且可用的源少于规定的品质好的源。
    //下面的类型为坏的:
    //类型                                                              值          说明
    //OPC_QUALITY_BAD                    0x00       值为坏的，没有标明原因。
    //OPC_QUALITY_CONFIG_ERROR           0x04       服务器特定的配置问题。
    //OPC_QUALITY_NOT_CONNECTED   0x08      输入没有可用的连接。
    //OPC_QUALITY_DEVICE_FAILURE        0x0c       设备故障。
    //OPC_QUALITY_LAST_KNOWN             0x14       通讯失败。最后的值是可用的。
    //OPC_QUALITY_COMM_FAILURE           0x18       通讯失败，最后的值不可用。
    //OPC_QUALITY_OUT_OF_SERVICE        0x1C       块脱离扫描或者被锁。
    //OPC_QUALITY_SENSOR_FAILURE         0x10       传感器故障。
    //The OPC_LIMIT_xxx定义了值的限制范围。
    //类型                                                              值          说明
    //OPC_LIMIT_OK                              0x00       值在上低限，高限之内。
    //OPC_LIMIT_LOW                             0x01       值低限。
    //OPC_LIMIT_HIGH                            0x02       值高限。
    //OPC_LIMIT_CONST                           0x03       值是常数。
    public enum Quality {
        BAD = 0, //差
        UNCERTAIN = 64, //不确定
        GOOD = 192, //良好
        NOT_CONNECTED = 8, //输入没有可用的连接。
        DEVICE_FAILURE = 13, //设备故障
        SENSOR_FAILURE = 16, //传感器故障
        LAST_KNOWN = 20, //  通讯失败。最后的值是可用的。
        COMM_FAILURE = 24, //  通讯失败，最后的值不可用。
        OUT_OF_SERVICE = 28, //  块脱离扫描或者被锁。
        LAST_USABLE = 132, //  最后的可用值。
        SENSOR_CAL = 144, //   传感器达到了它的一个限值或者超过了它的量程。
        EGU_EXCEEDED = 148, // 返回值越限。
        SUB_NORMAL = 152, //  值有几个源，并且可用的源少于规定的品质好的源。
        LOCAL_OVERRIDE = 216 //  值被覆盖。典型意思为输入失去连接和手动被强制。
    }

    public enum PLCTagName {
        RunStat,
        AMStat,
        DoorStat,
        TopTemp,
        BTMTemp,
        TopHR,
        BTMHR,
        ErrCode,
        LedStat,
        HPNum,
        HPCurNum,
        TempSET1,
        TempSET2,
        HRSET1,
        HRSET2,
        OpenDoor,
        Reset,
        CloseTime,
        OpenCP,
        DoorAlermTime, //自动关门报警时间设置
        CPSwapTime //压缩机切换时间设置
    }

    public enum IDdataType {
        BOOL,//True (1)、False (0)
        BYTE, //0 至 255
        INT, //-32768 至 32767
        WORD,//0 至 65535
        DINT,//-2147483648 至 2147483647
        DWORD, //0 至 4294967295
        REAL, //IEEE 32 位浮点数
        STRING //1 到 254 个字节
    }

    public enum AccessMode {
        RW,
        R
    }

    public enum DoorAction {
        None,
        Close,
        Open,
        Other
    }

    public enum DoorStat {
        Closed = 8,
        Opened = 4,
        Moving = 2
    }

    public enum RunStat {
        Turning,
        Stop
    }

    public enum CPAction {
        None,
        OpenCp1,
        CloseCp1,
        OpenCp2,
        CloseCp2
    }

    public class OPCAPI: object {
        private OpcServer TheSrv { get; set; }
        private OpcGroup TheGrp { get; set; }
        private Dictionary<string,CItemID> mItemIDList;

        public Dictionary<string,CItemID> Items
        {
            get { return mItemIDList; }
        }

        private Dictionary<int,CItemID> HandleClients { get; set; }

        //    List<OPCItemDef> ItemIDs { get; set; }
        //    List<OpcGroup> Groups { get; set; }

        //     Dictionary<string,Object> ItemValues;

        //     Dictionary<string,int> HandlesSrv;
        private List<string> GetLocalServer() {
            string strHostName;
            OPCServer KepServer;
            var IPHost = Dns.GetHostEntry(Environment.MachineName);
            strHostName = IPHost.HostName;
            //获取本地计算机上的OPCServerName
            var cmbServerName=new List<string>();
            try {
                KepServer = new OPCServer();
                var serverList = KepServer.GetOPCServers(strHostName);
                foreach (string turn in (Array) serverList) {
                    cmbServerName.Add(turn);
                }

                return cmbServerName;
            } catch (Exception) {
                cmbServerName.Clear();
                return cmbServerName;
            }
        }

        public List<string> ServerList
        {
            get {
                return GetLocalServer();
            }
        }

        private int mUpdateRate=900;

        /// <summary>
        /// 刷新时间 ms
        /// </summary>
        public int UpdateRate
        {
            get { return mUpdateRate; }
            set {
                mUpdateRate = value;
                if (TheGrp != null)
                    TheGrp.UpdateRate = mUpdateRate;
            }
        }

        private int mMaxHp=16;

        public int MaxHp
        {
            get { return mMaxHp; }
            set {
                mMaxHp = value;
            }
        }

        public void AddItemID( string Name,string addr,IDdataType dataType,AccessMode RW_Mode ) {
            if (mItemIDList == null)
                mItemIDList = new Dictionary<string,CItemID>();

            CItemID r;
            if (mItemIDList.Keys.Contains(Name)) {
                r = Items[Name];
                r.Type = dataType;
                r.Access = RW_Mode;
                r.Address = addr;
                return;
            }
            mItemIDList.Add(Name,new CItemID(
                    Name,
                    PLC_IP,
                    TSAP1,
                    TSAP1,
                    addr, //PLC数据地址
                    dataType,
                    RW_Mode));
        }

        public void SetGroupActive( bool value ) {
            TheGrp.SetEnable(true);
            TheGrp.Active = value;
        }

        public static string PLC_IP="192.168.2.1";
        public static string TSAP1="0201";
        public static string TSAP2="0201";

        private void GetDefaultItemIDs() {
            AddItemID(PLCTagName.AMStat.ToString(),"V100.0",IDdataType.BOOL,AccessMode.RW);   //手自动状态
            AddItemID(PLCTagName.RunStat.ToString(),"V100.1",IDdataType.BOOL,AccessMode.R); //料斗电机是否转动 1=转动
            AddItemID(PLCTagName.Reset.ToString(),"V100.2",IDdataType.BOOL,AccessMode.RW); //清除报警
            AddItemID(PLCTagName.DoorStat.ToString(),"VB101",IDdataType.BYTE,AccessMode.R); //门开闭状态

            AddItemID(PLCTagName.HPNum.ToString(),"VB102",IDdataType.BYTE,AccessMode.RW); //料斗号
            AddItemID(PLCTagName.HPCurNum.ToString(),"VB103",IDdataType.BYTE,AccessMode.R); //当前料斗号 大于64无作用
            AddItemID(PLCTagName.ErrCode.ToString(),"VB104",IDdataType.BYTE,AccessMode.R); //错误码
            AddItemID(PLCTagName.OpenCP.ToString(),"VB105",IDdataType.BYTE,AccessMode.RW); //开关压缩机
            AddItemID(PLCTagName.LedStat.ToString(),"VD106",IDdataType.DINT,AccessMode.RW); //指示灯状态

            AddItemID(PLCTagName.TopTemp.ToString(),"VD110",IDdataType.REAL,AccessMode.R); //顶部温度
            AddItemID(PLCTagName.BTMTemp.ToString(),"VD114",IDdataType.REAL,AccessMode.R); //底部温度
            AddItemID(PLCTagName.TopHR.ToString(),"VD118",IDdataType.REAL,AccessMode.R); //顶部湿度
            AddItemID(PLCTagName.BTMHR.ToString(),"VD122",IDdataType.REAL,AccessMode.R); //底部湿度

            AddItemID(PLCTagName.TempSET1.ToString(),"VD126",IDdataType.REAL,AccessMode.RW); //温度设置1
            AddItemID(PLCTagName.TempSET2.ToString(),"VD130",IDdataType.REAL,AccessMode.RW); //温度设置2
            AddItemID(PLCTagName.HRSET1.ToString(),"VD134",IDdataType.REAL,AccessMode.RW); //湿度设置1
            AddItemID(PLCTagName.HRSET2.ToString(),"VD138",IDdataType.REAL,AccessMode.RW); //湿度设置2

            AddItemID(PLCTagName.OpenDoor.ToString(),"VB142",IDdataType.BYTE,AccessMode.RW); //开门1:=close 2=open 缺省=3
            AddItemID(PLCTagName.CloseTime.ToString(),"VW144",IDdataType.WORD,AccessMode.RW); //关门时间1-60分钟;
            AddItemID(PLCTagName.DoorAlermTime.ToString(),"VW146",IDdataType.WORD,AccessMode.RW); //自动关门报警时间(秒);
            AddItemID(PLCTagName.CPSwapTime.ToString(),"VW148",IDdataType.WORD,AccessMode.RW); //压缩机切换时间(分);
        }

        public void InitOPC() {
            try {
                try {
                    if (!Connect()) return;
                } catch (System.Exception ex) {
                    throw ex;
                }

                try {
                    AddGroup("MyGroup");
                    TheGrp.UpdateRate = 2000;
                } catch (System.Exception ex) {
                    throw ex;
                }

                try {
                    if (mItemIDList == null) {
                        GetDefaultItemIDs();
                    }
                } catch (System.Exception ex) {
                    throw ex;
                }
                try {
                    AddItemIDs(Items);
                } catch (System.Exception ex) {
                    throw ex;
                }
            } catch (Exception ex) {
                throw ex;
            }
        }

        public event EventHandler WriteCompleted;

        protected virtual void OnWriteCompleted( EventArgs e ) {
            WriteCompleted?.Invoke(this,e);
        }

        public event EventHandler ReadCompleted;

        protected virtual void OnReadCompleted( EventArgs e ) {
            ReadCompleted?.Invoke(this,e);
        }

        public int ServerState
        {
            get {
                // if (TheSrv == null) return (int) OPCServerState.OPCNoconfig;
                SERVERSTATUS a;
                TheSrv.GetStatus(out a);
                return (int) a.eServerState;
            }
        }

        public bool Connect( params string[] ServerProgID ) {
            try {
                if (TheSrv == null) {
                    TheSrv = new OpcServer();
                    if (ServerProgID.Length == 0) {
                        var s=ServerList;
                        if (s.Count > 0) {
                            TheSrv.Connect(s[0]);
                        } else {
                            return false;
                        }
                    } else {
                        TheSrv.Connect(ServerProgID[0]);
                    }
                } else {
                    var a=new SERVERSTATUS();
                    TheSrv.GetStatus(out a);
                    if (a.eServerState != OPCSERVERSTATE.OPC_STATUS_RUNNING) {
                        if (ServerProgID.Length == 0) {
                            var s=ServerList;
                            if (s.Count > 0) {
                                TheSrv.Connect(s[0]);
                            }
                        } else {
                            TheSrv.Connect(ServerProgID[0]);
                        }
                    }
                }
                return true;
            } catch (Exception) {
                TheSrv.Disconnect();
                throw;
            }
        }

        public bool Disconnect() {
            var flag=false;
            try
            {
                if (mItemIDList != null)
                {
                    var handlesSrv = HandleClients.Keys.ToArray<int>();
                    if (TheGrp != null)
                    {
                        int[] aE;
                        TheGrp.RemoveItems(handlesSrv, out aE);
                        TheGrp.DataChanged -= TheGrp_DataChanged;
                        TheGrp.ReadCompleted -= TheGrp_ReadCompleted;
                        TheGrp.WriteCompleted -= TheGrp_WriteCompleted;
                        TheGrp.Remove(false);
                        TheGrp = null;
                    }
                }
                if (TheSrv != null)
                {
                    TheSrv.Disconnect();
                    flag = true;
                    TheSrv = null;
                }
            }
            finally
            {
                TheSrv = null;
                TheGrp = null;
            }
            return flag;
        }

        private OpcGroup AddGroup( string GroupName ) {
            if (TheGrp != null) {
                return TheGrp;
            }
            TheGrp = TheSrv.AddGroup(GroupName,false,mUpdateRate);
            TheGrp.DataChanged += TheGrp_DataChanged;
            TheGrp.ReadCompleted += TheGrp_ReadCompleted;
            TheGrp.WriteCompleted += TheGrp_WriteCompleted;
            TheGrp.SetEnable(true);
            TheGrp.Active = false;

            return TheGrp;
        }

        private void TheGrp_WriteCompleted( object sender,WriteCompleteEventArgs e ) {
            foreach (var r in e.res) {
                if (r.Error != 0) {
                    HandleClients[r.HandleClient].errorCode = r.Error;
                }
            }
            OnWriteCompleted(e);
        }

        private void TheGrp_ReadCompleted( object sender,ReadCompleteEventArgs e ) {
            foreach (var s in e.sts) {
                if (s.Error != 0) {
                    HandleClients[s.HandleClient].errorCode = s.Error;
                } else {
                    HandleClients[s.HandleClient].errorCode = 0;
                    if (s.Quality == (int) Quality.GOOD) {
                        HandleClients[s.HandleClient].Value = s.DataValue;
                    }
                    HandleClients[s.HandleClient].Quality = s.Quality;
                    HandleClients[s.HandleClient].TimeStamp = DateTime.FromFileTime(s.TimeStamp);
                }
            }
            OnReadCompleted(e);
        }

        private object InitValue( CItemID ID ) {
            switch (ID.Type) {
                case IDdataType.BOOL:
                    return false;

                case IDdataType.BYTE:
                    return (byte) 0;

                case IDdataType.DINT:
                    return (Int32) 0;

                case IDdataType.DWORD:
                    return (UInt32) 0;

                case IDdataType.INT:
                    return (Int16) 0;

                case IDdataType.REAL:
                    return 0.0f;

                case IDdataType.STRING:
                    return "";

                case IDdataType.WORD:
                    return (UInt16) 0;

                default:
                    return 0;
            }
        }

        private void TheGrp_DataChanged( object sender,DataChangeEventArgs e ) {
            foreach (var s in e.sts) {
                if (s.Error != 0) {
                    HandleClients[s.HandleClient].errorCode = s.Error;
                } else {
                    HandleClients[s.HandleClient].errorCode = 0;
                    if (s.Quality == (int) Quality.GOOD) {
                        HandleClients[s.HandleClient].Value = s.DataValue;
                        HandleClients[s.HandleClient].TimeStamp = DateTime.FromFileTime(s.TimeStamp);
                    } else {
                        if (HandleClients[s.HandleClient].Value == null) {
                            HandleClients[s.HandleClient].Value = InitValue(HandleClients[s.HandleClient]);
                        }
                    }
                    HandleClients[s.HandleClient].Quality = s.Quality;
                }
            }
            OnReadCompleted(new EventArgs());
        }

        public void SetItemIDs( Dictionary<string,CItemID> IDs ) {
            mItemIDList = IDs;
        }

        public void AddItemIDs( Dictionary<string,CItemID> IDs ) {
            try {
                // string ItemA  = "2:192.168.2.1:0201:0201,MB0,BYTE,RW";
                var i=0;
                var a =new OPCItemDef[IDs.Count];
                OPCItemResult[] b;
                foreach (var ID in IDs.Values) {
                    var nID= new OPCItemDef();
                    nID.ItemID = ID.ToString();
                    nID.Active = true;
                    nID.HandleClient = 1000 + i;
                    if (HandleClients == null) HandleClients = new Dictionary<int,CItemID>();

                    HandleClients.Add(nID.HandleClient,ID);
                    a[i++] = nID;
                }
                TheGrp.AddItems(a,out b);

                if (b == null) return;
                for (i = 0; i < b.Length; i++) {
                    if (b[i].Error != 0) {
                        var s=Enum.GetName(typeof(OPCErrors),b[i].Error);
                        throw (new Exception("加入标签失败!"));
                    }
                }

                var names=IDs.Keys.ToList<string>();
                for (i = 0; i < b.Length; i++) {
                    IDs[names[i]].HandleSrv = b[i].HandleServer;
                }
                mItemIDList = IDs;
                TheGrp.SetEnable(true);
                TheGrp.Active = true;
            } catch (Exception) {
                throw;
            }
        }

        public void ReadAll() {
            int CancelID;
            int[]  aE;
            try {
                var HandlesSrv=new int[Items.Count];
                aE = new int[Items.Count];
                var names=Items.Keys.ToArray<string>();
                for (var i = 0; i < HandlesSrv.Length; i++) {
                    HandlesSrv[i] = Items[names[i]].HandleSrv;
                }
                TheGrp.AsyncRead(HandlesSrv,55667788,out CancelID,out aE);
            } catch (Exception) {
                throw;
            }
        }

        public void SetPLC_IP( string ip ) {
            foreach (var c in Items.Values) {
                c.IPAddress = ip;
            }
            var err=new int[HandleClients.Count];
            TheGrp.RemoveItems(HandleClients.Keys.ToArray(),out err);
            HandleClients.Clear();
            AddItemIDs(Items);
        }

        public void Set料斗和指示灯( byte 料斗号,int LedStart,int LedCount ) {
            SetItemValue(PLCTagName.HPNum,料斗号);
            SetItemValue(PLCTagName.LedStat,OPCAPI.GetLedValue(LedStart,LedCount));
            string[] s= { PLCTagName.HPNum.ToString(),PLCTagName.LedStat.ToString() };
            Write(s);
        }

        public bool GetValue( PLCTagName tag,out object value ) {
            if (Items[tag.ToString()].Quality == (int) Quality.BAD) {
                value = null;
                return false;
            }
            value = Items[tag.ToString()].Value;
            return true;
        }

        public void TurnUp() {
            object runStat;
            object HPnum;
            if (!GetValue(PLCTagName.RunStat,out runStat)) return;
            if ((bool) runStat == false) return;
            if (!GetValue(PLCTagName.HPCurNum,out HPnum)) return;
            HPnum = (byte) HPnum + 1;
            if ((int) HPnum > MaxHp) HPnum = 1;

            SetItemValue(PLCTagName.HPNum,(int) HPnum);
            string[] s= {PLCTagName.HPNum.ToString() };
            Write(s);
        }

        public void Alert() {
            SetItemValue(PLCTagName.Reset,0);
            string[] s= {PLCTagName.Reset.ToString() };
            Write(s);
        }

        public void ClearAlerm() {
            SetItemValue(PLCTagName.Reset,1);
            string[] s= {PLCTagName.Reset.ToString() };
            Write(s);
        }

        public void TurnDown() {
            object runStat;
            object HPnum;
            if (!GetValue(PLCTagName.RunStat,out runStat)) return;
            if ((bool) runStat == false) return;
            if (!GetValue(PLCTagName.HPCurNum,out HPnum)) return;

            HPnum = (byte) HPnum - 1;
            if ((int) HPnum <= 0) HPnum = MaxHp;

            SetItemValue(PLCTagName.HPNum,(int) HPnum);
            string[] s= {PLCTagName.HPNum.ToString() };
            Write(s);
        }

        public void OpenDoor() {
            SetItemValue(PLCTagName.OpenDoor,(int) DoorAction.Open);
            string[] s= {PLCTagName.OpenDoor.ToString() };
            Write(s);
        }

        public void OpenCompressor( int num ) {
            switch (num) {
                case 1:
                    SetItemValue(PLCTagName.OpenCP,(int) CPAction.OpenCp1);
                    break;

                case 2:
                    SetItemValue(PLCTagName.OpenCP,(int) CPAction.OpenCp2);
                    break;
            }
            string[] s= {PLCTagName.OpenCP.ToString() };
            Write(s);
        }

        public void CloseCompressor( int num ) {
            switch (num) {
                case 1:
                    SetItemValue(PLCTagName.OpenCP,(int) CPAction.CloseCp1);
                    break;

                case 2:
                    SetItemValue(PLCTagName.OpenCP,(int) CPAction.CloseCp2);
                    break;
            }
            string[] s= {PLCTagName.OpenCP.ToString() };
            Write(s);
        }

        public void CloseDoor() {
            SetItemValue(PLCTagName.OpenDoor,(int) DoorAction.Close);
            string[] s= {PLCTagName.OpenDoor.ToString() };
            Write(s);
        }

        public static UInt32 GetLedValue( int start,int num ) {
            var b=start;
            var a= 1 << (b-1);
            for (var i = 1; i < num; i++) {
                if ((int) start + i > 20) break;
                a = a << 1 | (1 << (start - 1));
            }
            if (num == 0) a = 0;
            var a1=(uint) a&0xff;
            var a2=(uint)(a&0xff00);
            var a3=(uint)(a&0xff0000)>>16;
            var c =(uint)((a1 << 16) | a2| a3)<<8;
            return c;
        }

        public bool SetItemValue( PLCTagName name,object Value ) {
            return SetItemValue(name.ToString(),Value);
        }

        public bool SetItemValue( string name,object Value ) {
            try {
                if (Items[name].Access == AccessMode.R) return false;
                // Type t= mItemIDList[name].Value.GetType();
                //mItemIDList[name].Value = Convert.ChangeType(Value,t);
                mItemIDList[name].Value = Value;
            } catch {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 写标签值
        /// </summary>
        /// <param name="itemNames"> 标签名数组 </param>
        /// <returns>0:成功; 1:无标签名;2:有标签名为Null; 3:不能写只读标签 4:其他错误 </returns>

        public int Write( string[] itemNames ) {
            var HandlesSrv=new int[itemNames.Length];
            var ItemValues=new object[itemNames.Length];
            int CancelID;
            var aE=new int[HandlesSrv.Length];

            if ((itemNames == null) || (itemNames.Length == 0)) {
                return 1;
            }
            var i=0;
            foreach (var s in itemNames) {
                if (Items[s].Value == null) return 2;
                if (Items[s].Access == AccessMode.R) return 3;
                HandlesSrv[i] = Items[s].HandleSrv;
                ItemValues[i] = Items[s].Value;
                i++;
            }

            try {
                TheGrp.AsyncWrite(HandlesSrv,ItemValues,55667788,out CancelID,out aE);
                return 0;
            } catch (Exception) {
                return 4;
            }
        }
    }
}