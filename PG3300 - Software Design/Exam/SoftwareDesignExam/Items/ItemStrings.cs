using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesignExam
{
    public class ItemStrings
    {
        // Item names
        public static string book   = "Book";
        public static string telsa  = "Tesla";
        public static string vase   = "Vase";
        public static string lamp   = "Lamp";
        public static string laptop = "Laptop";
        public static string ipad   = "iPad";
        public static string iphone = "iPhone";

        // Item conditions
        public static string default_condition      = "Default";
        public static string new_condition          = "New";
        public static string old_condition          = "Old";
        public static string used_condition         = "Used";
        public static string broken_condition       = "Broken";
        public static string torn_condition         = "Torn";

        public enum Condition
        {
            Default,
            New,
            Used,
            Old,
            Torn,
            Broken
        };

        public static string GetConditionString(Condition condition)
        {
            string cond = "";

            switch(condition)
            {
                case Condition.Default:
                    cond = "Default";
                    break;
                case Condition.New:
                    cond = "New";
                    break;
                case Condition.Used:
                    cond = "Used";
                    break;
                case Condition.Old:
                    cond = "Old";
                    break;
                case Condition.Torn:
                    cond = "Torn";
                    break;
                case Condition.Broken:
                    cond = "Broken";
                    break;
            }

            return cond;
        }
    }
}
