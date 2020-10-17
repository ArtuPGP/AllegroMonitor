using System;
using System.Collections.Generic;
using System.Text;

namespace AllegroMonitorClassLibrary
{
    public class TypeSelector
    {
        public static string selectType(int index)
        {
            switch(index)
            {
                case 0:
                    return "+price";
                case 1:
                    return "-price";
                case 2:
                    return "+withDeliveryPrice";
                case 3:
                    return "-withDeliveryPrice";
                case 4:
                    return "-popularity";
                case 5:
                    return "+endTime";
                case 6:
                    return "-startTime";
                default:
                    return "+price";
            }
        }
    }
}
