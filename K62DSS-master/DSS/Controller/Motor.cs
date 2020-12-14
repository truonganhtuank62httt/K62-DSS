using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using DSS.Model;

namespace DSS.Controller
{
    public class Motor
    {
        // B1: Khởi tạo tập sự kiện đã biết, chưa biết và tập luật
        // B2: Duyệt từng luật trong tập luật (CSTT) và thực hiện
        // + Kiểm tra xem luật nào có vế trái thuộc tập SKĐB thì nạp vế phải của
        // luật đó vào tập SKĐB đồng thời đánh dấu luật đã sử dụng
        // + Sau khi kiểm tra mỗi luật thì kiểm tra xem tập SKĐB có chứa tập SKCB
        // hay không, nếu có thì dừng lại và báo tìm thấy, nếu không thì chạy tiếp
        // B3: Lặp lại B2 cho đến khi:
        // + Không còn luật nào để duyệt
        // + Duyệt hết 1 vòng tập luật nhưng tập SKĐB không thay đổi

        public List<MMenhDe> TSKDB { get; set; }
        
        /// Nếu TSKCB = null thì tương đương với việc tìm tất cả các phương án        
        public List<MMenhDe> TSKCB { get; set; }
        public List<MLuat> TLuat { get; set; }

        /// <summary>
        /// Suy diễn tìm tất cả các phương án
        /// </summary>
        /// <returns>nếu tập SKDB thay đổi thì trả về true, ngược lại trả về false</returns>
        public List<MMenhDe> Search()
        {
            int demSKDB = 0;
            int demTLuat = 0;
            List<MMenhDe> TSKM = new List<MMenhDe>();
            while(demSKDB != TSKDB.Count || demTLuat != TLuat.Count)
            {
                demSKDB = TSKDB.Count;
                demTLuat = TLuat.Count;

                List<int> viTriLuatDaDung = new List<int>();
                for(int i = 0; i < TLuat.Count; i++)
                {
                    MLuat li = TLuat[i];
                    List<MChiTietLuat> veTrai = li.ChiTietLuat();
                    Boolean suDungDuoc = true;
                    foreach (MChiTietLuat m in veTrai)
                    {
                        if (TSKDB.FindIndex(item => item.ID == m.Left().ID) == -1)
                        {
                            Console.WriteLine("TEST: "+ m.Left().ID);
                            suDungDuoc = false;
                            break;
                        }
                        Console.WriteLine("TEST OUT: "+ m.Left().ID);
                        if (suDungDuoc)
                        {
                            TSKDB.Add(li.Right());
                            TSKM.Add(li.Right());
                            viTriLuatDaDung.Add(i);
                            break;
                        }
                    } 
                       
                }    

                for(int i = viTriLuatDaDung.Count - 1; i >= 0; i--)
                {
                    TLuat.RemoveAt(viTriLuatDaDung[i]);
                }    
            }
            return TSKM;
        }

        /// <summary>
        /// Suy diễn để chứng minh điều gì đó
        /// </summary>
        /// <returns>Nếu tập tìm thấy thì trả về true, ngược lại trả về false</returns>
        public Boolean SearchCondition(MMenhDe menhDeCanCM)
        {
            int demSKDB = 0;
            int demTLuat = 0;
            List<MMenhDe> TSKM = new List<MMenhDe>();
            while (demSKDB != TSKDB.Count || demTLuat != TLuat.Count)
            {
                demSKDB = TSKDB.Count;
                demTLuat = TLuat.Count;

                List<int> viTriLuatDaDung = new List<int>();
                for (int i = 0; i < TLuat.Count; i++)
                {
                    MLuat li = TLuat[i];
                    List<MChiTietLuat> veTrai = li.ChiTietLuat();
                    Boolean suDungDuoc = true;
                    foreach (MChiTietLuat m in veTrai)
                    {
                        if (!TSKDB.Contains(m.Left()))
                        {
                            suDungDuoc = false;
                            break;
                        }
                    }
                    if (suDungDuoc)
                    {
                        TSKDB.Add(li.Right());
                        TSKM.Add(li.Right());
                        viTriLuatDaDung.Add(i);
                    }
                }
                if (TSKDB.Contains(menhDeCanCM))
                    return true;                
                for (int i = viTriLuatDaDung.Count - 1; i >= 0; i--)
                {
                    TLuat.RemoveAt(viTriLuatDaDung[i]);
                }
            }
            return false;
        }
    }
}
