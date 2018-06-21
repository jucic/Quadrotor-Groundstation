using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quadrotor_groundstation.userclass
{
    class datacheck
    {
        public  bool DataCheck(byte[] data, int num)
        {
            byte sum = 0;
            for (byte i = 0; i < (num - 1); i++)
                sum += data[i];

            //int a = 0;//验证计算机运行速度
            //for (int i = 0; i < 100; i++)
            //    a += i;

            if (sum != data[num - 1]) return false;        //和校验
            else return true;
        }
    }
}
